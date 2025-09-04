using System;
using System.Collections.Generic;
using System.Data;
using Metro_Rail_DAL.Shared.Payroll.Transaction;

namespace Metro_Rail_DAL.DAL.Payroll.Transaction
{
    public class T19023DAL : CommonDAL
    {
        
        public DataTable LoadGridData() 
        {          
            DataTable dt = new DataTable();
            dt = Query($@"SELECT T10.T_EMP_CODE, (SELECT T_EMP_NAME FROM DBO.T11111 WHERE T_EMP_CODE=T10.T_EMP_CODE) EMP_NAME, T11.T_SALARY_INFO_CODE,T11.T_DEDUCTION_FLAG,T11.T_SALARY_SET_TOTAL TAX_AMOUNT FROM DBO.T19011 T11 JOIN DBO.T19010 T10 ON T11.T_SALARY_SET_CODE = T10.T_SALARY_SET_CODE WHERE T_SALARY_INFO_CODE='1111102' ORDER BY T10.T_EMP_CODE");
            return dt;
        }
        public DataTable ChalanDetails(string T_EMP_CODE)
        {
            DataTable dt = new DataTable();
            dt = Query($@"SELECT T10.T_EMP_CODE, (SELECT T_EMP_NAME FROM DBO.T11111 WHERE T_EMP_CODE=T10.T_EMP_CODE) EMP_NAME, T11.T_SALARY_INFO_CODE,T11.T_DEDUCTION_FLAG,T11.T_SALARY_SET_TOTAL TAX_AMOUNT,(SELECT dbo.fn_NumberToWords(T11.T_SALARY_SET_TOTAL)) TAX_IN_WORDS FROM DBO.T19011 T11 JOIN DBO.T19010 T10 ON T11.T_SALARY_SET_CODE = T10.T_SALARY_SET_CODE WHERE T_SALARY_INFO_CODE='1111102' AND T_EMP_CODE='{T_EMP_CODE}' ORDER BY T10.T_EMP_CODE");
            return dt;

        }
    }
}
