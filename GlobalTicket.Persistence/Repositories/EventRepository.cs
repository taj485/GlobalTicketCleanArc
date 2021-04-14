using GlobalTicket.Application.Contracts.Persistence;
using GlobalTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GlobalTicketDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            throw new NotImplementedException();
        }
    }
}
