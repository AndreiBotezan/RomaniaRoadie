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
        private RomaniaRoadieDataContextDataContext dbContext;

        public OrderChartRepository()
        {
            dbContext = new RomaniaRoadieDataContextDataContext();
        }

        public OrderChartRepository(RomaniaRoadieDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<OrderChartModel> GetAllOrderCharts(Guid ID)
        {
            List<OrderChartModel> orderChartList = new List<OrderChartModel>();
            foreach (OrderChart dbOrderChart in dbContext.OrderCharts.Where(x => x.IDCustomer == ID))
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
                dbOrderChart.IDCustomer = orderChart.IDCustomer;
                dbOrderChart.Quantity = orderChart.Quantity;
                dbOrderChart.TotalPrice = orderChart.TotalPrice;
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
                dbOrderChart.IDCustomer = orderChart.IDCustomer;
                dbOrderChart.Quantity = orderChart.Quantity;
                dbOrderChart.TotalPrice = orderChart.TotalPrice;
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
                orderChart.IDCustomer = dbOrderChart.IDCustomer;
                orderChart.Quantity = dbOrderChart.Quantity;
                orderChart.TotalPrice = dbOrderChart.TotalPrice;
                dbContext.SubmitChanges();

                return orderChart;
            }
            return null;
        }
        public Guid GetLastOrder()
        {
            return dbContext.OrderCharts.OrderByDescending(x => x.IDOrderChart)
                .FirstOrDefault().IDCustomerOrder;
        }
        /*public Guid GetLastCustomerOrder()
        {
            return dbContext.CustomerOrders.OrderByDescending(x => x.IDCustomerOrder)
                .FirstOrDefault().IDCustomerOrder;

        }*/
        public decimal GetOrderTotal(Guid IDCustomers)
        {
            var decimalTotal = 0M;
            var check = false;
            var y = dbContext.CustomerOrders.OrderByDescending(x => x.IDCustomerOrder).FirstOrDefault();
            Guid? test = null;
            if (y != null)
            {
                test = y.IDCustomerOrder;
            }
            List<OrderChartModel> orderChartModels = GetAllOrderCharts(IDCustomers);

            foreach (var item in orderChartModels)
            {
                if (test != null)
                {
                    if (check == true)
                    {
                        decimalTotal += item.TotalPrice;
                    }
                    if (item.IDCustomerOrder == test)
                    {
                        check = true;
                    }
                }
                else
                {
                    decimalTotal += item.TotalPrice;
                }
            }
            return decimalTotal;
        }
    }
}