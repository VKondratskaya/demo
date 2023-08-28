using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using FinalProjectL2.Utils;
using OpenQA.Selenium;


namespace FinalProjectL2.PageObject
{
    internal class HomePage : Form
    {
        public HomePage() : base(By.XPath($"//*[contains(text(), 'Version: {DataUtils.VariantNumber}')]"), "Variant of task")
        {

        }
        private IButton Nexage => ElementFactory.GetButton(By.XPath("//a[@class='list-group-item'  and text()='Nexage']"), "Go to Nexage");
        public ILink Add => ElementFactory.GetLink(By.XPath("//*[contains(text(),'+Add')]"), "Add project");
        public ILabel VariantNumber => ElementFactory.GetLabel(By.XPath($"//*[contains(text(), 'Version: {DataUtils.VariantNumber}')]"), "Variant of task");

        public void ChooseNexageProject()
        {
            Nexage.Click();
        }

        public bool VariantIsRight() => VariantNumber.State.IsExist;
        public void WaitForVariantIsDisplayed() => VariantNumber.State.WaitForDisplayed();


    }
}
