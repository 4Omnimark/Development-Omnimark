using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.IO;
using OmniUKClass.BLCode;
using OmniUKClass;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;



namespace OmnimarkAmazon.Service
{
    public partial class Service : ServiceBase
    {

        UKOmnimarkEntities db;
        Timer OrderDownloaderTimer;
        Timer ItemFetchTimer;
        Timer ReportActionsTimer;
        Timer FeedSubmitterTimer;
        Timer ImageDownloaderTimer;
        Timer FixMissingReceivedProductInventoryAdjustmentsTimer;
        bool IsConsole;
        Dictionary<string, bool> LogWasLastNewLine = new Dictionary<string, bool>();
        bool ShutdownTriggeredSports = false;
        bool ShutdownTriggeredBeauty = false;
        bool ShutdownTriggeredBaby = false;
        bool ShutdownTriggeredJewellery = false;
        bool ShutdownTriggeredToys = false;
        bool ShutdownTriggeredWatches = false;
        bool ShutdownTriggeredToysNotPrime = false;  // 8-6-2016 added notprime categories.
        bool ShutdownTriggeredHomeAndKitchen = false;
        bool ShutdownTriggeredWatchesNotPrime = false;
        bool ShutdownTriggeredJewelryNotPrime = false;
        bool ShutdownTriggeredSportsNotPrime = false;
        bool ShutdownTriggeredBabyNotPrime = false;
        bool ShutdownTriggeredBeautyNotPrime = false;
        bool ShutdownTriggeredHomeAndKitchenNotPrime = false;
      //  string LogDir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
        static string LogDir = ReadLogFilePath();
        // public static int count = 0;       

        public Service(bool IsConsole)
        {
            this.IsConsole = IsConsole;
            InitializeComponent();
        }


