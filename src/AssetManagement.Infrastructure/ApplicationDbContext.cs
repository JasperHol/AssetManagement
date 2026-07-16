using AssetManagement.Application.Exceptions;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Statuses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace AssetManagement.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options, IPublisher publisher) : DbContext(options), IUnitOfWork
{
    private readonly IPublisher _publisher = publisher;

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{


    //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    //    base.OnModelCreating(modelBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        //var nameConverter = new ValueConverter<Name, string>(
        //    v => v == null ? null : v.Value,
        //    v => v == null ? null : new Name(v)
        //);

        //var nameComparer = new ValueComparer<Name>(
        //    (Expression<Func<Name, Name, bool>>)((l, r) => l == null ? r == null : l.Value == r.Value),
        //    (Expression<Func<Name, int>>)(v => v == null ? 0 : v.Value.GetHashCode()),
        //    (Expression<Func<Name, Name>>)(v => v == null ? null : new Name(v.Value))
        //);

        //modelBuilder.Entity<Status>()
        //    .Property(s => s.Name)
        //    .HasConversion(nameConverter)
        //    .Metadata.SetValueComparer(nameComparer);

        //modelBuilder.Entity<Status>().HasData(
        //    new { Id = 1, Name = "CreateAsset", StatusTransitionId = 1 },
        //    new { Id = 2, Name = "Stock", StatusTransitionId = 2 },
        //    new { Id = 3, Name = "InUse", StatusTransitionId = 3 },
        //    new { Id = 4, Name = "AssetInServiceRepair", StatusTransitionId = 4 },
        //    new { Id = 5, Name = "ReportedStolenMissing", StatusTransitionId = 5 },
        //    new { Id = 6, Name = "ObsoleteAsset", StatusTransitionId = 6 },
        //    new { Id = 7, Name = "AssetDisposed", StatusTransitionId = 7 },
        //    new { Id = 8, Name = "AssetLost", StatusTransitionId = 8 }
        //);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

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
}