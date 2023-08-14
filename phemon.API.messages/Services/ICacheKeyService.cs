namespace phemon.API.messages.Services
{
    public interface ICacheKeyService
    {
        public string GenerateCacheKey(string prefix, params object[] arguments);

    }
}