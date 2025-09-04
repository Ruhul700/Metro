using Metro_Rail_DAL.Shared.Accounts.Setup;
using Metro_Rail_DAL.Shared.Payroll.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T13010DAL : CommonDAL
    {
        public DataTable LoadData()

        {
            DataTable dt = new DataTable();
            dt = Query($@"select T_SUPPLIER_ID,T_SUPPLIER_CODE,T_SUPPLIER_NAME,T_MOBILE_NO,T_TIN_NO,T_VAT_NO,T_NID_NO, T_ACCOUNT_NAME,T_ACCOUNT_NO,T_BANK_NAME,T_BRANCH,T_SUPPLIER_TYPE from T13010");
            return dt;
        }
        
        public string SaveData(T13010Data t13010)
        {
            string sms = "";
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            if (t13010.T_SUPPLIER_ID == 0)
            {
                var maxCode = Query($"select MAX( cast( T_SUPPLIER_CODE as int)+1)T_SUPPLIER_CODE from T13010").Rows[0]["T_SUPPLIER_CODE"].ToString();
                var sa = Command($"INSERT INTO T13010 (T_SUPPLIER_CODE,T_SUPPLIER_NAME,T_MOBILE_NO,T_TIN_NO,T_VAT_NO,T_NID_NO, T_ACCOUNT_NAME,T_ACCOUNT_NO,T_BANK_NAME,T_BRANCH,T_SUPPLIER_TYPE,T_ENTRY_DATE) VALUES('{maxCode}','{t13010.T_SUPPLIER_NAME}','{t13010.T_MOBILE_NO}','{t13010.T_TIN_NO}','{t13010.T_VAT_NO}','{t13010.T_NID_NO}','{t13010.T_ACCOUNT_NAME}','{t13010.T_ACCOUNT_NO}', '{t13010.T_BANK_NAME}', '{t13010.T_BRANCH}', '{t13010.T_SUPPLIER_TYPE}','{date}')");
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
                var sa = Command($"UPDATE T13010 SET T_SUPPLIER_NAME='{t13010.T_SUPPLIER_NAME}',T_MOBILE_NO='{t13010.T_MOBILE_NO}',T_TIN_NO='{t13010.T_TIN_NO}',T_VAT_NO='{t13010.T_VAT_NO}', T_NID_NO='{t13010.T_NID_NO}',T_ACCOUNT_NAME='{t13010.T_ACCOUNT_NAME}',T_ACCOUNT_NO='{t13010.T_ACCOUNT_NO}', T_BANK_NAME='{t13010.T_BANK_NAME}',T_BRANCH='{t13010.T_BRANCH}',T_SUPPLIER_TYPE='{t13010.T_SUPPLIER_TYPE}',T_UPDATE_DATE ='{date}' WHERE T_SUPPLIER_ID ='{t13010.T_SUPPLIER_ID}'");
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