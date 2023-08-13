using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace phemon.Application.message.Command.DeleteMessage
{
    public class DeleteMessageCommand : IRequest<bool>
    {
            public int Id { get; set; }
    }
}
