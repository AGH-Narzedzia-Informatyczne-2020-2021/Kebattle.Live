using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Models.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            KebabTypes = new List<SelectListItem>();
            SauceTypes = new List<SelectListItem>();
            MeatTypes = new List<SelectListItem>();
        }

        public OrderViewModel(DomainModel.Order order) : this()
        {
            ID = order.Id;
            CompanyID = order.CompanyId;
            Name = order.Name;
            KebabTypeID = order.KebabTypeId;
            SouceTypeID = order.SauceTypeId;
            MeatTypeID = order.MeatTypeId;
            Notes = order.Notes;
            DateAdded = order.DateAdded;
            DateUpdated = order.DateUpdated;
            AddedBy = order.AddedBy;
            AddedByName = "";
            UpdatedBy = order.UpdatedBy;
            UpdatedByName = "";
        }

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
        public string AddedBy { get; set; }
        public string AddedByName { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }
    }
}