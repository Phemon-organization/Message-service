using phemon.Application.message.DTO;
using phemon.Persistence.message;
using phemon.Core.message.Entities;

namespace phemon.Application.message.Query.Messages.GetMessageById
{
    public class GetMessageByIdQueryHandler
    {
        private readonly IMessageDbContext _dbContext;

        public GetMessageByIdQueryHandler(IMessageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MessageDTO> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            MessageEntity result = await Task.Run(() => _dbContext
            .Message
                .Where(s => 
                    s.Id.Equals(request.Id))
                .FirstOrDefault(), cancellationToken);

            MessageDTO message = new()
            {
                Id = request.Id,
                Message = result.Message,
                UserId = result.UserId,
            };

            return message;
        }
    }
}
