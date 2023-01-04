using Space_CF_Project.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Space_CF_Project.Models.Context
{
    public class CONTEXT:DbContext
    {
        public DbSet<TBLUser> TBLUsers { get; set; }
        public DbSet<TBLGonderi> TBLGonderis { get;set; }
        public DbSet<TBLKategori> TBLKategoris { get; set;}
        public DbSet<TBLStatePaylasım> statePaylasıms { get; set;}
    }
}