using AutoMapper;
using GlobalTicket.Application.Contracts.Persistence;
using GlobalTicket.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.Application.Contracts.Features.Events
{
    //Request Handler
    public class GetEventsListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListVm>>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventsListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public async Task<List<EventListVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var allEvents =  (await _eventRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<EventListVm>>(allEvents);
        }
    }
}
 