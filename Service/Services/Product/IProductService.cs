using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace ServiceLayer.Services.Product
{
    public interface IProductService
    {
        List<ProductModel> GetProduct();
        bool AddProduct(ProductModel cm);
        ProductModel EditProduct(int id);
        void DeleteProduct(int id);
    }
}
