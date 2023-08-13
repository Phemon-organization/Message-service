using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using phemon.Core.message.Common;
using phemon.Core.message.Entities;
using phemon.Infrastructure.message;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace phemon.Persistence.message
{
    public class MessageDbContext : IdentityDbContext<ApplicationUser>, IMessageDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public MessageDbContext(DbContextOptions<MessageDbContext> options)
            : base(options)
        {
        }

        public MessageDbContext(DbContextOptions<MessageDbContext> options,
            ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MessageEntity> Message { get; set; }
    }
}
