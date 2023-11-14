using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherPresentationLayer.ComponentModel
{
    public class FileUploader
    {
        public string Name { get; set; }
        public string ButtonFarsiName { get; set; }
        public string DefualtNullFileImagePath { get; set; } 
        public string DefualtSelectedFileImagePath { get; set; } 
        public string KnockoutExpressionString { get; set; }
        public bool HasDeleteBtn { get; set; }
        public string Description { get; set; }
        public int MaxFileSize { get; set; }
        public string Title { get; set; }
        public FileUploader()
        { 
            HasDeleteBtn = true; 
        }

    }
}
