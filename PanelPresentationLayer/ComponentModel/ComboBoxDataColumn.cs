using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.ComponentModel
{
    public class ComboBoxDataColumn
    {
        public string ColumnName { get; set; }
        public string ColumnTitle { get; set; }
        public bool IsOrderable { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsVisible { get; set; }
        public string FontColor { get; set; }

        public ComboBoxDataColumn()
        {
            IsOrderable = true;
            IsSearchable = true;
            IsVisible = true;
            FontColor = "Black";
        }
    }
}
