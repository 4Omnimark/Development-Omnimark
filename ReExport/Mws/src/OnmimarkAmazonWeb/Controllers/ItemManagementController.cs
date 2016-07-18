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
using System.Transactions;
using System.Data.Entity.Validation;
using System.Diagnostics;




namespace OmnimarkAmazonWeb.Controllers
{

    public class ItemManagementController : _BaseController
    {
        UKOmnimarkEntities ukdb = new UKOmnimarkEntities();
        bool IsConsole;
        Dictionary<string, bool> LogWasLastNewLine = new Dictionary<string, bool>();
        static string LogDir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
        string LogFile = LogDir + "\\ProcessLogic" + DateTime.Now.ToString("yyyyMMdd") + ".log";
        public static int fcountSport = 1, fcountToys = 1, fcountBeauty = 1, fcountAllExport = 1, fcountBaby = 1, fcountWatches = 1, fcountJewelry = 1;

        public string ExportForUK(string sc, string cat, int flag)
        {
            string fname = "";
            ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;
            IEnumerable<tbl_Sports> Sdata = null;
            IEnumerable<tbl_Toys> Tdata = null;
            // IEnumerable<tbl_Beauty> Bdata = null;
            IEnumerable<tbl_Baby> Bbdata = null;
            IEnumerable<tbl_Watches> Wdata = null;
            IEnumerable<tbl_Jewellery> Jdata = null;
            IEnumerable<tbl_HomeandKitchen> Hdata = null;

            IEnumerable<tbl_SportsNotPrime> SdataNotPrime = null;
            IEnumerable<tbl_ToysNotPrime> TdataNotPrime = null;
            //IEnumerable<tbl_BeautyNotPrime> BdataNotPrime = null;
            IEnumerable<tbl_BabyNotPrime> BbdataNotPrime = null;
            IEnumerable<tbl_WatchesNotPrime> WdataNotPrime = null;
            IEnumerable<tbl_JewelleryNotPrime> JdataNotPrime = null;
            IEnumerable<tbl_HomeAndKitchenNotPrime> HdataNotPrime = null;
            DateTime tempdate = DateTime.Now.AddMinutes(-60.00);

            try
            {


                if (cat == ConstantData.SportingGoods)
                {
                    if (sc == ConstantData.ED)
                    {
                        if (flag == 1)
                        {
                            Sdata = ukdb.tbl_Sports.Where(x => (x.Prime != "1" && x.Account1_Status == 1 && x.Account1_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                            fname = ReExport(cat, Sdata, sc, flag);
                        }
                        else if (flag == 2)
                        {
                            SdataNotPrime = ukdb.tbl_SportsNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                            fname = ReExport(cat + "NotPrime", SdataNotPrime, sc, flag);
                        }

                    }
                    else if (sc == ConstantData.EM)
                    {
                        if (flag == 1)
                        {
                            Sdata = ukdb.tbl_Sports.Where(x => (x.Prime != "1" && x.Account2_Status == 1 && x.Account2_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                            fname = ReExport(cat, Sdata, sc, flag);
                        }
                        else if (flag == 2)
                        {
                            SdataNotPrime = ukdb.tbl_SportsNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                            fname = ReExport(cat + "NotPrime", SdataNotPrime, sc, flag);
                        }
                    }
                    else if (sc == ConstantData.DI)
                    {
                        if (flag == 1)
                        {
                            Sdata = ukdb.tbl_Sports.Where(x => (x.Prime != "1" && x.Account4_Status == 1 && x.Account4_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                            fname = ReExport(cat, Sdata, sc, flag);
                        }
                        else if (flag == 2)
                        {
                            SdataNotPrime = ukdb.tbl_SportsNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                            fname = ReExport(cat + "NotPrime", SdataNotPrime, sc, flag);
                        }

                    }
                    else if (sc == ConstantData.DC)
                    {
                        if (flag == 1)
                        {
                            Sdata = ukdb.tbl_Sports.Where(x => (x.Prime != "1" && x.Account3_Status == 1 && x.Account3_ReExport == 0 && x.CanadaProhibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                            fname = ReExportCanada(cat, Sdata, sc, flag);
                        }
                        else if (flag == 2)
                        {
                            SdataNotPrime = ukdb.tbl_SportsNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                            fname = ReExportCanada(cat + "NotPrime", Sdata, sc, flag);
                        }

                    }


                }
                else
                    if (cat == ConstantData.Toys)
                    {
                        if (sc == ConstantData.ED)
                        {
                            if (flag == 1)
                            {
                                Tdata = ukdb.tbl_Toys.Where(x => (x.Prime != "1" && x.Account1_Status == 1 && x.Account1_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat, Tdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                TdataNotPrime = ukdb.tbl_ToysNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat + "NotPrime", TdataNotPrime, sc, flag);
                            }

                        }

                        else if (sc == ConstantData.EM)
                        {
                            if (flag == 1)
                            {
                                Tdata = ukdb.tbl_Toys.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat, Tdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                TdataNotPrime = ukdb.tbl_ToysNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat + "NotPrime", TdataNotPrime, sc, flag);
                            }

                        }
                        else if (sc == ConstantData.DI)
                        {
                            if (flag == 1)
                            {
                                Tdata = ukdb.tbl_Toys.Where(x => (x.Prime != "1" && x.Account4_Status == 1 && x.Account4_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat, Tdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                TdataNotPrime = ukdb.tbl_ToysNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat + "NotPrime", TdataNotPrime, sc, flag);
                            }

                        }
                        else if (sc == ConstantData.DC)
                        {
                            if (flag == 1)
                            {
                                Tdata = ukdb.tbl_Toys.Where(x => (x.Prime != "1" && x.Account3_Status == 1 && x.Account3_ReExport == 0 && x.CanadaProhibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                fname = ReExportCanada(cat, Tdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                TdataNotPrime = ukdb.tbl_ToysNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                fname = ReExportCanada(cat + "NotPrime", TdataNotPrime, sc, flag);
                            }

                        }

                    }
                    //else
                    //    if (cat == ConstantData.Beauty)
                    //    {
                    //        if (sc == ConstantData.ED)
                    //        {
                    //            if (flag == 1)
                    //            {
                    //                Bdata = ukdb.tbl_Beauty.Where(x => (x.Prime != "1" && x.Account1_Status == 1 && x.Account1_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                    //                fname = ReExport(cat, Bdata, sc);
                    //            }
                    //            else if (flag == 2)
                    //            {
                    //                BdataNotPrime = ukdb.tbl_BeautyNotPrime.Where(x =>  (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                    //                fname = ReExport(cat + "NotPrime", BdataNotPrime, sc);
                    //            }

                    //        }
                    //        else if (sc == ConstantData.EM)
                    //        {
                    //            if (flag == 1)
                    //            {
                    //                Bdata = ukdb.tbl_Beauty.Where(x => (x.Prime != "1" && x.Account2_Status == 1 && x.Account2_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                    //                fname = ReExport(cat, Bdata, sc);
                    //            }
                    //            else if (flag == 2)
                    //            {
                    //                BdataNotPrime = ukdb.tbl_BeautyNotPrime.Where(x =>  (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                    //                fname = ReExport(cat + "NotPrime", BdataNotPrime, sc);
                    //            }

                    //        }
                    //        else if (sc == ConstantData.DI)
                    //        {
                    //            if (flag == 1)
                    //            {
                    //                Bdata = ukdb.tbl_Beauty.Where(x => (x.Prime != "1" && x.Account4_Status == 1 && x.Account4_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                    //                fname = ReExport(cat, Bdata, sc);
                    //            }
                    //            else if (flag == 2)
                    //            {
                    //                BdataNotPrime = ukdb.tbl_BeautyNotPrime.Where(x =>  (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                    //                fname = ReExport(cat + "NotPrime", BdataNotPrime, sc);
                    //            }

                    //        }
                    //        else if (sc == ConstantData.DC)
                    //        {
                    //            if (flag == 1)
                    //            {
                    //                Bdata = ukdb.tbl_Beauty.Where(x => (x.Prime != "1" && x.Account3_Status == 1 && x.Account3_ReExport == 0 && x.CanadaProhibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                    //                fname = ReExportCanada(cat, Bdata, sc);
                    //            }
                    //            else if (flag == 2)
                    //            {
                    //                BdataNotPrime = ukdb.tbl_BeautyNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                    //                fname = ReExportCanada(cat + "NotPrime", BdataNotPrime, sc);
                    //            }

                    //        }


                    //    }  Beauty Category excluded from system 16/6/2016
                    else if (cat == ConstantData.Baby)
                    {
                        if (sc == ConstantData.ED)
                        {
                            if (flag == 1)
                            {
                                Bbdata = ukdb.tbl_Baby.Where(x => (x.Prime != "1" && x.Account1_Status == 1 && x.Account1_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat, Bbdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                BbdataNotPrime = ukdb.tbl_BabyNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat + "NotPrime", BbdataNotPrime, sc, flag);
                            }

                        }
                        else if (sc == ConstantData.EM)
                        {
                            if (flag == 1)
                            {
                                Bbdata = ukdb.tbl_Baby.Where(x => (x.Prime != "1" && x.Account2_Status == 1 && x.Account2_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat, Bbdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                BbdataNotPrime = ukdb.tbl_BabyNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat + "NotPrime", BbdataNotPrime, sc, flag);
                            }

                        }
                        else if (sc == ConstantData.DI)
                        {
                            if (flag == 1)
                            {
                                Bbdata = ukdb.tbl_Baby.Where(x => (x.Prime != "1" && x.Account4_Status == 1 && x.Account4_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat, Bbdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                BbdataNotPrime = ukdb.tbl_BabyNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                fname = ReExport(cat + "NotPrime", BbdataNotPrime, sc, flag);
                            }

                        }
                        else if (sc == ConstantData.DC)
                        {
                            if (flag == 1)
                            {
                                Bbdata = ukdb.tbl_Baby.Where(x => (x.Prime != "1" && x.Account3_Status == 1 && x.Account3_ReExport == 0 && x.CanadaProhibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                fname = ReExportCanada(cat, Bbdata, sc, flag);
                            }
                            else if (flag == 2)
                            {
                                BbdataNotPrime = ukdb.tbl_BabyNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                fname = ReExportCanada(cat + "NotPrime", BbdataNotPrime, sc, flag);
                            }

                        }

                    }
                    else
                        if (cat == ConstantData.Watches)
                        {
                            if (sc == ConstantData.ED)
                            {
                                if (flag == 1)
                                {
                                    Wdata = ukdb.tbl_Watches.Where(x => (x.Prime != "1" && x.Account1_Status == 1 && x.Account1_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                    fname = ReExport(cat, Wdata, sc, flag);
                                }
                                else if (flag == 2)
                                {
                                    WdataNotPrime = ukdb.tbl_WatchesNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                    fname = ReExport(cat + "NotPrime", WdataNotPrime, sc, flag);
                                }

                            }
                            else if (sc == ConstantData.EM)
                            {
                                if (flag == 1)
                                {
                                    Wdata = ukdb.tbl_Watches.Where(x => (x.Prime != "1" && x.Account2_Status == 1 && x.Account2_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                    fname = ReExport(cat, Wdata, sc, flag);
                                }
                                else if (flag == 2)
                                {
                                    WdataNotPrime = ukdb.tbl_WatchesNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                    fname = ReExport(cat + "NotPrime", WdataNotPrime, sc, flag);
                                }

                            }
                            else if (sc == ConstantData.DI)
                            {
                                if (flag == 1)
                                {
                                    Wdata = ukdb.tbl_Watches.Where(x => (x.Prime != "1" && x.Account4_Status == 1 && x.Account4_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                    fname = ReExport(cat, Wdata, sc, flag);
                                }
                                else if (flag == 2)
                                {
                                    WdataNotPrime = ukdb.tbl_WatchesNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                    fname = ReExport(cat + "NotPrime", WdataNotPrime, sc, flag);
                                }

                            }
                            else if (sc == ConstantData.DC)
                            {
                                if (flag == 1)
                                {
                                    Wdata = ukdb.tbl_Watches.Where(x => (x.Prime != "1" && x.Account3_Status == 1 && x.Account3_ReExport == 0 && x.CanadaProhibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                    fname = ReExportCanada(cat, Wdata, sc, flag);
                                }
                                else if (flag == 2)
                                {
                                    WdataNotPrime = ukdb.tbl_WatchesNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                    fname = ReExportCanada(cat + "NotPrime", WdataNotPrime, sc, flag);
                                }

                            }
                        }
                        else
                            if (cat == ConstantData.Jewelry)
                            {
                                if (sc == ConstantData.ED)
                                {
                                    if (flag == 1)
                                    {
                                        Jdata = ukdb.tbl_Jewellery.Where(x => (x.Prime != "1" && x.Account1_Status == 1 && x.Account1_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                        fname = ReExport(cat, Jdata, sc, flag);
                                    }
                                    else if (flag == 2)
                                    {
                                        JdataNotPrime = ukdb.tbl_JewelleryNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                        fname = ReExport(cat + "NotPrime", JdataNotPrime, sc, flag);
                                    }

                                }
                                else if (sc == ConstantData.EM)
                                {
                                    if (flag == 1)
                                    {
                                        Jdata = ukdb.tbl_Jewellery.Where(x => (x.Prime != "1" && x.Account2_Status == 1 && x.Account2_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                        fname = ReExport(cat, Jdata, sc, flag);
                                    }
                                    else if (flag == 2)
                                    {
                                        JdataNotPrime = ukdb.tbl_JewelleryNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                        fname = ReExport(cat + "NotPrime", JdataNotPrime, sc, flag);
                                    }

                                }
                                else if (sc == ConstantData.DI)
                                {
                                    if (flag == 1)
                                    {
                                        Jdata = ukdb.tbl_Jewellery.Where(x => (x.Prime != "1" && x.Account4_Status == 1 && x.Account4_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                        fname = ReExport(cat, Jdata, sc, flag);
                                    }
                                    else if (flag == 2)
                                    {
                                        JdataNotPrime = ukdb.tbl_JewelleryNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                        fname = ReExport(cat + "NotPrime", JdataNotPrime, sc, flag);
                                    }

                                }
                                else if (sc == ConstantData.DC)
                                {
                                    if (flag == 1)
                                    {
                                        Jdata = ukdb.tbl_Jewellery.Where(x => (x.Prime != "1" && x.Account3_Status == 1 && x.Account3_ReExport == 0 && x.CanadaProhibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                        fname = fname = ReExportCanada(cat, Jdata, sc, flag);
                                    }
                                    else if (flag == 2)
                                    {
                                        JdataNotPrime = ukdb.tbl_JewelleryNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                        fname = ReExportCanada(cat + "NotPrime", JdataNotPrime, sc, flag);
                                    }

                                }
                            }
                            else
                                if (cat == ConstantData.HomeandKitchen)
                                {
                                    if (sc == ConstantData.ED)
                                    {
                                        if (flag == 1)
                                        {
                                            Hdata = ukdb.tbl_HomeandKitchen.Where(x => (x.Prime != 1 && x.Account1_Status == 1 && x.Account1_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                            fname = HomeAndKitchen(cat, Hdata, sc, flag);
                                        }
                                        else if (flag == 2)
                                        {
                                            HdataNotPrime = ukdb.tbl_HomeAndKitchenNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account1_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account1_ReExport == 0 && x.Account1_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account1_ExportDate).Take(2000).ToList();
                                             fname = HomeAndKitchen(cat + "NotPrime", HdataNotPrime, sc, flag);
                                        }

                                    }
                                    else if (sc == ConstantData.EM)
                                    {
                                        if (flag == 1)
                                        {
                                            Hdata = ukdb.tbl_HomeandKitchen.Where(x => (x.Prime != 1 && x.Account2_Status == 1 && x.Account2_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                            fname = HomeAndKitchen(cat, Hdata, sc, flag);
                                        }
                                        else if (flag == 2)
                                        {
                                            HdataNotPrime = ukdb.tbl_HomeAndKitchenNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account2_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account2_ReExport == 0 && x.Account2_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account2_ExportDate).Take(2000).ToList();
                                             fname = HomeAndKitchen(cat + "NotPrime", HdataNotPrime, sc, flag);
                                        }

                                    }
                                    else if (sc == ConstantData.DI)
                                    {
                                        if (flag == 1)
                                        {
                                            Hdata = ukdb.tbl_HomeandKitchen.Where(x => (x.Prime != 1 && x.Account4_Status == 1 && x.Account4_ReExport == 0 && x.UK_Prohibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                            fname = HomeAndKitchen(cat, Hdata, sc, flag);
                                        }
                                        else if (flag == 2)
                                        {
                                            HdataNotPrime = ukdb.tbl_HomeAndKitchenNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account4_ReExport == 1 && x.UK_Prohibited != 1) || (x.Account4_ReExport == 0 && x.Account4_ExportDate < tempdate && x.UK_Prohibited != 1)).OrderByDescending(x => x.Account4_ExportDate).Take(2000).ToList();
                                            fname = HomeAndKitchen(cat + "NotPrime", HdataNotPrime, sc, flag);
                                        }

                                    }
                                    else if (sc == ConstantData.DC)
                                    {
                                        if (flag == 1)
                                        {
                                            Hdata = ukdb.tbl_HomeandKitchen.Where(x => (x.Prime != 1 && x.Account3_Status == 1 && x.Account3_ReExport == 0 && x.CanadaProhibited != 1) || (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                            fname = HomeAndKitchenCanada(cat, Hdata, sc, flag);
                                        }
                                        else if (flag == 2)
                                        {
                                            HdataNotPrime = ukdb.tbl_HomeAndKitchenNotPrime.Where(x => (x.UpdatedSalesPriceTimeStamp != null && x.Account3_ReExport == 1 && x.CanadaProhibited != 1) || (x.Account3_ReExport == 0 && x.Account3_ExportDate < tempdate && x.CanadaProhibited != 1)).OrderByDescending(x => x.Account3_ExportDate).Take(2000).ToList();
                                            fname = HomeAndKitchenCanada(cat + "NotPrime", HdataNotPrime, sc, flag);
                                        }

                                    }
                                }
            }
            catch (Exception ex)
            {
                Log(LogFile, true, "Issue in Selecting Records from database :" + sc + ex);
            }

            return fname;
        }



        public string ReExport(string foldername, IEnumerable<dynamic> data, string shortcode, int flag)
        {


            ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

            string fname = "";
            string path = "";
            string cname = "";


            StringWriter st = new StringWriter();

            string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);

            double addToMinVal =  double.Parse(ConfigurationManager.AppSettings["ProdPriceAddToMinValUK"]);
            if (data != null && data.Count() != 0)
            {
                foreach (var d in data)
                {
                    try
                    {

                        int reExportChange = 1;
                        double price = 0;

                        double pricemin = 0.00;
                        double finalprice;
                        double displayMinprice;
                        double displayMaxprice;
                        string ASIN;
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

                            double minval = double.Parse(ConfigurationManager.AppSettings["ProdPriceMinValUK"]);
                            if (price > 0 && price <= 19.99)
                            {
                                pricemin = minval;
                            }
                            else
                            {
                                for (double i = 20; i < 500; i += 10)
                                {
                                    minval = minval + addToMinVal;
                                    double temp = i + 10;
                                    if (price >= i && price < temp)
                                    {
                                        pricemin = minval;
                                        break;
                                    }
                                }
                            }

                            finalprice = pricemin;

                        }
                        else
                        {
                            finalprice = 17.45;
                        }
                        string qty;
                        if (flag != 2)
                        {
                            ASIN = d.ASIN.Trim();
                            if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;

                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }
                        else
                        {
                            ASIN = "NP-" + d.ASIN.Trim();
                            if (d.Prime == null || d.Prime == "2")
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;

                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }

                        displayMinprice = Math.Round(finalprice - 45, 2);
                        displayMaxprice = Math.Round(finalprice + 30, 2);
                        if (displayMinprice <= 17.45)
                        {
                            displayMinprice = 17.45;
                        }

                        sb.AppendLine(string.Join("\t",
                                     string.Format(@"""{0}""", ASIN),
                                     string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
                                     string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
                                     string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
                                     string.Format(@"""{0}""", qty),
                                     string.Format(@"""{0}""", "4")));


                        if (shortcode == "ED")
                        {

                            d.Account1_ReExport = reExportChange;
                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_" + foldername + "_ED_" + fcountSport + "";
                            d.Account1_FileName = cname;

                        }
                        else if (shortcode == "EM")
                        {

                            d.Account2_ReExport = reExportChange;
                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_" + foldername + "_EM_" + fcountSport + "";
                            d.Account2_FileName = cname;
                        }
                        else if (shortcode == "DI")
                        {

                            d.Account4_ReExport = reExportChange;
                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_" + foldername + "_DI_" + fcountSport + "";
                            d.Account4_FileName = cname;
                        }


                        d.ReExportFilename = cname;
                        fname = d.ReExportFilename + ".txt";
                        // d.ForceExport = 0;/
                        d.ReExportTimeStamp = DateTime.Now;
                        d.ReExportStatus = 1;
                        d.UpdatedSalesPriceTimeStamp = null;
                        ukdb.SaveChanges();



                    }
                    catch (Exception ex)
                    {
                        Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
                    }
                }


                fcountSport++;
                path = Generate(fname, sb, foldername);

            }
            else
            {
                path = Generate("Blank", sb, foldername);
            }

            return path;



        }
        public string ReExportCanada(string foldername, IEnumerable<dynamic> data, string shortcode, int flag)
        {

            ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

            string fname = "";
            string path = "";
            string cname = "";


            StringWriter st = new StringWriter();

            //string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
            string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);


            if (data != null && data.Count() != 0)
            {
                foreach (var d in data)
                {

                    try
                    {
                        string ASIN;
                        double price = 0;
                        double pricemin = 0.00;
                        double finalprice;
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
                            double minval = 0.00;

                            if (price > 0 && price <= 19.99)
                            {
                                pricemin = 92.99;
                            }
                            else if (price > 19.99 && price <= 29.99)
                            {
                                pricemin = 120.99;
                            }
                            else if (price > 29.99 && price <= 39.99)
                            {
                                pricemin = 142.99;
                            }
                            else if (price > 39.99 && price <= 49.99)
                            {
                                pricemin = 168.99;
                            }
                            else if (price > 49.99 && price <= 59.99)
                            {
                                pricemin = 192.99;
                            }
                            else if (price > 59.99 && price <= 69.99)
                            {
                                pricemin = 222.99;
                            }
                            else if (price > 69.99 && price <= 79.99)
                            {
                                pricemin = 255.99;
                            }
                            else if (price > 79.99 && price <= 89.99)
                            {
                                pricemin = 285.99;
                            }
                            else if (price > 89.99 && price <= 99.99)
                            {
                                pricemin = 313.99;
                            }
                            else if (price > 99.99 && price <= 109.99)
                            {
                                pricemin = 327.99;
                            }
                            else if (price > 109.99 && price <= 119.99)
                            {
                                pricemin = 356.99;
                            }
                            else if (price > 119.99 && price <= 129.99)
                            {
                                pricemin = 385.99;
                            }
                            else if (price > 129.99 && price <= 139.99)
                            {
                                pricemin = 420.99;
                            }
                            else if (price > 139.99 && price <= 149.99)
                            {
                                pricemin = 442.99;
                            }
                            else if (price > 149.99 && price <= 159.99)
                            {
                                pricemin = 463.99;
                            }
                            else if (price > 159.99 && price <= 169.99)
                            {
                                pricemin = 485.99;
                            }
                            else if (price > 169.99 && price <= 179.99)
                            {
                                pricemin = 513.99;
                            }
                            else if (price > 179.99 && price <= 189.99)
                            {
                                pricemin = 542.99;
                            }
                            else if (price > 189.99 && price <= 199.99)
                            {
                                pricemin = 569.99;
                            }

                            finalprice = pricemin;

                        }
                        else
                        {
                            finalprice = 10.01;
                        }
                        string qty;
                        if (flag != 2)
                        {
                            ASIN = d.ASIN.Trim();
                            if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;
                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }
                        else
                        {
                            ASIN = "NP-" + d.ASIN.Trim();
                            if (d.Prime == null || d.Prime == "2")
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;
                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }
                        sb.AppendLine(string.Join("\t",
                                                  string.Format(@"""{0}""", ASIN),
                                                  string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
                                                  string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
                                                  string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
                                                  string.Format(@"""{0}""", qty),
                                                  string.Format(@"""{0}""", "4")));

                        d.Account3_ReExport = 1;
                        cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_" + foldername + "_DC_" + fcountSport + "";
                        d.Account3_FileName = cname;


                        d.ReExportFilename = cname;
                        fname = d.ReExportFilename + ".txt";

                        d.ReExportTimeStamp = DateTime.Now;
                        d.ReExportStatus = 1;
                        d.UpdatedSalesPriceTimeStamp = null;
                        ukdb.SaveChanges();



                    }
                    catch (Exception ex)
                    {
                        Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);

                    }
                }

                fcountSport++;
                path = Generate(fname, sb, foldername);

            }
            else
            {
                path = Generate("Blank", sb, foldername);
            }

            return path;


        }


        //public string Sports(string foldername, IEnumerable<dynamic> data, string shortcode)
        //{
        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{

        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    // string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";

        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);


        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {
        //                //   string delData = "";
        //                int reExportChange = 1;
        //                double price = 0;
        //                // double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                double displayMinprice;
        //                double displayMaxprice;
        //                //if (d.UK_Prohibited == 1)
        //                //{
        //                //    delData = "X";
        //                //    reExportChange = 2;
        //                //}

        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.SalesPrice);
        //                }

        //                if (price != 0)
        //                {

        //                    double minval = 49.99;
        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = minval;
        //                    }
        //                    else
        //                    {
        //                        for (double i = 20; i < 500; i += 10)
        //                        {
        //                            minval = minval + 10;
        //                            double temp = i + 10;
        //                            if (price >= i && price < temp)
        //                            {
        //                                pricemin = minval;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    finalprice = pricemin;

        //                }
        //                else
        //                {
        //                    finalprice = 17.45;
        //                }

        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;

        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }


        //                displayMinprice = Math.Round(finalprice - 45, 2);
        //                displayMaxprice = Math.Round(finalprice + 30, 2);
        //                if (displayMinprice <= 17.45)
        //                {
        //                    displayMinprice = 17.45;
        //                }


        //                //sb.AppendLine(string.Join("\t",
        //                //               string.Format(@"""{0}""", d.ASIN.Trim()),
        //                //               string.Format(@"""{0}""", ""),
        //                //               string.Format(@"""{0}""", ""),
        //                //               string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                //               string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                //               string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                //               string.Format(@"""{0}""", "new"),
        //                //               string.Format(@"""{0}""", qty),
        //                //               string.Format(@"""{0}""", delData),
        //                //               string.Format(@"""{0}""", ""),
        //                //               string.Format(@"""{0}""", ""),
        //                //               string.Format(@"""{0}""", ""),
        //                //               string.Format(@"""{0}""", ""),
        //                //               string.Format(@"""{0}""", "")));



        //                sb.AppendLine(string.Join("\t",
        //                             string.Format(@"""{0}""", d.ASIN.Trim()),
        //                             string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                             string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                             string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                             string.Format(@"""{0}""", qty),
        //                             string.Format(@"""{0}""", "4")));


        //                if (shortcode == "ED")
        //                {
        //                    // d.Account1_ExportDate = DateTime.Now;
        //                    d.Account1_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Sports_ED_" + fcountSport + "";
        //                    d.Account1_FileName = cname;

        //                }
        //                else if (shortcode == "EM")
        //                {
        //                    // d.Account2_ExportDate = DateTime.Now;
        //                    d.Account2_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Sports_EM_" + fcountSport + "";
        //                    d.Account2_FileName = cname;
        //                }
        //                else if (shortcode == "DI")
        //                {
        //                    //  d.Account4_ExportDate = DateTime.Now;
        //                    d.Account4_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Sports_DI_" + fcountSport + "";
        //                    d.Account4_FileName = cname;
        //                }


        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                // d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();



        //            }
        //            catch (Exception ex)
        //            {
        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }
        //       // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);

        //        fcountSport++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;

        //    //  }

        //}
        //public string SportsCanada(string foldername, IEnumerable<tbl_Sports> data, string shortcode)
        //{
        //    using (TransactionScope transaction = new TransactionScope())
        //    {


        //        ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //        string fname = "";
        //        string path = "";
        //        string cname = "";


        //        StringWriter st = new StringWriter();

        //        //string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //        string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";

        //        StringBuilder sb = new StringBuilder();
        //        sb.AppendLine(header);


        //        if (data != null && data.Count() != 0)
        //        {
        //            foreach (var d in data)
        //            {
        //                //Nullable<double> price;
        //                try
        //                {
        //                    double price = 0;
        //                    string delData = "";
        //                    //  int reExportChange = 1;
        //                    double pricemin = 0.00;
        //                    double finalprice;
        //                    if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.UpdatedSalesPrice);
        //                    }
        //                    else if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                    if (price != 0)
        //                    {
        //                        double minval = 0.00;

        //                        if (price > 0 && price <= 19.99)
        //                        {
        //                            pricemin = 92.99;
        //                        }
        //                        else if (price > 19.99 && price <= 29.99)
        //                        {
        //                            pricemin = 120.99;
        //                        }
        //                        else if (price > 29.99 && price <= 39.99)
        //                        {
        //                            pricemin = 142.99;
        //                        }
        //                        else if (price > 39.99 && price <= 49.99)
        //                        {
        //                            pricemin = 168.99;
        //                        }
        //                        else if (price > 49.99 && price <= 59.99)
        //                        {
        //                            pricemin = 192.99;
        //                        }
        //                        else if (price > 59.99 && price <= 69.99)
        //                        {
        //                            pricemin = 222.99;
        //                        }
        //                        else if (price > 69.99 && price <= 79.99)
        //                        {
        //                            pricemin = 255.99;
        //                        }
        //                        else if (price > 79.99 && price <= 89.99)
        //                        {
        //                            pricemin = 285.99;
        //                        }
        //                        else if (price > 89.99 && price <= 99.99)
        //                        {
        //                            pricemin = 313.99;
        //                        }
        //                        else if (price > 99.99 && price <= 109.99)
        //                        {
        //                            pricemin = 327.99;
        //                        }
        //                        else if (price > 109.99 && price <= 119.99)
        //                        {
        //                            pricemin = 356.99;
        //                        }
        //                        else if (price > 119.99 && price <= 129.99)
        //                        {
        //                            pricemin = 385.99;
        //                        }
        //                        else if (price > 129.99 && price <= 139.99)
        //                        {
        //                            pricemin = 420.99;
        //                        }
        //                        else if (price > 139.99 && price <= 149.99)
        //                        {
        //                            pricemin = 442.99;
        //                        }
        //                        else if (price > 149.99 && price <= 159.99)
        //                        {
        //                            pricemin = 463.99;
        //                        }
        //                        else if (price > 159.99 && price <= 169.99)
        //                        {
        //                            pricemin = 485.99;
        //                        }
        //                        else if (price > 169.99 && price <= 179.99)
        //                        {
        //                            pricemin = 513.99;
        //                        }
        //                        else if (price > 179.99 && price <= 189.99)
        //                        {
        //                            pricemin = 542.99;
        //                        }
        //                        else if (price > 189.99 && price <= 199.99)
        //                        {
        //                            pricemin = 569.99;
        //                        }

        //                        finalprice = pricemin;

        //                    }
        //                    else
        //                    {
        //                        finalprice = 10.01;
        //                    }

        //                    string qty;
        //                    if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                    {
        //                        qty = "0";
        //                        d.Instock = 0;
        //                        d.Qty = 0;
        //                    }
        //                    else
        //                    {
        //                        qty = "3";
        //                        d.Instock = 3;
        //                        d.Qty = 3;
        //                    }

        //                    sb.AppendLine(string.Join("\t",
        //                                              string.Format(@"""{0}""", d.ASIN.Trim()),
        //                                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
        //                                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
        //                                              string.Format(@"""{0}""", qty),
        //                                              string.Format(@"""{0}""", "4")));


        //                    if (shortcode == "DC")
        //                    {
        //                        //  d.Account3_ExportDate = DateTime.Now;
        //                        d.Account3_ReExport = 1;
        //                        cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Sports_DC_" + fcountSport + "";
        //                        d.Account3_FileName = cname;
        //                    }

        //                    d.ReExportFilename = cname;
        //                    fname = d.ReExportFilename + ".txt";
        //                    //    d.ForceExport = 0;
        //                    d.ReExportTimeStamp = DateTime.Now;
        //                    d.ReExportStatus = 1;
        //                    d.UpdatedSalesPriceTimeStamp = null;
        //                    ukdb.SaveChanges();



        //                }
        //                catch (Exception ex)
        //                {
        //                    Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);

        //                }
        //            }
        //            // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //            fcountSport++;
        //            path = Generate(fname, sb, foldername);

        //        }
        //        else
        //        {
        //            path = Generate("Blank", sb, foldername);
        //        }
        //        //if (path != "failed" && (!path.Contains("Blank")))
        //        //{
        //        //    transaction.Complete();
        //        //    ukdb.ObjectContext().AcceptAllChanges();
        //        //}
        //        return path;

        //    }
        //}
        //public string Toys(string foldername, IEnumerable<tbl_Toys> data, string shortcode)
        //{
        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;
        //    string fname = "";
        //    string path = "";
        //    string cname = "";
        //    StringWriter st = new StringWriter();
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    // string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";


        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);


        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {
        //                // string delData = "";
        //                int reExportChange = 1;
        //                double price = 0;
        //                //double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                double displayMinprice;
        //                double displayMaxprice;
        //                //if (d.UK_Prohibited == 1)
        //                //{
        //                //    delData = "X";
        //                //    reExportChange = 2;
        //                //}

        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.SalesPrice);
        //                }

        //                if (price != 0)
        //                {

        //                    double minval = 49.99;
        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = minval;
        //                    }
        //                    else
        //                    {
        //                        for (double i = 20; i < 500; i += 10)
        //                        {
        //                            minval = minval + 10;
        //                            double temp = i + 10;
        //                            if (price >= i && price < temp)
        //                            {
        //                                pricemin = minval;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    finalprice = pricemin;

        //                }
        //                else
        //                {
        //                    finalprice = 17.45;
        //                }

        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }

        //                displayMinprice = Math.Round(finalprice - 45, 2);
        //                displayMaxprice = Math.Round(finalprice + 30, 2);
        //                if (displayMinprice <= 17.45)
        //                {
        //                    displayMinprice = 17.45;
        //                }
        //                //sb.AppendLine(string.Join("\t",
        //                //              string.Format(@"""{0}""", d.ASIN.Trim()),
        //                //              string.Format(@"""{0}""", ""),
        //                //              string.Format(@"""{0}""", ""),
        //                //              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                //              string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                //              string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                //              string.Format(@"""{0}""", "new"),
        //                //              string.Format(@"""{0}""", qty),
        //                //              string.Format(@"""{0}""", delData),
        //                //              string.Format(@"""{0}""", ""),
        //                //              string.Format(@"""{0}""", ""),
        //                //              string.Format(@"""{0}""", ""),
        //                //              string.Format(@"""{0}""", ""),
        //                //              string.Format(@"""{0}""", "")));


        //                sb.AppendLine(string.Join("\t",
        //                     string.Format(@"""{0}""", d.ASIN.Trim()),
        //                     string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                     string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                     string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                     string.Format(@"""{0}""", qty),
        //                     string.Format(@"""{0}""", "4")));


        //                if (shortcode == "ED")
        //                {
        //                    //  d.Account1_ExportDate = DateTime.Now;
        //                    d.Account1_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Toys_ED_" + fcountToys + "";
        //                    d.Account1_FileName = cname;

        //                }
        //                else
        //                    if (shortcode == "EM")
        //                    {
        //                        //     d.Account2_ExportDate = DateTime.Now;
        //                        d.Account2_ReExport = reExportChange;
        //                        cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Toys_EM_" + fcountToys + "";
        //                        d.Account2_FileName = cname;
        //                    }
        //                    else
        //                        if (shortcode == "DI")
        //                        {
        //                            //  d.Account4_ExportDate = DateTime.Now;
        //                            d.Account4_ReExport = reExportChange;
        //                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Toys_DI_" + fcountToys + "";
        //                            d.Account4_FileName = cname;
        //                        }

        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                //  d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }
        //        //  ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountToys++;
        //        path = Generate(fname, sb, foldername);
        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    //   }
        //}
        //public string ToysCanada(string foldername, IEnumerable<tbl_Toys> data, string shortcode)
        //{
        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);


        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;

        //            try
        //            {
        //                double price = 0;
        //                double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {
        //                    double minval = 0.00;

        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = 92.99;
        //                    }
        //                    else if (price > 19.99 && price <= 29.99)
        //                    {
        //                        pricemin = 120.99;
        //                    }
        //                    else if (price > 29.99 && price <= 39.99)
        //                    {
        //                        pricemin = 142.99;
        //                    }
        //                    else if (price > 39.99 && price <= 49.99)
        //                    {
        //                        pricemin = 168.99;
        //                    }
        //                    else if (price > 49.99 && price <= 59.99)
        //                    {
        //                        pricemin = 192.99;
        //                    }
        //                    else if (price > 59.99 && price <= 69.99)
        //                    {
        //                        pricemin = 222.99;
        //                    }
        //                    else if (price > 69.99 && price <= 79.99)
        //                    {
        //                        pricemin = 255.99;
        //                    }
        //                    else if (price > 79.99 && price <= 89.99)
        //                    {
        //                        pricemin = 285.99;
        //                    }
        //                    else if (price > 89.99 && price <= 99.99)
        //                    {
        //                        pricemin = 313.99;
        //                    }
        //                    else if (price > 99.99 && price <= 109.99)
        //                    {
        //                        pricemin = 327.99;
        //                    }
        //                    else if (price > 109.99 && price <= 119.99)
        //                    {
        //                        pricemin = 356.99;
        //                    }
        //                    else if (price > 119.99 && price <= 129.99)
        //                    {
        //                        pricemin = 385.99;
        //                    }
        //                    else if (price > 129.99 && price <= 139.99)
        //                    {
        //                        pricemin = 420.99;
        //                    }
        //                    else if (price > 139.99 && price <= 149.99)
        //                    {
        //                        pricemin = 442.99;
        //                    }
        //                    else if (price > 149.99 && price <= 159.99)
        //                    {
        //                        pricemin = 463.99;
        //                    }
        //                    else if (price > 159.99 && price <= 169.99)
        //                    {
        //                        pricemin = 485.99;
        //                    }
        //                    else if (price > 169.99 && price <= 179.99)
        //                    {
        //                        pricemin = 513.99;
        //                    }
        //                    else if (price > 179.99 && price <= 189.99)
        //                    {
        //                        pricemin = 542.99;
        //                    }
        //                    else if (price > 189.99 && price <= 199.99)
        //                    {
        //                        pricemin = 569.99;
        //                    }

        //                    finalprice = pricemin;


        //                }
        //                else
        //                {
        //                    finalprice = 10.01;
        //                }



        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }

        //                sb.AppendLine(string.Join("\t",
        //                              string.Format(@"""{0}""", d.ASIN.Trim()),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
        //                              string.Format(@"""{0}""", qty),
        //                              string.Format(@"""{0}""", "4")));

        //                if (shortcode == "DC")
        //                {
        //                    //      d.Account3_ExportDate = DateTime.Now;
        //                    d.Account3_ReExport = 1;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Toys_DC_" + fcountToys + "";
        //                    d.Account3_FileName = cname;
        //                }

        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                //  d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();

        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }
        //        // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountToys++;
        //        path = Generate(fname, sb, foldername);
        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    // }
        //}
        //public string Beauty(string foldername, IEnumerable<tbl_Beauty> data, string shortcode)
        //{

        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";

        //    StringWriter st = new StringWriter();
        //    // string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {

        //                //string delData = "";
        //                int reExportChange = 1;
        //                double price = 0;
        //                //double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                double displayMinprice;
        //                double displayMaxprice;
        //                //if (d.UK_Prohibited == 1)
        //                //{
        //                //    delData = "X";
        //                //    reExportChange = 2;
        //                //}

        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {

        //                    double minval = 49.99;
        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = minval;
        //                    }
        //                    else
        //                    {
        //                        for (double i = 20; i < 500; i += 10)
        //                        {
        //                            minval = minval + 10;
        //                            double temp = i + 10;
        //                            if (price >= i && price < temp)
        //                            {
        //                                pricemin = minval;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    finalprice = pricemin;

        //                }
        //                else
        //                {
        //                    finalprice = 17.45;
        //                }


        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }


        //                displayMinprice = Math.Round(finalprice - 45, 2);
        //                displayMaxprice = Math.Round(finalprice + 30, 2);
        //                if (displayMinprice <= 17.45)
        //                {
        //                    displayMinprice = 17.45;
        //                }

        //                //sb.AppendLine(string.Join("\t",
        //                //                   string.Format(@"""{0}""", d.ASIN.Trim()),
        //                //                   string.Format(@"""{0}""", ""),
        //                //                   string.Format(@"""{0}""", ""),
        //                //                   string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                //                   string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                //                   string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                //                   string.Format(@"""{0}""", "new"),
        //                //                   string.Format(@"""{0}""", qty),
        //                //                   string.Format(@"""{0}""", delData),
        //                //                   string.Format(@"""{0}""", ""),
        //                //                   string.Format(@"""{0}""", ""),
        //                //                   string.Format(@"""{0}""", ""),
        //                //                   string.Format(@"""{0}""", ""),
        //                //                   string.Format(@"""{0}""", "")));

        //                sb.AppendLine(string.Join("\t",
        //                     string.Format(@"""{0}""", d.ASIN.Trim()),
        //                     string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                     string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                     string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                     string.Format(@"""{0}""", qty),
        //                     string.Format(@"""{0}""", "4")));

        //                if (shortcode == "ED")
        //                {
        //                    //  d.Account1_ExportDate = DateTime.Now;
        //                    d.Account1_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Beauty_ED_" + fcountBeauty + "";
        //                    d.Account1_FileName = cname;

        //                }
        //                else
        //                    if (shortcode == "EM")
        //                    {
        //                        //     d.Account2_ExportDate = DateTime.Now;
        //                        d.Account2_ReExport = reExportChange;
        //                        cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Beauty_EM_" + fcountBeauty + "";
        //                        d.Account2_FileName = cname;
        //                    }
        //                    else
        //                        if (shortcode == "DI")
        //                        {
        //                            //      d.Account4_ExportDate = DateTime.Now;
        //                            d.Account4_ReExport = reExportChange;
        //                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Beauty_DI_" + fcountBeauty + "";
        //                            d.Account4_FileName = cname;
        //                        }


        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                //    d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }
        //        //ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountBeauty++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    //}
        //}
        //public string BeautyCanada(string foldername, IEnumerable<tbl_Beauty> data, string shortcode)
        //{

        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{

        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";

        //    StringWriter st = new StringWriter();
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {
        //                double price = 0;
        //                double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {
        //                    double minval = 0.00;

        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = 92.99;
        //                    }
        //                    else if (price > 19.99 && price <= 29.99)
        //                    {
        //                        pricemin = 120.99;
        //                    }
        //                    else if (price > 29.99 && price <= 39.99)
        //                    {
        //                        pricemin = 142.99;
        //                    }
        //                    else if (price > 39.99 && price <= 49.99)
        //                    {
        //                        pricemin = 168.99;
        //                    }
        //                    else if (price > 49.99 && price <= 59.99)
        //                    {
        //                        pricemin = 192.99;
        //                    }
        //                    else if (price > 59.99 && price <= 69.99)
        //                    {
        //                        pricemin = 222.99;
        //                    }
        //                    else if (price > 69.99 && price <= 79.99)
        //                    {
        //                        pricemin = 255.99;
        //                    }
        //                    else if (price > 79.99 && price <= 89.99)
        //                    {
        //                        pricemin = 285.99;
        //                    }
        //                    else if (price > 89.99 && price <= 99.99)
        //                    {
        //                        pricemin = 313.99;
        //                    }
        //                    else if (price > 99.99 && price <= 109.99)
        //                    {
        //                        pricemin = 327.99;
        //                    }
        //                    else if (price > 109.99 && price <= 119.99)
        //                    {
        //                        pricemin = 356.99;
        //                    }
        //                    else if (price > 119.99 && price <= 129.99)
        //                    {
        //                        pricemin = 385.99;
        //                    }
        //                    else if (price > 129.99 && price <= 139.99)
        //                    {
        //                        pricemin = 420.99;
        //                    }
        //                    else if (price > 139.99 && price <= 149.99)
        //                    {
        //                        pricemin = 442.99;
        //                    }
        //                    else if (price > 149.99 && price <= 159.99)
        //                    {
        //                        pricemin = 463.99;
        //                    }
        //                    else if (price > 159.99 && price <= 169.99)
        //                    {
        //                        pricemin = 485.99;
        //                    }
        //                    else if (price > 169.99 && price <= 179.99)
        //                    {
        //                        pricemin = 513.99;
        //                    }
        //                    else if (price > 179.99 && price <= 189.99)
        //                    {
        //                        pricemin = 542.99;
        //                    }
        //                    else if (price > 189.99 && price <= 199.99)
        //                    {
        //                        pricemin = 569.99;
        //                    }

        //                    finalprice = pricemin;


        //                }
        //                else
        //                {
        //                    finalprice = 10.01;
        //                }


        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }



        //                sb.AppendLine(string.Join("\t",
        //                              string.Format(@"""{0}""", d.ASIN.Trim()),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
        //                              string.Format(@"""{0}""", qty),
        //                              string.Format(@"""{0}""", "4")));

        //                if (shortcode == "DC")
        //                {
        //                    //     d.Account3_ExportDate = DateTime.Now;
        //                    d.Account3_ReExport = 1;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Beauty_DC_" + fcountBeauty + "";
        //                    d.Account3_FileName = cname;
        //                }

        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";

        //                //    d.ForceExport = 0;

        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }
        //        // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountBeauty++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    //  }
        //}
        //public string Baby(string foldername, IEnumerable<tbl_Baby> data, string shortcode)
        //{
        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    //  string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {

        //                // string delData = "";
        //                int reExportChange = 1;
        //                double price = 0;
        //                // double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                double displayMinprice;
        //                double displayMaxprice;
        //                //if (d.UK_Prohibited == 1)
        //                //{
        //                //    delData = "X";
        //                //    reExportChange = 2;
        //                //}
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {

        //                    double minval = 49.99;
        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = minval;
        //                    }
        //                    else
        //                    {
        //                        for (double i = 20; i < 500; i += 10)
        //                        {
        //                            minval = minval + 10;
        //                            double temp = i + 10;
        //                            if (price >= i && price < temp)
        //                            {
        //                                pricemin = minval;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    finalprice = pricemin;

        //                }
        //                else
        //                {
        //                    finalprice = 17.45;
        //                }



        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }

        //                displayMinprice = Math.Round(finalprice - 45, 2);
        //                displayMaxprice = Math.Round(finalprice + 30, 2);
        //                if (displayMinprice <= 17.45)
        //                {
        //                    displayMinprice = 17.45;
        //                }
        //                //sb.AppendLine(string.Join("\t",
        //                //                string.Format(@"""{0}""", d.ASIN.Trim()),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                //                string.Format(@"""{0}""", "new"),
        //                //                string.Format(@"""{0}""", qty),
        //                //                string.Format(@"""{0}""", delData),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", "")));

        //                sb.AppendLine(string.Join("\t",
        //             string.Format(@"""{0}""", d.ASIN.Trim()),
        //             string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //             string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //             string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //             string.Format(@"""{0}""", qty),
        //             string.Format(@"""{0}""", "4")));

        //                if (shortcode == "ED")
        //                {
        //                    //                      d.Account1_ExportDate = DateTime.Now;
        //                    d.Account1_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Baby_ED_" + fcountBaby + "";
        //                    d.Account1_FileName = cname;

        //                }
        //                else
        //                    if (shortcode == "EM")
        //                    {
        //                        //                        d.Account2_ExportDate = DateTime.Now;
        //                        d.Account2_ReExport = reExportChange;
        //                        cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Baby_EM_" + fcountBaby + "";
        //                        d.Account2_FileName = cname;
        //                    }
        //                    else
        //                        if (shortcode == "DI")
        //                        {
        //                            //                       d.Account4_ExportDate = DateTime.Now;
        //                            d.Account4_ReExport = reExportChange;
        //                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Baby_DI_" + fcountBaby + "";
        //                            d.Account4_FileName = cname;
        //                        }

        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                //d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }

        //        // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountBaby++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    //  }
        //}
        //public string BabyCanada(string foldername, IEnumerable<tbl_Baby> data, string shortcode)
        //{
        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {
        //                double price = 0;
        //                double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {
        //                    double minval = 0.00;

        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = 92.99;
        //                    }
        //                    else if (price > 19.99 && price <= 29.99)
        //                    {
        //                        pricemin = 120.99;
        //                    }
        //                    else if (price > 29.99 && price <= 39.99)
        //                    {
        //                        pricemin = 142.99;
        //                    }
        //                    else if (price > 39.99 && price <= 49.99)
        //                    {
        //                        pricemin = 168.99;
        //                    }
        //                    else if (price > 49.99 && price <= 59.99)
        //                    {
        //                        pricemin = 192.99;
        //                    }
        //                    else if (price > 59.99 && price <= 69.99)
        //                    {
        //                        pricemin = 222.99;
        //                    }
        //                    else if (price > 69.99 && price <= 79.99)
        //                    {
        //                        pricemin = 255.99;
        //                    }
        //                    else if (price > 79.99 && price <= 89.99)
        //                    {
        //                        pricemin = 285.99;
        //                    }
        //                    else if (price > 89.99 && price <= 99.99)
        //                    {
        //                        pricemin = 313.99;
        //                    }
        //                    else if (price > 99.99 && price <= 109.99)
        //                    {
        //                        pricemin = 327.99;
        //                    }
        //                    else if (price > 109.99 && price <= 119.99)
        //                    {
        //                        pricemin = 356.99;
        //                    }
        //                    else if (price > 119.99 && price <= 129.99)
        //                    {
        //                        pricemin = 385.99;
        //                    }
        //                    else if (price > 129.99 && price <= 139.99)
        //                    {
        //                        pricemin = 420.99;
        //                    }
        //                    else if (price > 139.99 && price <= 149.99)
        //                    {
        //                        pricemin = 442.99;
        //                    }
        //                    else if (price > 149.99 && price <= 159.99)
        //                    {
        //                        pricemin = 463.99;
        //                    }
        //                    else if (price > 159.99 && price <= 169.99)
        //                    {
        //                        pricemin = 485.99;
        //                    }
        //                    else if (price > 169.99 && price <= 179.99)
        //                    {
        //                        pricemin = 513.99;
        //                    }
        //                    else if (price > 179.99 && price <= 189.99)
        //                    {
        //                        pricemin = 542.99;
        //                    }
        //                    else if (price > 189.99 && price <= 199.99)
        //                    {
        //                        pricemin = 569.99;
        //                    }

        //                    finalprice = pricemin;


        //                }
        //                else
        //                {
        //                    finalprice = 10.01;
        //                }


        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }

        //                sb.AppendLine(string.Join("\t",
        //                              string.Format(@"""{0}""", d.ASIN.Trim()),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
        //                              string.Format(@"""{0}""", qty),
        //                              string.Format(@"""{0}""", "4")));


        //                if (shortcode == "DC")
        //                {
        //                    //              d.Account3_ExportDate = DateTime.Now;
        //                    d.Account3_ReExport = 1;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Baby_DC_" + fcountBaby + "";
        //                    d.Account3_FileName = cname;
        //                }

        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";

        //                // d.ForceExport = 0;

        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }

        //        //ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountBaby++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    //  }
        //}
        //public string Watches(string foldername, IEnumerable<tbl_Watches> data, string shortcode)
        //{

        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{

        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    //string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {

        //                // string delData = "";
        //                int reExportChange = 1;
        //                double price = 0;
        //                //  double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                double displayMinprice;
        //                double displayMaxprice;
        //                //if (d.UK_Prohibited == 1)
        //                //{
        //                //    delData = "X";
        //                //    reExportChange = 2;
        //                //}
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {

        //                    double minval = 49.99;
        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = minval;
        //                    }
        //                    else
        //                    {
        //                        for (double i = 20; i < 500; i += 10)
        //                        {
        //                            minval = minval + 10;
        //                            double temp = i + 10;
        //                            if (price >= i && price < temp)
        //                            {
        //                                pricemin = minval;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    finalprice = pricemin;

        //                }
        //                else
        //                {
        //                    finalprice = 17.45;
        //                }


        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }


        //                displayMinprice = Math.Round(finalprice - 45, 2);
        //                displayMaxprice = Math.Round(finalprice + 30, 2);
        //                if (displayMinprice <= 17.45)
        //                {
        //                    displayMinprice = 17.45;
        //                }

        //                //sb.AppendLine(string.Join("\t",
        //                //                string.Format(@"""{0}""", d.ASIN.Trim()),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                //                string.Format(@"""{0}""", "new"),
        //                //                string.Format(@"""{0}""", qty),
        //                //                string.Format(@"""{0}""", delData),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", "")));


        //                sb.AppendLine(string.Join("\t",
        //         string.Format(@"""{0}""", d.ASIN.Trim()),
        //         string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //         string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //         string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //         string.Format(@"""{0}""", qty),
        //         string.Format(@"""{0}""", "4")));

        //                if (shortcode == "ED")
        //                {
        //                    //  d.Account1_ExportDate = DateTime.Now;
        //                    d.Account1_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Watches_ED_" + fcountWatches + "";
        //                    d.Account1_FileName = cname;

        //                }
        //                else
        //                    if (shortcode == "EM")
        //                    {
        //                        //                d.Account2_ExportDate = DateTime.Now;
        //                        d.Account2_ReExport = reExportChange;
        //                        cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Watches_EM_" + fcountWatches + "";
        //                        d.Account2_FileName = cname;
        //                    }
        //                    else
        //                        if (shortcode == "DI")
        //                        {
        //                            //                    d.Account4_ExportDate = DateTime.Now;
        //                            d.Account4_ReExport = reExportChange;
        //                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Watches_DI_" + fcountWatches + "";
        //                            d.Account4_FileName = cname;
        //                        }


        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                //  d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }

        //        // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountWatches++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    //   }
        //}
        //public string WatchesCanada(string foldername, IEnumerable<tbl_Watches> data, string shortcode)
        //{

        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {
        //                double price = 0;
        //                double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {
        //                    double minval = 0.00;

        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = 92.99;
        //                    }
        //                    else if (price > 19.99 && price <= 29.99)
        //                    {
        //                        pricemin = 120.99;
        //                    }
        //                    else if (price > 29.99 && price <= 39.99)
        //                    {
        //                        pricemin = 142.99;
        //                    }
        //                    else if (price > 39.99 && price <= 49.99)
        //                    {
        //                        pricemin = 168.99;
        //                    }
        //                    else if (price > 49.99 && price <= 59.99)
        //                    {
        //                        pricemin = 192.99;
        //                    }
        //                    else if (price > 59.99 && price <= 69.99)
        //                    {
        //                        pricemin = 222.99;
        //                    }
        //                    else if (price > 69.99 && price <= 79.99)
        //                    {
        //                        pricemin = 255.99;
        //                    }
        //                    else if (price > 79.99 && price <= 89.99)
        //                    {
        //                        pricemin = 285.99;
        //                    }
        //                    else if (price > 89.99 && price <= 99.99)
        //                    {
        //                        pricemin = 313.99;
        //                    }
        //                    else if (price > 99.99 && price <= 109.99)
        //                    {
        //                        pricemin = 327.99;
        //                    }
        //                    else if (price > 109.99 && price <= 119.99)
        //                    {
        //                        pricemin = 356.99;
        //                    }
        //                    else if (price > 119.99 && price <= 129.99)
        //                    {
        //                        pricemin = 385.99;
        //                    }
        //                    else if (price > 129.99 && price <= 139.99)
        //                    {
        //                        pricemin = 420.99;
        //                    }
        //                    else if (price > 139.99 && price <= 149.99)
        //                    {
        //                        pricemin = 442.99;
        //                    }
        //                    else if (price > 149.99 && price <= 159.99)
        //                    {
        //                        pricemin = 463.99;
        //                    }
        //                    else if (price > 159.99 && price <= 169.99)
        //                    {
        //                        pricemin = 485.99;
        //                    }
        //                    else if (price > 169.99 && price <= 179.99)
        //                    {
        //                        pricemin = 513.99;
        //                    }
        //                    else if (price > 179.99 && price <= 189.99)
        //                    {
        //                        pricemin = 542.99;
        //                    }
        //                    else if (price > 189.99 && price <= 199.99)
        //                    {
        //                        pricemin = 569.99;
        //                    }

        //                    finalprice = pricemin;


        //                }
        //                else
        //                {
        //                    finalprice = 10.01;
        //                }

        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }


        //                sb.AppendLine(string.Join("\t",
        //                              string.Format(@"""{0}""", d.ASIN.Trim()),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
        //                              string.Format(@"""{0}""", qty),
        //                              string.Format(@"""{0}""", "4")));


        //                if (shortcode == "DC")
        //                {
        //                    //                 d.Account3_ExportDate = DateTime.Now;
        //                    d.Account3_ReExport = 1;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Watches_DC_" + fcountWatches + "";
        //                    d.Account3_FileName = cname;
        //                }

        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                //   d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }

        //        // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountWatches++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    //  }
        //}
        //public string Jewelry(string foldername, IEnumerable<tbl_Jewellery> data, string shortcode)
        //{

        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    //string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {

        //                //  string delData = "";
        //                int reExportChange = 1;
        //                double price = 0;
        //                //  double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                double displayMinprice;
        //                double displayMaxprice;
        //                //if (d.UK_Prohibited == 1)
        //                //{
        //                //    delData = "X";
        //                //    reExportChange = 2;
        //                //}
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {

        //                    double minval = 49.99;
        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = minval;
        //                    }
        //                    else
        //                    {
        //                        for (double i = 20; i < 500; i += 10)
        //                        {
        //                            minval = minval + 10;
        //                            double temp = i + 10;
        //                            if (price >= i && price < temp)
        //                            {
        //                                pricemin = minval;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    finalprice = pricemin;

        //                }
        //                else
        //                {
        //                    finalprice = 17.45;
        //                }

        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }


        //                displayMinprice = Math.Round(finalprice - 45, 2);
        //                displayMaxprice = Math.Round(finalprice + 30, 2);
        //                if (displayMinprice <= 17.45)
        //                {
        //                    displayMinprice = 17.45;
        //                }
        //                //sb.AppendLine(string.Join("\t",
        //                //                string.Format(@"""{0}""", d.ASIN.Trim()),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //                //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //                //                string.Format(@"""{0}""", "new"),
        //                //                string.Format(@"""{0}""", qty),
        //                //                string.Format(@"""{0}""", delData),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", ""),
        //                //                string.Format(@"""{0}""", "")));


        //                sb.AppendLine(string.Join("\t",
        //      string.Format(@"""{0}""", d.ASIN.Trim()),
        //      string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //      string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
        //      string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
        //      string.Format(@"""{0}""", qty),
        //      string.Format(@"""{0}""", "4")));

        //                if (shortcode == "ED")
        //                {
        //                    //d.Account1_ExportDate = DateTime.Now;
        //                    d.Account1_ReExport = reExportChange;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Jewelry_ED_" + fcountJewelry + "";
        //                    d.Account1_FileName = cname;

        //                }
        //                else
        //                    if (shortcode == "EM")
        //                    {
        //                        // d.Account2_ExportDate = DateTime.Now;
        //                        d.Account2_ReExport = reExportChange;
        //                        cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Jewelry_EM_" + fcountJewelry + "";
        //                        d.Account2_FileName = cname;
        //                    }
        //                    else
        //                        if (shortcode == "DI")
        //                        {
        //                            //   d.Account4_ExportDate = DateTime.Now;
        //                            d.Account4_ReExport = reExportChange;
        //                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_Jewelry_DI_" + fcountJewelry + "";
        //                            d.Account4_FileName = cname;
        //                        }


        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";
        //                //    d.ForceExport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();

        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }

        //        // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
        //        fcountJewelry++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    // }
        //}
        //public string JewelryCanada(string foldername, IEnumerable<tbl_Jewellery> data, string shortcode)
        //{

        //    //using (TransactionScope transaction = new TransactionScope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;
        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //Nullable<double> price;
        //            try
        //            {
        //                double price = 0;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                if (d.UpdatedSalesPrice != null && d.UpdatedSalesPrice != "Too low to display")
        //                {
        //                    price = double.Parse(d.UpdatedSalesPrice);
        //                }
        //                else
        //                    if (d.SalesPrice != null && d.SalesPrice != "Too low to display")
        //                    {
        //                        price = double.Parse(d.SalesPrice);
        //                    }

        //                if (price != 0)
        //                {
        //                    //double minval = 0.00;

        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = 92.99;
        //                    }
        //                    else if (price > 19.99 && price <= 29.99)
        //                    {
        //                        pricemin = 120.99;
        //                    }
        //                    else if (price > 29.99 && price <= 39.99)
        //                    {
        //                        pricemin = 142.99;
        //                    }
        //                    else if (price > 39.99 && price <= 49.99)
        //                    {
        //                        pricemin = 168.99;
        //                    }
        //                    else if (price > 49.99 && price <= 59.99)
        //                    {
        //                        pricemin = 192.99;
        //                    }
        //                    else if (price > 59.99 && price <= 69.99)
        //                    {
        //                        pricemin = 222.99;
        //                    }
        //                    else if (price > 69.99 && price <= 79.99)
        //                    {
        //                        pricemin = 255.99;
        //                    }
        //                    else if (price > 79.99 && price <= 89.99)
        //                    {
        //                        pricemin = 285.99;
        //                    }
        //                    else if (price > 89.99 && price <= 99.99)
        //                    {
        //                        pricemin = 313.99;
        //                    }
        //                    else if (price > 99.99 && price <= 109.99)
        //                    {
        //                        pricemin = 327.99;
        //                    }
        //                    else if (price > 109.99 && price <= 119.99)
        //                    {
        //                        pricemin = 356.99;
        //                    }
        //                    else if (price > 119.99 && price <= 129.99)
        //                    {
        //                        pricemin = 385.99;
        //                    }
        //                    else if (price > 129.99 && price <= 139.99)
        //                    {
        //                        pricemin = 420.99;
        //                    }
        //                    else if (price > 139.99 && price <= 149.99)
        //                    {
        //                        pricemin = 442.99;
        //                    }
        //                    else if (price > 149.99 && price <= 159.99)
        //                    {
        //                        pricemin = 463.99;
        //                    }
        //                    else if (price > 159.99 && price <= 169.99)
        //                    {
        //                        pricemin = 485.99;
        //                    }
        //                    else if (price > 169.99 && price <= 179.99)
        //                    {
        //                        pricemin = 513.99;
        //                    }
        //                    else if (price > 179.99 && price <= 189.99)
        //                    {
        //                        pricemin = 542.99;
        //                    }
        //                    else if (price > 189.99 && price <= 199.99)
        //                    {
        //                        pricemin = 569.99;
        //                    }
        //                    finalprice = pricemin;


        //                }
        //                else
        //                {
        //                    finalprice = 10.01;
        //                }

        //                string qty;
        //                if (d.Prime == "0" || d.Prime == null || d.Prime == "2")
        //                {
        //                    qty = "0";
        //                    d.Instock = 0;
        //                    d.Qty = 0;
        //                }
        //                else
        //                {
        //                    qty = "3";
        //                    d.Instock = 3;
        //                    d.Qty = 3;
        //                }

        //                sb.AppendLine(string.Join("\t",
        //                              string.Format(@"""{0}""", d.ASIN.Trim()),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
        //                              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
        //                              string.Format(@"""{0}""", qty),
        //                              string.Format(@"""{0}""", "4")));


        //                if (shortcode == "DC")
        //                {
        //                    //      d.Account3_ExportDate = DateTime.Now;
        //                    d.Account3_ReExport = 1;
        //                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd") + "_UpdatePriceQTY_Jewelry_DC_" + fcountJewelry + "";
        //                    d.Account3_FileName = cname;
        //                }

        //                d.ReExportFilename = cname;
        //                fname = d.ReExportFilename + ".txt";

        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();


        //            }
        //            catch (Exception ex)
        //            {

        //                Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
        //            }
        //        }
        //        // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);

        //        fcountJewelry++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.Contains("Blank")))
        //    //{
        //    //    transaction.Complete();
        //    //    ukdb.ObjectContext().AcceptAllChanges();
        //    //}
        //    return path;
        //    // }
        //}

        //public string homeandkitchen(string foldername, IEnumerable<tbl_HomeandKitchen> data, string shortcode, int flag)
        //{

        //    //using (transactionscope transaction = new transactionscope())
        //    //{
        //    ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

        //    string fname = "";
        //    string path = "";
        //    string cname = "";


        //    StringWriter st = new StringWriter();
        //    //string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";
        //    string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine(header);

        //    if (data != null && data.Count() != 0)
        //    {
        //        foreach (var d in data)
        //        {
        //            //nullable<double> price;
        //            try
        //            {

        //                string ASIN;
        //                //  string deldata = "";

        //                Nullable<float> price = 0;
        //                // 
        //                double pricecal;
        //                double pricemin = 0.00;
        //                double finalprice;
        //                double displayminprice;
        //                double displaymaxprice;
        //                //if (d.uk_prohibited == 1)
        //                //{
        //                //    deldata = "x";
        //                //    reexportchange = 2;
        //                //}
        //                if (d.UpdatedSalesPrice != null)
        //                {
        //                    price = d.UpdatedSalesPrice;
        //                }
        //                else
        //                    if (d.SalesPrice != null)
        //                    {
        //                        price = d.SalesPrice;
        //                    }

        //                if (price != 0)
        //                {

        //                    double minval = 49.99;
        //                    if (price > 0 && price <= 19.99)
        //                    {
        //                        pricemin = minval;
        //                    }
        //                    else
        //                    {
        //                        for (double i = 20; i < 500; i += 10)
        //                        {
        //                            minval = minval + 10;
        //                            double temp = i + 10;
        //                            if (price >= i && price < temp)
        //                            {
        //                                pricemin = minval;
        //                                break;
        //                            }
        //                        }
        //                    }

        //                    finalprice = pricemin;

        //                }
        //                else
        //                {
        //                    finalprice = 17.45;
        //                }

        //                string qty;
        //                if (flag != 2)
        //                {
        //                    ASIN = d.ASIN.Trim();
        //                    if (d.Prime == 0 || d.Prime == null || d.Prime == 2)
        //                    {
        //                        qty = "0";
        //                        d.Instock = 0;
        //                        d.Qty = 0;
        //                    }
        //                    else
        //                    {
        //                        qty = "3";
        //                        d.Instock = 3;
        //                        d.Qty = 3;
        //                    }
        //                }
        //                else
        //                {
        //                    ASIN = "NP-" + d.ASIN.Trim();
        //                    if (d.Prime == null || d.Prime == 2)
        //                    {
        //                        qty = "0";
        //                        d.Instock = 0;
        //                        d.Qty = 0;
        //                    }
        //                    else
        //                    {
        //                        qty = "3";
        //                        d.Instock = 3;
        //                        d.Qty = 3;
        //                    }
        //                }

        //                displayminprice = Math.Round(finalprice - 45, 2);
        //                displaymaxprice = Math.Round(finalprice + 30, 2);
        //                if (displayminprice <= 17.45)
        //                {
        //                    displayminprice = 17.45;
        //                }
        //                //sb.appendline(string.join("\t",
        //                //                string.format(@"""{0}""", d.asin.trim()),
        //                //                string.format(@"""{0}""", ""),
        //                //                string.format(@"""{0}""", ""),
        //                //                string.format(@"""{0}""", string.format("{0:0.00}", finalprice)),
        //                //                string.format(@"""{0}""", string.format("{0:0.00}", displayminprice)),
        //                //                string.format(@"""{0}""", string.format("{0:0.00}", displaymaxprice)),
        //                //                string.format(@"""{0}""", "new"),
        //                //                string.format(@"""{0}""", qty),
        //                //                string.format(@"""{0}""", deldata),
        //                //                string.format(@"""{0}""", ""),
        //                //                string.format(@"""{0}""", ""),
        //                //                string.format(@"""{0}""", ""),
        //                //                string.format(@"""{0}""", ""),
        //                //                string.format(@"""{0}""", "")));


        //                sb.AppendLine(string.Join("\t",
        //      string.Format(@"""{0}""", ASIN),
        //      string.Format(@"""{0}""", string.Format("{0:0.00}", finalprice)),
        //      string.Format(@"""{0}""", string.Format("{0:0.00}", displayminprice)),
        //      string.Format(@"""{0}""", string.Format("{0:0.00}", displaymaxprice)),
        //      string.Format(@"""{0}""", qty),
        //      string.Format(@"""{0}""", "4")));

        //                if (shortcode == "ED")
        //                {
        //                    //d.account1_exportdate = datetime.now;
        //                    d.Account1_ReExport = 1;
        //                    cname = "" + DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss") + "_updatepriceqty_"+foldername+"_ED_" + fcountJewelry + "";
        //                    d.Account1_FileName = cname;

        //                }
        //                else
        //                    if (shortcode == "EM")
        //                    {
        //                        // d.account2_exportdate = datetime.now;
        //                        d.Account2_ReExport = 1;
        //                        cname = "" + DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss") + "_updatepriceqty_" + foldername + "_EM_" + fcountJewelry + "";
        //                        d.Account2_FileName = cname;
        //                    }
        //                    else
        //                        if (shortcode == "DI")
        //                        {
        //                            //   d.account4_exportdate = datetime.now;
        //                            d.Account4_ReExport = 1;
        //                            cname = "" + DateTime.Now.ToString("yyyy-mm-dd-hh-mm-ss") + "_updatepriceqty_" + foldername + "_DI_" + fcountJewelry + "";
        //                            d.Account4_FileName = cname;
        //                        }


        //                d.ReExportFileName = cname;
        //                fname = d.ReExportFileName + ".txt";
        //                //    d.forceexport = 0;
        //                d.ReExportTimeStamp = DateTime.Now;
        //                d.ReExportStatus = 1;
        //                d.UpdatedSalesPriceTimeStamp = null;
        //                ukdb.SaveChanges();

        //            }
        //            catch (Exception ex)
        //            {


        //                Log(LogFile, true, "issue in rexeport: " + d.ASIN + ex);
        //            }
        //        }

        //        // ukdb.objectcontext().savechanges(saveoptions.detectchangesbeforesave);
        //        fcountJewelry++;
        //        path = Generate(fname, sb, foldername);

        //    }
        //    else
        //    {
        //        path = Generate("Blank", sb, foldername);
        //    }
        //    //if (path != "failed" && (!path.contains("blank")))
        //    //{
        //    //    transaction.complete();
        //    //    ukdb.objectcontext().acceptallchanges();
        //    //}
        //    return path;
        //    // }
        //}

        public string HomeAndKitchen(string foldername, IEnumerable<dynamic> data, string shortcode, int flag)
        {

            //using (TransactionScope transaction = new TransactionScope())
            //{
            ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;

            string fname = "";
            string path = "";
            string cname = "";


            StringWriter st = new StringWriter();
            //string header = "sku	product-id	product-id-type	price	minimum-seller-allowed-price	maximum-seller-allowed-price	item-condition	quantity	add-delete	will-ship-internationally	expedited-shipping	item-note	fulfillment-center-id	merchant-shipping-group-name";
            string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);

            if (data != null && data.Count() != 0)
            {
                foreach (var d in data)
                {
                    //Nullable<double> price;
                    try
                    {

                        //  string delData = "";
                        string ASIN;
                        Nullable<float> price = 0;
                        //  double pricecal;
                        double pricemin = 0.00;
                        double finalprice;
                        double displayMinprice;
                        double displayMaxprice;
                        //if (d.UK_Prohibited == 1)
                        //{
                        //    delData = "X";
                        //    reExportChange = 2;
                        //}
                        if (d.UpdatedSalesPrice != null)
                        {
                            price = d.UpdatedSalesPrice;
                        }
                        else
                            if (d.SalesPrice != null)
                            {
                                price = d.SalesPrice;
                            }

                        if (price != 0)
                        {

                            double minval = 57.49;
                            if (price > 0 && price <= 19.99)
                            {
                                pricemin = minval;
                            }
                            else
                            {
                                for (double i = 20; i < 500; i += 10)
                                {
                                    minval = minval + 12;
                                    double temp = i + 10;
                                    if (price >= i && price < temp)
                                    {
                                        pricemin = minval;
                                        break;
                                    }
                                }
                            }

                            finalprice = pricemin;

                        }
                        else
                        {
                            finalprice = 17.45;
                        }

                        string qty;
                        if (flag != 2)
                        {
                            ASIN =  d.ASIN.Trim();
                            if (d.Prime == 0 || d.Prime == null || d.Prime == 2)
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;
                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }
                        else
                        {
                            ASIN = "NP-" + d.ASIN.Trim();
                            if (d.Prime == null || d.Prime == 2)
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;
                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }

                        displayMinprice = Math.Round(finalprice - 45, 2);
                        displayMaxprice = Math.Round(finalprice + 30, 2);
                        if (displayMinprice <= 17.45)
                        {
                            displayMinprice = 17.45;
                        }
                        //sb.AppendLine(string.Join("\t",
                        //                string.Format(@"""{0}""", d.ASIN.Trim()),
                        //                string.Format(@"""{0}""", ""),
                        //                string.Format(@"""{0}""", ""),
                        //                string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
                        //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
                        //                string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
                        //                string.Format(@"""{0}""", "new"),
                        //                string.Format(@"""{0}""", qty),
                        //                string.Format(@"""{0}""", delData),
                        //                string.Format(@"""{0}""", ""),
                        //                string.Format(@"""{0}""", ""),
                        //                string.Format(@"""{0}""", ""),
                        //                string.Format(@"""{0}""", ""),
                        //                string.Format(@"""{0}""", "")));


                        sb.AppendLine(string.Join("\t",
              string.Format(@"""{0}""", ASIN),
              string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
              string.Format(@"""{0}""", String.Format("{0:0.00}", displayMinprice)),
              string.Format(@"""{0}""", String.Format("{0:0.00}", displayMaxprice)),
              string.Format(@"""{0}""", qty),
              string.Format(@"""{0}""", "4")));

                        if (shortcode == "ED")
                        {
                            //d.Account1_ExportDate = DateTime.Now;
                            d.Account1_ReExport = 1;
                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_"+foldername+"_ED_" + fcountJewelry + "";
                            d.Account1_FileName = cname;

                        }
                        else
                            if (shortcode == "EM")
                            {
                                // d.Account2_ExportDate = DateTime.Now;
                                d.Account2_ReExport = 1;
                                cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_" + foldername + "_EM_" + fcountJewelry + "";
                                d.Account2_FileName = cname;
                            }
                            else
                                if (shortcode == "DI")
                                {
                                    //   d.Account4_ExportDate = DateTime.Now;
                                    d.Account4_ReExport = 1;
                                    cname = "" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_UpdatePriceQTY_" + foldername + "_DI_" + fcountJewelry + "";
                                    d.Account4_FileName = cname;
                                }


                        d.ReExportFileName = cname;
                        fname = d.ReExportFileName + ".txt";
                        //    d.ForceExport = 0;
                        d.ReExportTimeStamp = DateTime.Now;
                        d.ReExportStatus = 1;
                        d.UpdatedSalesPriceTimeStamp = null;
                        ukdb.SaveChanges();

                    }

                    catch (Exception ex)
                    {

                        Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
                    }

                    //catch (DbEntityValidationException dbEx)
                    //{
                    //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    //    {
                    //        foreach (var validationError in validationErrors.ValidationErrors)
                    //        {
                    //            Trace.TraceInformation("Property: {0} Error: {1}",
                    //                                    validationError.PropertyName,
                    //                                    validationError.ErrorMessage);
                    //        }
                    //    }
                    //}

                   
                }

                // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);
                fcountJewelry++;
                path = Generate(fname, sb, foldername);

            }
            else
            {
                path = Generate("Blank", sb, foldername);
            }
            //if (path != "failed" && (!path.Contains("Blank")))
            //{
            //    transaction.Complete();
            //    ukdb.ObjectContext().AcceptAllChanges();
            //}
            return path;
            // }
        }
        public string HomeAndKitchenCanada(string foldername, IEnumerable<dynamic> data, string shortcode, int flag)
        {

            //using (TransactionScope transaction = new TransactionScope())
            //{
            ((IObjectContextAdapter)ukdb).ObjectContext.CommandTimeout = 1800;
            string fname = "";
            string path = "";
            string cname = "";
            string ASIN;

            StringWriter st = new StringWriter();
            string header = "sku	price	minimum-seller-allowed-price	maximum-seller-allowed-price	quantity	leadtime-to-ship";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(header);

            if (data != null && data.Count() != 0)
            {
                foreach (var d in data)
                {
                    //Nullable<double> price;
                    try
                    {
                        Nullable<float> price = 0;
                        double pricemin = 0.00;
                        double finalprice;
                        if (d.UpdatedSalesPrice != null)
                        {
                            price = d.UpdatedSalesPrice;
                        }
                        else
                            if (d.SalesPrice != null)
                            {
                                price = d.SalesPrice;
                            }

                        if (price != 0)
                        {
                            //double minval = 0.00;

                            if (price > 0 && price <= 19.99)
                            {
                                pricemin = 92.99;
                            }
                            else if (price > 19.99 && price <= 29.99)
                            {
                                pricemin = 120.99;
                            }
                            else if (price > 29.99 && price <= 39.99)
                            {
                                pricemin = 142.99;
                            }
                            else if (price > 39.99 && price <= 49.99)
                            {
                                pricemin = 168.99;
                            }
                            else if (price > 49.99 && price <= 59.99)
                            {
                                pricemin = 192.99;
                            }
                            else if (price > 59.99 && price <= 69.99)
                            {
                                pricemin = 222.99;
                            }
                            else if (price > 69.99 && price <= 79.99)
                            {
                                pricemin = 255.99;
                            }
                            else if (price > 79.99 && price <= 89.99)
                            {
                                pricemin = 285.99;
                            }
                            else if (price > 89.99 && price <= 99.99)
                            {
                                pricemin = 313.99;
                            }
                            else if (price > 99.99 && price <= 109.99)
                            {
                                pricemin = 327.99;
                            }
                            else if (price > 109.99 && price <= 119.99)
                            {
                                pricemin = 356.99;
                            }
                            else if (price > 119.99 && price <= 129.99)
                            {
                                pricemin = 385.99;
                            }
                            else if (price > 129.99 && price <= 139.99)
                            {
                                pricemin = 420.99;
                            }
                            else if (price > 139.99 && price <= 149.99)
                            {
                                pricemin = 442.99;
                            }
                            else if (price > 149.99 && price <= 159.99)
                            {
                                pricemin = 463.99;
                            }
                            else if (price > 159.99 && price <= 169.99)
                            {
                                pricemin = 485.99;
                            }
                            else if (price > 169.99 && price <= 179.99)
                            {
                                pricemin = 513.99;
                            }
                            else if (price > 179.99 && price <= 189.99)
                            {
                                pricemin = 542.99;
                            }
                            else if (price > 189.99 && price <= 199.99)
                            {
                                pricemin = 569.99;
                            }
                            finalprice = pricemin;


                        }
                        else
                        {
                            finalprice = 10.01;
                        }

                        string qty;
                        if (flag != 2)
                        {
                            ASIN = d.ASIN.Trim();
                            if (d.Prime == 0 || d.Prime == null || d.Prime == 2)
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;
                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }
                        else
                        {
                            ASIN = "NP-" + d.ASIN.Trim();
                            if (d.Prime == null || d.Prime == 2)
                            {
                                qty = "0";
                                d.Instock = 0;
                                d.Qty = 0;
                            }
                            else
                            {
                                qty = "3";
                                d.Instock = 3;
                                d.Qty = 3;
                            }
                        }

                        sb.AppendLine(string.Join("\t",
                                      string.Format(@"""{0}""", ASIN),
                                      string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice)),
                                      string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice - 10)),
                                      string.Format(@"""{0}""", String.Format("{0:0.00}", finalprice + 10)),
                                      string.Format(@"""{0}""", qty),
                                      string.Format(@"""{0}""", "4")));


                        if (shortcode == "DC")
                        {
                            //      d.Account3_ExportDate = DateTime.Now;
                            d.Account3_ReExport = 1;
                            cname = "" + DateTime.Now.ToString("yyyy-MM-dd") + "_UpdatePriceQTY_" + foldername + "_DC_" + fcountJewelry + "";
                            d.Account3_FileName = cname;
                        }

                        d.ReExportFileName = cname;
                        fname = d.ReExportFileName + ".txt";

                        d.ReExportTimeStamp = DateTime.Now;
                        d.ReExportStatus = 1;
                        d.UpdatedSalesPriceTimeStamp = null;
                        ukdb.SaveChanges();


                    }
                    catch (Exception ex)
                    {

                        Log(LogFile, true, "Issue in Rexeport: " + d.ASIN + ex);
                    }
                }
                // ukdb.ObjectContext().SaveChanges(SaveOptions.DetectChangesBeforeSave);

                fcountJewelry++;
                path = Generate(fname, sb, foldername);

            }
            else
            {
                path = Generate("Blank", sb, foldername);
            }
            //if (path != "failed" && (!path.Contains("Blank")))
            //{
            //    transaction.Complete();
            //    ukdb.ObjectContext().AcceptAllChanges();
            //}
            return path;
            // }
        }
        public string Generate(string filename, StringBuilder sb, string foldername)
        {
            try
            {

                if (filename != "Blank")
                {
                    // HttpPostedFileBase file = null;

                    string targetPath = "C:/MWS_SERVICE/" + foldername; //with complete path
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
                    string targetPath = "C:/MWS_SERVICE/" + foldername; //with complete path
                    return (targetPath + "/" + "Blank");
                }
            }
            catch (Exception ex)
            {
                Log(LogFile, true, "Issue in Writting File: " + ex);

                return "failed";
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

                throw;
            }
        }


    }
}