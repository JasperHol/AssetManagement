using AssetManagement.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Infrastructure.Repositories;

internal abstract class Repository<T>
    where T : Entity
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
          .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
          //.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id, cancellationToken);
          //.FirstOrDefaultAsync(e => Microsoft.EntityFrameworkCore.EF.Property<int>(e, "Id") == id, cancellationToken);



    }

    public void Add(T entity)
    {
        DbContext.Add(entity);
    }
}