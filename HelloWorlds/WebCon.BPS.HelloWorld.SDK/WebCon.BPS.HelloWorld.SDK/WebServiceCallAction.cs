using System;
using System.Linq;
using WebCon.BPS.HelloWorld.SDK.WebServiceProxyStub;
using WebCon.WorkFlow.SDK.ActionPlugins;
using WebCon.WorkFlow.SDK.ActionPlugins.Model;

namespace WebCon.BPS.HelloWorld.SDK.CustomActions
{
    public class WebServiceCallAction : CustomAction<WebServiceCallActionConfig>
    {
        // Form fields identifiers in the process configuration
        private const int StartDateFormFieldID = 14;           // Form field that contains start date of a vacation request
        private const int EndDateFormFieldID = 15;           // Form field that contains end date of a vacation request
        private const int RequestorFormFieldID = 16;           // Form field that contains requestor login of a vacation request
        private const int VacationIDFormFieldID = 17;           // Form field to store the identifier that registered vacation obtained in HR external system

        public override void Run(RunCustomActionParams args)
        {
            try
            {
                // create web service client
                var client = new VacationWebServiceClient(Configuration.WebServiceUrl);
                // prepare input parameters - read them from the Form Fields
                var registerVacationParams = new RegisterVacationParams
                {
                    StartDate = args.Context.CurrentDocument.DateTimeFields.GetByID(StartDateFormFieldID).Value.Value,
                    EndDate = args.Context.CurrentDocument.DateTimeFields.GetByID(EndDateFormFieldID).Value.Value,
                    Requestor = args.Context.CurrentDocument.PeopleFields.GetByID(RequestorFormFieldID).Values.First().BpsID
                };
                // call web service method
                var result = client.RegisterVacation(registerVacationParams);
                // store the result in the Form Field
                args.Context.CurrentDocument.TextFields.GetByID(VacationIDFormFieldID).Value = result.VacationID;
            }
            catch (Exception ex)
            {
                // when something goes wrong you can stop the workflow
                args.HasErrors = true;                  // Mark that there was error in the action
                args.Message = "Error: " + ex.Message;  // Prepare the message for end users
                args.LogMessage = ex.ToString();        // Prepare log entry
            }
        }
    }
}
