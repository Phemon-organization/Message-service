using MediatR;
using phemon.Application.message.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Application.message.Query.Messages.GetMessages
{
    public class GetMessagesQuery : IRequest<IList<MessageDTO>>
    {

    }
}
