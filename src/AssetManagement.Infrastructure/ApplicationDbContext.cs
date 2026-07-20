using AssetManagement.Application.Exceptions;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Infrastructure.Auditing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using System.Text.Json;

namespace AssetManagement.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options, IPublisher publisher) : DbContext(options), IUnitOfWork
{
    private readonly IPublisher _publisher = publisher;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        
            
                
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }




    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    try
    //    {
    //        var result = await base.SaveChangesAsync(cancellationToken);

    //        await PublishDomainEventsAsync();

    //        return result;
    //    }
    //    catch (DbUpdateConcurrencyException ex)
    //    {
    //        throw new ConcurrencyException("Concurrency exception occurred.", ex);
    //    }
    //}

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    public override async Task<int> SaveChangesAsync(
     CancellationToken cancellationToken = default)
    {
        var auditEntries = new List<AuditLog>();

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog)
                continue;

            if (entry.State == EntityState.Unchanged ||
                entry.State == EntityState.Detached)
                continue;

            var changes = new Dictionary<string, object>();

            foreach (var property in entry.Properties)
            {
                if (entry.State == EntityState.Modified &&
                    !Equals(property.OriginalValue, property.CurrentValue))
                {
                    changes[property.Metadata.Name] = new
                    {
                        Old = property.OriginalValue,
                        New = property.CurrentValue
                    };
                }
            }

            string currentUser = "12345";

            var audit = AuditLog.Create(
                entry.Metadata.ClrType.Name,
                entry.Property("Id").CurrentValue?.ToString() ?? string.Empty,
                entry.State.ToString(),
                currentUser,
                changes);

            auditEntries.Add(audit);
        }

        AuditLogs.AddRange(auditEntries);

        return await base.SaveChangesAsync(cancellationToken);
    }
}