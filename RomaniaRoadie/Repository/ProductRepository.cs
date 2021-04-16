using RomaniaRoadie.Models;
using RomaniaRoadie.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RomaniaRoadie.Repository
{
    public class ProductRepository
    {
        private RomaniaRoadieDataContext dbContext;

        public ProductRepository()
        {
            dbContext = new RomaniaRoadieDataContext();
        }

        public ProductRepository(RomaniaRoadieDataContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productsList = new List<ProductModel>();
            foreach (Product dbProduct in dbContext.Products)
            {
                productsList.Add(MapDbObjectToModel(dbProduct));
            }
            return productsList;
        }

        public ProductModel GetProductByID(Guid ID)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.IDProduct == ID);
            return MapDbObjectToModel(product);
        }
        public List<ProductModel> GetProductsByManufacturer(string manufacturer)
        {
            List<ProductModel> productsList = new List<ProductModel>();
            foreach (Product dbProducts in dbContext.Products.Where(
                x => x.Manufacturer == manufacturer))
            {
                productsList.Add(MapDbObjectToModel(dbProducts));
            }
            return productsList;
        }
        public void InsertProduct(ProductModel product)
        {
            product.IDProduct = Guid.NewGuid();
            dbContext.Products.InsertOnSubmit(MapModelToDbObject(product));
            dbContext.SubmitChanges();
        }
        public void UpdateProduct(ProductModel product)
        {
            Product dbProduct = dbContext.Products
                .FirstOrDefault(x => x.IDProduct == product.IDProduct);
            if (dbProduct != null)
            {
                dbProduct.IDProduct = product.IDProduct;
                dbProduct.Manufacturer = product.Manufacturer;
                dbProduct.Model = product.Model;
                dbProduct.Description = product.Description;

                dbContext.SubmitChanges();
            }
        }
        public void DeleteProduct(Guid ID)
        {
            Product dbProduct = dbContext.Products
               .FirstOrDefault(x => x.IDProduct == ID);
            if (dbProduct != null)
            {
                dbContext.Products.DeleteOnSubmit(dbProduct);
                dbContext.SubmitChanges();
            }
        }
        private Product MapModelToDbObject(ProductModel product)
        {
            Product dbProduct = new Product();

            if (product != null)
            {
                dbProduct.IDProduct = product.IDProduct;
                dbProduct.Manufacturer = product.Manufacturer;
                dbProduct.Model = product.Model;
                dbProduct.Description = product.Description;
                dbContext.SubmitChanges();

                return dbProduct;
            }
            return null;
        }

        private ProductModel MapDbObjectToModel(Product dbProduct)
        {
            ProductModel product = new ProductModel();

            if (dbProduct != null)
            {
                product.IDProduct = dbProduct.IDProduct;
                product.Manufacturer = dbProduct.Manufacturer;
                product.Model = dbProduct.Model;
                product.Description = dbProduct.Description;
                dbContext.SubmitChanges();

                return product;
            }
            return null;
        }
    }
}