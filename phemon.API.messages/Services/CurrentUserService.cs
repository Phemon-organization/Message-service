using phemon.Core.message.Common;
using System.Security.Claims;

namespace phemon.API.messages.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; }
        public string? UserName { get; }
        public bool IsAuthenticated { get; }
        public string IpAddress { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            IpAddress = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress.ToString();
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }
    }
}
