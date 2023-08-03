using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phemon.Core.message.Common
{
    public interface ICurrentUserService
    {
        public string UserId { get; }
        bool IsAuthenticated { get; }
        public string IpAddress { get; }
    }
}
