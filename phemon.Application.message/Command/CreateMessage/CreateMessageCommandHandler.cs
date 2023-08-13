﻿using MediatR;
using phemon.Application.message.DTO;
using phemon.Core.message.Entities;
using phemon.Persistence.message;

namespace phemon.Application.message.Command.CreateMessage
{
    public class CreateMessageCommandHandler:IRequestHandler<CreateMessageCommand, MessageDTO>
    {
        private readonly IMediator _mediator;
        private readonly IMessageDbContext _dbcontext;

        public CreateMessageCommandHandler(IMediator mediator, IMessageDbContext dbcontext)
        {
            _mediator = mediator;
            _dbcontext = dbcontext;
        }

        public async Task<MessageDTO> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            MessageEntity message = new()
            {
                Message = request.Message,
                UserId = request.UserId,
            };

            _dbcontext.Message.Add(message);
            await _dbcontext.SaveChangesAsync(cancellationToken);

            MessageDTO messageDTO = new()
            {
                UserId = request.UserId,
            };
            
            return messageDTO;

        }
    }
}
