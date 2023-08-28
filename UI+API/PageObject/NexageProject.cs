using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using FinalProjectL2.Models;
using FinalProjectL2.Utils;
using OpenQA.Selenium;



namespace FinalProjectL2.PageObject
{

    internal class NexageProject : Form
    {
        public NexageProject() : base(By.XPath("//a[@href='/web/projects' and text()='Home']"), "Go to Home Page")
        {

        }

        public void ClickHomePageButton()
        {
            HomePageButton.Click();
        }

        public bool CompareStartDates(IList<Model> testDeserialized)
        {
            if (GetAPISortedTests(testDeserialized).SequenceEqual(GetStartDatesFromUI()))
            {
                return true;

            }
            return false;
        }
        private IButton HomePageButton => ElementFactory.GetButton(By.XPath("//a[@href='/web/projects' and text()='Home']"), "Go to Home Page");

        private IList<ILabel> StarttimeElements => ElementFactory.FindElements<ILabel>(By.XPath("//table//tr//td[4]"));

        private IList<DateTime> GetAPISortedTests(IList<Model> testDeserialized)
        {
            var sortedList = testDeserialized.OrderByDescending(test => DateTime.Parse(test.StartTime)).ToList();

            var testsOnFirstPage = sortedList.Skip((Constants.PageNumber - 1) * Constants.PageSize).Take(Constants.PageSize).ToList();

            IList<DateTime> APIstartDates = new List<DateTime>();

            foreach (var test in testsOnFirstPage)
            {
                APIstartDates.Add(DateTime.Parse(test.StartTime));
            }
            return APIstartDates;
        }

        private IList<DateTime> GetStartDatesFromUI()
        {
            IList<DateTime> startDates = new List<DateTime>();

            foreach (var starttimeElement in StarttimeElements)
            {
                var startDateText = starttimeElement.GetAttribute("innerText");
                startDates.Add(DateTime.Parse(startDateText));
            }
            return startDates;
        }
    }
}
