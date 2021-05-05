using RomaniaRoadie.Models;
using RomaniaRoadie.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RomaniaRoadie.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository customerRepository = new CustomerRepository();

        // GET: Customer
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<CustomerModel> customers = customerRepository.GetAllCustomers();

            return View("Index", customers);
        }

        // GET: Customer/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid id)
        {
            CustomerModel customerModel = customerRepository.GetCustomerByID(id);

            return View("CustomerDetails", customerModel);
        }

        // GET: Customer/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        // POST: Customer/Create
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                UpdateModel(customerModel);

                customerRepository.InsertCustomer(customerModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCustomer");
            }
        }

        // GET: Customer/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(Guid id)
        {
            CustomerModel customerModel = customerRepository.GetCustomerByID(id);
            return View("EditCustomer", customerModel);
        }

        // POST: Customer/Edit/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                CustomerModel customerModel = new CustomerModel();
                UpdateModel(customerModel);
                customerRepository.UpdateCustomer(customerModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCustomer");
            }
        }

        // GET: Customer/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            CustomerModel customerModel = customerRepository.GetCustomerByID(id);
            return View("DeleteCustomer", customerModel);
        }

        // POST: Customer/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                customerRepository.DeleteCustomer(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCustomer");
            }
        }
    }
}
