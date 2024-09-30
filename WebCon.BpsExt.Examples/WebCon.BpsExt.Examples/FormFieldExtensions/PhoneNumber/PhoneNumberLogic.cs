using WebCon.WorkFlow.SDK.FormFieldPlugins;

namespace WebCon.BpsExt.Examples.FormFieldExtensions.PhoneNumber
{
    public class PhoneNumberLogic : FormFieldExtension<PhoneNumberLogicConfig>
    {
        public override object OnDBValueSet(object valueToSet)
        {
            var stringValue = valueToSet as string;
            stringValue = stringValue.Replace("-", "").Replace(" ", "");
            return stringValue;
        }
    }
}