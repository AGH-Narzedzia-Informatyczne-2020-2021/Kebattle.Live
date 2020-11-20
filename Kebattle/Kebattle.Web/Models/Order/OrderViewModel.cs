using Kebattle.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Models.Order
{
    public class OrderViewModel : ViewModelBase
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
            KebabType = order.KebabType?.Name;
            SauceTypeId = order.SauceTypeId;
            SauceType = order.SauceType?.Name;
            MeatTypeId = order.MeatTypeId;
            MeatType = order.MeatType?.Name;
            KebabSizeId = order.KebabSizeId;
            KebabSize = order.KebabSize?.Name;
            Notes = order.Notes;
            DateAdded = order.DateAdded;
            AddedBy = order.AddedBy;
            AddedByName = order.AspNetUser_AddedBy.Email;
        }

        public void Initialize(IOrderRepository _orderRepository)
        {
            var kebabTypes = _orderRepository.GetKebabTypes();
            KebabTypes = GetSelectList(kebabTypes, true, "Wybierz", "0");

            var sauceTypes = _orderRepository.GetSauceTypes();
            SauceTypes = GetSelectList(sauceTypes, true, "Wybierz", "0");

            var meatTypes = _orderRepository.GetMeatTypes();
            MeatTypes = GetSelectList(meatTypes, true, "Wybierz", "0");

            var kebabSizes = _orderRepository.GetKebabSizes();
            KebabSizes = GetSelectList(kebabSizes, true, "Wybierz", "0");
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [DisplayName("Typ kebaba")]
        [Required]
        public int KebabTypeId { get; set; }
        public string KebabType { get; set; }
        public List<SelectListItem> KebabTypes { get; set; }

        [DisplayName("Typ sosu")]
        [Required]
        public int SauceTypeId { get; set; }
        public string SauceType { get; set; }
        public List<SelectListItem> SauceTypes { get; set; }

        [DisplayName("Rodzaj mięsa")]
        [Required]
        public int MeatTypeId { get; set; }
        public string MeatType { get; set; }
        public List<SelectListItem> MeatTypes { get; set; }

        [DisplayName("Rozmiar kebaba")]
        [Required]
        public int KebabSizeId { get; set; }
        public string KebabSize { get; set; }
        public List<SelectListItem> KebabSizes { get; set; }

        [DisplayName("Dodatkowe informacje")]
        public string Notes { get; set; }
        public DateTime? DateAdded { get; set; }
        public string AddedBy { get; set; }
        public string AddedByName { get; set; }

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
                KebabSizeId = KebabSizeId,
                Notes = Notes,
                DateAdded = DateAdded ?? DateTime.Now,
                AddedBy = AddedBy
            };
        }
    }
}