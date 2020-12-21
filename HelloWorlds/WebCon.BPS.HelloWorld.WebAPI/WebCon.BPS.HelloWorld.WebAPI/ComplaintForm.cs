using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCon.BPS.HelloWorld.WebAPI
{
    public partial class ComplaintForm : Form
    {
        public ComplaintForm()
        {
            // Ensure that all the IDs used further 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsDataInvalid())
            {
                tbOutput.Text = "Please fill all inputs!";
                return;
            }
            var clientName = tbClientName.Text;
            var clientAddress = tbClientAddress.Text;
            var clientZipCode = tbClientZipCode.Text;
            var clientCity = tbClientCity.Text;
            var complaintDescription = tbComplaintDescription.Text;
            var purchaseDate = dtpPurchaseDate.Value;
            var withAttachment = cbWithAttachment.Checked;

            var formDataBag = new FormDataBag()
            {
                ClientAddress = clientAddress,
                ClientCity = clientCity,
                ClientName = clientName,
                ClientZipCode = clientZipCode,
                ComplaintDescription = complaintDescription,
                PurchaseDate = purchaseDate,
                WithAttachment = withAttachment
            };

            CallWebservice(formDataBag);
        }

        private void CallWebservice(FormDataBag formDataBag)
        {
            string result;
            try
            {
                result = WebAPICaller.StartNewComplaint(formDataBag);
            }
            catch (Exception e)
            {
                result = string.Format("Exception thrown!{0}{1}", Environment.NewLine, e);
            }
            tbOutput.Text = result;
        }

        private bool IsDataInvalid()
        {
            return (string.IsNullOrEmpty(tbClientName.Text) ||
                string.IsNullOrEmpty(tbClientAddress.Text) ||
                string.IsNullOrEmpty(tbClientZipCode.Text) ||
                string.IsNullOrEmpty(tbClientCity.Text) ||
                string.IsNullOrEmpty(tbComplaintDescription.Text)
                );
        }
    }
}
