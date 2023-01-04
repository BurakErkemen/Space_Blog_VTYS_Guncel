using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Space_CF_Project.Models.Entity
{
    public class TBLKategori
    {
        [Key]
        public int KatID { get; set; }
        public string KatAd { get; set; }
        public List<TBLGonderi> ListGonderi{ get; set; }
    }
}