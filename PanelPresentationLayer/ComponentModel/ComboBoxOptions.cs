using System.Collections.Generic;

namespace PanelPresentationLayer.ComponentModel
{
    public class ComboBoxOptions
    {
        public bool IsMultiSelect { get; set; }
        public string ComboBoxName { get; set; }
        public string Url { get; set; }
        public List<ComboBoxDataColumn> ComboBoxDataColumn { get; set; }
        public string CascadingComboIds { get; set; }
        public string ValueField { get; set; }
        public string TextField { get; set; }
        public string TargetValueInputId { get; set; }
        public string CascadingEmptyErrorMessage { get; set; }
        public ComboBoxOptions()
        {
            this.CascadingComboIds = "";
        }
    }
    
}
