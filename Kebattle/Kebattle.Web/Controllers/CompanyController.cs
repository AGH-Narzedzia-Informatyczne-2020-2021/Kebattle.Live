using Kebattle.Interfaces.Repositories;
using Kebattle.Web.Models.Company;
using Kebattle.Web.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IOrderRepository _orderRepository;

        public CompanyController(ICompanyRepository companyRepository, IOrderRepository orderRepository)
        {
            _companyRepository = companyRepository;
            _orderRepository = orderRepository;
        }

        public ActionResult Index()
        {
            var vm = new CompaniesListViewModel(_companyRepository.GetAll().ToList());
            return View(vm);
        }

        public ActionResult Statistics(int companyId)
        {
            var orders = _orderRepository.GetByCompanyId(companyId);
            var model = new StatisticsListViewModel(orders);
            return View(model);
        }

        public ActionResult Settings(int companyId)
        {

            return View();
        }
    }
}