        static string ReadLogFilePath()
        {
            string configpath = Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]);
            if (configpath==string.Empty)
                return AppDomain.CurrentDomain.BaseDirectory + "Logs";
            else
                return configpath;
        }
        protected override void OnStart(string[] args)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            Log(LogFile, true, "OnStart Executing...");
            Startup();
        }

        public void Startup()
        {

            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {

                Log(LogFile, true, "");
                Log(LogFile, true, "Service Starting...");

                Log(LogFile, true, "Spawning ItemLookup thread...");
                //ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFind), null);

                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchSports), null);
               // ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchBeauty), null);///Beauty category removed
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchBaby), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchJewellery), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchToys), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchWatches), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchToysNotPrime), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchHomeAndKitchen), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchWatchesNotPrime), null);  // 8-6-2016 added notprime categories.
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchJewelryNotPrime), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchSportsNotPrime), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchBabyNotPrime), null);
               // ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchBeautyNotPrime), null);
                ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetchHomeAndKitchenNotPrime), null);
            }
            catch (Exception Ex)
            {
                while (Ex != null)
                {
                    Log(LogFile, true, "EXCEPTION: " + Ex.Message + "\n" + Ex.StackTrace);
                    Ex = Ex.InnerException;
                }

            }

        }

        protected override void OnStop()
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            //Service.StopService("UK_Project_Itemlookup_Service", 150000000);             
            // Shutdown();
            Log(LogFile, true, "");
            Log(LogFile, true, "Service Stopping...");

        }

        public void Shutdown()
        {
            OrderDownloaderTimer.Dispose();
            ItemFetchTimer.Dispose();
            ShutdownTriggeredSports = true;
            ShutdownTriggeredBeauty = true;
            ShutdownTriggeredBaby = true;
            ShutdownTriggeredJewellery = true;
            ShutdownTriggeredToys = true;
            ShutdownTriggeredWatches = true;
            ShutdownTriggeredToysNotPrime = true;
            ShutdownTriggeredHomeAndKitchen = true;
            ShutdownTriggeredWatchesNotPrime = true;  // 8-6-2016 added notprime categories.
            ShutdownTriggeredJewelryNotPrime = true;
            ShutdownTriggeredSportsNotPrime = true;
            ShutdownTriggeredBabyNotPrime = true;
            ShutdownTriggeredBeautyNotPrime = true;
            ShutdownTriggeredHomeAndKitchenNotPrime = true;
        }

        //public static void StopService(string serviceName, int timeoutMilliseconds)
        //{
        //    ServiceController service = new ServiceController(serviceName);

        //    try
        //    {
        //        TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
        //        //string status = service.Status.ToString();
        //        //service.CanStop.ToString();

        //        //service.WaitForStatus(ServiceControllerStatus.Stopped);
        //        //Console.WriteLine("Stop service " + serviceName + " ");
        //        if (service.Status.Equals(ServiceControllerStatus.Running)
        //                          && service.CanStop)
        //        {
        //            service.Stop();
        //            Console.WriteLine("Service Stopped");
        //        }
        //        Console.ReadLine();
        //    }
        //    catch (Exception ex)
        //    {
        //        // ...
        //    }
        //}


        public void ItemFetchSports(object o)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinSports();
                Thread.Sleep(3600000);
                this.ItemFetchSports(o);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggerSports = true;
                if (ShutdowntriggerSports)
                {
                    Log(LogFile, true, "Re-enabling Sports.....");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchSports, null, 3600000, 3600000);
                }

            }
        }

        public void ItemFetchBeauty(object bty)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinBeauty();
                Thread.Sleep(3600000);
                this.ItemFetchBeauty(bty);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredBeauty = true;
                if (ShutdowntriggeredBeauty)
                {
                    Log(LogFile, true, "Re-enabling Beauty...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchBeauty, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchBaby(object bby)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinBaby();
                Thread.Sleep(3600000);
                this.ItemFetchBaby(bby);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredBaby = true;
                if (ShutdowntriggeredBaby)
                {
                    Log(LogFile, true, "Re-enabling Baby...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchBaby, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchJewellery(object jwy)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinJewellery();
                Thread.Sleep(3600000);
                this.ItemFetchJewellery(jwy);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredJewellery = true;
                if (ShutdowntriggeredJewellery)
                {
                    Log(LogFile, true, "Re-enabling Jewellery...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchJewellery, null, 3600000, 3600000);
                }
            }

        }

        public void ItemFetchToys(object tys)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinToys();
                Thread.Sleep(3600000);
                this.ItemFetchToys(tys);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredToys = true;
                if (ShutdowntriggeredToys)
                {
                    Log(LogFile, true, "Re-enabling Toys...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchToys, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchWatches(object wts)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinWatches();
                Thread.Sleep(3600000);
                this.ItemFetchWatches(wts);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredWatches = true;
                if (ShutdowntriggeredWatches)
                {
                    Log(LogFile, true, "Re-enabling Watches...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchWatches, null, 3600000, 3600000);
                }
            }
        }


        public void ItemFetchToysNotPrime(object tnp)
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinToysNotPrime();
                Thread.Sleep(3600000);
                this.ItemFetchToysNotPrime(tnp);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredToysNotPrime = true;
                if (ShutdowntriggeredToysNotPrime)
                {
                    Log(LogFile, true, "Re-enabling ToysNotPrime...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchToysNotPrime, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchHomeAndKitchen(object hak) 
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinHomeAndKitchen();
                Thread.Sleep(3600000);
                this.ItemFetchHomeAndKitchen(hak);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredHomeAndKitchen = true;
                if (ShutdowntriggeredHomeAndKitchen)
                {
                    Log(LogFile, true, "Re-enabling HomeAndKitchen...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchHomeAndKitchen, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchWatchesNotPrime(object wnp) //8-6-2016 added WatchesNotPrime category.
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinWatchesNotPrime();
                Thread.Sleep(3600000);
                this.ItemFetchWatchesNotPrime(wnp);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredWatchesNotPrime = true;
                if (ShutdowntriggeredWatchesNotPrime)
                {
                    Log(LogFile, true, "Re-enabling WatchesNotPrime...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchWatchesNotPrime, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchJewelryNotPrime(object jnp) //8-6-2016 added JewelryNotPrime category.
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinJewelryNotPrime();
                Thread.Sleep(3600000);
                this.ItemFetchJewelryNotPrime(jnp);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredJewelryNotPrime = true;
                if (ShutdowntriggeredJewelryNotPrime)
                {
                    Log(LogFile, true, "Re-enabling JewelryNotPrime...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchJewelryNotPrime, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchSportsNotPrime(object snp) //8-6-2016 added SportsNotPrime category.
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinSportsNotPrime();
                Thread.Sleep(3600000);
                this.ItemFetchSportsNotPrime(snp);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredSportsNotPrime = true;
                if (ShutdowntriggeredSportsNotPrime)
                {
                    Log(LogFile, true, "Re-enabling SportsNotPrime...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchSportsNotPrime, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchBabyNotPrime(object bnp) //8-6-2016 added BabyNotPrime category.
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinBabyNotPrime();
                Thread.Sleep(3600000);
                this.ItemFetchBabyNotPrime(bnp);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredBabyNotPrime = true;
                if (ShutdowntriggeredBabyNotPrime)
                {
                    Log(LogFile, true, "Re-enabling BabyNotPrime...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchBabyNotPrime, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchBeautyNotPrime(object btnp) //8-6-2016 added BeautyNotPrime category.
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinBeautyNotPrime();
                Thread.Sleep(3600000);
                this.ItemFetchBeautyNotPrime(btnp);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredBeautyNotPrime = true;
                if (ShutdowntriggeredBeautyNotPrime)
                {
                    Log(LogFile, true, "Re-enabling BeautyNotPrime...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchBeautyNotPrime, null, 3600000, 3600000);
                }
            }
        }

        public void ItemFetchHomeAndKitchenNotPrime(object hnp) //8-6-2016 added HomeAndKitchenNotPrime category.
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                UKItemSearch.UpdateAsinHomeAndKitchenNotPrime();
                Thread.Sleep(3600000);
                this.ItemFetchHomeAndKitchenNotPrime(hnp);
            }
            catch (Exception Ex)
            {
                bool ShutdowntriggeredHomeAndKitchenNotPrime = true;
                if (ShutdowntriggeredHomeAndKitchenNotPrime)
                {
                    Log(LogFile, true, "Re-enabling HomeAndKitchenNotPrime...");
                    FixMissingReceivedProductInventoryAdjustmentsTimer = new Timer(ItemFetchHomeAndKitchenNotPrime, null, 3600000, 3600000);
                }
            }
        }

        public void Log(string LogFile, bool Linefeed, string line)
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
