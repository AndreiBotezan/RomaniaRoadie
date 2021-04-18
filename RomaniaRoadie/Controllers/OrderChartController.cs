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

        // GET: OrderChart
        public ActionResult Index()
        {
            List<OrderChartModel> orderChartModels = orderChartRepository.GetAllOrderCharts();
            
            return View("Index", orderChartModels);
        }

        // GET: OrderChart/Details/5
        public ActionResult Details(Guid id)
        {
            OrderChartModel orderChartModel = orderChartRepository.GetOrderChartByID(id);
            
            return View("OrderChartDetails", orderChartModel);
        }

        // GET: OrderChart/Create
        public ActionResult Create()
        {
            return View("CreateOrderChart");
        }

        // POST: OrderChart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                OrderChartModel orderChartModel = new OrderChartModel();
                UpdateModel(orderChartModel);

                orderChartRepository.InsertOrderChart(orderChartModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrderChart");
            }
        }

        // GET: OrderChart/Edit/5
        public ActionResult Edit(Guid id)
        {
            OrderChartModel orderChartModel = orderChartRepository.GetOrderChartByID(id);

            return View("EditOrderChart", orderChartModel);
        }

        // POST: OrderChart/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                OrderChartModel orderChartModel = new OrderChartModel();
                UpdateModel(orderChartModel);
                orderChartRepository.UpdateOrderChart(orderChartModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditOrderChart");
            }
        }

        // GET: OrderChart/Delete/5
        public ActionResult Delete(Guid id)
        {
            OrderChartModel orderChartModel = orderChartRepository.GetOrderChartByID(id);
            return View("DeleteOrderChart", orderChartModel);
        }

        // POST: OrderChart/Delete/5
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
