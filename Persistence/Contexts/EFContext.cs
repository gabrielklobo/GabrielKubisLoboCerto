﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models.Tables;
using Models.Registers;

namespace Persistence.Contexts
{
    public class EFContext : DbContext


    {

       

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
       
        public EFContext() : base("Asp_Net_MVC_CS") { Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>()); }


    }


}