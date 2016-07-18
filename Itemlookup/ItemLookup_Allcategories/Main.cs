using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using OmniUKClass.BLCode;
using System.Threading;
using System.IO;
using System.Configuration;

namespace OmnimarkAmazon.Service
{
    class Startup
    {
        // 8-6-2016 added notprime categories.

        static Thread SportsThread;
        static Thread BeautyThread;
        static Thread BabyThread;
        static Thread JewelleryThread;
        static Thread ToysThread;
        static Thread WatchesThread;
        static Thread ToysNotPrimeThread;
        static Thread HomeAndKitchenThread;
        static Thread WatchesNotPrimeThread;
        static Thread JewelryNotPrimeThread;
        static Thread SportsNotPrimeThread;
        static Thread BabyNotPrimeThread;
        static Thread BeautyNotPrimeThread;
        static Thread HomeAndKitchenNotPrimeThread;

       // static string LogDir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
        static string LogDir = ReadLogFilePath();
        static string LogFile = LogDir + "\\UKService" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        static Dictionary<string, bool> LogWasLastNewLine = new Dictionary<string, bool>();
        static bool IsConsole;
        static Timer FixMissingReceivedProductInventoryAdjustmentsTimer;
        static int Main(string[] args)
        {

            Log(LogFile, true, "Main Executing.....");

            bool install = false, uninstall = false, console = false, rethrow = false;
            
            try
            {
                foreach (string arg in args)
                {
                    switch (arg)
                    {
                        case "-i":
                        case "-install":
                            install = true; break;
                        case "-u":
                        case "-uninstall":
                            uninstall = true; break;
                        case "-c":
                        case "-console":
                            console = true; break;
                        default:
                            Console.Error.WriteLine("Argument not expected: " + arg);
                            break;
                    }
                }

                if (uninstall)
                {
                    Installer.Install(true, args);
                }
                if (install)
                {
                    Installer.Install(false, args);
                }
                if (console)
                {
                    Service s = new Service(true);
                    Console.WriteLine("Starting...");
                    s.Startup();
                    Console.WriteLine("System running; press any key to stop");
                    Console.ReadKey(true);
                    //s.Shutdown();
                    Console.WriteLine("System stopped");
                }
                else if (!(install || uninstall))
                {
                    rethrow = true; // so that windows sees error...
                    ServiceBase[] services = { new Service(false) };
                    ServiceBase.Run(services);
                    rethrow = false;
                }
                return 0;

            }
            catch (Exception ex)
            {
                if (rethrow) throw;
                Console.Error.WriteLine(ex.Message);
                return -1;
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
        public static void Log(string LogFile, bool Linefeed, string line)
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