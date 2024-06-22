using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
    public TEntity Get(
        Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        using (TContext context = new TContext())
        {
            IQueryable<TEntity> query = Query(include, context);

            return query.FirstOrDefault(filter);
        }
    }

    public List<TEntity> GetAll(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        using (TContext context = new TContext())
        {
            IQueryable<TEntity> query = Query(include, context);

            return filter == null ? query.ToList() : query.Where(filter).ToList();
        }
    }

    private IQueryable<TEntity> Query(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include, TContext context)
    {
        IQueryable<TEntity> query = context.Set<TEntity>();

        if (include != null)
        {
            query = include(query);
        }

        return query;
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
