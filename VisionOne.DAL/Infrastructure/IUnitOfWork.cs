namespace VisionOne.DAL.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository();
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
