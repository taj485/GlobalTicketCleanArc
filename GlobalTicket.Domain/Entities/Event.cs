using GlobalTicket.Domain.Common;
using System;

namespace GlobalTicket.Domain.Entities
{
    public class Event : AuditableEntity
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
    }
}