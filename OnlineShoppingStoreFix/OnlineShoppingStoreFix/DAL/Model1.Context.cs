﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShoppingStoreFix.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbMyOnlineShoppingEntities : DbContext
    {
        public dbMyOnlineShoppingEntities()
            : base("name=dbMyOnlineShoppingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_cart> Tbl_cart { get; set; }
        public virtual DbSet<Tbl_CartStatus> Tbl_CartStatus { get; set; }
        public virtual DbSet<Tbl_Category> Tbl_Category { get; set; }
        public virtual DbSet<Tbl_Product> Tbl_Product { get; set; }
        public virtual DbSet<Tbl_Roles> Tbl_Roles { get; set; }
        public virtual DbSet<Tbl_ShippingDetails> Tbl_ShippingDetails { get; set; }
        public virtual DbSet<Tbl_SlideImage> Tbl_SlideImage { get; set; }
        public virtual DbSet<Tbl_UserRole> Tbl_UserRole { get; set; }
        public virtual DbSet<Tbl_Users> Tbl_Users { get; set; }
    }
}
