using WebCon.WorkFlow.SDK.Common.Model;
using WebCon.WorkFlow.SDK.FormFieldPlugins;
using WebCon.WorkFlow.SDK.FormFieldPlugins.Model;

namespace WebCon.BPS.Sample.DateRangeControl.CustomControls
{
    public class DateRangeLogic : CustomFormField<DateRangeConfig, DateRangeValue>
    {
        public override DateRangeValue LoadValue(LoadValueParams<CustomFormFieldContext> args)
        {    
            return new DateRangeValue()
            {
                FromDate = args.Context.CurentDocument.DateTimeFields.GetByID(Configuration.DateFromDbID).Value,
                ToDate = args.Context.CurentDocument.DateTimeFields.GetByID(Configuration.DateToDbID).Value
            };
        }

        public override void OnBeforeElementSave(BeforeSaveParams<CustomFormFieldValueContextInfo<DateRangeValue>> args)
        {
            args.Context.CurentDocument.DateTimeFields.GetByID(Configuration.DateFromDbID).SetValue(args.Context.Value?.FromDate);
            args.Context.CurentDocument.DateTimeFields.GetByID(Configuration.DateToDbID).SetValue(args.Context.Value?.ToDate);
        }

        public override void Validate(ControlValidationParams<CustomFormFieldValueContextInfo<DateRangeValue>> args)
        {
            if (!args.Context.CurrentField.IsRequired)
                return;
            if (args.Context.Value == null || args.Context.Value.FromDate == null || args.Context.Value.ToDate == null)
            {
                args.IsValid = false;
                args.ErrorMessage = "Date from and date to must contain values!";
                return;
            }
            if(args.Context.Value.FromDate > args.Context.Value.ToDate)
            { 
                args.IsValid = false;
                args.ErrorMessage = "Date to cannot be earlier than date from!";
            }
        }
    }
}