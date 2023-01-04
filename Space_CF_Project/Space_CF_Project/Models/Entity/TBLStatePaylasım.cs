using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Space_CF_Project.Models.Entity
{
    public class TBLStatePaylasım
    {
        [Key]
        public int StateID { get; set; }
        public string StateAd { get; set; }
        public string StateSoyad { get; set; }
        public string StateText { get; set; }
    }
}