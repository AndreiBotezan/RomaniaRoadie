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
        private RomaniaRoadieDataContext dbContext;

        public CustomerOrderRepository()
        {
            dbContext = new RomaniaRoadieDataContext();
        }
        public CustomerOrderRepository(RomaniaRoadieDataContext _dbContext)
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
        public CustomerOrderModel GetCustomerOrderByID(Guid ID)
        {
            var customerOrder = dbContext.CustomerOrders.FirstOrDefault(x => x.IDCustomerOrder == ID);
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
            customerOrder.IDCustomerOrder = Guid.NewGuid();
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
                dbCustomerOrder.Phone = customerOrder.Phone;
                dbCustomerOrder.Details = customerOrder.Details;
                dbCustomerOrder.DateCreated = customerOrder.DateCreated;
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
        private CustomerOrderModel MapDbObjectToModel(CustomerOrder dbCustomerOrder)
        {
            CustomerOrderModel customerOrder = new CustomerOrderModel();

            if (dbCustomerOrder != null)
            {
                customerOrder.IDCustomerOrder = dbCustomerOrder.IDCustomerOrder;
                customerOrder.IDCustomer = dbCustomerOrder.IDCustomer;
                customerOrder.Adress = dbCustomerOrder.Adress;
                customerOrder.City = dbCustomerOrder.City;
                customerOrder.Phone = dbCustomerOrder.Phone;
                customerOrder.Details = dbCustomerOrder.Details;
                customerOrder.DateCreated = dbCustomerOrder.DateCreated;
                dbContext.SubmitChanges();

                return customerOrder;
            }
            return null;
        }
        private CustomerOrder MapModelToDbObject(CustomerOrderModel customerOrder)
        {
            CustomerOrder dbCustomerOrder = dbContext.CustomerOrders
                .FirstOrDefault(x => x.IDCustomerOrder == customerOrder.IDCustomerOrder);
            if (dbCustomerOrder != null)
            {
                dbCustomerOrder.IDCustomerOrder = customerOrder.IDCustomerOrder;
                dbCustomerOrder.IDCustomer = customerOrder.IDCustomer;
                dbCustomerOrder.Adress = customerOrder.Adress;
                dbCustomerOrder.City = customerOrder.City;
                dbCustomerOrder.Phone = customerOrder.Phone;
                dbCustomerOrder.Details = customerOrder.Details;
                dbCustomerOrder.DateCreated = customerOrder.DateCreated;
                dbContext.SubmitChanges();

                return dbCustomerOrder;
            }
            return null;
        }
    }
}