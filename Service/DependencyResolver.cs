using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DependencyResolver : NinjectModule
    {
        public override void Load()
        {
            Bind<RepositoryLayer.Repositories.Category.ICategoryRepository>().To<RepositoryLayer.Repositories.Category.CategoryRepository>();
            Bind<RepositoryLayer.Repositories.Product.IProductRepository>().To<RepositoryLayer.Repositories.Product.ProductRepository>();
        }
    }
}
