using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPresentationLayer.ComponentModel
{
    public class ImageUploader
    {
        public string Name { get; set; }
        public string ButtonFarsiName { get; set; }
        public string DefualuNullImagePath { get; set; }
        public string KnockoutExpressionString { get; set; }
        public bool HasDeleteBtn { get; set; }
        public string Description { get; set; }
        public bool IsSquareImage { get; set; }
        public int MaxImageHeight { get; set; }
        public int MinImageHeight { get; set; }
        public int MaxImageWidth { get; set; }
        public int MinImageWidth { get; set; }
        public int MaxImageSize { get; set; }
        public string Title { get; set; }
        public ImageUploader()
        {
            IsSquareImage = false;
            HasDeleteBtn = true;
            MinImageHeight = 300;
            MaxImageHeight = 2160;
            MinImageWidth = 300;
            MaxImageWidth = 3840;
            MaxImageSize = 2048;
        }

    }
}
