using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCon.BPS.HelloWorld.WebAPI
{
    class FormDataBag
    {
        public string ClientName { get; set; }

        public string ClientAddress { get; set; }

        public string ClientZipCode { get; set; }

        public string ClientCity { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string ComplaintDescription { get; set; }

        public bool WithAttachment { get; set; }
    }
}
