using AutoMapper;
using Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RepositoryLayer.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {

        #region Initialize

        UnityOfWork uow = null;
        IMapper mapper = null;
        NetSmartzCodeTestEntities obj = new NetSmartzCodeTestEntities();
        public CategoryRepository()
        {
            if (uow == null)
            {
                uow = new UnityOfWork(new NetSmartzCodeTestEntities());
            }
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CategoryModel, Repository.Data.Category>();
            }).CreateMapper();
        }
        #endregion  

        public List<CategoryModel> GetCategories()
        {
            var result = uow.Repository<Repository.Data.Category>().GetAll();
            List<CategoryModel> CategoryList = mapper.Map<List<CategoryModel>>(result);
            return CategoryList;
        }
        public bool AddCategory(CategoryModel cm)
        {
            var result = mapper.Map<Repository.Data.Category>(cm);
            obj.Categories.Add(result);
            obj.SaveChanges();
            return true;
        }

        public CategoryModel EditCategory(int Id)
        {
            var result = obj.Categories.Find(Id);
            return mapper.Map<CategoryModel>(result);
        }

        public void DeleteCategory(int Id)
        {
            var result = obj.Categories.Find(Id);
            obj.Categories.Remove(result);
            obj.SaveChanges();
        }

    }
}
