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

        public DbSet<MessageEntity> Message { get; set; }

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
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }

            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
