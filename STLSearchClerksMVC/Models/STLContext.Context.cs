﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STLSearchClerksMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class STLContext : DbContext
    {
        public STLContext()
            : base("name=STLContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authority> Authorities { get; set; }
        public virtual DbSet<DoubleBooking> DoubleBookings { get; set; }
        public virtual DbSet<SearchClerk> SearchClerks { get; set; }
    }
}
