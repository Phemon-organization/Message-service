namespace phemon.API.messages.Routes
{
    public class ApiRoutes
    {
        public const string Domain = "api";
        public const string Version = "v{version:apiVersion}";
        public const string Base = Domain + "/" + Version;

        public static class Auth
        {
            public const string SignIn = Base + "/signin";
        }

        public static class Message
        {
            public const string Create = Base + "/messages";
            public const string Get = Base + "/message/{id}";
            public const string GetAll = Base + "/messages";
            public const string Update = Base + "/message/{id}";
            public const string Delete = Base + "/message/{id}";
        }
    }
}
