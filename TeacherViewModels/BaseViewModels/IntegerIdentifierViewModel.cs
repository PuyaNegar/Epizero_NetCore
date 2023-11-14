using System;
using System.ComponentModel.DataAnnotations;

namespace TeacherViewModels.BaseViewModels
{
    public class IntegerIdentifierViewModel
    {
        /// <summary>
        /// شناسه
        /// </summary>
        [Required(ErrorMessage = "شناسه نبایستی خالی باشد")]
        public int? Id { get; set;  }
    }
}
