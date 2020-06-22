using AutoMapper;
using Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {


        #region Initialize

        UnityOfWork uow = null;
        IMapper mapper = null;
        NetSmartzCodeTestEntities obj = new NetSmartzCodeTestEntities();
        public ProductRepository()
        {
            if (uow == null)
            {
                uow = new UnityOfWork(new NetSmartzCodeTestEntities());
            }
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductModel, Repository.Data.Product>();
            }).CreateMapper();
        }
        #endregion  

        public List<ProductModel> GetProduct()
        {
            var result = uow.Repository<Repository.Data.Product>().GetAll();
            List<ProductModel> productList = mapper.Map<List<ProductModel>>(result);
            return productList;
        }
        public bool AddProduct(ProductModel cm)
        {
            var result = mapper.Map<Repository.Data.Product>(cm);
            obj.Products.Add(result);
            obj.SaveChanges();
            return true;
        }

        public ProductModel EditProduct(int Id)
        {
            var result = obj.Products.Find(Id);
            return mapper.Map<ProductModel>(result);
        }

        public void DeleteProduct(int Id)
        {
            var result = obj.Products.Find(Id);
            obj.Products.Remove(result);
            obj.SaveChanges();
        }

    }
}
