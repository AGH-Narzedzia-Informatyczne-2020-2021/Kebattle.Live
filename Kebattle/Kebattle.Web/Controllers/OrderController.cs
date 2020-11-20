using Kebattle.Interfaces.Repositories;
using Kebattle.Web.Helpers;
using Kebattle.Web.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kebattle.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ActionResult Index(int companyId)
        {
            var orders = _orderRepository.GetByCompanyId(companyId);
            var model = new OrdersListViewModel(orders)
            {
                CompanyId = companyId
            };
            return View(model);
        }

        public ActionResult View(int id)
        {
            var order = _orderRepository.GetOrder(id);
            var model = new OrderViewModel(order);
            return View(model);
        }

        public ActionResult Create(int companyId)
        {
            var model = new OrderViewModel()
            {
                CompanyId = companyId
            };
            model.Initialize(_orderRepository);

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(OrderViewModel order)
        {
            order.AddedBy = SessionHelper.GetUserId();

            if (ModelState.IsValid)
            {
                _orderRepository.SaveOrder(order.ToOrder());
                return RedirectToAction("Index", new { companyID = order.CompanyId });
            }
            order.Initialize(_orderRepository);
            return View(order.Id == 0 ? "Create" : "Edit", order);
        }

        public ActionResult Edit(int id)
        {
            var order = _orderRepository.GetOrder(id);
            var model = new OrderViewModel(order);
            model.Initialize(_orderRepository);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _orderRepository.DeleteOrder(id);

                return Json("Zamówienie usunięte!");
            }
            catch
            {
                return Json("Coś poszło nie tak!");
            }
        }
    }
}
