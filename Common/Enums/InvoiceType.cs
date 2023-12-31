﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Enums
{
    public enum InvoiceType
    {
        //==================================================
        /// <summary>
        /// شارژ كیف پول
        /// </summary>
        ChargeCredit = 1,
        //==================================================
        /// <summary>
        /// سفارش آنلاین خرید
        /// </summary>
        Order = 2,
        //==================================================
        /// <summary>
        /// افزایش اعتبار به علت ثبت نام با کد معرف
        /// </summary>
        IncreaseCreditsDueToRegistrationWithIdentifierCode = 3,
        //==================================================
        /// <summary>
        /// افزایش اعتبار به علت معرفی کاربر
        /// </summary>
        IncreaseCreditsDueToUserIntroduction = 4,
        //==================================================
        /// <summary>
        /// برداشت جهت شارژ اعتبار پیامکی
        /// </summary>
        ChargeSmsCredit = 5,
        //==================================================
        /// <summary>
        /// افزایش اعتبار کیف پول توسط مدیر
        /// </summary>
        IncreaseCreditsByAdmin = 6,
        //==================================================
        /// <summary>
        /// کاهش اعتبار کیف پول توسط مدیر
        /// </summary>
        DecreaseCreditsByAdmin = 7 , 
        //==================================================
        /// <summary>
        /// تسویه صورت حساب دوره با  لینک پرداختی 
        /// </summary>
        StudentPaymentLink = 8 ,
        //==================================================
        /// <summary>
        /// شارژ کیف پول به علت عودت وجه  به دانش آموز
        /// </summary>
        IncreaseCreditsDueStudentFinancialReturnPayment = 9 ,
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        DecreaseCreditDueStudentFinancialPayment = 10 ,
        //==================================================
        /// <summary>
        /// 
        /// </summary>
        IncreaseDueConvertCoinToCredit = 11 ,
        //==================================================
    }
}
