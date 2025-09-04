using Metro_Rail_DAL.Shared.Payroll.Transaction;
using System.Collections.Generic;
using System.Data;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
   public class T19036DAL : CommonDAL
    {
        public DataTable LoadGridData()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T35.T_APLCTN_CODE, T35.T_EMP_CODE, T11.T_EMP_NAME, T35.T_LEAVE_CODE, T13.T_LEAVE_NAME, T35.T_FROM_DATE FROM_DATE_STRING, T35.T_TO_DATE TO_DATE_STRING, T35.T_WIDTH_PAY, T35.T_WIDTHOUT_PAY, T35.T_TOTAL_DATE, case T_STATUS when 1 then 'Applied' when 2 then 'Accepted' when 3 then 'Cancelled' when 4 then 'Rejected' end AS T_STATUS FROM dbo.T19035 T35 JOIN dbo.T11111 T11 ON T35.T_EMP_CODE = T11.T_EMP_CODE JOIN dbo.T19013 T13 ON T35.T_LEAVE_CODE = T13.T_LEAVE_CODE");
            return dt;
        }
        public string SaveData(List<T19036Data> list, string EntryUser)
        {
            string sms = "";
            DataTable dt = new DataTable();
            bool isUpdated = false;
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.T_VERIFY_FLAG))
                {
                    var sa = Command($"UPDATE T19035 SET T_VERIFY_FLAG='{item.T_VERIFY_FLAG}',T_VERIFY_DATE=CAST(GETDATE() AS DATE),T_VERIFY_USER ='{EntryUser}',T_STATUS='2' WHERE T_APLCTN_CODE ='{item.T_APLCTN_CODE}'");
                    isUpdated = true;

                }
                if (!string.IsNullOrEmpty(item.T_REJECT_FLAG))
                {
                    var sa = Command($"UPDATE T19035 SET T_STATUS='4' WHERE T_APLCTN_CODE ='{item.T_APLCTN_CODE}'");
                    isUpdated = true;

                }

            }
            if (isUpdated)
            {
                sms = "Update Successfully-1";
            }
            else
            {
                sms = "Do not Update-0";
            }

            return sms;
        }
    }
}
