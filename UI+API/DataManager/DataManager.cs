using Aquality.Selenium.Core.Utilities;
namespace FinalProjectL2.Utils;
public static class JsonReader
{

    private static JsonSettingsFile testData = new JsonSettingsFile("testData.json");
    private static JsonSettingsFile config = new JsonSettingsFile("config.json");

    public static string GetTestDataValue(string key)
    {
        return testData.GetValue<string>(key);
    }
    public static string GetConfigValue(string key)
    {
        return config.GetValue<string>(key);
    }



}




