using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using FinalProjectL2.Utils;
using OpenQA.Selenium;

namespace FinalProjectL2.PageObject
{
    internal class AddProjectPage : Form
    {
        public AddProjectPage() : base(By.XPath("//input[@id='projectName']"), "Add project")
        {

        }
        private ITextBox AddProject => ElementFactory.GetTextBox(By.XPath("//input[@id='projectName']"), "Add project");
        private IButton SaveProject => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Submit project button");
        private ILabel ProjectTextBox => ElementFactory.GetLabel(By.XPath($"//a[contains(@class, 'list-group-item') and text()='{DataUtils.projectName}']"), "Get list of projects");
        private ITextBox FaultSave => ElementFactory.GetTextBox(By.XPath("//div[@class='alert alert-danger']"), "Test wasn't saved");
        private ILabel FirstTest => ElementFactory.GetLabel(By.XPath("//td/a"), "The first test was added");
        private ILink AddTestToNewProjectLink => ElementFactory.GetLink(By.XPath($"//a[@class='list-group-item' and text()='{DataUtils.projectName}']"), "New project");
       


        public void AddProjectMethod(string projectName)
        {
            AqualityServices.Browser.Tabs().SwitchToLastTab();
            AddProject.Type(projectName);
            SaveProject.State.WaitForDisplayed();
            SaveProject.Click();
            
        }
        public void AddTestToNewProject(string projectName)
        {
            
            AddTestToNewProjectLink.Click();
        }

        public bool ProjectSaved() => FaultSave.State.IsExist;
      
        public bool TestExists() 
        {
            FirstTest.State.WaitForDisplayed();
            return FirstTest.State.IsExist;
        }


        public bool GetProjectTextBox()
        {
            return ProjectTextBox.State.IsExist;
        }



    }
}
