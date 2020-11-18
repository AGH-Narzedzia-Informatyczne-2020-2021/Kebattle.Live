using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Models.Order
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> KebabTypes { get; set; }
        public int KebabTypeID { get; set; }
        public List<SelectListItem> SauceTypes { get; set; }
        public int SouceTypeID { get; set; }
        public List<SelectListItem> MeatTypes { get; set; }
        public int MeatTypeID { get; set; }
        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int AddedBy { get; set; }
        public string AddedByName { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }

    }
}