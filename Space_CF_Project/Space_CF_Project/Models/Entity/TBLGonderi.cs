using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Space_CF_Project.Models.Entity
{
    public class TBLGonderi
    {
        [Key]
        public int? GonID { get; set; }
        public string GonBaslık { get; set; }
        public string GonText { get; set; }
        public string GonPicture { get; set; }
        public DateTime DateTime { get; set; }
        public int UserID { get; set; }
        public virtual TBLUser TBLUser { get; set; }
        public int KatID{ get; set; }
        public virtual TBLKategori TBLKategori{ get; set; }
        public List<TBLGonderi> gonderiList { get; set; }
    }
}