namespace FinalProjectL2.Utils
{
    public static class Endpoints
    {
        public enum ApiEndpoint
        {
            TokenGet,
            TestGetJson,
            TestPut,
            TestPutLog,
            TestPutAttachment
        }

        public static string GetEndpointPath(ApiEndpoint endpoint)
        {
            switch (endpoint)
            {
                case ApiEndpoint.TokenGet:
                    return "token/get";
                case ApiEndpoint.TestGetJson:
                    return "test/get/json";
                case ApiEndpoint.TestPut:
                    return "test/put";
                case ApiEndpoint.TestPutLog:
                    return "test/put/log";
                case ApiEndpoint.TestPutAttachment:
                    return "test/put/attachment";
                default:
                    throw new ArgumentException("Invalid API endpoint.");
            }
        }
    }
}
    

