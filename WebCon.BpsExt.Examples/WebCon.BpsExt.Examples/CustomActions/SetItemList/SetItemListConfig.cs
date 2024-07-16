using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace WebCon.BpsExt.Examples.CustomActions.SetItemList
{
    public class SetItemListConfig : PluginConfiguration
    {
        [ConfigEditableText("Sql query", Description = "SQL query returning data to be inserted into item list", Multiline = true, TagEvaluationMode = EvaluationMode.SQL)]
        public string SqlQuery { get; set; }

        [ConfigEditableItemList("Item List")]
        public ItemList ItemListConfig { get; set; }

    }

    public class ItemList : IConfigEditableItemList
    {
        public int ItemListId { get; set; }

        [ConfigEditableItemListColumnID("First column", IsRequired = true)]
        public int FirstColumnId { get; set; }

        [ConfigEditableItemListColumnID("Second column", IsRequired = true)]
        public int SecondColumnId { get; set; }

        [ConfigEditableItemListColumnID("Third column", IsRequired = true)]
        public int ThirdColumnId { get; set; }
    }
}