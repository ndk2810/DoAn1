﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeThongThueXe.Controllers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class THUEXEEntities1 : DbContext
    {
        public THUEXEEntities1()
            : base("name=THUEXEEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BANGBAOGIA> BANGBAOGIAs { get; set; }
        public virtual DbSet<HIEUXE> HIEUXEs { get; set; }
        public virtual DbSet<KHACH> KHACHes { get; set; }
        public virtual DbSet<LIENHE> LIENHEs { get; set; }
        public virtual DbSet<LOAIXE> LOAIXEs { get; set; }
        public virtual DbSet<THONGKE> THONGKEs { get; set; }
        public virtual DbSet<THUE> THUEs { get; set; }
        public virtual DbSet<TINTUC> TINTUCs { get; set; }
        public virtual DbSet<XE> XEs { get; set; }
        public virtual DbSet<YEUCAUTHUE> YEUCAUTHUEs { get; set; }
    }
}