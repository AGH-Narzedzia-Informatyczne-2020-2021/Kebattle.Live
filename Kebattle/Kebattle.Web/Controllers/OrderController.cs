using Kebattle.Interfaces.Repositories;
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

        // GET: Order/Index/[id]
        public ActionResult Index(int id)
        {
            var orders = _orderRepository.GetByCompanyId(id);
            var model = new OrdersListViewModel(orders);
            return View(model);
        }

        // GET: Order/Details/[id]
        public ActionResult View(int id)
        {
            var order = _orderRepository.GetOrder(id);
            var model = new OrderViewModel(order);
            return View(model);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var model = new OrderViewModel();
            model.Initialize(_orderRepository);

            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderViewModel order)
        {
            try
            {
                _orderRepository.SaveOrder(order.ToOrder());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/[id]
        public ActionResult Edit(int id)
        {
            var order = _orderRepository.GetOrder(id);
            var model = new OrderViewModel(order);
            model.Initialize(_orderRepository);

            return View();
        }

        // POST: Order/Edit/[id]
        [HttpPost]
        public ActionResult Edit(OrderViewModel order)
        {
            try
            {
                _orderRepository.SaveOrder(order.ToOrder());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Order/Delete/[id]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _orderRepository.DeleteOrder(id);

                return Json("Zamówienie usunięte");
            }
            catch
            {
                return Json("Coś poszło nie tak!");
            }
        }
    }
}
