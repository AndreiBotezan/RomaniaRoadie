using RomaniaRoadie.Models;
using RomaniaRoadie.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RomaniaRoadie.Controllers
{
    public class CustomerOrderController : Controller
    {
        private CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository();
        // GET: CustomerOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerOrder/Create
        public ActionResult Create()
        {
            return View("CreateCustomerOrder");
        }

        // POST: CustomerOrder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustomerOrderModel customerOrderModel = new CustomerOrderModel();
                UpdateModel(customerOrderModel);

                customerOrderRepository.UpdateCustomerOrder(customerOrderModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCustomerOrder");
            }
        }

        // GET: CustomerOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerOrder/Edit/5
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

        // GET: CustomerOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerOrder/Delete/5
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
