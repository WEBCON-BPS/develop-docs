using services.webcon.pl.BPS.Version._2017._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCon.BPS.HelloWorld.WebAPI.AttachmentStub;

namespace WebCon.BPS.HelloWorld.WebAPI
{
    class WebAPICaller
    {
        // Form field identifiers in the process configuration
        private const int ClientNameFormFieldID = 19;           // Form field that contains complaint issuer's name
        private const int ClientAddressFormFieldID = 20;        // Form field that contains complaint issuer's address
        private const int ClientZipCodeFormFieldID = 21;        // Form field that contains complaint issuer's zip code
        private const int ClientCityFormFieldID = 22;           // Form field that contains complaint issuer's city
        private const int PurchaseDateFormFieldID = 23;         // Form field that contains date of purchase of a product
        private const int ComplaintDescriptionFormFieldID = 24;  // Form field that contains complaint description and explanation

        public static string StartNewComplaint(FormDataBag formData)
        {
            // object identifiers int BPS Complaint Process
            const int docTypeID = 4;        // complaint document type ID
            const int workFlowID = 5;       // complaint workflow
            const int startPathID = 15;     // path id to start a new complaint workflow

            // create BPS Web API proxy client
            var client = new BPSWebserviceClient("BasicHttpBinding_BPSWebservice");
            client.ClientCredentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
            client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

            // Step 1 - get new empty element prefilled with defaults
            GetNewElementParams getNewElementParams = new GetNewElementParams()
            {
                DocTypeId = docTypeID,
                WorkFlowId = workFlowID
            };

            NewElement element = client.GetNewElement(getNewElementParams);

            // Step 2 - fill form field values
            element.TextAttributes.First(x => x.Id == ClientNameFormFieldID).Value = formData.ClientName;
            element.TextAttributes.First(x => x.Id == ClientAddressFormFieldID).Value = formData.ClientAddress;
            element.TextAttributes.First(x => x.Id == ClientZipCodeFormFieldID).Value = formData.ClientZipCode;
            element.TextAttributes.First(x => x.Id == ClientCityFormFieldID).Value = formData.ClientCity;
            element.DateTimeAttributes.First(x => x.Id == PurchaseDateFormFieldID).Value = formData.PurchaseDate;
            element.TextAttributes.First(x => x.Id == ComplaintDescriptionFormFieldID).Value = formData.ComplaintDescription;

            // Create attachment object
            var attachment = new Attachment()
            {
                FileName = "image.jpg",
                Description = "Photo",
                FileType = ".jpg",
                Content = FileResolver.GetStubFileBytes()
            };

            // Step 3 - start new complaint workflow
            StartWorkFlowParams startWorkFlowParams = new StartWorkFlowParams
            {
                Element = element,
                AttachmentsToAdd = new[] { attachment },
                PathId = startPathID
            };

            ExistingElement result = client.StartWorkFlow(startWorkFlowParams);

            var elementID = result.ID;
            var status = result.Status;

            return string.Format("New element ID: {0}, status: {1}", elementID, status);
        }
    }
}
