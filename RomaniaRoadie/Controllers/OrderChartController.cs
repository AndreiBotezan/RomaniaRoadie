using RomaniaRoadie.Models;
using RomaniaRoadie.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RomaniaRoadie.Controllers
{
    public class OrderChartController : Controller
    {
        private OrderChartRepository orderChartRepository = new OrderChartRepository();
        private ProductRepository productRepository = new ProductRepository();
        private CustomerRepository customerRepository = new CustomerRepository();
        private CustomerOrderRepository customerOrderRepository = new CustomerOrderRepository();

        // GET: OrderChart
        [AllowAnonymous]
        public ActionResult Index()
        {
            Guid id = customerRepository.GetCustomerByEmail(User.Identity.Name);

            List<OrderChartModel> orderChartModels = orderChartRepository.GetAllOrderCharts(id);
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            foreach(OrderChartModel item in orderChartModels)
            {
                OrderViewModel orderViewModel = new OrderViewModel();
                orderViewModel.IdOrderChart = item.IDOrderChart;
                orderViewModel.Model = productRepository.GetProductByID(item.IDProduct).Model;
                orderViewModel.Manufacturer = productRepository.GetProductByID(item.IDProduct).Manufacturer;
                orderViewModel.Quantity = item.Quantity;
                orderViewModel.TotalPrice = item.TotalPrice;

                orderViewModels.Add(orderViewModel);
            }

            return View("Index", orderViewModels);
        }

        // GET: OrderChart/Details/5
        [AllowAnonymous]
        public ActionResult Details(Guid id)
        {
            OrderChartModel orderChartModel = orderChartRepository.GetOrderChartByID(id);
            
            return View("OrderChartDetails", orderChartModel);
        }

        // GET: OrderChart/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            return View("CreateOrderChart");
        }

        // POST: OrderChart/Create
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Create(Guid id, FormCollection collection)
        {
            try
            {
                OrderChartModel orderChartModel = new OrderChartModel();
                UpdateModel(orderChartModel);

                orderChartModel.TotalPrice = orderChartModel.Quantity * productRepository.GetProductByID(id).Price;
                orderChartModel.IDProduct = id;
                orderChartModel.IDCustomer = customerRepository.GetCustomerByEmail(User.Identity.Name);
                orderChartModel.IDCustomerOrder = customerOrderRepository.GetIDCustomerOrder();

                orderChartRepository.InsertOrderChart(orderChartModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrderChart");
            }
        }
        // GET: OrderChart/Edit/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Edit(Guid id)
        {
            OrderChartModel orderChartModel = orderChartRepository.GetOrderChartByID(id);

            return View("EditOrderChart", orderChartModel);
        }

        // POST: OrderChart/Edit/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                OrderChartModel orderChartModel = new OrderChartModel();
                UpdateModel(orderChartModel);
                
                orderChartModel.TotalPrice = orderChartModel.Quantity * productRepository.GetProductByID(orderChartModel.IDProduct).Price;

                orderChartRepository.UpdateOrderChart(orderChartModel);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditOrderChart");
            }
        }

        // GET: OrderChart/Delete/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(Guid id)
        {
            OrderChartModel orderChartModel = orderChartRepository.GetOrderChartByID(id);
            return View("DeleteOrderChart", orderChartModel);
        }

        // POST: OrderChart/Delete/5
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                orderChartRepository.DeleteOrderChart(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteOrderChart");
            }
        }
        
    }
}
