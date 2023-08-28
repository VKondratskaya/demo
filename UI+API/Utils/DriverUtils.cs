using Aquality.Selenium.Browsers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenQA.Selenium;


namespace FinalProjectL2.Utils
{
    public class DriverUtils
    {

        public void Login(string authToken)
        {
            RegisterAuthenticationHandler();
            GoToWebUrl();
            AddAuthTokenCookie(authToken);
            RefreshPage();
            ScrollToBottom();
        }
        private void RegisterAuthenticationHandler()
        {
            NetworkAuthenticationHandler handler = new NetworkAuthenticationHandler()
            {
                UriMatcher = (matcher) => true,
                Credentials = new PasswordCredentials(DataUtils.login, DataUtils.password)
            };
            AqualityServices.Browser.RegisterBasicAuthenticationAndStartMonitoring(handler);
        }

        private void GoToWebUrl()
        {
            AqualityServices.Browser.GoTo(DataUtils.webUrl);
        }

        private void AddAuthTokenCookie(string authToken)
        {
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new Cookie("token", authToken));
        }

        public void RefreshPage()
        {
            AqualityServices.Browser.Refresh();
        }

        public void ScrollToBottom()
        {
            AqualityServices.Browser.ExecuteScript(JsUtils.ScrollScript);
        }

        public void CloseTab() 
        { 
            AqualityServices.Browser.Tabs().CloseTab(); 
        }
        public void SwitchToLastTab()
        {
            AqualityServices.Browser.Tabs().SwitchToLastTab();
        }

        public bool IsValidJson(string jsonString)
        {
            try
            {
                JToken.Parse(jsonString);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}
