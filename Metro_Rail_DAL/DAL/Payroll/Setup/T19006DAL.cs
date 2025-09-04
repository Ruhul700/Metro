using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Payroll.Setup
{
   public class T19006DAL:CommonDAL
    {
        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("SELECT T_BENEFIT_ID,T_BENEFIT_CODE,T_BENEFIT_NAME,T_BENEFIT_AMOUNT FROM T19006 ORDER BY T_BENEFIT_ID");
            return dt;
        }        
        public string SaveData(T19006Data t19006)
        {
            string sms = "";
            if (t19006.T_BENEFIT_ID == 0)
            {
                var sa = Command($"INSERT INTO T19006 (T_BENEFIT_CODE,T_BENEFIT_NAME,T_BENEFIT_AMOUNT) VALUES('{t19006.T_BENEFIT_CODE}','{t19006.T_BENEFIT_NAME}','{t19006.T_BENEFIT_AMOUNT}')");
                if (sa == true)
                {
                    sms = "Save Successfully-1";
                }
                else
                {
                    sms = "Do not Save-0";
                }
            }
            else
            {
                var sa = Command($"UPDATE T19006 SET T_BENEFIT_CODE='{t19006.T_BENEFIT_CODE}', T_BENEFIT_NAME='{t19006.T_BENEFIT_NAME}',T_BENEFIT_AMOUNT='{t19006.T_BENEFIT_AMOUNT}'WHERE T_BENEFIT_ID ='{t19006.T_BENEFIT_ID}'");
                if (sa == true)
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
