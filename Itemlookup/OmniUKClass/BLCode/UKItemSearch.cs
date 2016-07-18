using AmazonProductAdvtApi;
using MarketplaceWebServiceProducts;
using MarketplaceWebServiceProducts.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using OmniUKClass.BLCode;
//using OmnimarkAmazon.Service;


namespace OmniUKClass.BLCode
{
    public static class UKItemSearch
    {
        static string LogDir = ReadLogFilePath();
       // static string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        static Dictionary<string, bool> LogWasLastNewLine = new Dictionary<string, bool>();
        static bool IsConsole;
        //static Timer FixMissingReceivedProductInventoryAdjustmentsTimer;
        static KeySets keys;
        static KeySet _useKeySet;

        //Retrieving key values using constructor
        static UKItemSearch()
        {
            keys = new KeySets();
            _useKeySet = (KeySet)keys.Current;
        }
        public static void ItemLookup(IEnumerable<string> lstASIN, string cat)
        {
             string LogFile = LogDir + "\\ItemLookupAPICode" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            GetLowestOfferListingsForASINResponse response = null;
            try
            {
                // Create a configuration object
                MarketplaceWebServiceProductsConfig config = new MarketplaceWebServiceProductsConfig();
                config.ServiceURL = _useKeySet.serviceurlkey;
                MarketplaceWebServiceProducts.MarketplaceWebServiceProducts client = new MarketplaceWebServiceProductsClient(_useKeySet.appnamekey, _useKeySet.appversionkey, _useKeySet.accesskey, _useKeySet.secretkey, config);

                GetLowestOfferListingsForASINRequest request = new GetLowestOfferListingsForASINRequest();

                request.SellerId = _useKeySet.selleridkey;
                request.MWSAuthToken = _useKeySet.mwsauthtokenkey;
                request.MarketplaceId = _useKeySet.marketplaceidkey;
                ASINListType asinList = new ASINListType();
                asinList.ASIN = new List<string>();
                asinList.WithASIN(lstASIN.ToArray());
                request.ASINList = asinList;
                request.ItemCondition = "new";
                bool excludeMe = true;
                request.ExcludeMe = excludeMe;
                response = client.GetLowestOfferListingsForASIN(request);
                if (response != null && response.GetLowestOfferListingsForASINResult.Count > 0)
                {
                    string xml = "<Items>";
                    for (int i = 0; i < response.GetLowestOfferListingsForASINResult.Count; i++)
                    {
                        try
                        {
                            if (response.GetLowestOfferListingsForASINResult[i].Product.LowestOfferListings.LowestOfferListing.Count > 0)
                            {
                                LowestOfferListingType lowestOfferListing = null;
                                lowestOfferListing = response.GetLowestOfferListingsForASINResult[i].Product.LowestOfferListings.LowestOfferListing.FirstOrDefault(s => s.Qualifiers.FulfillmentChannel == "Amazon");
                                if (lowestOfferListing == null)
                                {
                                    lowestOfferListing = response.GetLowestOfferListingsForASINResult[i].Product.LowestOfferListings.LowestOfferListing.FirstOrDefault();
                                }
                                xml += "<item>";
                                xml += "<ASIN>" + response.GetLowestOfferListingsForASINResult[i].ASIN + "</ASIN>";
                                xml += "<FormattedPrice>" + lowestOfferListing.Price.LandedPrice.Amount /*response.GetLowestOfferListingsForASINResult[i].Product.LowestOfferListings.LowestOfferListing[0].Price.ListingPrice.Amount*/ + "</FormattedPrice>";
                                xml += "<IsEligibleForPrime>";
                                xml += lowestOfferListing.Qualifiers.FulfillmentChannel == "Amazon" ? "1" : "0"; //response.GetLowestOfferListingsForASINResult[i].Product.LowestOfferListings.LowestOfferListing[0].Qualifiers.FulfillmentChannel == "Amazon" ? "1" : "0";
                                xml += "</IsEligibleForPrime>";
                                xml += "</item>";
                            }
                            else
                            {
                                xml += "<item>";
                                xml += "<ASIN>" + response.GetLowestOfferListingsForASINResult[i].ASIN + "</ASIN>";
                                xml += "<FormattedPrice>" + "0" + /*response.GetLowestOfferListingsForASINResult[i].Product.LowestOfferListings.LowestOfferListing[0].Price.ListingPrice.Amount*/  "</FormattedPrice>";
                                xml += "<IsEligibleForPrime>";
                                xml += "2"; //response.GetLowestOfferListingsForASINResult[i].Product.LowestOfferListings.LowestOfferListing[0].Qualifiers.FulfillmentChannel == "Amazon" ? "1" : "0";
                                xml += "</IsEligibleForPrime>";
                                xml += "</item>";
                            }
                        }
                        catch (Exception ex)
                        {
                            Log(LogFile, true, "Issue in Fetching Response from API : " + cat + response.GetLowestOfferListingsForASINResult[i].ASIN + ex);
                        }
                    }
                    xml += "</Items>";
                    SendAWSResponse(xml, cat);
                }
            }
            // Handling Request Throttling Exception using  MarketplaceWebServiceProductsException Exception class
            catch (MarketplaceWebServiceProductsException ex)
            {
                Log(LogFile, true, "Amazon Throttling EXCEPTION: " + ex.Message + "\n" + ex.StackTrace);
                if (ex.Message.Contains("You exceeded your quota")) //29-June-2016 Changes exception conditions.
                {
                    if (!keys.MoveNext())
                    {
                        keys.Reset();
                    }
                    _useKeySet = (KeySet)keys.Current;
                    ItemLookup(lstASIN, cat);
                }
                else
                    ItemLookup(lstASIN, cat);
                   // throw;

            }
            catch (Exception ex)
            {
                Log(LogFile, true, "EXCEPTION: " + ex.Message + "\n" + ex.StackTrace);
                //ex = ex.InnerException throws;
                throw;
                 
            }
        }
        private static void SendAWSResponse(string xml, string cat)
        {
            string LogFile = LogDir + "\\AWSResponseUpdateCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UKMain"].ToString()))
                {
                    XDocument document = XDocument.Parse(xml);

                    //XDocument document = XDocument.Load(xml);
                    var Category = (from r in document.Descendants("item")

                                    select new
                                    {
                                        ASIN = r.Element("ASIN").Value,
                                        Forprice = r.Element("FormattedPrice").Value,
                                        Isprime = r.Element("IsEligibleForPrime").Value,
                                    }).ToList();


                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        foreach (var i in Category)
                        {
                            if (cat == Categories.baby)
                            {
                                var bby = db.tbl_Baby.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                if (bby != null)
                                {
                                    bby.UpdatedTimeStamp = DateTime.Now;
                                    bby.AccessKeyID = _useKeySet.accesskey;
                                    if (bby.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                    {
                                        bby.account1_cmaxexport = 1;
                                        bby.account2_cmaxexport = 1;
                                        bby.account3_cmaxexport = 1;
                                        bby.account4_cmaxexport = 1;
                                        bby.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                        bby.UpdatedSalesPrice = i.Forprice;
                                    }
                                    else if (bby.Prime != i.Isprime)
                                    {
                                        bby.Account1_ReExport = 0;
                                        bby.Account2_ReExport = 0;
                                        bby.Account3_ReExport = 0;
                                        bby.Account4_ReExport = 0;
                                        bby.Prime = i.Isprime;
                                    }
                                }
                            }

                            if (cat == Categories.jewelry)
                            {
                                var jwy = db.tbl_Jewellery.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                if (jwy != null)
                                {
                                    jwy.UpdatedTimeStamp = DateTime.Now;
                                    jwy.AccessKeyID = _useKeySet.accesskey;
                                    if (jwy.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                    {
                                        jwy.account1_cmaxexport = 1;
                                        jwy.account2_cmaxexport = 1;
                                        jwy.account3_cmaxexport = 1;
                                        jwy.account4_cmaxexport = 1;
                                        jwy.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                        jwy.UpdatedSalesPrice = i.Forprice;
                                    }
                                    else if (jwy.Prime != i.Isprime)
                                    {
                                        jwy.Account1_ReExport = 0;
                                        jwy.Account2_ReExport = 0;
                                        jwy.Account3_ReExport = 0;
                                        jwy.Account4_ReExport = 0;
                                        jwy.Prime = i.Isprime;
                                    }
                                }
                            }

                            if (cat == Categories.beauty)
                            {
                                var bty = db.tbl_Beauty.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                if (bty != null)
                                {
                                    bty.UpdatedTimeStamp = DateTime.Now;
                                    bty.AccessKeyID = _useKeySet.accesskey;
                                    if (bty.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                    {
                                        bty.account1_cmaxexport = 1;
                                        bty.account2_cmaxexport = 1;
                                        bty.account3_cmaxexport = 1;
                                        bty.account4_cmaxexport = 1;
                                        bty.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                        bty.UpdatedSalesPrice = i.Forprice;
                                    }
                                    else if (bty.Prime != i.Isprime)
                                    {
                                        bty.Account1_ReExport = 0;
                                        bty.Account2_ReExport = 0;
                                        bty.Account3_ReExport = 0;
                                        bty.Account4_ReExport = 0;
                                        bty.Prime = i.Isprime;
                                    }
                                }
                            }
                            if (cat == Categories.spgoods)
                            {
                                var spg = db.tbl_Sports.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                if (spg != null)
                                {
                                    spg.UpdatedTimeStamp = DateTime.Now;
                                    spg.AccessKeyID = _useKeySet.accesskey;
                                    if (spg.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                    {
                                        spg.account1_cmaxexport = 1;
                                        spg.account2_cmaxexport = 1;
                                        spg.account3_cmaxexport = 1;
                                        spg.account4_cmaxexport = 1;
                                        spg.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                        spg.UpdatedSalesPrice = i.Forprice;
                                    }
                                    else if (spg.Prime != i.Isprime)
                                    {
                                        spg.Account1_ReExport = 0;
                                        spg.Account2_ReExport = 0;
                                        spg.Account3_ReExport = 0;
                                        spg.Account4_ReExport = 0;
                                        spg.Prime = i.Isprime;
                                    }
                                }
                            }

                            if (cat == Categories.toys)
                            {
                                var tys = db.tbl_Toys.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                if (tys != null)
                                {
                                    tys.UpdatedTimeStamp = DateTime.Now;
                                    tys.AccessKeyID = _useKeySet.accesskey;
                                    if (tys.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                    {
                                        tys.account1_cmaxexport = 1;
                                        tys.account2_cmaxexport = 1;
                                        tys.account3_cmaxexport = 1;
                                        tys.account4_cmaxexport = 1;
                                        tys.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                        tys.UpdatedSalesPrice = i.Forprice;
                                    }
                                    else if (tys.Prime != i.Isprime)
                                    {
                                        tys.Account1_ReExport = 0;
                                        tys.Account2_ReExport = 0;
                                        tys.Account3_ReExport = 0;
                                        tys.Account4_ReExport = 0;
                                        tys.Prime = i.Isprime;
                                    }
                                }
                            }

                            if (cat == Categories.watches)
                            {
                                var wts = db.tbl_Watches.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                if (wts != null)
                                {
                                    wts.UpdatedTimeStamp = DateTime.Now;
                                    wts.AccessKeyID = _useKeySet.accesskey;
                                    if (wts.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                    {
                                        wts.account1_cmaxexport = 1;
                                        wts.account2_cmaxexport = 1;
                                        wts.account3_cmaxexport = 1;
                                        wts.account4_cmaxexport = 1;
                                        wts.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                        wts.UpdatedSalesPrice = i.Forprice;
                                    }
                                    else if (wts.Prime != i.Isprime)
                                    {
                                        wts.Account1_ReExport = 0;
                                        wts.Account2_ReExport = 0;
                                        wts.Account3_ReExport = 0;
                                        wts.Account4_ReExport = 0;
                                        wts.Prime = i.Isprime;
                                    }
                                }
                            }
                                if (cat == Categories.ToysNotPrime)
                                {
                                    var tnp = db.tbl_ToysNotPrime.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (tnp != null)
                                    {
                                        tnp.UpdatedTimeStamp = DateTime.Now;
                                        tnp.AccessKeyID = _useKeySet.accesskey;
                                        if (tnp.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                        {
                                            tnp.Account1_cmaxExport = 1;
                                            tnp.Account2_cmaxExport = 1;
                                            tnp.Account3_cmaxExport = 1;
                                            tnp.Account4_cmaxExport = 1;
                                            //w.account1_cmaxexport = 1;
                                            //w.account2_cmaxexport = 1;
                                            //w.account3_cmaxexport = 1;    
                                            tnp.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            tnp.UpdatedSalesPrice = i.Forprice;
                                        }
                                        else if (tnp.Prime != i.Isprime)
                                        {
                                            tnp.Account1_ReExport = 0;
                                            tnp.Account2_ReExport = 0;
                                            tnp.Account3_ReExport = 0;
                                            tnp.Account4_ReExport = 0;
                                            tnp.Prime = i.Isprime;
                                        }
                                    }
                                }

                                if (cat == Categories.HomeAndKitchen)
                                {
                                    var hNk = db.tbl_HomeandKitchen.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (hNk != null)
                                    {
                                        hNk.UpdatedTimeStamp = DateTime.Now;
                                        hNk.AccessKeyID = _useKeySet.accesskey;
                                        if (hNk.UpdatedSalesPrice.ToString() != i.Forprice && i.Forprice != "0")
                                        {
                                            hNk.account1_cmaxexport = 1;
                                            hNk.account2_cmaxexport = 1;
                                            hNk.account3_cmaxexport = 1;
                                            hNk.account4_cmaxexport = 1;
                                            hNk.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            hNk.UpdatedSalesPrice = float.Parse(i.Forprice);
                                        }
                                        else if (hNk.Prime.ToString() != i.Isprime)
                                        {
                                            hNk.Account1_ReExport = 0;
                                            hNk.Account2_ReExport = 0;
                                            hNk.Account3_ReExport = 0;
                                            hNk.Account4_ReExport = 0;
                                            hNk.Prime = short.Parse(i.Isprime);
                                        }
                                    }
                                }

                                if (cat == Categories.WatchesNotPrime)
                                {
                                    var wnp = db.tbl_WatchesNotPrime.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (wnp != null)
                                    {
                                        wnp.UpdatedTimeStamp = DateTime.Now;
                                        wnp.AccessKeyID = _useKeySet.accesskey;
                                        if (wnp.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                        {
                                            wnp.Account1_cmaxExport = 1;
                                            wnp.Account2_cmaxExport = 1;
                                            wnp.Account3_cmaxExport = 1;
                                            wnp.Account4_cmaxExport = 1;
                                            wnp.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            wnp.UpdatedSalesPrice = i.Forprice;
                                        }
                                        else if (wnp.Prime != i.Isprime)
                                        {
                                            wnp.Account1_ReExport = 0;
                                            wnp.Account2_ReExport = 0;
                                            wnp.Account3_ReExport = 0;
                                            wnp.Account4_ReExport = 0;
                                            wnp.Prime = i.Isprime;
                                        }
                                    }
                                }

                                if (cat == Categories.JewelryNotPrime)
                                {
                                    var jnp = db.tbl_JewelleryNotPrime.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (jnp != null)
                                    {
                                        jnp.UpdatedTimeStamp = DateTime.Now;
                                        jnp.AccessKeyID = _useKeySet.accesskey;
                                        if (jnp.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                        {
                                            jnp.Account1_cmaxExport = 1;
                                            jnp.Account2_cmaxExport = 1;
                                            jnp.Account3_cmaxExport = 1;
                                            jnp.Account4_cmaxExport = 1;
                                            jnp.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            jnp.UpdatedSalesPrice = i.Forprice;
                                        }
                                        else if (jnp.Prime != i.Isprime)
                                        {
                                            jnp.Account1_ReExport = 0;
                                            jnp.Account2_ReExport = 0;
                                            jnp.Account3_ReExport = 0;
                                            jnp.Account4_ReExport = 0;
                                            jnp.Prime = i.Isprime;
                                        }
                                    }
                                }

                                if (cat == Categories.SportsNotPrime)
                                {
                                    var snp = db.tbl_SportsNotPrime.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (snp != null)
                                    {
                                        snp.UpdatedTimeStamp = DateTime.Now;
                                        snp.AccessKeyID = _useKeySet.accesskey;
                                        if (snp.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                        {

                                            snp.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            snp.UpdatedSalesPrice = i.Forprice;
                                        }
                                        else if (snp.Prime != i.Isprime)
                                        {
                                            snp.Account1_ReExport = 0;
                                            snp.Account2_ReExport = 0;
                                            snp.Account3_ReExport = 0;
                                            snp.Account4_ReExport = 0;
                                            snp.Prime = i.Isprime;
                                        }
                                    }
                                }

                                if (cat == Categories.BabyNotPrime)
                                {
                                    var bnp = db.tbl_BabyNotPrime.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (bnp != null)
                                    {
                                        bnp.UpdatedTimeStamp = DateTime.Now;
                                        bnp.AccessKeyID = _useKeySet.accesskey;
                                        if (bnp.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                        {
                                            bnp.Account1_cmaxExport = 1;
                                            bnp.Account2_cmaxExport = 1;
                                            bnp.Account3_cmaxExport = 1;
                                            bnp.Account4_cmaxExport = 1;

                                            bnp.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            bnp.UpdatedSalesPrice = i.Forprice;
                                        }
                                        else if (bnp.Prime != i.Isprime)
                                        {
                                            bnp.Account1_ReExport = 0;
                                            bnp.Account2_ReExport = 0;
                                            bnp.Account3_ReExport = 0;
                                            bnp.Account4_ReExport = 0;
                                            bnp.Prime = i.Isprime;
                                        }
                                    }
                                }

                                if (cat == Categories.BeautyNotPrime)
                                {
                                    var btnp = db.tbl_BeautyNotPrime.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (btnp != null)
                                    {
                                        btnp.UpdatedTimeStamp = DateTime.Now;
                                        btnp.AccessKeyID = _useKeySet.accesskey;
                                        if (btnp.UpdatedSalesPrice != i.Forprice && i.Forprice != "0")
                                        {
                                            btnp.Account1_cmaxExport = 1;
                                            btnp.Account2_cmaxExport = 1;
                                            btnp.Account3_cmaxExport = 1;
                                            btnp.Account4_cmaxExport = 1;
                                            btnp.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            btnp.UpdatedSalesPrice = i.Forprice;
                                        }
                                        else if (btnp.Prime != i.Isprime)
                                        {
                                            btnp.Account1_ReExport = 0;
                                            btnp.Account2_ReExport = 0;
                                            btnp.Account3_ReExport = 0;
                                            btnp.Account4_ReExport = 0;
                                            btnp.Prime = i.Isprime;
                                        }
                                    }
                                }

                                if (cat == Categories.HomeAndKitchenNotPrime)
                                {
                                    var hnp = db.tbl_HomeAndKitchenNotPrime.Where(a => a.ASIN.Equals(i.ASIN)).FirstOrDefault();
                                    if (hnp != null)
                                    {
                                        hnp.UpdatedTimeStamp = DateTime.Now;
                                        hnp.AccessKeyID = _useKeySet.accesskey;
                                        if (hnp.UpdatedSalesPrice.ToString() != i.Forprice && i.Forprice != "0")
                                        {
                                            hnp.account1_cmaxexport=1;
                                            hnp.account2_cmaxexport = 1;
                                            hnp.account3_cmaxexport = 1;
                                            hnp.account4_cmaxexport = 1;
                                            hnp.UpdatedSalesPriceTimeStamp = DateTime.Now;
                                            hnp.UpdatedSalesPrice = float.Parse(i.Forprice);
                                        }
                                        else if (hnp.Prime.ToString() != i.Isprime)
                                        {
                                            hnp.Account1_ReExport = 0;
                                            hnp.Account2_ReExport = 0;
                                            hnp.Account3_ReExport = 0;
                                            hnp.Account4_ReExport = 0;
                                            hnp.Prime = short.Parse(i.Isprime);
                                        }
                                    }
                                }


                            }
                            db.SaveChanges();

                        }
                    }
                }
            
            catch (Exception ex)
            {
                Log(LogFile, true, "Issue in Updating Values..." + cat + ex);
            }

        }


        public static void UpdateAsinSports()
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {


                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.spgoods;
                        var ASINList = db.tbl_Sports.Where(x => (x.Status == 1) || (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();

                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("Sports");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                             Thread.Sleep(2000);

                        }
                        //db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from Sports Table..." + ex);
                }
            }

        }

        public static void UpdateAsinBeauty()
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.beauty;
                        var ASINList = db.tbl_Beauty.Where(x => (x.Status == 1) || (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("Beauty");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);

                        }
                        // db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from Beauty Table..." + ex);
                }
            }

        }

        public static void UpdateAsinBaby()
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.baby;
                        var ASINList = db.tbl_Baby.Where(x => (x.Status == 1) || (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("Baby");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);

                        }

                    }
                }
                catch (Exception ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from Baby Table..." + ex);
                }
            }

        }
        public static void UpdateAsinJewellery()
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.jewelry;
                        var ASINList = db.tbl_Jewellery.Where(x => (x.Status == 1) || (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("Jewellery");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);

                        }

                    }
                }
                catch (Exception ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from Jewelry Table..." + ex);
                }
            }

        }
        public static void UpdateAsinToys()
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.toys;
                        var ASINList = db.tbl_Toys.Where(x => (x.Status == 1) || (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("Toys");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from Toys Table..." + Ex);
                }
            }

        }
        public static void UpdateAsinWatches()
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.watches;
                        var ASINList = db.tbl_Watches.Where(x => (x.Status == 1) || (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("Watches");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from Watches Table..." + Ex);
                }
            }

        }

        public static void UpdateAsinToysNotPrime()
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.ToysNotPrime;
                        var ASINList = db.tbl_ToysNotPrime.Where(x => (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("ToysNotPrime");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }
                        
                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from ToysNotPrime Table..." + Ex);
                }
            }

        }// ToysNotPrime not Prime

        public static void UpdateAsinHomeAndKitchen() 
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.HomeAndKitchen;
                        var ASINList = db.tbl_HomeandKitchen.Where(x => (x.Status == 1) || (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("HomeAndKitchen");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from HomeAndKitchen Table..." + Ex);
                }
            }

        } //HomeAndKitchen not prime

        public static void UpdateAsinWatchesNotPrime() //8-6-2016 added WatchesNotPrime category.
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.WatchesNotPrime;
                        var ASINList = db.tbl_WatchesNotPrime.Where(x => (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("WatchesNotPrime");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from WatchesNotPrime Table..." + Ex);
                }
            }

        }// WatchesNotPrime not Prime

        public static void UpdateAsinJewelryNotPrime() //8-6-2016 added JewelryNotPrime category.
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.JewelryNotPrime;
                        var ASINList = db.tbl_JewelleryNotPrime.Where(x => (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("JewelryNotPrime");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from JewelryNotPrime Table..." + Ex);
                }
            }

        }// JewelryNotPrime not Prime

        public static void UpdateAsinSportsNotPrime() //8-6-2016 added SportsNotPrime category.
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.SportsNotPrime;
                        var ASINList = db.tbl_SportsNotPrime.Where(x => (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("SportsNotPrime");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from SportsNotPrime Table..." + Ex);
                }
            }

        }// SportsNotPrime not Prime

        public static void UpdateAsinBabyNotPrime() //8-6-2016 added BabyNotPrime category.
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.BabyNotPrime;
                        var ASINList = db.tbl_BabyNotPrime.Where(x => (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("BabyNotPrime");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from BabyNotPrime Table..." + Ex);
                }
            }

        }// BabyNotPrime not Prime

        public static void UpdateAsinBeautyNotPrime() //8-6-2016 added BeautyNotPrime category.
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.BeautyNotPrime;
                        var ASINList = db.tbl_BeautyNotPrime.Where(x => (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("BeautyNotPrime");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from BeautyNotPrime Table..." + Ex);
                }
            }

        }// BeautyNotPrime not Prime

        public static void UpdateAsinHomeAndKitchenNotPrime() //8-6-2016 added HomeAndKitchenNotPrime category.
        {
            string LogFile = LogDir + "\\SelectReordsCode" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            StringBuilder sb = new StringBuilder();
            lock (sb)
            {
                try
                {
                    int skipAsinCount = 0;
                    using (UKOmnimarkEntities db = new UKOmnimarkEntities())
                    {
                        ((IObjectContextAdapter)db).ObjectContext.CommandTimeout = 1800;
                        string cat = Categories.HomeAndKitchenNotPrime;
                        var ASINList = db.tbl_HomeAndKitchenNotPrime.Where(x => (x.WeightUnits <= 500 && x.UK_Prohibited != 1 && x.HeightUnits < 3000 && x.WidthUnits < 3000 && x.LengthUnits < 3000)).OrderByDescending(x => x.Status).Select(x => x.ASIN.TrimEnd()).ToList();
                        if (((IObjectContextAdapter)db).ObjectContext.Connection.State == ConnectionState.Open)
                            ((IObjectContextAdapter)db).ObjectContext.Connection.Close();
                        double r = (ASINList.Count / 20.00);
                        int requestCount = int.Parse(Math.Ceiling(r).ToString());
                        for (int i = 0; i < requestCount; i++)
                        {
                            UKItemSearch.ItemLookup(ASINList.Skip(skipAsinCount).Take(20), cat);
                            Console.WriteLine("HomeAndKitchenNotPrime");
                            skipAsinCount = skipAsinCount + 20;
                            sb.Append(i);
                            Thread.Sleep(2000);
                        }

                    }
                }
                catch (Exception Ex)
                {
                    Log(LogFile, true, "Issue in Selecting Values from HomeAndKitchenNotPrime Table..." + Ex);
                }
            }

        }// HomeAndKitchenNotPrime not Prime


        static string ReadLogFilePath()
        {
            string configpath = Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]);
            if (configpath == string.Empty)
                return AppDomain.CurrentDomain.BaseDirectory + "Logs";
            else
                return configpath;
        }
        public static void Log(string LogFile, bool Linefeed, string line)
        {
            try
            {

                if (!LogWasLastNewLine.ContainsKey(LogFile))
                    LogWasLastNewLine.Add(LogFile, true);

                if (IsConsole)
                {
                    if (LogWasLastNewLine[LogFile])
                        Console.Write(DateTime.Now.ToString("yyyyMMdd HHmmss") + ": ");

                    Console.Write(line);

                    if (Linefeed)
                        Console.WriteLine("");

                }

                StreamWriter sw = new StreamWriter(LogFile, true);

                if (LogWasLastNewLine[LogFile])
                    sw.Write(DateTime.Now.ToString("HHmmss") + ": ");

                sw.Write(line);

                if (Linefeed)
                {
                    sw.WriteLine("");
                    LogWasLastNewLine[LogFile] = true;
                }
                else
                    LogWasLastNewLine[LogFile] = false;

                sw.Close();
            }

            catch (Exception)
            {

            }
        }

    }


}
