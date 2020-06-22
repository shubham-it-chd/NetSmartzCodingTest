using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace NetSmartzCodingTest.Controllers
{
    public class CategoryController : Controller 
    {
        ServiceLayer.Services.Category.ICategoryService _ICategoryService;
         
        public CategoryController(ServiceLayer.Services.Category.ICategoryService _iCategoryService)
        {
            _ICategoryService = _iCategoryService;
        }


        // GET: Category
        public ActionResult Index()
        {
            var Categories = _ICategoryService.GetCategories();
            return View();
        }


        [HttpPost]
        public ActionResult GetAllCategories()
        {
            var Categories = _ICategoryService.GetCategories();

            return PartialView("CategoryList",Categories);
        }




        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        // GET: Category/Create
        public ActionResult CreateOrEdit()
        {
            return PartialView("CatgoryCreateEdit", new CategoryModel());
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryModel cm)
        {
            try
            {
                // TODO: Add insert logic here
                var result = _ICategoryService.AddCategory(cm);
                if(!result)
                {
                    return View("CatgoryCreateEdit");
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            CategoryModel obj = new CategoryModel();
            if (id != 0)
            {
                obj = _ICategoryService.EditCategory(id);
            }
            return View(obj);
        }

        // POST: Category/Edit/5
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            _ICategoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
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
