/******************************************************************************* 
 *  Copyright 2009 Amazon Services.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service CSharp Library
 *  API Version: 2009-01-01
 *  Generated: Mon Mar 16 17:31:42 PDT 2009 
 * 
 */

using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using MarketplaceWebService;
using MarketplaceWebService.Mock;
using MarketplaceWebService.Model;
using OmnimarkAmazonWeb.Controllers;
using System.IO;
using UkListing;
using System.Web.Mvc;
using System.Linq;
using OmnimarkAmazonWeb.Models;
using System.Configuration;


namespace MarketplaceWebService.Samples
{

    /// <summary>
    /// Marketplace Web Service  Samples
    /// </summary>
    public class MarketplaceWebServiceSamples
    {
        static bool IsConsole;
        static Dictionary<string, bool> LogWasLastNewLine = new Dictionary<string, bool>();
        static bool ShutdownTriggered = false;
        static string LogDir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
        static string LogFile = LogDir + "\\MarketplaceWebServiceSamples" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        /**
         * Samples for Marketplace Web Service functionality
         */
        public static void AmazonUpload()
        {

            /************************************************************************
             * Access Key ID and Secret Acess Key ID, obtained from:
             * http://aws.amazon.com
             * 
             * IMPORTANT: Your Secret Access Key is a secret, and should be known 
             * only by you and AWS. You should never include your Secret Access Key 
             * in your requests to AWS. You should never e-mail your Secret Access Key 
             * to anyone. It is important to keep your Secret Access Key confidential 
             * to protect your account.
             ***********************************************************************/
            String accessKeyId = "";
            String secretAccessKey = "";
            string merchantId = "";
            string marketplaceId = "";
            UKOmnimarkEntities ukdb = new UKOmnimarkEntities();
            string[] accessKeyIdFrmConfig = ConfigurationManager.AppSettings["accessKeyIdFrmConfig"].ToString().Split(',');
            string[] secretAccessKeyFrmConfig = ConfigurationManager.AppSettings["secretAccessKeyFrmConfig"].ToString().Split(',');
            string[] marketplaceIdFrmConfig = ConfigurationManager.AppSettings["marketplaceIdFrmConfig"].ToString().Split(',');
            string[] merchantIdFrmConfig = ConfigurationManager.AppSettings["merchantIdFrmConfig"].ToString().Split(',');
            

            List<string> shortcode1 = ukdb.tbl_Account.Where(x => x.ReExportAllow == 1).Select(x => x.ShortCode).ToList();
            foreach (var item in shortcode1)
            {
                var category = ukdb.tbl_Category.Where(x => x.Account_Name == item && x.Enabled == 1).ToList();
                foreach (var cat in category)
                {
                    for (int flag = 1; flag <= 2; flag++)
                    {
                        try
                        {

                            if (item == ConstantData.ED)
                            {
                                accessKeyId = accessKeyIdFrmConfig[0];  /// values are coming from config file {0,1,2,3} as [ED,EM,DI,DC] Date 18/7/2016
                                secretAccessKey = secretAccessKeyFrmConfig[0];                              
                                merchantId = merchantIdFrmConfig[0];
                                marketplaceId = marketplaceIdFrmConfig[0];
                            }
                            else if (item == ConstantData.EM)
                            {
                                accessKeyId = accessKeyIdFrmConfig[1];
                                secretAccessKey = secretAccessKeyFrmConfig[1];
                                merchantId = merchantIdFrmConfig[1];
                                marketplaceId = marketplaceIdFrmConfig[0];

                            }
                            else if (item == ConstantData.DI)
                            {
                                accessKeyId = accessKeyIdFrmConfig[2];
                                secretAccessKey = secretAccessKeyFrmConfig[2];
                                merchantId = merchantIdFrmConfig[2];
                                marketplaceId = marketplaceIdFrmConfig[0];

                            }
                            else if (item == ConstantData.DC)
                            {
                                accessKeyId = accessKeyIdFrmConfig[3];
                                secretAccessKey = secretAccessKeyFrmConfig[3];
                                merchantId = merchantIdFrmConfig[3];
                                marketplaceId = marketplaceIdFrmConfig[1];

                            }



                            /************************************************************************
                            * Instantiate  Implementation of Marketplace Web Service 
                            ***********************************************************************/

                            MarketplaceWebServiceConfig config = new MarketplaceWebServiceConfig();

                            /************************************************************************
                             * The application name and version are included in each MWS call's
                             * HTTP User-Agent field. These are required fields.
                             ***********************************************************************/
                            // string[] category = new string[] { "tbl_Sports", "tbl_Toys", "tbl_Beauty" };
                            const string applicationName = "<Your Application Name>";
                            const string applicationVersion = "<Your Application Version>";
                            string fname = "";
                            MarketplaceWebService service =
                                new MarketplaceWebServiceClient(
                                    accessKeyId,
                                    secretAccessKey,
                                    applicationName,
                                    applicationVersion,
                                    config);



                            if (item == ConstantData.ED || item == ConstantData.EM || item == ConstantData.DI)
                            {
                                config.ServiceURL = "https://mws.amazonservices.co.uk";
                            }
                            else if (item == ConstantData.DC)
                            {
                                // Canada:
                                config.ServiceURL = "https://mws.amazonservices.ca";
                            }



                            /************************************************************************
                             * Uncomment to invoke Submit Feed Action
                             ***********************************************************************/
                            {
                                SubmitFeedRequest request = new SubmitFeedRequest();
                                request.Merchant = merchantId;
                                request.MWSAuthToken = "<Your MWS Auth Token>"; // Optional
                                request.MarketplaceIdList = new IdList();
                                request.MarketplaceIdList.Id = new List<string>(new string[] { marketplaceId });



                                ItemManagementController it = new ItemManagementController();
                                fname = it.ExportForUK(item, cat.CategoryName,flag);
                              // fname = it.ExportForUK("ED", "HomeAndKitchen",1);
                               
                                if (fname.Contains("Blank"))
                                {
                                    Console.WriteLine("=======File is Blank=========");

                                }
                                else
                                {
                                    // string path = "D:/api/Mws/src/UpFile/" + fname;
                                    request.FeedContent = File.Open(fname, FileMode.Open, FileAccess.Read);
                                    // Calculating the MD5 hash value exhausts the stream, and therefore we must either reset the
                                    // position, or create another stream for the calculation.
                                    request.ContentMD5 = MarketplaceWebServiceClient.CalculateContentMD5(request.FeedContent);
                                    request.FeedContent.Position = 0;

                                    //request.FeedType = "_POST_FLAT_FILE_LISTINGS_DATA_";
                                    request.FeedType = "_POST_FLAT_FILE_PRICEANDQUANTITYONLY_UPDATE_DATA_";
                                    // request.FeedType = "_POST_FLAT_FILE_INVLOADER_DATA_";

                                    string SubmissionID = SubmitFeedSample.InvokeSubmitFeed(service, request);
                                    string[] file = fname.Split('/');


                                    AmazonResponse ar = new AmazonResponse();
                                    ar.SubmissionID = SubmissionID;
                                    ar.SubmissionTimeStamp = DateTime.Now;
                                    ar.FileName = file[3];
                                    ukdb.AmazonResponses.Add(ar);
                                    ukdb.SaveChanges();
                                    System.Threading.Thread.Sleep(600000);// sleep for 10 minutes
                                }


                            }
                        }
                        catch (Exception ex)
                        {
                            Log(LogFile, true, "Issue in Uploading to Amazon...." + ex);
                        }


                    }

                }

            }


            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");
            ukdb.Dispose();
           // System.Threading.Thread.Sleep(120000);
            AmazonUpload();

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
