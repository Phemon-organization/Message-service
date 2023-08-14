using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
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
        private readonly IDistributedCache _cache;
        public GetMessagesQueryHandler(IMessageDbContext dbcontext, IDistributedCache cache)
        {
            _dbcontext = dbcontext;
            _cache = cache;
        }

        public async Task<IList<MessageDTO>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            string cachedData = await _cache.GetStringAsync(request.Cachekey);

            if (cachedData != null)
            {
                var messagelist = JsonConvert.DeserializeObject<IList<MessageDTO>>(cachedData);
                return messagelist;
            }
            else
            {
                var messages = await _dbcontext.Message
                .Select(message => new MessageDTO
                {
                    Id = message.Id,
                    Message = message.Message,
                    UserId = message.UserId,
                })
                .ToListAsync(cancellationToken);

                // serialize data
                var cachedDataString = JsonConvert.SerializeObject(messages);
                var newDataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                // set cache options 
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));

                // Add data in cache
                await _cache.SetAsync(request.Cachekey, newDataToCache, options);


                return messages;
            }
        }
    }
}

