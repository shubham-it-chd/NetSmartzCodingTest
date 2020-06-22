using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace NetSmartzCodingTest.Controllers
{
    public class ProductController : Controller
    {

        ServiceLayer.Services.Product.IProductService _IProductService;
        ServiceLayer.Services.Category.ICategoryService _ICategoryService;
        public ProductController(ServiceLayer.Services.Product.IProductService _ProductService, ServiceLayer.Services.Category.ICategoryService _iCategoryService)
        {
            _IProductService = _ProductService;
            _ICategoryService = _iCategoryService;
        }

        public ActionResult Index()
        {
            var products = _IProductService.GetProduct();
            return View(products);
        }

        public ActionResult Create()
        {
            ViewBag.Category = _ICategoryService.GetCategoryDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel pm)
        {
            try
            {
                var result = _IProductService.AddProduct(pm);
                if (!result)
                {
                    return View("CatgoryCreateEdit");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ProductModel obj = new ProductModel();
            if (id != 0)
            {
                obj = _IProductService.EditProduct(id);
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _IProductService.DeleteProduct(id);
            return RedirectToAction("Index");
        }


    }
}