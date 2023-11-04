using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using VisionOne.Core;

namespace VisionOne.DAL.Infrastructure
{
    public interface IRepository
    {
        Task<T?> GetById<T>(int id) where T : BaseEntity;
        IQueryable<T> FindQueryable<T>(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : BaseEntity;
        Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default) where T : class;
        Task<List<T>> FindAllAsync<T>(CancellationToken cancellationToken) where T : BaseEntity;
        Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression, string includeProperties) where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void UpdateRange<T>(IEnumerable<T> entities) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
    }
}
