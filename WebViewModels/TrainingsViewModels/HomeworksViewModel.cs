

namespace WebViewModels.TrainingsViewModels
{
  public  class HomeworksViewModel
    {
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string ExpiredDate { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsAnswered { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set;  }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public string FilePathAnswered { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public float?  Grade { get; set; }
    }
}
