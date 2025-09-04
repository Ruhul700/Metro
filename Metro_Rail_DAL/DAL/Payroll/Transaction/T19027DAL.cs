
using Metro_Rail_DAL.Shared.Payroll.Setup;
using System.Collections.Generic;
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Metro_Rail_DAL.Shared.Payroll.Transaction;

namespace Metro_Rail_DAL.DAL.Payroll.Transaction
{
    public class T19027DAL : CommonDAL
    {       
        public DataTable LoadGridData()
        {
            DataTable dt = new DataTable();
            dt = Query($@"select t21.T_EMP_CODE,te11.T_EMP_NAME, t20.T_BASE_CODE,t20.T_SALARY_CODE,t21.T_SALARY_GROSS,t21.T_SALARY_PAYABLE BONUS_AMOUNT,t21.T_SALARY_PAYABLE from dbo.T19020 t20 join dbo.T19021 t21 on t20.T_SALARY_CODE = t21.T_SALARY_CODE JOIN DBO.T11111 te11 on t21.T_EMP_CODE = te11.T_EMP_CODE where t20.T_BASE_CODE='103' AND T20.T_VERIFY_FLAG IS NULL");
            return dt;
        }
        public string SaveData(List<T19027Data> list, string EntryUser)
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
