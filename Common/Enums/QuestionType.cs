using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Enums
{
    public enum QuestionType
    {

        /// <summary>
        /// تشریحی
        /// </summary>
        DescriptiveQuestions = 1,
        /// <summary>
        /// تستی
        /// </summary>
        MultipleChoiceQuestions = 2,
        /// <summary>
        /// تشریحی_تستی
        /// </summary>
        Descriptive_MultipleChoiceQuestions = 3,
    }
}
