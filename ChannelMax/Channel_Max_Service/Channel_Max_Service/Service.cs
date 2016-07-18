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

using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
//using UkListing;


namespace OmnimarkAmazon.Service
{
    public partial class Service : ServiceBase
    {

        Timer OrderDownloaderTimer;
        Timer ItemFetchTimer;
        Timer ReportActionsTimer;
        Timer FeedSubmitterTimer;
        Timer ImageDownloaderTimer;
        Timer FixMissingReceivedProductInventoryAdjustmentsTimer;
        bool IsConsole;
        Dictionary<string, bool> LogWasLastNewLine = new Dictionary<string, bool>();
        bool ShutdownTriggered = false;
        string LogDir = ReadLogFilePath();
       // string LogDir=AppDomain.CurrentDomain.BaseDirectory + "Logs";
        public static int count = 0;
        public Service(bool IsConsole)
        {
            this.IsConsole = IsConsole;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Startup();
        }

        public void Startup()
        {

            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            Log(LogFile, true, "");
            Log(LogFile, true, "Service Starting...");

            Log(LogFile, true, "Spawning ItemSearch thread...");
            ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFind), null);
            //Log(LogFile, true, "Spawning ItemSearch thread...");
            //ThreadPool.QueueUserWorkItem(new WaitCallback(ItemFetch), null);


        }

        protected override void OnStop()
        {
            string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
           // Shutdown();
            Log(LogFile, true, "");
            Log(LogFile, true, "Service Stopping...");

        }

        public void Shutdown()
        {
            OrderDownloaderTimer.Dispose();
            ItemFetchTimer.Dispose();
            ShutdownTriggered = true;
        }
        public void ItemFind(object o)
        {
            string LogFile = LogDir + "\\UKservice_ItemSearch" + DateTime.Now.ToString("yyyyMMdd") + ".log";
           
               
                    try
                    {
                        OmnimarkAmazonWeb.Controllers.ItemManagementController ic = new OmnimarkAmazonWeb.Controllers.ItemManagementController();
                        ic.ExportForUK();
                       
                    }
                    catch (Exception Ex)
                    {
                        while (Ex != null)
                        {
                            Log(LogFile, true, "EXCEPTION: " + Ex.Message + "\n" + Ex.StackTrace);
                            Ex = Ex.InnerException;
                        }

                    }

                
                Thread.Sleep(10800000);/*3 hrs*/
                Log(LogFile, true, "Renabling service......"+DateTime.Now.ToString());
                this.ItemFind(o);
              
           
        }
        static string ReadLogFilePath()
        {
            string configpath = Convert.ToString(ConfigurationManager.AppSettings["LogFilePath"]);
            if (configpath == string.Empty)
                return AppDomain.CurrentDomain.BaseDirectory + "Logs";
            else
                return configpath;
        }
        void Log(string LogFile, bool Linefeed, string line)
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
