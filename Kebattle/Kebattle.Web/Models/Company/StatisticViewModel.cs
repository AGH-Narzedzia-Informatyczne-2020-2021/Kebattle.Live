using Kebattle.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Models.Company
{
    public class StatisticViewModel : ViewModelBase
    {
        public StatisticViewModel()
        {
            KebabTypes = new List<SelectListItem>();
            SauceTypes = new List<SelectListItem>();
            MeatTypes = new List<SelectListItem>();
        }

        public StatisticViewModel(DomainModel.Order statistic) : this()
        {
            Id = statistic.Id;
            CompanyId = statistic.CompanyId;
            Name = statistic.Name;
            KebabTypeId = statistic.KebabTypeId;
            KebabType = statistic.KebabType?.Name;
            SauceTypeId = statistic.SauceTypeId;
            SauceType = statistic.SauceType?.Name;
            MeatTypeId = statistic.MeatTypeId;
            MeatType = statistic.MeatType?.Name;
            KebabSizeId = statistic.KebabSizeId;
            KebabSize = statistic.KebabSize?.Name;
            Notes = statistic.Notes;
            DateAdded = statistic.DateAdded;
            AddedBy = statistic.AddedBy;
            AddedByName = statistic.AspNetUser_AddedBy.Email;
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

        public DomainModel.Order ToStatistic()
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