//using AssetManagement.Domain.Statuses;

//namespace AssetManagement.Api;

//public static class DatabaseSeeder
//{
//    public static async Task SeedStatusesAsync(
//        IServiceProvider serviceProvider,
//        CancellationToken cancellationToken = default)
//    {
//        using IServiceScope scope = serviceProvider.CreateScope();

//        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//        var statuses = new[]
//        {
//            new { Id = 1, Name = "CreateAsset", StatusTransitionId = 1 },
//            new { Id = 2, Name = "Stock", StatusTransitionId = 2 },
//            new { Id = 3, Name = "InUse", StatusTransitionId = 3 },
//            new { Id = 4, Name = "AssetInServiceRepair", StatusTransitionId = 4 },
//            new { Id = 5, Name = "ReportedStolenMissing", StatusTransitionId = 5 },
//            new { Id = 6, Name = "ObsoleteAsset", StatusTransitionId = 6 },
//            new { Id = 7, Name = "AssetDisposed", StatusTransitionId = 7 },
//            new { Id = 8, Name = "AssetLost", StatusTransitionId = 8 }
//        };

//        foreach (var s in statuses)
//        {
//            var existing = await context.Statuses
//                .SingleOrDefaultAsync(x => x.Id == s.Id, cancellationToken);

//            if (existing == null)
//            {
//                context.Statuses.Add(new Status(
//                    s.Id,
//                    new Name(s.Name),
//                    s.StatusTransitionId));
//            }
//            else
//            {
//                existing.Update(
//                    new Name(s.Name),
//                    s.StatusTransitionId);
//            }
//        }

//        // Remove obsolete rows
//        var validIds = statuses.Select(x => x.Id).ToList();

//        var obsolete = await context.Statuses
//            .Where(x => !validIds.Contains(x.Id))
//            .ToListAsync(cancellationToken);

//        context.Statuses.RemoveRange(obsolete);

//        await context.SaveChangesAsync(cancellationToken);
//    }
//}