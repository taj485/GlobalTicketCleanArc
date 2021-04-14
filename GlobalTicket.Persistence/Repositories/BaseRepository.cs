using GlobalTicket.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly GlobalTicketDbContext _dbContext;

        public BaseRepository(GlobalTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
