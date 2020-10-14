using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using SandboxProject.ApplicationStructure.Constants;
using System;

namespace SandboxProject.ApplicationStructure.Pages
{
    public class PlaygroundPage : PageObject
    {
        WebDriverWait wait;
        public PlaygroundPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        public PlaygroundPage NavigateToProjectsPage()
        {
            Driver.FindElement(By.XPath(PlaygroundPageConstants.ProjectsTAB)).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ProjectsPageConstants.CreateProjectButton)));

            return this;
        }

        public PlaygroundPage NavigateToTeamsPage()
        {
            Driver.FindElement(By.XPath(PlaygroundPageConstants.TeamsTAB)).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TeamsPageConstants.CreateTeamButton)));

            return this;
        }
        
        public PlaygroundPage NavigateToPeoplePage()
        {
            Driver.FindElement(By.XPath(PlaygroundPageConstants.PeopleTAB)).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(PeoplePageConstants.CreatePersonButton)));

            return this;
        }

        public PlaygroundPage NavigateToSenioritiesPage()
        {
            Driver.FindElement(By.XPath(PlaygroundPageConstants.SenioritiesTAB)).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(SenioritiesPageConstants.CreateSeniorityButton)));

            return this;
        }

        public PlaygroundPage NavigateToTechnologiesPage()
        {
            Driver.FindElement(By.XPath(PlaygroundPageConstants.TechnologiesTAB)).Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TechnologiesPageConstants.CreateTechnologyButton)));

            return this;
        }
    }
}
