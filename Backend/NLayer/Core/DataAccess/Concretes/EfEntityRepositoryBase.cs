using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DataAccess.Abstracts;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Entities.Authentication;
using System.Linq.Expressions;

namespace NLAyer.Core.DataAccess.Concretes.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : IdentityDbContext<AppUser, AppRole, int>, new() 
{
    public void Add(TEntity entity)
    {
        CrudOperation(entity, EntityState.Added);
    }

    public void Update(TEntity entity)
    {
        CrudOperation(entity, EntityState.Modified);
    }
    public void Delete(TEntity entity)
    {
        CrudOperation(entity, EntityState.Deleted);
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
    private void CrudOperation(TEntity entity, EntityState entityState)
    {
        try
        {
            switch (entityState)
            {
                case EntityState.Added: Crud(entity, EntityState.Added); break;
                case EntityState.Deleted: Crud(entity, EntityState.Deleted); break;
                case EntityState.Modified: Crud(entity, EntityState.Modified); break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
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
}
