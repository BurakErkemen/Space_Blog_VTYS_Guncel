using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Space_CF_Project.Models.Entity
{
    public class TBLUser
    {
        [Key]
        public int? UserID{ get; set; }
        public string UserAd { get; set; }
        public string UserSoyad { get; set; }
        public string UserMail{ get; set; }
        public string UserSifre{ get; set; }
        public virtual List<TBLGonderi> Gonderiler { get;set; }
    }
}