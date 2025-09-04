

using System.Collections.Generic;

namespace Metro_Rail_DAL.Shared.Payroll.Setup
{
    public class T19010Data
    {
        public int T_EMP_ID { get; set; }
        public string T_SALARY_SET_CODE { get; set; }
        public string T_EMP_CODE { get; set; }
        public string T_EMP_NAME { get; set; }
        public string T_DESIGNATION_CODE { get; set; }
        public string T_JOINING_DATE { get; set; }
        public string T_PRO_JOING_DATE { get; set; }
        public string T_GRADE_CODE { get; set; }
        public string T_SAL_INC_DATE { get; set; }//not in database
        public string T_PAY_SCALE { get; set; }//not in database
        public string T_NID { get; set; }
        public string T_TIN_NO { get; set; }
        public string T_EMP_ADDRESS { get; set; }
        public string T_BANK_CODE { get; set; }//not in database
        public string T_BANK_NAME { get; set; }
        public string T_ACCOUNT_NO { get; set; }
        public string T_EMP_TYPE { get; set; }
        public string T_PF { get; set; }
        public string T_SALARY { get; set; }
        public string T_HOUSE_RENT { get; set; }
        public string T_OVERTIME { get; set; }
        public string T_BONUS { get; set; }
        public string T_ROUTING_NO { get; set; }
        public string T_ACTIVE_FLAG { get; set; }
        public string T_ENTRY_USER { get; set; }
        public string T_ENTRY_DATE { get; set; }
        public string T_UPDATE_USER { get; set; }
        public string T_UPDATE_DATE { get; set; }
        public int T_PAYMENT_TOTAL { get; set; }
        public int T_DEDUCTION_TOTAL { get; set; }
    }

    public class T19010PaymentListData
    {
        public int T_SALARY_SET_DETL_ID { get; set; }
        public string T_SALARY_SET_CODE { get; set; }
        public string T_SALARY_INFO_CODE { get; set; }
        public string T_SALARY_SET_TOTAL { get; set; }
        public string T_AMOUNT { get; set; }
    }

    public class T19010DeductionListData
    {
        public int T_DEDUCTION_ID { get; set; }
        public string T_DEDUCTION_CODE { get; set; }
        public string T_DEDUCTION_NAME { get; set; }
        public string T_DEDUCTION_AMOUNT { get; set; }
    }

    public class T19010SaveModel
    {
        public T19010Data T19010 { get; set; }
        public List<T19010PaymentListData> PaymentList { get; set; }
        public List<T19010DeductionListData> DeductionList { get; set; }
    }
}
