using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandboxProject.ApplicationStructure.Constants
{
    class UseCasesPageConstants
    {
        public static readonly string CreateUseCaseButton = "//a[@data-testid='create_use_case_btn']";
        public static readonly string UseCaseTitleField = "title";
        public static readonly string UseCaseDescriptionField = "description";
        public static readonly string UseCaseExpectedResultField = "expected_result";
        public static readonly string UseCaseFirstStepField = "testStepId-0";
        public static readonly string AddStepButton = "//span[contains(@data-testid, 'add_step_btn')]";
        public static readonly string UseCaseSecondStepField = "testStepId-1";
        public static readonly string SubmitButton = "//button[contains(@data-testid, 'submit_btn')]";
        public static readonly string ListOfCreatedUseCases = "//div[@class='list-group mt-5']";
        public static readonly string RemoveButton = "//button[contains(@data-testid, 'remove_usecase_btn')]";
        public static readonly string ConfirmDeletionButton = "//button[@class= 'btn btn-lg btn-danger ']";

    }

}
