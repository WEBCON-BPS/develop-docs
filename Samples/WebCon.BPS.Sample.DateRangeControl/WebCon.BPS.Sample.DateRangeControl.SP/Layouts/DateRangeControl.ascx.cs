using WebCon.BPS.Sample.DateRangeControl.CustomControls;
using WebCon.WorkFlow.SDK.Documents.Model.Base;
using WebCon.WorkFlow.SDK.SP.FormFieldPlugins;
using WebCon.WorkFlow.SDK.SP.FormFieldPlugins.Model;

namespace WebCon.BPS.Sample.DateRangeControl.SP.Layouts
{
    public partial class DateRangeControl : CustomFormFieldSPControl<DateRangeConfig, DateRangeValue>
    {

        public override DisplayNamePlace FormFieldDisplayNamePlace => DisplayNamePlace.Beside;

        public override DateRangeValue GetControlValue(GetControlValueParams<CustomFormFieldContext> args)
        {
            if (!DateTimeControl1.IsDateEmpty && !DateTimeControl2.IsDateEmpty)
                return new DateRangeValue()
                {
                    FromDate = DateTimeControl1.SelectedDate,
                    ToDate = DateTimeControl2.SelectedDate
                };
            else
                return null;
        }

        public override void SetControlValue(SetControlValueParams<CustomFormFieldContext, DateRangeValue> args)
        {
            ValidateReadOnly(args.Context.CurrentField);
            if (args.ValueToSet != null)
            {
                if (args.ValueToSet.FromDate != null)
                    DateTimeControl1.SelectedDate = args.ValueToSet.FromDate.Value;
                if (args.ValueToSet.ToDate != null)
                    DateTimeControl2.SelectedDate = args.ValueToSet.ToDate.Value;
            }
        }

        private void ValidateReadOnly(FormElement currentField)
        {
            DateTimeControl1.Enabled = currentField.IsEditable;
            DateTimeControl2.Enabled = currentField.IsEditable;
        }
    }
}