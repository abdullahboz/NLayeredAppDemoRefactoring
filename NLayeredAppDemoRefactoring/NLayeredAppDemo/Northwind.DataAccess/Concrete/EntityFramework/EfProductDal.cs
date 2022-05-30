using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    // Data access'te veritabanı ile ilgili bu işlemler yapılır. 
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
        // inherit ediyoruz 
        // interfaceler implement edilir, classlar, abstract classlar innheritance
    
    {
        
    }
}
