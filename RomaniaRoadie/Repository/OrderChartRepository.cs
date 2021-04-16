using RomaniaRoadie.Models;
using RomaniaRoadie.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomaniaRoadie.Repository
{
    public class OrderChartRepository
    {
        private RomaniaRoadieDataContext dbContext;

        public OrderChartRepository()
        {
            dbContext = new RomaniaRoadieDataContext();
        }

        public OrderChartRepository(RomaniaRoadieDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<OrderChartModel> GetAllOrderCharts()
        {
            List<OrderChartModel> orderChartList = new List<OrderChartModel>();
            foreach (OrderChart dbOrderChart in dbContext.OrderCharts)
            {
                orderChartList.Add(MapDbObjectToModel(dbOrderChart));
            }
            return orderChartList;
        }

        public OrderChartModel GetOrderChartByID(Guid IDOrderChart)
        {
            var orderChart = dbContext.OrderCharts.FirstOrDefault(x => x.IDOrderChart == IDOrderChart);
            return MapDbObjectToModel(orderChart);
        }
        public OrderChartModel GetOrderChartByIDCustomerOrder(Guid IDCustomerOrder)
        {
            var orderChart = dbContext.OrderCharts.FirstOrDefault(x => x.IDCustomerOrder == IDCustomerOrder);
            return MapDbObjectToModel(orderChart);
        }
        public void InsertOrderChart(OrderChartModel orderChart)
        {
            orderChart.IDOrderChart = Guid.NewGuid();
            dbContext.OrderCharts.InsertOnSubmit(MapModelToDbObject(orderChart));
            dbContext.SubmitChanges();
        }

        public void UpdateOrderChart(OrderChartModel orderChart)
        {
            OrderChart dbOrderChart = dbContext.OrderCharts
                .FirstOrDefault(x => x.IDOrderChart == orderChart.IDOrderChart);
            if (dbOrderChart != null)
            {
                dbOrderChart.IDOrderChart = orderChart.IDOrderChart;
                dbOrderChart.IDCustomerOrder = orderChart.IDCustomerOrder;
                dbOrderChart.IDProduct = orderChart.IDProduct;
                dbOrderChart.Quantity = orderChart.Quantity;
                dbOrderChart.Price = orderChart.Price;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteOrderChart(Guid IDOrderChart)
        {
            OrderChart dbOrderChart = dbContext.OrderCharts.FirstOrDefault(x => x.IDOrderChart == IDOrderChart);
            if (dbOrderChart != null)
            {
                dbContext.OrderCharts.DeleteOnSubmit(dbOrderChart);
                dbContext.SubmitChanges();
            }
        }
        private OrderChart MapModelToDbObject(OrderChartModel orderChart)
        {
            OrderChart dbOrderChart = new OrderChart();

            if (orderChart != null)
            {
                dbOrderChart.IDOrderChart = orderChart.IDOrderChart;
                dbOrderChart.IDCustomerOrder = orderChart.IDCustomerOrder;
                dbOrderChart.IDProduct = orderChart.IDProduct;
                dbOrderChart.Quantity = orderChart.Quantity;
                dbOrderChart.Price = orderChart.Price;
                dbContext.SubmitChanges();

                return dbOrderChart;
            }
            return null;
        }
        private OrderChartModel MapDbObjectToModel(OrderChart dbOrderChart)
        {
            OrderChartModel orderChart = new OrderChartModel();

            if (dbOrderChart != null)
            {
                orderChart.IDOrderChart = dbOrderChart.IDOrderChart;
                orderChart.IDCustomerOrder = dbOrderChart.IDCustomerOrder;
                orderChart.IDProduct = dbOrderChart.IDProduct;
                orderChart.Quantity = dbOrderChart.Quantity;
                orderChart.Price = dbOrderChart.Price;
                dbContext.SubmitChanges();

                return orderChart;
            }
            return null;
        }
    }
}