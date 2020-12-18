using Kebattle.DomainModel;
using Kebattle.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kebattle.Web.Models.Company
{
    public class SettingsViewModel
    {
        public int CompanyId { get; set; }
        [Display(Name = "Nazwa firmy")]
        public string CompanyName { get; set; }
        [Display(Name = "Url ze zdjęciem firmy")]
        public string Url { get; set; }
        public List<KebabType> KebabTypes { get; set; }
        public List<KebabSize> KebabSizes { get; set; }
        public List<CompaniesPrice> CompaniesPrice { get; set; }

        public SettingsViewModel()
        {
            KebabTypes = new List<KebabType>();
            KebabSizes = new List<KebabSize>();
            CompaniesPrice = new List<CompaniesPrice>();
        }

        public void Initialize(IOrderRepository orderRepository)
        {
            KebabTypes = orderRepository.GetKebabTypes();
            KebabSizes = orderRepository.GetKebabSizes();
        }

        public void InitializeCompany(ICompanyRepository companyRepository)
        {
            CompaniesPrice = companyRepository.GetCompaniesPriceByCompanyId(CompanyId);
            CompanyName = companyRepository.GetById(CompanyId).Name;
            Url = companyRepository.GetById(CompanyId).Url;
        }
    }
}