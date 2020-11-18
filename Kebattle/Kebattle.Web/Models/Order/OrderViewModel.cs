using Kebattle.Interfaces.Repositories;
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
            Id = order.Id;
            CompanyId = order.CompanyId;
            Name = order.Name;
            KebabTypeId = order.KebabTypeId;
            SauceTypeId = order.SauceTypeId;
            MeatTypeId = order.MeatTypeId;
            Notes = order.Notes;
            DateAdded = order.DateAdded;
            DateUpdated = order.DateUpdated;
            AddedBy = order.AddedBy;
            AddedByName = "";
            UpdatedBy = order.UpdatedBy;
            UpdatedByName = "";
        }

        public void Initialize(IOrderRepository _orderRepository)
        {
            var kebabTypes = _orderRepository.GetKebabTypes();
            KebabTypes = kebabTypes.Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString(), Selected = KebabTypeId == a.Id }).ToList();

            var sauceTypes = _orderRepository.GetSauceTypes();
            SauceTypes = sauceTypes.Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString(), Selected = SauceTypeId == a.Id }).ToList();

            var meatTypes = _orderRepository.GetMeatTypes();
            MeatTypes = meatTypes.Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString(), Selected = MeatTypeId == a.Id }).ToList();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> KebabTypes { get; set; }
        public int KebabTypeId { get; set; }
        public List<SelectListItem> SauceTypes { get; set; }
        public int SauceTypeId { get; set; }
        public List<SelectListItem> MeatTypes { get; set; }
        public int MeatTypeId { get; set; }
        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string AddedBy { get; set; }
        public string AddedByName { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedByName { get; set; }

        public DomainModel.Order ToOrder()
        {
            return new DomainModel.Order()
            {
                Id = Id,
                CompanyId = CompanyId,
                Name = Name,
                KebabTypeId = KebabTypeId,
                SauceTypeId = SauceTypeId,
                MeatTypeId = MeatTypeId,
                Notes = Notes,
                DateAdded = DateAdded,
                DateUpdated = DateUpdated,
                AddedBy = AddedBy,
                UpdatedBy = UpdatedBy,
        };
        }
    }
}