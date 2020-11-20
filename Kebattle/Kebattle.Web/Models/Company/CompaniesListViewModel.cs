using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kebattle.Web.Models.Company
{
    public class CompaniesListViewModel
    {
        public CompaniesListViewModel()
        {
            Companies = new List<DomainModel.Company>();
        }

        public CompaniesListViewModel(List<DomainModel.Company> companies)
        {
            Companies = companies;
        }

        public List<DomainModel.Company> Companies { get; set; }
    }
}