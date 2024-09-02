using BeFit.Application.Repositories;
using BeFit.Persistence.Contexts;

namespace BeFit.Persistence.Repositories
{
    public class UnitOfWork(BeFitDbContext context) : IUnitOfWork
    {
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await context.DisposeAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
