using Kebattle.Interfaces.Repositories;
using Kebattle.Web.Models.Company;
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

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ActionResult Index()
        {
            var vm = new CompaniesListViewModel(_companyRepository.GetAll().ToList());
            return View(vm);
        }

        public ActionResult Statistics(int companyId)
        {
            
            return View();
        }

        public ActionResult Settings(int companyId)
        {

            return View();
        }
    }
}