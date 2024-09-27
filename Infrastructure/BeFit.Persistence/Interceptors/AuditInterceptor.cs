using BeFit.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BeFit.Persistence.Interceptors;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context != null)
        {
            foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                if (entry.State == EntityState.Modified)
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
            }
        }
        return base.SavingChanges(eventData, result);
    }
}


