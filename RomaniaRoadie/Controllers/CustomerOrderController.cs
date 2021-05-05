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
        private ProductRepository productRepository = new ProductRepository();
        private CustomerRepository customerRepository = new CustomerRepository();
        private OrderChartRepository orderChartRepository = new OrderChartRepository();
        private CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository();

        // GET: CustomerOrder
        [Authorize(Roles = "User, Admin")]
        public ActionResult Index()
        {
            List<CustomerOrderModel> customerOrders = customerOrderRepository.GetAllCustomerOrders();
            
            return View("Index", customerOrders);
        }

        // GET: CustomerOrder/Details/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(Guid id)
        {
            CustomerOrderModel customerOrderModel = customerOrderRepository.GetCustomerOrderByID(id);
            
            return View("CustomerOrderDetails", customerOrderModel);
        }

        // GET: CustomerOrder/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            return View("CreateCustomerOrder");
        }

        // POST: CustomerOrder/Create
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustomerOrderModel customerOrderModel = new CustomerOrderModel();
                UpdateModel(customerOrderModel);

                customerOrderModel.IDCustomerOrder = orderChartRepository.GetLastOrder();
                customerOrderModel.IDCustomer = customerRepository.GetCustomerByEmail(User.Identity.Name);
                customerOrderModel.DateCreated = DateTime.Now;
                customerOrderModel.OrderTotal = orderChartRepository.GetOrderTotal(customerOrderModel.IDCustomer);
                customerOrderRepository.InsertCustomerOrder(customerOrderModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCustomerOrder");
            }
        }

        // GET: CustomerOrder/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(Guid id)
        {
            CustomerOrderModel customerOrderModel = customerOrderRepository.GetCustomerOrderByID(id);

            return View("EditCustomerOrder", customerOrderModel);
        }

        // POST: CustomerOrder/Edit/5
        [Authorize(Roles = "User, Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            CustomerOrderModel customerOrderModel = customerOrderRepository.GetCustomerOrderByID(id);

            return View("DeleteCustomerOrder", customerOrderModel);
        }

        // POST: CustomerOrder/Delete/5
        [Authorize(Roles = "Admin")]
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
