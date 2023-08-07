using MediatR;
using phemon.Application.message.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Application.message.Query.Messages.GetMessageById
{
    public class GetMessageByIdQuery : IRequest<MessageDTO>
    {
        public int Id { get; set; }
    }
}
