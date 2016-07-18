using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.AWS;
using AmazonProductAdvtApi;
using System.IO;
using System.Xml;
using System.Net;
using System.Xml.Serialization;
using HtmlAgilityPack;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;


namespace OmniUKClass.BLCode
{
   public static class UKItemSearch
    {
       public static int fcountSport = 1, fcountToys = 1, fcountBeauty = 1, fcountAllExport = 1;
       public static void AutoExport(Nullable<decimal> count, double PriceValue, string tblname)
       {

           UKOmnimarkEntities dbcontext = new UKOmnimarkEntities();


           ((IObjectContextAdapter)dbcontext).ObjectContext.CommandTimeout = 1800;

           StringWriter st = new StringWriter();
           string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
           Response.ClearContent();
           Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToString("yyyy-MM-dd") + "_UpdatePriceQTY_Sports_" + fcountSport + ".txt");
           //Response.AddHeader("content-disposition", "attachment;filename="+name+"_"+ DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
           Response.ContentType = "application/text";
           Response.ContentEncoding = Encoding.GetEncoding(1252);
           
           StringBuilder sb = new StringBuilder();
           sb.AppendLine(header);
           
           var data = dbcontext.tbl_Sports.Where(x => (x.Prime == "0" && x.Status == 1 && x.ReExportStatus == 0) || (x.UpdatedSalesPriceTimeStamp != null && x.Status == 1)).ToList();
           //var data = dbcontext.tbl_Sports.Where(x => x.Prime == "0" && x.Status == 1).Take(int.Parse(count.ToString())).ToList();
           if (data != null)
           {
               foreach (var d in data)
               {
                   //Nullable<double> price;

                   double price;
                   double pricecal;
                   double pricemin = 0.00;
                   double finalprice;
                   if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
                   {


                       price = double.Parse(d.UpdatedSalesPrice);
                       double minval = 49.99;
                       if (price > 0 && price <= 19.99)
                       {
                           pricemin = minval;
                       }
                       else
                       {
                           for (double i = 20; i < 500; i += 10)
                           {
                               minval = minval + 10;
                               double temp = i + 10;
                               if (price >= i && price < temp)
                               {
                                   pricemin = minval;
                                   break;
                               }
                           }
                       }
                       pricecal = price * PriceValue;
                       if (pricemin >= pricecal)
                       {
                           finalprice = pricemin;
                       }
                       else
                       {
                           finalprice = pricecal;
                       }


                   }
                   else
                   {
                       if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
                       {
                           double minval = 49.99;
                           price = double.Parse(d.SalesPrice);

                           if (price > 0 && price <= 19.99)
                           {
                               pricemin = minval;
                           }
                           else
                           {
                               for (double i = 20; i < 500; i += 10)
                               {
                                   minval = minval + 10;
                                   double temp = i + 10;
                                   if (price >= i && price < temp)
                                   {
                                       pricemin = minval;
                                       break;
                                   }
                               }
                           }
                           pricecal = price * PriceValue;
                           if (pricemin >= pricecal)
                           {
                               finalprice = pricemin;
                           }
                           else
                           {
                               finalprice = pricecal;
                           }

                       }
                       else
                       {
                           finalprice = 0.00;
                           d.Qty = 0;
                       }
                   }

                   string ItemName;
                   if (d.Title != null)
                   {
                       ItemName = new string(d.Title.Take(490).ToArray());
                   }
                   else
                   {
                       ItemName = null;
                   }
                   string description;

                   if (d.Description != null)
                   {
                       string desc = Regex.Replace(d.Description, "<.*?>", String.Empty);
                       description = new string(desc.Take(1990).ToArray());
                   }
                   else
                   {
                       description = null;
                   }

                   string qty;
                   if (d.Qty == 0)
                   {
                       qty = "0";
                       d.Instock = 0;
                   }
                   else
                   {
                       qty = "1";
                       d.Instock = 1;
                   }

                   string manufacturer;
                   string brand;
                   if (d.Manufacturer == null && d.Brand == null)
                   {
                       manufacturer = "Unknown";
                       brand = "Unknown";
                   }
                   else
                   {
                       if (d.Manufacturer == null)
                       {
                           manufacturer = d.Brand;
                       }
                       else
                       {
                           manufacturer = d.Manufacturer;
                       }

                       if (d.Brand == null)
                       {
                           brand = d.Manufacturer;
                       }
                       else
                       {
                           brand = d.Brand;
                       }

                   }

                   sb.AppendLine(string.Join("\t",
                                 string.Format(@"""{0}""", d.ASIN.Trim()),
                                 string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
                                 string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
                                 string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
                                 string.Format(@"""{0}""", qty),
                                 string.Format(@"""{0}""", "")));

                   d.FileName = DateTime.Now.ToString("yyyy-MM-dd") + "_UpdatePriceQTY_Sports_" + fcountSport;

                   d.ExportDate = DateTime.Now;
                   d.ReExportStatus = 1;
                   d.UpdatedSalesPriceTimeStamp = null;
                   dbcontext.SaveChanges();
               }


               fcountSport++;
               //Response.Write(sb.ToString());
               //Response.End();
           }
       }



    }

}
