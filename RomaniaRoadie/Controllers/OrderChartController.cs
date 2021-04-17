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
            return View();
        }

        // GET: OrderChart/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderChart/Edit/5
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

        // GET: OrderChart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderChart/Delete/5
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
