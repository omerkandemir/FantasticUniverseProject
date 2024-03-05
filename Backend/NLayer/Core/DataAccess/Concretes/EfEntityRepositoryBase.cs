using Microsoft.EntityFrameworkCore;
using NLayer.Core.DataAccess.Abstracts;
using NLayer.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLAyer.Core.DataAccess.Concretes.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            try
            {
                Crud(entity,EntityState.Added);
            }
            catch 
            {
                throw new Exception("Ekleme gerçekleşemedi");
            }
        }
        public void Update(TEntity entity)
        {
            try
            {
                Crud(entity, EntityState.Modified);
            }
            catch
            {
                throw new Exception("Güncelleme gerçekleşemedi");
            }
        }
        public void Delete(TEntity entity)
        {
            try
            {
                Crud(entity,EntityState.Deleted);
            }
            catch 
            {
                throw new Exception("Silme gerçekleşemedi");
            }
            
        }

        private static void Crud(TEntity entity, EntityState entityState)
        {
            using (TContext context = new TContext())
            {
                var crudEntity = context.Entry(entity);
                crudEntity.State = entityState;
                context.SaveChanges();
            }
        }
        

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filtre nullsa TEntity e abone et. Null değilse Where uygula onu da listeyi çevirmeyi unutma :)
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

    }
}
