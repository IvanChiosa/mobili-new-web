using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobiliNew.Web.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Find(params object[] keyValues);
        TEntity FindIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> QueryableIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindIncludingAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        void InsertAsync(TEntity entity);
    }
}
