namespace phemon.API.messages.Services
{
    public class CacheKeyService : ICacheKeyService
    {
        private const string CacheKeySeparator = ":";
        public string GenerateCacheKey(string prefix, params object[] arguments)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                throw new ArgumentException("Prefix cannot be null or empty.", nameof(prefix));
            }

            string argumentKey = GenerateArgumentKey(arguments);
            string cacheKey = $"{prefix}{CacheKeySeparator}{argumentKey}";

            return cacheKey;
        }

        private string GenerateArgumentKey(object[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                return "default";
            }

            string argumentKey = string.Join(CacheKeySeparator, arguments.Select(arg => arg.ToString()));
            return argumentKey;
        }
    }
}
