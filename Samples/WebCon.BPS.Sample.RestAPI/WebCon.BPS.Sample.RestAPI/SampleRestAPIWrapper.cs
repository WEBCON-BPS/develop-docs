using System;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Globalization;
using System.Net;

namespace WebCon.BPS.Sample.RestAPI
{
    public class SampleRestAPIWrapper
    {
        private static readonly string BaseBPSPortalAddress = "https://dev46.webcon.pl:48439";

        /// <summary>
        /// Method starts new cost invoice workflow instance with the following parameters:
        /// - Registration date
        /// - Sale date
        /// - Payment date
        /// - Issue date
        /// - Contractor
        /// - Gross value
        /// - Net value
        /// - Invoice number
        /// </summary>
        public int RegisterInvoice()
        {
            // Form field guids in the WEBCON BPS Invoice Process
            const string saleDateAttributeGuid = "602edd8f-933e-472c-8519-7b67ace7a6a7"; // Form field of type 'Date and time' that contains invoice sale date
            const string documentReceiveDateAttributeGuid = "8b14acdd-d422-4841-9fb0-0c90fce66613"; // Form field of type 'Date and time' that contains document receive date
            const string invoiceIssueDateAttributeGuid = "fd3f3655-389c-4c61-b6b4-2119b269d1d9"; // Form field of type 'Date and time' that contains invoice issue date
            const string contractorAttributeGuid = "1b421ccd-2ccf-409b-b50e-b03ca1d57f53"; // Form field of type 'Person or group' that contains contractor
            const string grossValueAttributeGuid = "99a4c19b-d807-46b8-a450-5fa47d5ab775"; // Form field of type 'Floating-point number' that contains gross value 
            const string netValueAttributeGuid = "3aa86faa-8f9d-4d9b-b1c6-3621f7cd4a16"; // Form field of type 'Floating-point number' that contains net value
            const string invoiceNumberAttributeGuid = "a2c73841-fcb2-48b7-9f94-f4429bf994f0"; // Form field of type 'Single line of text' that contains invoice number

            // Object identifiers in the WEBCON BPS Invoice Process
            const int workflowID = 21;  // Invoice workflow ID
            const int docTypeID = 23;   // Invoice document type ID
            const int pathId = 118; // Path ID to start a new complaint workflow instance
            const int dbId = 1; // Content database ID where the complaint process is stored

            using (var httpClient = new HttpClient())
            {
                // Get access token (JWT) in order to make calls to WEBCON BPS REST API
                GetAccessTokenAndSetAuthorization(httpClient);

                var startNewWorkflowRequestBody = new JObject
                {
                    new JProperty("workflow", new JObject
                    {
                        new JProperty("id", workflowID),
                    }),
                    new JProperty("formType", new JObject
                    {
                        new JProperty("id", docTypeID)
                    }),
                    new JProperty("formFields", new JArray
                    {
                        new JObject
                        {
                            new JProperty("guid", saleDateAttributeGuid),
                            new JProperty("value", new DateTime(2019, 2, 6).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                        },
                        new JObject
                        {
                            new JProperty("guid", invoiceIssueDateAttributeGuid),
                            new JProperty("value", new DateTime(2019, 2, 7).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                        },
                        new JObject
                        {
                            new JProperty("guid", documentReceiveDateAttributeGuid),
                            new JProperty("value", new DateTime(2019, 2, 8).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
                        },
                        new JObject
                        {
                            new JProperty("guid", grossValueAttributeGuid),
                            new JProperty("value", 1000)
                        },
                        new JObject
                        {
                            new JProperty("guid", netValueAttributeGuid),
                            new JProperty("value", 800)
                        },
                        new JObject
                        {
                            new JProperty("guid", invoiceNumberAttributeGuid),
                            new JProperty("value", 213)
                        },
                        new JObject
                        {
                            new JProperty("guid", contractorAttributeGuid),
                            new JProperty("svalue", "t.green@webcon.pl#Tom Green")
                        }
                    })
                };

                var response = httpClient.PostAsync($"/api/data/v1.0/db/{dbId}/elements?pathId={pathId}", new StringContent(JsonConvert.SerializeObject(startNewWorkflowRequestBody), Encoding.UTF8, "application/json")).Result;
                var startNewWorkflowResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(startNewWorkflowResponse);

                if (response.StatusCode == HttpStatusCode.OK)
                    return int.Parse(JObject.Parse(startNewWorkflowResponse)["id"].ToString());
                else
                    return -1;
            }
        }

        /// <summary>
        /// Method moves the instance whose identifier was passed as an argument from step "Awaiting for a scan" to step "Verification" through path with GUID 3e3be4fb-cd51-46b4-98fa-5f0b374cf0b7. 
        /// On path transition, the document invoice scan (file SampleElectricBill.pdf) is added to the instance as an attachment.
        /// </summary>
        public void AddInvoiceAttachment(int elementId)
        {
            const int dbId = 1;
            const string pathGuid = "3e3be4fb-cd51-46b4-98fa-5f0b374cf0b7";

            using (var httpClient = new HttpClient())
            {
                GetAccessTokenAndSetAuthorization(httpClient);

                byte[] bytes = File.ReadAllBytes("SampleElectricBill.pdf");

                var addNewAttachmentRequestBody = new JObject
                {
                    new JProperty("metadata", new JObject
                    {
                        new JProperty("name", "invoice.pdf"),
                        new JProperty("description", "Invoice for electricity"),
                    }),
                    new JProperty("content", Convert.ToBase64String(bytes))
                };

                var response = httpClient.PostAsync($"/api/data/v1.0/db/{dbId}/elements/{elementId}/attachments", new StringContent(JsonConvert.SerializeObject(addNewAttachmentRequestBody), Encoding.UTF8, "application/json")).Result;
                var addNewAttachmentResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(addNewAttachmentResponse);

                response = httpClient.PatchAsync($"/api/data/v1.0/db/{dbId}/elements/{elementId}?pathguid={pathGuid}", new StringContent("{}", Encoding.UTF8, "application/json")).Result;
                var moveWorkflowInstanceToNextStepResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(moveWorkflowInstanceToNextStepResponse);
            }
        }

        /// <summary>
        /// Method is used for invoice analytical breakdown for the instance whose identifier was passed as an argument. 
        /// New rows are added to the item list with GUID 15055074-d969-4e97-9e7d-243b1e87890d and then the instance is updated. 
        /// Method should be executed for instances residing in the "Verification" step.
        /// </summary>
        public void UpdateInvoice(int elementId)
        {
            // Item list identifiers in the WEBCON BPS Invoice Process
            const int departmentColumnId = 15; // Item list column of type 'Single line of text' that contains department name
            const int netValueColumnId = 16; // Item list column of type 'Floating-point number' that contains net value
            const int descriptionColumnId = 17; // Item list column of type 'Single line of text' that contains description

            const int dbId = 1;
            const string itemListGuid = "15055074-d969-4e97-9e7d-243b1e87890d"; // Item list GUID which contains invoice analytical breakdown 

            using (HttpClient httpClient = new HttpClient())
            {
                GetAccessTokenAndSetAuthorization(httpClient);

                var fillItemListsRequestBody = new JObject
                {
                    new JProperty("itemLists", new JArray
                    {
                        new JObject
                        {
                            new JProperty("guid", itemListGuid),
                            new JProperty("rows", new JArray
                            {
                                new JObject
                                {
                                    new JProperty("fields", new JArray
                                    {
                                        new JObject
                                        {
                                            new JProperty("id", departmentColumnId),
                                            new JProperty("value", "Department 1")
                                        },
                                        new JObject
                                        {
                                            new JProperty("id", netValueColumnId),
                                            new JProperty("value", "100")
                                        },
                                        new JObject
                                        {
                                            new JProperty("id", descriptionColumnId),
                                            new JProperty("value", "Department 1 costs")
                                        }
                                    }),
                                },
                                new JObject
                                {
                                    new JProperty("fields", new JArray
                                    {
                                        new JObject
                                        {
                                            new JProperty("id", departmentColumnId),
                                            new JProperty("value", "Department 2")
                                        },
                                        new JObject
                                        {
                                            new JProperty("id", netValueColumnId),
                                            new JProperty("value", "200")
                                        },
                                        new JObject
                                        {
                                            new JProperty("id", descriptionColumnId),
                                            new JProperty("value", "Department 2 costs")
                                        }
                                    }),
                                },
                                new JObject
                                {
                                    new JProperty("fields", new JArray
                                    {
                                        new JObject
                                        {
                                            new JProperty("id", departmentColumnId),
                                            new JProperty("value", "Department 3")
                                        },
                                        new JObject
                                        {
                                            new JProperty("id", netValueColumnId),
                                            new JProperty("value", "300")
                                        },
                                        new JObject
                                        {
                                            new JProperty("id", descriptionColumnId),
                                            new JProperty("value", "Department 3 costs")
                                        }
                                    }),
                                }
                            })
                        }
                    })
                };

                var response = httpClient.PatchAsync($"/api/data/v1.0/db/{dbId}/elements/{elementId}", new StringContent(JsonConvert.SerializeObject(fillItemListsRequestBody), Encoding.UTF8, "application/json")).Result;
                var createInvoiceDecretationResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(createInvoiceDecretationResponse);
            }
        }

        private void GetAccessTokenAndSetAuthorization(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(BaseBPSPortalAddress);

            var accessTokenRequestBody = new JObject
            {
                new JProperty("clientId", "639fa26f-5bb8-4f11-b8e9-9c585bfd08bb"),
                new JProperty("clientSecret", "6630e3b2-f9a6-499c-883e-70c799494e35"),
            };

            var response = httpClient.PostAsync("/api/login", new StringContent(JsonConvert.SerializeObject(accessTokenRequestBody), Encoding.UTF8, "application/json")).Result;
            var responseObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var accessToken = (string)responseObject["token"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}