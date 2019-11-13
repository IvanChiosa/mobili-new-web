using Microsoft.EntityFrameworkCore;
using MobiliNew.Web.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobiliNew.Web.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context = null;
        private readonly DbSet<TEntity> _dbSet = null;

        public Repository(DbContext context)
        {
            this._context = context;
            _dbSet = context.Set<TEntity>();
        }
        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public TEntity FindIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Queryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(predicate);
        }

        public async Task<TEntity> FindIncludingAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Queryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet;
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Queryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async void InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> QueryableIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = Queryable();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Update(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}
