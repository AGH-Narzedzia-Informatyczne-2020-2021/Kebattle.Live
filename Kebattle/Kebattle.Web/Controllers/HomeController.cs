using Kebattle.Interfaces.Repositories;
using Kebattle.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICompanyRepository _companyRepository;
        public HomeController(IOrderRepository orderRepository, ICompanyRepository companyRepository)
        {
            _orderRepository = orderRepository;
            _companyRepository = companyRepository;
        }
        public ActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Initialize(_orderRepository, _companyRepository);
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}