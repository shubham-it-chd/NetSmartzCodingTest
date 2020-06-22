using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models;

namespace RepositoryLayer.Repositories.Category
{
    public interface ICategoryRepository
    {
        List<CategoryModel> GetCategories();
        bool AddCategory(CategoryModel cm);
        CategoryModel EditCategory(int Id);
        void DeleteCategory(int id);
    }
}
