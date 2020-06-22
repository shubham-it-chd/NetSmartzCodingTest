
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models;

namespace ServiceLayer.Services.Category
{
    public interface ICategoryService
    {
        List<CategoryModel> GetCategories();
        bool AddCategory(CategoryModel cm);
        CategoryModel EditCategory(int id);
        void DeleteCategory(int id);
        List<SelectListItem> GetCategoryDropDown();

    }
}
