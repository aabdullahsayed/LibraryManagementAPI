using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LibraryManagementAPI.Interceptors;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        
       
        if (context == null) 
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

       
        var entries = context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || 
                        e.State == EntityState.Modified || 
                        e.State == EntityState.Deleted)
            .ToList();

        var auditLogs = new List<AuditLog>();

        foreach (var entry in entries)
        {
            
            if (entry.Entity is AuditLog)
            {
                continue;
            }

           
            var log = new AuditLog
            {
                EntityName = entry.Entity.GetType().Name,
                Action = entry.State.ToString(), 
                OccurredAt = DateTime.UtcNow
            };

            auditLogs.Add(log);
        }
        
        if (auditLogs.Any())
        {
            context.Set<AuditLog>().AddRange(auditLogs);
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}