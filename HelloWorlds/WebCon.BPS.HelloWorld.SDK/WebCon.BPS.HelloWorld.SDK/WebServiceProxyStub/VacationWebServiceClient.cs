using System;

namespace WebCon.BPS.HelloWorld.SDK.WebServiceProxyStub
{
    class VacationWebServiceClient
    {
        private string _url;
        public VacationWebServiceClient(string url)
        {
            _url = url;
        }

        public RegisterVacationResult RegisterVacation(RegisterVacationParams registerVacationParams)
        {
            return new RegisterVacationResult() { VacationID = "42" };
        }
    }
}
