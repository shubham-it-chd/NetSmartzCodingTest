using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RepositoryLayer.Repositories.Product
{
     public interface IProductRepository
    {
        List<ProductModel> GetProduct();
        bool AddProduct(ProductModel cm);
        ProductModel EditProduct(int id);
        void DeleteProduct(int id);
    }
}
