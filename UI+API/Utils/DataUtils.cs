using FinalProjectL2.Models;


namespace FinalProjectL2.Utils
{
    public static class DataUtils
    {
        public static string projectName = Randomizer.GenerateRandomText(12);

        public static string VariantNumber = JsonReader.GetTestDataValue("Variant").ToString();
        public static string ProjectId = JsonReader.GetTestDataValue("ProjectId").ToString();
        public static string SID = JsonReader.GetTestDataValue("SID").ToString();
        public static string testName = JsonReader.GetTestDataValue("testName").ToString();
        public static string methodName = JsonReader.GetTestDataValue("methodName").ToString();
        public static string env = JsonReader.GetTestDataValue("env").ToString();
        public static string browser = JsonReader.GetTestDataValue("browser").ToString();
        public static string content = JsonReader.GetTestDataValue("content").ToString();
        public static string contentType = JsonReader.GetTestDataValue("contentType").ToString();

        public static string login = JsonReader.GetConfigValue("Login");
        public static string password = JsonReader.GetConfigValue("Password");
        public static string webUrl = JsonReader.GetConfigValue("baseUrl").ToString() + JsonReader.GetConfigValue("WebEndpoint").ToString();
        public static string ApiUrl = JsonReader.GetConfigValue("baseUrl").ToString() + JsonReader.GetConfigValue("ApiEndpoint").ToString();       
        public static string ApiEndpoint = JsonReader.GetConfigValue("ApiEndpoint").ToString();

        public static List<Model> ReadTestResults()
        {
            return ReadTestResults();
        }



        


    }



}
