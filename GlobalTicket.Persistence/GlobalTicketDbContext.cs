using GlobalTicket.Domain.Common;
using GlobalTicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalTicket.Persistence
{
    public class GlobalTicketDbContext : DbContext
    {
        public GlobalTicketDbContext(DbContextOptions<GlobalTicketDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //will search for all configurations and apply them on modelbuilder
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GlobalTicketDbContext).Assembly);

            //Seed Data
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
