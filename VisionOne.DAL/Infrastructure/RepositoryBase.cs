using System.Data;
using System.Linq.Expressions;
using VisionOne.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using VisionOne.Core;

namespace VisionOne.DAL.Infrastructure
{
    public class RepositoryBase : IRepository
    {
        private readonly IMainDbContext _dbContext;


        public RepositoryBase(IMainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetById<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> FindQueryable<T>(Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().Where(expression);
            return orderBy != null ? orderBy(query) : query;
        }

        public Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
            where T : class
        {
            var query = expression != null ? _dbContext.Set<T>().Where(expression) : _dbContext.Set<T>();
            return orderBy != null
                ? orderBy(query).ToListAsync(cancellationToken)
                : query.ToListAsync(cancellationToken);
        }

        public Task<List<T>> FindAllAsync<T>(CancellationToken cancellationToken) where T : BaseEntity
        {
            return _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression, string includeProperties) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();

            query = includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));

            return query.SingleOrDefaultAsync(expression);
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}