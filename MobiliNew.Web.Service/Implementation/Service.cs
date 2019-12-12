using MobiliNew.Web.Data.Models;
using MobiliNew.Web.Repository.Interfaces;
using MobiliNew.Web.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobiliNew.Web.Service.Implementation
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _repository.FindAsync(keyValues);
        }

        public TEntity FindIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.FindIncluding(predicate, includeProperties);
        }

        public async Task<TEntity> FindIncludingAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _repository.FindIncludingAsync(predicate, includeProperties);
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.Get();
        }

        public IEnumerable<TEntity> Get(IEnumerable<Product> cat)
        {
            return _repository.Get();
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.GetBy(predicate, includeProperties);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _repository.Queryable();
        }

        public IQueryable<TEntity> QueryableIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _repository.QueryableIncluding(includeProperties);
        }
    }
}
