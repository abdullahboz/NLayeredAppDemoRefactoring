using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolves.Ninject
{
    public class BusinessModule : NinjectModule
    {
        //Dependency Injection
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            //Bir daha üretilmesin diye insingletonscope'u ekledik.           
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            
        }
    }
}
