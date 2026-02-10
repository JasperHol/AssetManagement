using AssetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Models;
public interface IModelRepository
{
    Task<Model?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Model model);

    Model Update(Model model);

}