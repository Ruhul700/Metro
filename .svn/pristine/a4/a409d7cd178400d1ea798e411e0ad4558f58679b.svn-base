using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Data;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
   public class T19035DAL : CommonDAL
    {
        public DataTable LoadGridData()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T35.T_APLCTN_CODE, T35.T_EMP_CODE, T11.T_EMP_NAME, T35.T_LEAVE_CODE, T13.T_LEAVE_NAME, T35.T_FROM_DATE FROM_DATE_STRING, T35.T_TO_DATE TO_DATE_STRING, T35.T_WIDTH_PAY, T35.T_WIDTHOUT_PAY, T35.T_TOTAL_DATE, case T_STATUS when 1 then 'Applied' when 2 then 'Accepted' when 3 then 'Cancelled' when 4 then 'Rejected' end AS T_STATUS FROM dbo.T19035 T35 JOIN dbo.T11111 T11 ON T35.T_EMP_CODE = T11.T_EMP_CODE JOIN dbo.T19013 T13 ON T35.T_LEAVE_CODE = T13.T_LEAVE_CODE");
            return dt;
        }
        public DataTable GetLeaveTypeList()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT D.T_LEAVE_CODE,D.T_LEAVE_NAME,D.T_LEAVE_DAY FROM DBO.T19013 D");
            return dt;
        }

        public DataTable GetEmpList()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T_EMP_CODE, T_EMP_NAME FROM dbo.T11111");
            return dt;
        }

        public string CancelApplication(T19035Data t19035, string EntryUser)
        {
            string sms = "";
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(t19035.T_CANCELLED))
            {
                var sa = Command($"UPDATE T19035 SET T_STATUS='3' WHERE T_APLCTN_CODE ='{t19035.T_APLCTN_CODE}'");
                if (sa == true)
                {
                    sms = "Application Cancelled Successfully-1";
                }
                else
                {
                    sms = "Do not Update-0";
                }
            }
            else
            {
                sms = "Do not Update-0";
            }            
            return sms;
        }

        public string SaveData(T19035Data t19035, string EntryUser)
        {
            string sms = "";
            DataTable dt = new DataTable();
            dt = Query($@"SELECT count(*)  FROM dbo.T19035 where dbo.T19035.T_APLCTN_CODE = '{t19035.T_APLCTN_CODE}'");
            var recordExist = Convert.ToInt32(dt.Rows[0][0]);

            if (recordExist > 0)
            {
                //update
                var sa = Command($"UPDATE T19035 SET T_LEAVE_CODE='{t19035.T_LEAVE_CODE}',T_WIDTH_PAY='{t19035.T_WIDTH_PAY}',T_WIDTHOUT_PAY ='{t19035.T_WIDTHOUT_PAY}',T_FROM_DATE ='{t19035.FROM_DATE_STRING}',T_TO_DATE='{t19035.TO_DATE_STRING}',T_TOTAL_DATE='{t19035.T_TOTAL_DATE}'WHERE T_APLCTN_CODE ='{t19035.T_APLCTN_CODE}'");
                if (sa == true)
                {
                    sms = "Update Successfully-1";
                }
                else
                {
                    sms = "Do not Update-0";
                }
            }
            else
            {
                int MaxApplicationCode = Convert.ToInt32(Query("SELECT ISNULL(MAX(T_APLCTN_CODE), 0) + 1 FROM dbo.T19035").Rows[0][0]);
                var sa = Command($@"INSERT INTO dbo.T19035 (T_APLCTN_CODE, T_EMP_CODE, T_LEAVE_CODE, T_WIDTH_PAY, T_WIDTHOUT_PAY, T_FROM_DATE, T_TO_DATE, T_TOTAL_DATE,T_STATUS, T_ENTRY_USER, T_ENTRY_DATE) values ('{MaxApplicationCode}', '{t19035.T_EMP_CODE}', '{t19035.T_LEAVE_CODE}', '{t19035.T_WIDTH_PAY}', '{t19035.T_WIDTHOUT_PAY}','{t19035.FROM_DATE_STRING}','{t19035.TO_DATE_STRING}','{t19035.T_TOTAL_DATE}','1', '{EntryUser}',CAST(GETDATE() AS DATE))");
                if (sa == true)
                {
                    sms = "Save Successfully-1";
                }
                else
                {
                    sms = "Do not Save-0";
                }
            }
            return sms;
        }
    }
}
