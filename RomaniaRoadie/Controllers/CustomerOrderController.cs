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
            List<CustomerOrderModel> customerOrders = customerOrderRepository.GetAllCustomerOrders();
            
            return View("Index", customerOrders);
        }

        // GET: CustomerOrder/Details/5
        public ActionResult Details(Guid id)
        {
            CustomerOrderModel customerOrderModel = customerOrderRepository.GetCustomerOrderByID(id);
            
            return View("CustomerOrderDetails", customerOrderModel);
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
        public ActionResult Edit(Guid id)
        {
            CustomerOrderModel customerOrderModel = customerOrderRepository.GetCustomerOrderByID(id);

            return View("EditCustomerOrder", customerOrderModel);
        }

        // POST: CustomerOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
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
                return View("EditCustomerOrder");
            }
        }

        // GET: CustomerOrder/Delete/5
        public ActionResult Delete(Guid id)
        {
            CustomerOrderModel customerOrderModel = customerOrderRepository.GetCustomerOrderByID(id);

            return View("DeleteCustomerOrder", customerOrderModel);
        }

        // POST: CustomerOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                customerOrderRepository.DeleteCustomerOrder(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCustomerOrder");
            }
        }
    }
}
