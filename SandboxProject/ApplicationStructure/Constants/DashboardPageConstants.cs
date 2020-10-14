using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox_project.ApplicationStructure.Constants
{
    class DashboardPageConstants
    {
        public static readonly string ReportingIssueCard = "//a[@href ='/reports']/div/span";
        public static readonly string UseCaseCard = "//a[@href ='/use-cases']/div/span";
        public static readonly string PlaygroundCard = "//div[contains(@data-testid, 'playground_card_id')]/div";
        public static readonly string QASandbox = "//b[contains(text(), 'QA Sandbox')]";
    }
}
