﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OmniUKClass
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UKOmnimarkEntities : DbContext
    {
        public UKOmnimarkEntities()
            : base("name=UKOmnimarkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_Baby> tbl_Baby { get; set; }
        public DbSet<tbl_Beauty> tbl_Beauty { get; set; }
        public DbSet<tbl_HomeandKitchen> tbl_HomeandKitchen { get; set; }
        public DbSet<tbl_Jewellery> tbl_Jewellery { get; set; }
        public DbSet<tbl_Sports> tbl_Sports { get; set; }
        public DbSet<tbl_Toys> tbl_Toys { get; set; }
        public DbSet<tbl_Watches> tbl_Watches { get; set; }
        public DbSet<tbl_ToysNotPrime> tbl_ToysNotPrime { get; set; }
        public DbSet<tbl_BabyNotPrime> tbl_BabyNotPrime { get; set; }
        public DbSet<tbl_BeautyNotPrime> tbl_BeautyNotPrime { get; set; }
        public DbSet<tbl_HomeAndKitchenNotPrime> tbl_HomeAndKitchenNotPrime { get; set; }
        public DbSet<tbl_JewelleryNotPrime> tbl_JewelleryNotPrime { get; set; }
        public DbSet<tbl_SportsNotPrime> tbl_SportsNotPrime { get; set; }
        public DbSet<tbl_WatchesNotPrime> tbl_WatchesNotPrime { get; set; }
    }
}