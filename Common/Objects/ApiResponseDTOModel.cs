using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Objects
{
    public class ApiResponseDTOModel<TResponseResult>  
    {
        /// <summary>
        /// 
        /// </summary>
        public List<KeyValuePair<string, string>> Headers { get; set; } = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// 
        /// </summary>
        public TResponseResult  responseResult { get; set; } 
    }
}
