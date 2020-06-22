using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models;

namespace ServiceLayer.Services.Product
{
    public class ProductService : IProductService
    {

        RepositoryLayer.Repositories.Product.IProductRepository _IProductRepository = null;
        private ModelStateDictionary _modelState;
        private IValidationDictionary _validatonDictionary;

        public ProductService(IValidationDictionary validationDictionary, RepositoryLayer.Repositories.Product.IProductRepository _iProductRepository)
        {
            _IProductRepository = _iProductRepository;
            _validatonDictionary = validationDictionary;
            // _modelState = modelState;

        }

        public List<ProductModel> GetProduct()
        {
            return _IProductRepository.GetProduct();
        }

        public bool AddProduct(ProductModel cm)
        {
            // Validation logic
            if (!ValidateProduct(cm))
                return false;

            // Database logic
            try
            {
                return _IProductRepository.AddProduct(cm);
            }
            catch
            {
                return false;
            }

        }

        protected bool ValidateProduct(ProductModel pm)
        {
            if (string.IsNullOrEmpty(pm.Name))
                _validatonDictionary.AddError("Name", "Name is required.");

            return _validatonDictionary.IsValid;
        }
        public ProductModel EditProduct(int id)
        {
            return _IProductRepository.EditProduct(id);
        }
        public void DeleteProduct(int id)
        {
            _IProductRepository.DeleteProduct(id);
        }

    }
}
