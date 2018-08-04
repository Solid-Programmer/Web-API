using System;
using System.Data.Entity;
using System.Linq;
using SkSampleDataAccessLayer.DataAccess.Interfaces;

namespace SkSampleDataAccessLayer.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        protected readonly SkAppContext Context;
        protected DbSet<TEntity> Entities;

        protected BaseRepository(SkAppContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {

            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query;
        }

        public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
            return query;
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

    }
}