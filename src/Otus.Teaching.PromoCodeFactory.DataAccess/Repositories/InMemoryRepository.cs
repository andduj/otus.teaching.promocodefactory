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
        protected IList<T> Data { get; set; }

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

        public Task<T> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            var item = Data.FirstOrDefault(x => x.Id == id);
            if(item != null)
            {
                Data.Remove(item);
            }

            return Task.FromResult<T>(null);
        }

        public Task<T> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}