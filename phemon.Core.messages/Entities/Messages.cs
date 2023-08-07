using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Core.message.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
    }
}
