using Aquality.Selenium.Browsers;
using FinalProjectL2.PageObject;
using FinalProjectL2.Utils;
using NUnit.Framework.Internal;


namespace FinalTaskL2;

[TestFixture]
public class UnitTest

{

    private HomePage homePage = new HomePage();
    private AddProjectPage addprojectPage = new AddProjectPage();
    private NexageProject nexageProject = new NexageProject();
    private ApiUtils apiutils = new ApiUtils();
    private DriverUtils driverUtils = new DriverUtils();


    [Test]

    public void Test2()
    {

        string token = apiutils.GetAuthToken();
        Assert.IsTrue(!string.IsNullOrEmpty(token), "Token should not be null or empty.");
        driverUtils.Login(token);
        Assert.IsTrue(homePage.VariantIsRight(), "Variant is not right");
        homePage.ChooseNexageProject();
        driverUtils.ScrollToBottom();
        homePage.WaitForVariantIsDisplayed();
        var listFromApi = apiutils.GetTestStringAPI();
        Assert.IsTrue(driverUtils.IsValidJson(listFromApi), "The response is not a valid JSON");
        Assert.IsTrue(nexageProject.CompareStartDates(apiutils.GetTestListFromAPI(listFromApi)), "Dates are not in descened order");
        nexageProject.ClickHomePageButton();
        homePage.Add.Click();
        addprojectPage.AddProjectMethod(DataUtils.projectName);
        driverUtils.CloseTab();
        driverUtils.SwitchToLastTab();
        driverUtils.RefreshPage();
        Assert.IsFalse(addprojectPage.ProjectSaved(), "Project wasn't saved");
        IReadOnlyCollection<string> windowHandles = AqualityServices.Browser.Driver.WindowHandles;
        int windowCount = windowHandles.Count;
        Assert.AreEqual(Constants.ExpectedWindowCount, windowCount, $"Expected {Constants.ExpectedWindowCount} windows, but found {windowCount} windows.");
        Assert.IsTrue(addprojectPage.GetProjectTextBox(), "Project isn't in a list");
        addprojectPage.AddTestToNewProject(DataUtils.projectName);
        apiutils.CreateTest(DataUtils.projectName);
        apiutils.AddTestLog();
        string screenshotBase64 = apiutils.GetScreenshotAsBase64();
        apiutils.UploadScreenshotAttachment(screenshotBase64);
        Assert.IsTrue(addprojectPage.TestExists(), "The first test is not displayed in the project.");
    }


    [TearDown]
    public void Teardown()
    {
       AqualityServices.Browser.Quit();
    }







}