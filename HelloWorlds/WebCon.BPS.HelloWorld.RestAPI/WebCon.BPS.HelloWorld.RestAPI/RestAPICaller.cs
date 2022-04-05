using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebCon.BPS.HelloWorld.RestAPI
{
    public class RestAPICaller
    {
        // Form field identifiers in the WEBCON BPS Complaint Process
        private static readonly int ClientNameFormFieldID = 136;    // Form field that contains complaint issuer's name
        private static readonly int ClientAddressFormFieldID = 137; // Form field that contains complaint issuer's address
        private static readonly int ClientZipCodeFormFieldID = 138; // Form field that contains complaint issuer's zip code
        private static readonly int ClientCityFormFieldID = 139;    // Form field that contains complaint issuer's city
        private static readonly int PurchaseDateFormFieldID = 140;  // Form field that contains date of purchase of a product
        private static readonly int ComplaintDescriptionFormFieldID = 141;  // Form field that contains complaint description and explanation

        private static readonly string ClientName = "Tom Green";
        private static readonly string ClientAddress = "Babinskiego 69";
        private static readonly string ClientZipCode = "30-393";
        private static readonly string ClientCity = "Krakow";
        private static readonly DateTime PurchaseDate = new DateTime(2019, 03, 19);
        private static readonly string ComplaintDescription = "Description...";

        private static readonly string BaseBPSPortalAddress = "https://dev46.webcon.pl:48439";

        public static void StartNewComplaint()
        {
            // Object identifiers in the WEBCON BPS Complaint Process
            const int workflowID = 22;  // Complaint workflow ID
            const int docTypeID = 24;   // Complaint document type ID
            const int startPathID = 121;    // Path ID to start a new complaint workflow instance
            const int dbId = 1; // Content database ID where the complaint process is stored

            using (HttpClient httpClient = new HttpClient())
            {
                // Get access token (JWT) in order to make calls to WEBCON BPS REST API
                GetAccessTokenAndSetAuthorization(httpClient);

                // Create JSON request body to start new workflow instance
                // Not the most efficient way, shows structure of the JSON request body
                var startNewWorkflowRequestBody = $@"{{
                    'workflow': {{
                        'id': {workflowID}
                    }}, 
                    'formType': {{
                        'id': {docTypeID}
                    }},
                    'formFields': [
                        {{
                            'id': {ClientNameFormFieldID},
                            'value': '{ClientName}'
                        }},
                        {{
                            'id': {ClientAddressFormFieldID},
                            'value': '{ClientAddress}'
                        }},
                        {{
                            'id': {ClientZipCodeFormFieldID},
                            'value': '{ClientZipCode}'
                        }},
                        {{
                            'id': {ClientCityFormFieldID},
                            'value': '{ClientCity}'
                        }},
                        {{
                            'id': {PurchaseDateFormFieldID},
                            'value': '{PurchaseDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}'
                        }},
                        {{
                            'id': {ComplaintDescriptionFormFieldID}, 
                            'svalue': '{ComplaintDescription}'
                        }}
                    ]          
                }}";

                // Start new complaint workflow instance
                var response = httpClient.PostAsync($"/api/data/v4.0/db/{dbId}/elements?pathId={startPathID}", new StringContent(startNewWorkflowRequestBody, Encoding.UTF8, "application/json")).Result;
                var startNewWorkflowResponse = response.Content.ReadAsStringAsync().Result;
                var elementId = JObject.Parse(startNewWorkflowResponse)["id"];
                Console.WriteLine("Start new workflow response:");
                Console.WriteLine(startNewWorkflowResponse + '\n');

                // Create JSON request body to add new attachment 
                var addNewAttachmentRequestBody = $@"{{
                   'metadata': {{
                       'name': 'monitor.jpg',
                       'description': 'Broken equipment'
                   }},
                   'content': '{Convert.ToBase64String(File.ReadAllBytes("Monitor.jpg"))}'
                }}";

                // Add new attachment to started workflow instance
                response = httpClient.PostAsync($"/api/data/v4.0/db/{dbId}/elements/{elementId}/attachments", new StringContent(addNewAttachmentRequestBody, Encoding.UTF8, "application/json")).Result;
                var addNewAttachmentResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Add new attachment response:");
                Console.WriteLine(addNewAttachmentResponse + '\n');

                // Get created workflow instance’s content
                response = httpClient.GetAsync($"/api/data/v4.0/db/{dbId}/elements/{elementId}").Result;
                var workflowInstanceContent = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                var instanceNumber = workflowInstanceContent["header"]["instanceNumber"];
                var statusId = workflowInstanceContent["header"]["statusId"];
                Console.WriteLine("New element ID: {0}, instance number: {1}, status ID: {2}", elementId, instanceNumber, statusId);
            }
        }

        private static void GetAccessTokenAndSetAuthorization(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(BaseBPSPortalAddress);

            // Create JSON request body to get access token
            // clientId and clientSecret are acquired from WEBCON admin panel
            var accessTokenRequestBody = @"{
                'clientId': '639fa26f-5bb8-4f11-b8e9-9c585bfd08bb',
                'clientSecret': '6630e3b2-f9a6-499c-883e-70c799494e35'
            }";

            // Get access token
            var response = httpClient.PostAsync("/api/login", new StringContent(accessTokenRequestBody, Encoding.UTF8, "application/json")).Result;
            var responseObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var accessToken = (string)responseObject["token"];
            // Set authorization
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
