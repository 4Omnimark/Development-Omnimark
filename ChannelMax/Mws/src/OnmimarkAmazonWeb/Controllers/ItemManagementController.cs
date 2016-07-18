using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OmnimarkAmazon.Models;
using Startbutton.ConfigSections;
using System.Configuration;
using System.Data;
using OmnimarkAmazonWeb.Models;
using Startbutton.ExtensionMethods;
using UkListing;
using System.Data.OleDb;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;




namespace OmnimarkAmazonWeb.Controllers
{

    public class ItemManagementController : _BaseController
    {

        bool IsConsole;
        Dictionary<string, bool> LogWasLastNewLine = new Dictionary<string, bool>();
        bool ShutdownTriggered = false;
        string LogDir = ReadLogFilePath();
       // string LogDir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
        UKOmnimarkEntities ukdb = new UKOmnimarkEntities();

        public static int fcountSport = 1, fcountToys = 1, fcountBeauty = 1, fcountAllExport = 1, fcountBaby = 1, fcountWatches = 1, fcountJewelry = 1;
        public void ExportForUK()
        {
            string LogFile = LogDir + "\\ExportForUK" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            string[] shortcode = { "ED", "EM", "DI" };
            foreach (string item in shortcode)
            {
                var category = ukdb.tbl_Category.Where(x => x.Account_Name == item && x.Enabled == 1).Select(x => x.CategoryName).ToList();
                foreach (var cat in category)
                {
                    try
                    {
                        for (int primeStatus = 1; primeStatus <= 2; primeStatus++)//for Prime and Non Prime 1: Prime,2:Non Prime  Date: 21/6/2016
                        {
                            ExportRequest(cat, item, primeStatus);
                           // ExportRequest("HomeAndKitchen", "ED", 1);
                        }

                    }
                    catch (Exception Ex)
                    {
                        Log(LogFile, true, "Issue in Getting Shorcode and Categories :" + Ex);
                    }

                }

            }
        }
        public void ExportRequest(string cat, string shortcode, int primeStatus)
        {

            string LogFile = LogDir + "\\ExportRequest" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                IEnumerable<dynamic> data = null;

                ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;
                string sellingVenue = null;
                DateTime dt = DateTime.Now.AddHours(-24);
                if (shortcode == "ED")
                {
                    sellingVenue = "Amzn UK";
                    if (cat == "SportingGoods")
                    {
                        if (primeStatus == 1)// This is for Prime
                        {
                            data = ukdb.tbl_Sports.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 11, "ChannelMax",primeStatus);
                        }
                        else     //This is for Non Prime
                        {
                            data = ukdb.tbl_SportsNotPrime.Where(x => x.Account1_Status == 1 && x.Account1_cmaxExport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account1_cmaxExport }).Take(50000).ToList();  /*Select records from non prime tables */ 
                            ExportFile(sellingVenue, shortcode, data, 111, "ChannelMax",primeStatus);
                        }

                    }
                    else if (cat == "Toys")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Toys.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 12, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_ToysNotPrime.Where(x => x.Account1_Status == 1 && x.Account1_cmaxExport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account1_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 122, "ChannelMax", primeStatus);
                        }
                    }
                    else if (cat == "Beauty")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Beauty.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 13, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_BeautyNotPrime.Where(x => x.Account1_Status == 1 && x.Account1_cmaxExport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account1_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 133, "ChannelMax", primeStatus);
                        }
                    }
                    else if (cat == "Baby")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Baby.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 14, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_BabyNotPrime.Where(x => x.Account1_Status == 1 && x.Account1_cmaxExport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account1_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 144, "ChannelMax", primeStatus);
                        }

                    }
                    else if (cat == "Watches")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Watches.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 15, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_WatchesNotPrime.Where(x => x.Account1_Status == 1 && x.Account1_cmaxExport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account1_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 155, "ChannelMax", primeStatus);
                        }
                    }
                    else if (cat == "Jewelry")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Jewellery.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 16, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_JewelleryNotPrime.Where(x => x.Account1_Status == 1 && x.Account1_cmaxExport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account1_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 166, "ChannelMax", primeStatus);
                        }
                    }
                    else if (cat == "HomeAndKitchen")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_HomeandKitchen.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            HomeAndKitchenExport(sellingVenue, shortcode, data, 17, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_HomeAndKitchenNotPrime.Where(x => x.Account1_Status == 1 && x.account1_cmaxexport == 1 && x.Account1_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account1_cmaxexport }).Take(50000).ToList();
                            HomeAndKitchenExport(sellingVenue, shortcode, data, 177, "ChannelMax", primeStatus);
                        }
                    }


                }
                else if (shortcode == "EM")
                {
                    sellingVenue = "Amzn UK2";
                    if (cat == "SportingGoods")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Sports.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 21, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_SportsNotPrime.Where(x => x.Account2_Status == 1 && x.Account2_cmaxExport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account2_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 211, "ChannelMax", primeStatus);
                        }
                    }
                    else if (cat == "Toys")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Toys.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 22, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_ToysNotPrime.Where(x => x.Account2_Status == 1 && x.Account2_cmaxExport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account2_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 222, "ChannelMax", primeStatus);
                        }
                        
                    }
                    else if (cat == "Beauty")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Beauty.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 23, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_BeautyNotPrime.Where(x => x.Account2_Status == 1 && x.Account2_cmaxExport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account2_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 233, "ChannelMax", primeStatus);
                        }
                       
                    }
                    else if (cat == "Baby")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Baby.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 24, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_BabyNotPrime.Where(x => x.Account2_Status == 1 && x.Account2_cmaxExport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account2_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 244, "ChannelMax", primeStatus);
                        }
                       
                    }
                    else if (cat == "Watches")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Watches.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 25, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_WatchesNotPrime.Where(x => x.Account2_Status == 1 && x.Account2_cmaxExport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account2_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 255, "ChannelMax", primeStatus);
                        }
                       
                    }
                    else if (cat == "Jewelry")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Jewellery.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 26, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_JewelleryNotPrime.Where(x => x.Account2_Status == 1 && x.Account2_cmaxExport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account2_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 266, "ChannelMax", primeStatus);
                        }
                       
                    }
                    else if (cat == "HomeAndKitchen")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_HomeandKitchen.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            HomeAndKitchenExport(sellingVenue, shortcode, data, 27, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_HomeAndKitchenNotPrime.Where(x => x.Account2_Status == 1 && x.account2_cmaxexport == 1 && x.Account2_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account2_cmaxexport }).Take(50000).ToList();
                            HomeAndKitchenExport(sellingVenue, shortcode, data, 277, "ChannelMax", primeStatus);
                        }
                       
                    }



                }
                else if (shortcode == "DI")
                {
                    sellingVenue = "Amazon UK";
                    if (cat == "SportingGoods")
                    {
                        if(primeStatus==1)
                        {
                            data = ukdb.tbl_Sports.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 41, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_SportsNotPrime.Where(x => x.Account4_Status == 1 && x.Account4_cmaxExport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account4_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 411, "ChannelMax", primeStatus);
                        }
                        
                    }
                    else if (cat == "Toys")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Toys.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 42, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_ToysNotPrime.Where(x => x.Account4_Status == 1 && x.Account4_cmaxExport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account4_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 422, "ChannelMax", primeStatus);
                        }
                       
                    }
                    else if (cat == "Beauty")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Beauty.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 43, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_BeautyNotPrime.Where(x => x.Account4_Status == 1 && x.Account4_cmaxExport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account4_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 433, "ChannelMax", primeStatus);
                        }
                        
                    }
                    else if (cat == "Baby")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Baby.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 44, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_BabyNotPrime.Where(x => x.Account4_Status == 1 && x.Account4_cmaxExport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account4_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 444, "ChannelMax", primeStatus);

                        }
                       
                    }
                    else if (cat == "Watches")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Watches.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 45, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_WatchesNotPrime.Where(x => x.Account4_Status == 1 && x.Account4_cmaxExport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account4_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 455, "ChannelMax", primeStatus);
                        }
                       
                    }
                    else if (cat == "Jewelry")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_Jewellery.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 46, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_JewelleryNotPrime.Where(x => x.Account4_Status == 1 && x.Account4_cmaxExport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.Account4_cmaxExport }).Take(50000).ToList();
                            ExportFile(sellingVenue, shortcode, data, 466, "ChannelMax", primeStatus);
                        }
                       
                    }
                    else if (cat == "HomeAndKitchen")
                    {
                        if (primeStatus == 1)
                        {
                            data = ukdb.tbl_HomeandKitchen.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            HomeAndKitchenExport(sellingVenue, shortcode, data, 47, "ChannelMax", primeStatus);
                        }
                        else
                        {
                            data = ukdb.tbl_HomeAndKitchenNotPrime.Where(x => x.Account4_Status == 1 && x.account4_cmaxexport == 1 && x.Account4_ExportDate < dt).Select(x => new { x.ASIN, x.SalesPrice, x.UpdatedSalesPrice, x.account4_cmaxexport }).Take(50000).ToList();
                            HomeAndKitchenExport(sellingVenue, shortcode, data, 477, "ChannelMax", primeStatus);
                        }
                       
                    }



                }
            }
            catch (Exception Ex)
            {
                Log(LogFile, true, "Issue in getting records from database For :" + shortcode + cat + Ex);
            }
        }
        public void ExportFile(string SelingVenue, string shortcode, IEnumerable<dynamic> data, int flag, string foldername,int PrimeStatus)
        {
            string LogFile = LogDir + "\\ExportFile" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {

                string fname = "";
                string path = "";
                string cname = "";
                string xml = "";
                string rePriceModel = "18510";
                StringWriter st = new StringWriter();

                //  string header = "sku  FBA Sellingvenue    ASIN    MinSellingPrice   MaxSellingPrice Quantity    Repricingmodel  MAP Purchaseprice   Leadtimetoship  UPC EAN Weight  Productname";
                string header = "sku	FBA	Sellingvenue	ASIN	MinSellingPrice	MaxSellingPrice	Quantity	Repricingmodel	MAP	Purchaseprice	Leadtimetoship	UPC	EAN	Weight	Productname";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(header);

                if (shortcode == "DI")
                {
                    rePriceModel = "18891";
                }
                if (data != null && data.Count() != 0)
                {
                    xml += "<Items>";
                    foreach (var d in data)
                    {

                        try
                        {
                            double price = 0;
                            double pricecal;
                            double pricemin = 17.45;//24.95
                            double finalprice = 0.00;

                            string ASIN;
                            if (PrimeStatus == 1)
                            {
                                ASIN = d.ASIN.Trim();
                            }
                            else
                                ASIN = "NP-" + d.ASIN.Trim();

                            if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
                            {

                                price = double.Parse(d.UpdatedSalesPrice);
                            }
                            else if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
                            {
                                price = double.Parse(d.SalesPrice);
                            }
                            if (price != 0)
                            {

                                if (price > 20.00)
                                {
                                    pricecal = (price * 1.14) + 4;
                                }
                                else
                                {
                                    pricecal = price + 4;
                                }

                                if (pricecal > pricemin)
                                {
                                    finalprice = pricecal;
                                }
                                else
                                {
                                    finalprice = pricemin;
                                }
                            }
                            else
                            {
                                finalprice = 17.45;
                            }

                            string roundprice = finalprice.ToString("0.00");
                            string[] rp = roundprice.Split('.');
                            if (int.Parse(rp[1]) <= 95)
                            {
                                roundprice = rp[0] + ".95";
                            }
                            else
                            {
                                roundprice = (int.Parse(rp[0]) + 1) + ".95";
                            }

                            double temp = double.Parse(roundprice);
                            double maxprice = temp + 30.00;
                            sb.AppendLine(string.Join("\t",
                                         string.Format(@"""{0}""", ASIN),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", SelingVenue),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", String.Format("{0:0.00}", roundprice)),
                                         string.Format(@"""{0}""", maxprice),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", rePriceModel),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", "5"),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", "")));

                            xml += "<Item>";
                            xml += "<ASIN>" + d.ASIN.Trim() + "</ASIN>";
                            xml += "</Item>";


                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    xml += "</Items>";
                    if (shortcode == "DI")
                    {
                        fname = "channelmax_superquickship_ftp_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                    }
                    else
                    {
                        fname = "channelmax_enutramart_ftp_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                    }
                    path = Generate(fname, sb, foldername);
                    SendAWSResponse(xml, flag);
                }
                else
                {
                    path = Generate("Blank", sb, foldername);
                }

            }
            catch (Exception ex)
            {

                Log(LogFile, true, "Isuue in Putting records in String Builder" + ex);
                //return "C:/ChannelMax_SERVICE/Blank";
            }
        }

        public void HomeAndKitchenExport(string SelingVenue, string shortcode, IEnumerable<dynamic> data, int flag, string foldername, int PrimeStatus)
        {
            string LogFile = LogDir + "\\ExportFile" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {

                string fname = "";
                string path = "";
                string cname = "";
                string xml = "";
                string rePriceModel = "18510";
                StringWriter st = new StringWriter();

                //  string header = "sku  FBA Sellingvenue    ASIN    MinSellingPrice   MaxSellingPrice Quantity    Repricingmodel  MAP Purchaseprice   Leadtimetoship  UPC EAN Weight  Productname";
                string header = "sku	FBA	Sellingvenue	ASIN	MinSellingPrice	MaxSellingPrice	Quantity	Repricingmodel	MAP	Purchaseprice	Leadtimetoship	UPC	EAN	Weight	Productname";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(header);

                if (shortcode == "DI")
                {
                    rePriceModel = "18891";
                }
                if (data != null && data.Count() != 0)
                {
                    xml += "<Items>";
                    foreach (var d in data)
                    {

                        try
                        {
                            double price = 0;
                            double pricecal;
                            double pricemin = 17.45;//24.95
                            double finalprice = 0.00;

                            string ASIN;
                            if (PrimeStatus == 1)
                            {
                                ASIN = d.ASIN.Trim();
                            }
                            else
                                ASIN = "NP-" + d.ASIN.Trim();

                            if (d.UpdatedSalesPrice != null)
                            {

                                price = d.UpdatedSalesPrice;
                            }
                            else if (d.SalesPrice != null)
                            {
                                price = d.SalesPrice;
                            }
                            if (price != 0)
                            {

                                if (price > 20.00)
                                {
                                    pricecal = (price * 1.14) + 4;
                                }
                                else
                                {
                                    pricecal = price + 4;
                                }

                                if (pricecal > pricemin)
                                {
                                    finalprice = pricecal;
                                }
                                else
                                {
                                    finalprice = pricemin;
                                }
                            }
                            else
                            {
                                finalprice = 17.45;
                            }

                            string roundprice = finalprice.ToString("0.00");
                            string[] rp = roundprice.Split('.');
                            if (int.Parse(rp[1]) <= 95)
                            {
                                roundprice = rp[0] + ".95";
                            }
                            else
                            {
                                roundprice = (int.Parse(rp[0]) + 1) + ".95";
                            }

                            double temp = double.Parse(roundprice);
                            double maxprice = temp + 30.00;
                            sb.AppendLine(string.Join("\t",
                                         string.Format(@"""{0}""", ASIN),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", SelingVenue),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", String.Format("{0:0.00}", roundprice)),
                                         string.Format(@"""{0}""", maxprice),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", rePriceModel),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", "5"),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", ""),
                                         string.Format(@"""{0}""", "")));

                            xml += "<Item>";
                            xml += "<ASIN>" + d.ASIN.Trim() + "</ASIN>";
                            xml += "</Item>";


                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    xml += "</Items>";
                    if (shortcode == "DI")
                    {
                        fname = "channelmax_superquickship_ftp_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                    }
                    else
                    {
                        fname = "channelmax_enutramart_ftp_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                    }
                    path = Generate(fname, sb, foldername);
                    SendAWSResponse(xml, flag);
                }
                else
                {
                    path = Generate("Blank", sb, foldername);
                }

            }
            catch (Exception ex)
            {

                Log(LogFile, true, "Isuue in Putting records in String Builder" + ex);
                //return "C:/ChannelMax_SERVICE/Blank";
            }
        }// This is export function specially for HomeandKitchen categories as Datatypes differ with other tables.Thus needs to be make different function.
        private void SendAWSResponse(string xml, int flag)
        {
            string LogFile = LogDir + "\\SendAWSResponse" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UKMain"].ToString());
                SqlCommand cmd = new SqlCommand("ChannelMax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@xmldata", xml);
                cmd.Parameters.AddWithValue("@flag", flag);
                cmd.CommandTimeout = 2200;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Log(LogFile, true, "Issue while updating Status in SP :" + ex);
            }
        }  //Send ASIN and Flag value to Stored Procedure in order to update Account_cmaxExport status
        public static string Generate(string filename, StringBuilder sb, string foldername)
        {
            if (filename != "Blank")
            {
                // HttpPostedFileBase file = null;

                string targetPath = "C:/Inetpub/vhosts/omnimark.revupcommerce.com/ChannelMax_SERVICE"; //with complete path
                FileStream fs = null;

                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                    if (!System.IO.File.Exists(targetPath + "/" + filename))
                    {
                        using (fs = System.IO.File.Create(targetPath + "/" + filename))
                        { }
                    }
                    if (System.IO.File.Exists(targetPath + "/" + filename))
                    {
                        using (StreamWriter sw = new StreamWriter(targetPath + "/" + filename))
                        {
                            sw.Write(sb);
                        }
                    }
                    //return (targetPath + "/" + filename);
                }


                else
                {
                    if (System.IO.Directory.Exists(targetPath))
                    {
                        if (!System.IO.File.Exists(targetPath + "/" + filename))
                        {
                            using (fs = System.IO.File.Create(targetPath + "/" + filename))
                            { }
                        }
                        if (System.IO.File.Exists(targetPath + "/" + filename))
                        {
                            using (StreamWriter sw = new StreamWriter(targetPath + "/" + filename))
                            {
                                sw.Write(sb);
                            }
                        }
                    }
                    //return (targetPath + "/" + filename);
                }
                return (targetPath + "/" + filename);
            }
            else
            {
                string targetPath = "C:/Inetpub/vhosts/omnimark.revupcommerce.com/ChannelMax_SERVICE"; //with complete path
                return (targetPath + "/" + "Blank");
            }
        }
        static string ReadLogFilePath()
        {
            string configpath = Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]);
            if (configpath == string.Empty)
                return AppDomain.CurrentDomain.BaseDirectory + "Logs";
            else
                return configpath;
        }
        public void Log(string LogFile, bool Linefeed, string line)
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

    }
}