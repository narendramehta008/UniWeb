﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseLib.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UniWebEntities : DbContext
    {
        public UniWebEntities()
            : base("name=UniWebEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FbAccount> FbAccounts { get; set; }
        public virtual DbSet<InstaAccount> InstaAccounts { get; set; }
        public virtual DbSet<PinAccount> PinAccounts { get; set; }
        public virtual DbSet<TwtAccount> TwtAccounts { get; set; }
        public virtual DbSet<WebAccount> WebAccounts { get; set; }
        public virtual DbSet<WebHeader> WebHeaders { get; set; }
    }
}
