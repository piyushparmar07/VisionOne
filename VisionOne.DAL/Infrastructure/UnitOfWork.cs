using VisionOne.DAL.Data;
using VisionOne.DAL.Infrastructure;

namespace VisionOne.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMainDbContext _databaseContext;
        private bool _disposed;

        public UnitOfWork(IMainDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository Repository()
        {
            return new RepositoryBase(_databaseContext);
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _databaseContext.SaveChangesAsync(cancellationToken);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _databaseContext.Dispose();
            _disposed = true;
        }
    }
}
