﻿using Newtonsoft.Json;
using PanelViewModels.UtilityJsonConvertor;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentFinanciaSummaryViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string StudentFullName { get; set;  }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int  TotalSum { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalFines { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public bool  IsDebt  { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalPayments { get; set;  }
        //===================================================== 
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalReturn { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalManualDebts { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(CurrencyIntegerConvertor))]
        public int TotalDebts { get; set; }  
        //=====================================================
        /// <summary>
        ///
        /// </summary>
        public List<StudentFinancialPaymentsViewModel> StudentFinancialPayments { get; set;  }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<StudentFinancialDebtsViewModel>  StudentFinancialDebts  { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<StudentFinancialManualDebtsViewModel> StudentFinancialManualDebts { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<StudentFinesViewModel > StudentFines { get; set;  }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public List<StudentFinancialReturnPaymentsViewModel> StudentFinancialReturnPayments { get; set; }

    }
}
