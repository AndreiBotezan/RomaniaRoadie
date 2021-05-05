using RomaniaRoadie.Models;
using RomaniaRoadie.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomaniaRoadie.Repository
{
    public class CustomerOrderRepository
    {
        private RomaniaRoadieDataContextDataContext dbContext;
        private OrderChartRepository orderChartRepository = new OrderChartRepository();

        public CustomerOrderRepository()
        {
            dbContext = new RomaniaRoadieDataContextDataContext();
        }
        public CustomerOrderRepository(RomaniaRoadieDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<CustomerOrderModel> GetAllCustomerOrders()
        {
            List<CustomerOrderModel> customerOrdersList = new List<CustomerOrderModel>();
            foreach (CustomerOrder dbCustomerOrders in dbContext.CustomerOrders)
            {
                customerOrdersList.Add(MapDbObjectToModel(dbCustomerOrders));
            }
            return customerOrdersList;
        }
        public CustomerOrderModel GetCustomerOrderByID(Guid IDCustomerOrder)
        {
            var customerOrder = dbContext.CustomerOrders.FirstOrDefault(x => x.IDCustomerOrder == IDCustomerOrder);
            return MapDbObjectToModel(customerOrder);
        }
        public List<CustomerOrderModel> GetCustomerOrderByCustomer(Guid IDCustomer)
        {
            List<CustomerOrderModel> customerOrdersList = new List<CustomerOrderModel>();
            foreach (CustomerOrder dbCustomerOrder in dbContext.CustomerOrders.Where(
                x => x.IDCustomer == IDCustomer))
            {
                customerOrdersList.Add(MapDbObjectToModel(dbCustomerOrder));
            }
            return customerOrdersList;
        }
        public void InsertCustomerOrder(CustomerOrderModel customerOrder)
        {
            dbContext.CustomerOrders.InsertOnSubmit(MapModelToDbObject(customerOrder));
            dbContext.SubmitChanges();
        }
        public void UpdateCustomerOrder(CustomerOrderModel customerOrder)
        {
            CustomerOrder dbCustomerOrder = dbContext.CustomerOrders
                .FirstOrDefault(x => x.IDCustomerOrder == customerOrder.IDCustomerOrder);
            if (dbCustomerOrder != null)
            {
                dbCustomerOrder.IDCustomerOrder = customerOrder.IDCustomerOrder;
                dbCustomerOrder.IDCustomer = customerOrder.IDCustomer;
                dbCustomerOrder.Adress = customerOrder.Adress;
                dbCustomerOrder.City = customerOrder.City;
                dbCustomerOrder.State = customerOrder.State;
                dbCustomerOrder.Phone = customerOrder.Phone;
                dbCustomerOrder.Details = customerOrder.Details;
                dbCustomerOrder.DateCreated = customerOrder.DateCreated;
                dbCustomerOrder.OrderTotal = customerOrder.OrderTotal;

                dbContext.SubmitChanges();
            }
        }
        public void DeleteCustomerOrder(Guid IDCustomerOrder)
        {
            CustomerOrder customerOrderDb = dbContext.CustomerOrders
               .FirstOrDefault(x => x.IDCustomerOrder == IDCustomerOrder);
            if (customerOrderDb != null)
            {
                dbContext.CustomerOrders.DeleteOnSubmit(customerOrderDb);
                dbContext.SubmitChanges();
            }
        }
        public CustomerOrderModel MapDbObjectToModel(CustomerOrder dbCustomerOrder)
        {
            CustomerOrderModel customerOrder = new CustomerOrderModel();

            if (dbCustomerOrder != null)
            {
                customerOrder.IDCustomerOrder = dbCustomerOrder.IDCustomerOrder;
                customerOrder.IDCustomer = dbCustomerOrder.IDCustomer;
                customerOrder.Adress = dbCustomerOrder.Adress;
                customerOrder.City = dbCustomerOrder.City;
                customerOrder.State = dbCustomerOrder.State;
                customerOrder.Phone = dbCustomerOrder.Phone;
                customerOrder.Details = dbCustomerOrder.Details;
                customerOrder.DateCreated = dbCustomerOrder.DateCreated;
                customerOrder.OrderTotal = dbCustomerOrder.OrderTotal;

                return customerOrder;
            }
            return null;
        }
        public CustomerOrder MapModelToDbObject(CustomerOrderModel customerOrder)
        {
            CustomerOrder dbCustomerOrder = new CustomerOrder();
            if (customerOrder != null)
            {
                dbCustomerOrder.IDCustomerOrder = customerOrder.IDCustomerOrder;
                dbCustomerOrder.IDCustomer = customerOrder.IDCustomer;
                dbCustomerOrder.Adress = customerOrder.Adress;
                dbCustomerOrder.City = customerOrder.City;
                dbCustomerOrder.State = customerOrder.State;
                dbCustomerOrder.Phone = customerOrder.Phone;
                dbCustomerOrder.Details = customerOrder.Details;
                dbCustomerOrder.DateCreated = customerOrder.DateCreated;
                dbCustomerOrder.OrderTotal = customerOrder.OrderTotal;

                return dbCustomerOrder;
            }
            return null;
        }
        public Guid GetIDCustomerOrder()
        {
            CustomerOrderModel customerOrderModel = MapDbObjectToModel(dbContext.CustomerOrders.OrderByDescending(x => x.DateCreated).FirstOrDefault());
            if (customerOrderModel == null)
            {
                return Guid.NewGuid();
            }
            else
            {
                if (customerOrderModel.IDCustomerOrder == orderChartRepository.GetLastOrder())
                {
                    return Guid.NewGuid();
                }
                return orderChartRepository.GetLastOrder();
            }
        }
    }
}