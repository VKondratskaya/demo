using Aquality.Selenium.Core.Utilities;


public static class JsonReader
{
    private static JsonSettingsFile configuration = new JsonSettingsFile("configuration.json");
     


    public static string GetConfigurationValue(string key)
    {
        return configuration.GetValue<string>(key);
    }


    public class CredentialsManager
    {
        public static string SetServer(string server)
        {
            Environment.SetEnvironmentVariable("Server", server);
            return server;
        }

        public static string SetPort(string port)
        {
            Environment.SetEnvironmentVariable("Port", port);
            return port;
        }
        public static string SetDataBase(string database)
        {
            Environment.SetEnvironmentVariable("DataBase", database);
            return database;
        }

        public static string SetUserName(string user)
        {
            Environment.SetEnvironmentVariable("User", user);
            return user;
        }

        public static string SetPassword(string password)
        {
            Environment.SetEnvironmentVariable("Password", password);
            return password;
        }
    }




}
public static class SQLReader
{
    public static string GetQuery(string fileName)
    {        
        string fileContent = File.ReadAllText(fileName);
        return fileContent;
    }

}







