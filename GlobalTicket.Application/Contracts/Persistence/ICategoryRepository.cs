using GlobalTicket.Domain.Entities;

namespace GlobalTicket.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
