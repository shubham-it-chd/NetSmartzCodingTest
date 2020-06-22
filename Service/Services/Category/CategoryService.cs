using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models;

namespace ServiceLayer.Services.Category
{
    public class CategoryService : ICategoryService
    {
        RepositoryLayer.Repositories.Category.ICategoryRepository _ICategoryRepository = null;
        private IValidationDictionary _validatonDictionary;


        public CategoryService(IValidationDictionary validationDictionary, RepositoryLayer.Repositories.Category.ICategoryRepository _iCategoryRepository)
        {
            _ICategoryRepository = _iCategoryRepository;
            _validatonDictionary = validationDictionary;
            // _modelState = modelState;

        }

        public List<CategoryModel> GetCategories()
        {
            return _ICategoryRepository.GetCategories();
        }

        public bool AddCategory(CategoryModel cm)
        {
            // Validation logic
            if (!ValidateProduct(cm))
                return false;

            // Database logic
            try
            {
                return _ICategoryRepository.AddCategory(cm);
            }
            catch
            {
                return false;
            }

        }

        protected bool ValidateProduct(CategoryModel cm)
        {
            if (string.IsNullOrEmpty(cm.Name))
                _validatonDictionary.AddError("Name", "Name is required.");

            return _validatonDictionary.IsValid;
        }
        public CategoryModel EditCategory(int id)
        {
            return _ICategoryRepository.EditCategory(id);
        }
        public void DeleteCategory(int id)
        {
            _ICategoryRepository.DeleteCategory(id);
        }

        public List<SelectListItem> GetCategoryDropDown()
        {
            var result = _ICategoryRepository.GetCategories();

          return  result.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }

    }
}
