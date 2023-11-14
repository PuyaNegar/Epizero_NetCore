using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Enums
{
    public enum UserScoreType
    {
        //==================================================
        /// <summary>
        /// افزایش اعتبار کیف پول توسط مدیر
        /// </summary>
        IncreaseCreditsByAdmin = 1,
        //==================================================
        /// <summary>
        /// کاهش اعتبار کیف پول توسط مدیر
        /// </summary>
        DecreaseCreditsByAdmin = 2,
        //==================================================
        /// <summary>
        /// افزایش اعتبار به علت خرید
        /// </summary>
        IncreaseCreditDuePurchase = 3,
        //===================================================
        /// <summary>
        /// افزایش اعتبار به علت نظردهی
        /// </summary>
        IncreaseCreditDueReviews = 4,
        //===================================================
        /// <summary>
        /// افزایش اعتبار به علت تکمیل پروفایل
        /// </summary>
        IncreaseCreditDueProfileCompletion = 5,
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        IncreaseCreditsDueStudentFinancialReturnPayment = 6, 
        //===================================================
        /// <summary>
        /// 
        /// </summary>
        DecreaseCreditDueStudentFinancialPayment = 7,
        //===================================================

        DecreaseDueConvertCoinToCredit = 8,

    }
}
