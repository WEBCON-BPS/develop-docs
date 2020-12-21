namespace WebCon.BPS.Sample.RestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SampleRestAPIWrapper sampleRestAPIWrapper = new SampleRestAPIWrapper();
            int elementId = sampleRestAPIWrapper.RegisterInvoice();
            if (elementId != -1)
            {
                sampleRestAPIWrapper.AddInvoiceAttachment(elementId);
                sampleRestAPIWrapper.UpdateInvoice(elementId);
            }
        }
    }
}
