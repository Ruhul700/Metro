
using Metro_Rail_DAL.Shared.Payroll.Setup;
using System.Collections.Generic;
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Metro_Rail_DAL.Shared.Payroll.Transaction;

namespace Metro_Rail_DAL.DAL.Payroll.Transaction
{
    public class T19022DAL : CommonDAL
    {
        
        public DataTable LoadGridData(string param)
        {
            DataTable dt = new DataTable();
            dt = Query($@"select t20.T_SALARY_ID, t20.T_BASE_CODE, t20.T_SALARY_CODE, t20.T_MONTH_CODE,t11.T_MONTH_NAME, t20.T_YEAR, t21.T_EMP_CODE,(select t111.T_EMP_NAME from dbo.T11111 t111 where t111.T_EMP_CODE = t21.T_EMP_CODE) EMP_NAME,t21.T_SALARY_GROSS,t21.T_SALARY_PAYMENT,t21.T_SALARY_PAYABLE from dbo.T19020 t20 join dbo.T19021 t21 on t20.T_SALARY_CODE = t21.T_SALARY_CODE join dbo.t11011 t11 on t20.T_MONTH_CODE = t11.T_MONTH_CODE where t20.T_MONTH_CODE = '{param}' and t20.T_VERIFY_FLAG is null and T_BASE_CODE != '103'");
            return dt;
        }

        public DataTable GetMonthList()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T_MONTH_CODE,T_MONTH_NAME FROM T11011");
            return dt;
        }

        public string SaveData(List<T19022Data> list, string EntryUser)
        {
            var sms = "";
            if (list != null && list.Count > 0)
            {
                string salaryCode = list[0].T_SALARY_CODE;
                var da = Command($@"UPDATE T19020 SET T_VERIFY_FLAG='1',T_UPDATE_USER='{EntryUser}',T_UPDATE_DATE=CAST(GETDATE() AS DATE) WHERE T_SALARY_CODE ='{salaryCode}'");

                if (da == true)
                {
                    sms = "Update Successfully-1";
                }
                else
                {
                    sms = "Do not Update-0";
                }
            }            
            return sms;

        }

    }
}
