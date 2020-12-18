using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kebattle.Interfaces.Repositories;

namespace Kebattle.Web.Models.Home
{
    public class HomeViewModel
    {
        public List<DomainModel.Company> Companies { get; set; }
        public List<DomainModel.Order> Orders { get; set; }

        public HomeViewModel()
        {
            Companies = new List<DomainModel.Company>();
            Orders = new List<DomainModel.Order>();
        }

        public void Initialize(IOrderRepository orderRepository, ICompanyRepository companyRepository)
        {
            Companies = companyRepository.GetAll().ToList();
            Orders = orderRepository.GetAll().ToList();
        }
    }
}