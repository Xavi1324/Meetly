using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Interfaces.Services
{
    public interface IGenericService<Entity>
    {
        Task<Entity> CreateAsync(Entity entity);
        Task DeleteAsync(int id);
        Task<List<Entity>> GetAllAsync();
        Task<Entity?> GetByIdAsync(int id);
        Task<Entity> UpdateAsync(Entity entity);
    }
}
