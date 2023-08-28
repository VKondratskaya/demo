using RestSharp;


namespace FinalProjectL2.Utils
{
    public static class HttpUtils
    {
        private static RestClient client = new RestClient(DataUtils.ApiUrl);

        public static RestResponse Post(RestRequest request)
        {
            return client.Post(request);
        }

        public static RestResponse Get(RestRequest request)
        {
            return client.Get(request);
        }

        public static void Execute(RestRequest request)
        {
            client.Execute(request);
        }


    }
}
