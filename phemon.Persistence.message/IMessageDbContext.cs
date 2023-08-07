using Microsoft.EntityFrameworkCore;
using phemon.Core.message.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Persistence.message
{
    public interface IMessageDbContext
    {
        DbSet<MessageEntity> Message { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
