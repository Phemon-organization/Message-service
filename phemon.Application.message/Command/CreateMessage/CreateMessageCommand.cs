using MediatR;
using phemon.Application.message.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Application.message.Command.CreateMessage
{
    public class CreateMessageCommand : IRequest<MessageDTO>
    {
        public string Message { get; set; }
        public Guid UserId { get; set; }
    }
}
