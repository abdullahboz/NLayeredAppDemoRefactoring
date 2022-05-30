using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T>where T : class,IEntity,new()
        // Burada generic kısıtlar koyuyoruz.
        // T reference type olmalı, ientity'den implemente etmeli, new'lenebilmeli.
        
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        //Linq mimarisi ile kullanılan burada bir T veriyoruz ve dönüş türü olarak bool alıyoruz bunada filter diyoruz. 
        //kullanıcı filter vermek zorunda değil vermezse tümü gelecek verirse filtrelenen gelecek.
        T Get(Expression<Func<T, bool>> filter);
        // burada mutlaka bir filtre istiyoruz. ürün neye göre gelsin mantığı ile.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
