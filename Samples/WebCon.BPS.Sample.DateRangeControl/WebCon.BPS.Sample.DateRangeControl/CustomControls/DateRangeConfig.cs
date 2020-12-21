using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BPS.Sample.DateRangeControl.CustomControls
{
    public class DateRangeConfig : PluginConfiguration
    {
        [ConfigEditableText(DisplayName = "Date from", Description = "Database field where \"date from\" will be stored")]
        public int DateFromDbID { get; set; }

        [ConfigEditableText(DisplayName = "Date to", Description = "Database field where \"date to\" will be stored")]
        public int DateToDbID { get; set; }
    }
}