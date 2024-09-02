namespace BeFit.Application.Repositories
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();

        void Dispose();
        Task DisposeAsync();

    }
}
