using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sandbox_project.ApplicationStructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Helpers
{
    class PlaygroudPageHelpers : PageObject
    {

        WebDriverWait wait;
        public PlaygroudPageHelpers(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        // method used for checking if the title of seniority, technology, team, person and project is displayed.
        public bool CheckIfTitleOfItemIsDisplayed(int rowInList, string title)
        {
            var element = Driver.FindElement(By.XPath("//div[@class= 'card-profile shadow ml-1 mr-1']/a[" + rowInList + "]")).Text;

            if (element != title)
            {
                return false;
            }
            return true;
        }
    }
}
