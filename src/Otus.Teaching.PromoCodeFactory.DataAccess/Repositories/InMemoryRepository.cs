using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T>
        : IRepository<T>
        where T: BaseEntity
    {
        protected ICollection<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
        {
            Data = new List<T>(data);
        }
        
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data.AsEnumerable());
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task UpdateAsync(T value)
        {
            var item = Data.FirstOrDefault(x => x.Id == value.Id);
            if (item != null)
            {
                Data.Remove(item);
                Data.Add(value);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T value)
        {
            Data.Remove(value);
            return Task.CompletedTask;
        }

        public Task AddAsync(T value)
        {
            Data.Add(value);
            return Task.CompletedTask;
        }
    }
}