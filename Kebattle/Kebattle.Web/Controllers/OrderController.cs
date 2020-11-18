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
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Order/Edit/[id]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/[id]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/[id]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
