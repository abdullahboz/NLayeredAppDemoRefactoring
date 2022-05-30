using Northwind.Business.Abstract;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Northwind.Business.Utilities;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        //EfProductDal _productDal = new EfProductDal();
        // bu kod kesinlikle hatalıdır, bağımlı yapar.

        //DependencyInjection yapıyoruz.
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        //Productmanager new'lendiğinde bir IProductDal türünde nesne istiyoruz.
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }
        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Silme İşlemi Gerçekleşemedi!");

            }
            // Son kullanıcıya bu hatayı gösteriyoruz.
        }

        public List<Product> GetAll()
        {
            //Business Code
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
            //delege = tümünü getir ama p için CategoryId'si  benim sana veridğim categoryId'si olanları döndür diyoruz.
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
            // Case sensitivi olan sistemlere gecişlerde zaafiyet yaşamamak için kullanılmalıdır(defensive programming). 
        }

        
    }
}
