using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using Sandbox_project.ApplicationStructure.Constants;
using SandboxProject.ApplicationStructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.ApplicationStructure.Pages
{
    public class DashboardPage : PageObject
    {
        WebDriverWait wait;
        public DashboardPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public DashboardPage ClickOnReportsCard()
        {
            var reportCard = Driver.FindElement(By.XPath(DashboardPageConstants.ReportingIssueCard));
            reportCard.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ReportsPageConstants.ReportIssueButton)));

            return this;
        }

        public DashboardPage ClickOnPlaygroundCard()
        {
            var reportCard = Driver.FindElement(By.XPath(DashboardPageConstants.PlaygroundCard));
            reportCard.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), 'Playground')]")));

            return this;
        }

        public DashboardPage ClickOnUseCaseCard()
        {
            var useCaseCard = Driver.FindElement(By.XPath("//div[@class='row']/div[2]/div"));
            useCaseCard.Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(UseCasesPageConstants.CreateUseCaseButton)));


            return this;
        }

    }
}
