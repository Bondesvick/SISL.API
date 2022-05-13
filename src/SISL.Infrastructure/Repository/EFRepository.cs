using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SISL.Core.Interfaces;
using SISL.Infrastructure.Data;

namespace SISL.Infrastructure.Repository
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<EfRepository<T>> _logger;
        private readonly DbSet<T> _entitySet;

        public EfRepository(AppDbContext dbContext, ILogger<EfRepository<T>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _entitySet = dbContext.Set<T>();
        }

        public virtual async Task<T> GetById(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task Add(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)

            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> IncludeQuery(string[] includes)
        {
            IQueryable<T> query = _entitySet;
            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}