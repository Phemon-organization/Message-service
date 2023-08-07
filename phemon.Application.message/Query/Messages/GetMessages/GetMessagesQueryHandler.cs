using MediatR;
using Microsoft.EntityFrameworkCore;
using phemon.Application.message.DTO;
using phemon.Persistence.message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Application.message.Query.Messages.GetMessages
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, IList<MessageDTO>>
    {
        private readonly IMessageDbContext _dbcontext;
        public GetMessagesQueryHandler(IMessageDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IList<MessageDTO>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            var messages = await _dbcontext.Message
                .Select(message => new MessageDTO
                {
                    Id = message.Id,
                    Message = message.Message,
                    UserId = message.UserId
                })
                .ToListAsync(cancellationToken);
                
            return messages;
        }
    }
}
