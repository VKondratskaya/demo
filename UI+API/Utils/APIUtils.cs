using Aquality.Selenium.Browsers;
using FinalProjectL2.Models;
using Newtonsoft.Json;
using RestSharp;



namespace FinalProjectL2.Utils;
public class ApiUtils
{
    public List<Model> testDeserialized;
    private string testId;

    public string GetAuthToken()
    {
        var request = new RestRequest(Endpoints.GetEndpointPath(Endpoints.ApiEndpoint.TokenGet));
        request.AddQueryParameter("variant", DataUtils.VariantNumber);
        var token = HttpUtils.Post(request).Content;
        return token;
    }
    public string GetTestStringAPI()
    {
        var request = new RestRequest(Endpoints.GetEndpointPath(Endpoints.ApiEndpoint.TestGetJson));
        request.AddQueryParameter("projectId", DataUtils.ProjectId);
        return HttpUtils.Post(request).Content;
    }

    public List<Model> GetTestListFromAPI(string testList)
    {
        var testDeserialized = JsonConvert.DeserializeObject<List<Model>>(testList);
        return testDeserialized;
    }



    public string CreateTest(string projectName)
    {
        var request = new RestRequest(Endpoints.GetEndpointPath(Endpoints.ApiEndpoint.TestPut));
        request.AddQueryParameter("SID", DataUtils.SID);
        request.AddQueryParameter("projectName", projectName);
        request.AddQueryParameter("testName", DataUtils.testName);
        request.AddQueryParameter("methodName", DataUtils.methodName);
        request.AddQueryParameter("env", DataUtils.env);
        request.AddQueryParameter("browser", DataUtils.browser);
        testId = HttpUtils.Post(request).Content;
        return testId;
    }

    public void AddTestLog()
    {
        var request = new RestRequest(Endpoints.GetEndpointPath(Endpoints.ApiEndpoint.TestPutLog));
        request.AddQueryParameter("testId", testId);
        request.AddQueryParameter("content", DataUtils.content);
        HttpUtils.Post(request);
    }


    public string GetScreenshotAsBase64()
    {
        return Convert.ToBase64String(AqualityServices.Browser.GetScreenshot());
    }

    public void UploadScreenshotAttachment(string screenshotBase64)
    {
        var request = new RestRequest(Endpoints.GetEndpointPath(Endpoints.ApiEndpoint.TestPutAttachment), Method.Post);
        request.AddQueryParameter("testId", testId);
        request.AddParameter("contentType", DataUtils.contentType);
        request.AddParameter("content", screenshotBase64);
        HttpUtils.Execute(request);
    }






}


