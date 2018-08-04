using System;
using System.Linq;
using System.Linq.Expressions;

namespace SkSampleDataAccessLayer.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        void Save();
    }
}