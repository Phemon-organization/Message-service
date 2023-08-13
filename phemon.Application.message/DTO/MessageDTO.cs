using phemon.Core.message.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Application.message.DTO
{
    public class MessageDTO : AuditableEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
    }
}
