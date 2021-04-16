﻿using RomaniaRoadie.Models;
using RomaniaRoadie.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomaniaRoadie.Repository
{
    public class CustomerRepository
    {
        private RomaniaRoadieDataContext dbContext;

        public CustomerRepository()
        {
            dbContext = new RomaniaRoadieDataContext();
        }

        public CustomerRepository(RomaniaRoadieDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customersList = new List<CustomerModel>();
            foreach (Customer dbCustomer in dbContext.Customers)
            {
                customersList.Add(MapDbObjectToModel(dbCustomer));
            }
            return customersList;
        }
        public CustomerModel GetCustomerByID(Guid ID)
        {
            var customer = dbContext.Customers.FirstOrDefault(x => x.IDCustomer == ID);
            return MapDbObjectToModel(customer);
        }
        public List<CustomerModel> GetCustomerByUserName(string title)
        {
            List<CustomerModel> customersList = new List<CustomerModel>();
            foreach (Customer dbCustomer in dbContext.Customers.Where(
                x => x.UserName == title))
            {
                customersList.Add(MapDbObjectToModel(dbCustomer));
            }
            return customersList;
        }
        public void InsertCustomer(CustomerModel customer)
        {
            customer.IDCustomer = Guid.NewGuid();
            dbContext.Customers.InsertOnSubmit(MapModelToDbObject(customer));
            dbContext.SubmitChanges();
        }
        public void UpdateCustomer(CustomerModel customer)
        {
            Customer dbCustomer = dbContext.Customers
                .FirstOrDefault(x => x.IDCustomer == customer.IDCustomer);
            if (dbCustomer != null)
            {
                dbCustomer.IDCustomer = customer.IDCustomer;
                dbCustomer.UserName = customer.UserName;
                dbCustomer.FirstName = customer.FirstName;
                dbCustomer.LastName = customer.LastName;
                dbCustomer.Email = customer.Email;
                dbContext.SubmitChanges();
            }
        }
        public void DeleteCustomer(Guid ID)
        {
            Customer customerDb = dbContext.Customers
               .FirstOrDefault(x => x.IDCustomer == ID);
            if (customerDb != null)
            {
                dbContext.Customers.DeleteOnSubmit(customerDb);
                dbContext.SubmitChanges();
            }
        }

        private Customer MapModelToDbObject(CustomerModel customer)
        {
            Customer dbCustomer = new Customer();
            if (customer != null)
            {
                dbCustomer.IDCustomer = customer.IDCustomer;
                dbCustomer.UserName = customer.UserName;
                dbCustomer.FirstName = customer.FirstName;
                dbCustomer.LastName = customer.LastName;
                dbCustomer.Email = customer.Email;
                dbContext.SubmitChanges();

                return dbCustomer;
            }
            return null;
        }

        private CustomerModel MapDbObjectToModel(Customer dbCustomer)
        {
            CustomerModel customer = new CustomerModel();

            if (dbCustomer != null)
            {
                customer.IDCustomer = dbCustomer.IDCustomer;
                customer.UserName = dbCustomer.UserName;
                customer.FirstName = dbCustomer.FirstName;
                customer.LastName = dbCustomer.LastName;
                customer.Email = dbCustomer.Email;
                dbContext.SubmitChanges();

                return customer;
            }
            return null;
        }
    }
}