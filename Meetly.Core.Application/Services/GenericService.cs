using Meetly.Core.Application.Interfaces.Repositories;
using Meetly.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Services
{
    public class GenericService<Entity> : IGenericService<Entity> where Entity : class 
    {
        private readonly IGenericRepository<Entity> _repository;
        public GenericService(IGenericRepository<Entity> repository)
        {
            _repository = repository;
        }
        public virtual async Task<Entity> CreateAsync(Entity entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }
        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public virtual async Task<Entity?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public virtual async Task<Entity> UpdateAsync(Entity entity)
        {
            await _repository.EditAsync(entity);
            return entity;
        }

    }
}
