using AssetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class ModelRepository : Repository<Model>, IModelRepository

{
    public ModelRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public Model Update(Model model)
    {
        DbContext.Set<Model>().Update(model);
        return model;
    }
}