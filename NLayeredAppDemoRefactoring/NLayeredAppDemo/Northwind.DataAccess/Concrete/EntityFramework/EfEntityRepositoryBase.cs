using Northwind.DataAccess.Abstract;
using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    // temel bir nesne ve gerekli operasyonları gerçekleştirecektir.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        /*TEntity ve TContext alıyoruz ona göre implementasyon yapıyoruz kim için yapıyoruz
         *IEntityRepository için yapıyoruz.
         *IEntityRepository ise Generic olduğu için tipini TEntity olarak belirliyoruz.
         *ve aşağıda implementasyonlar geliyor.
         *IEntityRepository olan kısıtlarımızı buradada tanımlayacağız.
         */
        where TEntity :class,IEntity, new()
        //class olmalı, IEntity'den implemente edilmeli ve newlenebilir olmalı.

        where TContext:DbContext,new()
        // DbContext'ten inherit edilmeli ve newlenebilir olmalı.

    
    {
        public void Add(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                //ilgili nesneye erişiyoruz.
                addedEntity.State = EntityState.Added;
                //yeni nesne bulanamayacağı için veritabanına eklenecek diye işaretliyoruz. 
                context.SaveChanges();
                // ve saveChanges'i çağırıyoruz.
                //savechangec(); implemente edenbir metottur.
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var DeletedEntity = context.Entry(entity);
                //ilgili nesneye erişiyoruz.
                DeletedEntity.State = EntityState.Deleted;
                // nesne veritabanında var ve nesneyi deleted olarak işaretle 
                context.SaveChanges();
                // ve saveChanges'i çağırıyoruz.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                //return context.Products.SingleOrDefault(p => p.ProductId == id);
                //filter tanımladığımız için eski kodumuz. çalışmayacaktır.
                return context.Set<TEntity>().SingleOrDefault(filter);
                //TEntity'ye set edip singleordefaul diyip filter'e göre getiriyoruz.

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //Yazacağımız kod çok basit olacak.
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //eğer filter null ise contexte'set<TEntity>diyerek bununla alaklı ürünleri getir diyoruz,
                //eğer null değilse context.Set diyerek buna where uygula where'i filter için uygula ve listeye çevir diyoruz.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
            var UpdatedEntity = context.Entry(entity);
            //ilgili nesneye erişiyoruz.
            UpdatedEntity.State = EntityState.Modified;
            // nesne veritabanında var ve nesneyi updated olarak işaretle 
            context.SaveChanges();
            // ve saveChanges'i çağırıyoruz.
            }
        }
    }
}
