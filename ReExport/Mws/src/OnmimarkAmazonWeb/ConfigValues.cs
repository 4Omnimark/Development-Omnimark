using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OmnimarkAmazonWeb
{
    public class ConfigValues
    {
        public double InitialRangeMinFrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["InitialRangeMinFrmConfig"]);
        public  double InitialRangeMaxFrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["InitialRangeMaxFrmConfig"]);
        public int TakeCountFromTable = Convert.ToInt32(ConfigurationManager.AppSettings["TakeCountFromTable"]);
        public  double NextRangeMFrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["NextRangeMFrmConfig"]);
        public  double TotalFrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["TotalFrmConfig"]);
        public double IncreamentRangeFrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["IncreamentRangeFrmConfig"]);
        public double MinimumPricefrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["MinimumPricefrmConfig"]);
        public double CanadaMinimumPricefrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["CanadaMinimumPricefrmConfig"]);
        public double IncreamentLoopRangeFrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["IncreamentLoopRangeFrmConfig"]);
        public int minimumQtyfrmConfig = Convert.ToInt32(ConfigurationManager.AppSettings["minimumQtyfrmConfig"]);
        public int maximumQtyfrmConfig = Convert.ToInt32(ConfigurationManager.AppSettings["maximumQtyfrmConfig"]);
        public double SubstractDisplayMinPricefrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["SubstractDisplayMinPricefrmConfig"]);
        public double AddDisplayMaxPricefrmConfig = Convert.ToDouble(ConfigurationManager.AppSettings["AddDisplayMaxPricefrmConfig"]);
        public int LeadTimeToShipfrmConfig = Convert.ToInt32(ConfigurationManager.AppSettings["LeadTimeToShipfrmConfig"]);
        public int CanadaLeadTimeToShipfrmConfig = Convert.ToInt32(ConfigurationManager.AppSettings["CanadaLeadTimeToShipfrmConfig"]);
        public string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
        public double addToMinVal = double.Parse(ConfigurationManager.AppSettings["ProdPriceAddToMinValUK"]); // added this on 18/7/2016  getting value from config file
       // public double minvalFrmConfig = double.Parse(ConfigurationManager.AppSettings["ProdPriceMinValUK"]); // added this on 18/7/2016
        
    }
}