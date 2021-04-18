﻿using RomaniaRoadie.Models;
using RomaniaRoadie.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RomaniaRoadie.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        // GET: Product
        public ActionResult Index()
        {
            List<ProductModel> products = productRepository.GetAllProducts();
            
            return View("Index", products);
        }

        // GET: Product/Details/5
        public ActionResult Details(Guid id)
        {
            ProductModel productModel = productRepository.GetProductByID(id);
            
            return View("ProductDetails", productModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ProductModel productModel = new ProductModel();
                UpdateModel(productModel);
                productRepository.InsertProduct(productModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProduct");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(Guid id)
        {
            ProductModel productModel = productRepository.GetProductByID(id);
            return View("EditProduct", productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                ProductModel productModel = new ProductModel();
                UpdateModel(productModel);
                productRepository.UpdateProduct(productModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditProduct");
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(Guid id)
        {
            ProductModel productModel = productRepository.GetProductByID(id);
            return View("DeleteProduct", productModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                productRepository.DeleteProduct(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProduct");
            }
        }
    }
}
