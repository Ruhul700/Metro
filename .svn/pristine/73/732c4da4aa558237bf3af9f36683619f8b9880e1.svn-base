using Metro_Rail_DAL.Shared.Accounts.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12010MDAL : CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($@"SELECT ACCOUNT_HEADER_MAIN_ID, ACCOUNT_HEADER_MAIN_CODE,ACCOUNT_ECONO_MAIN_CODE,ACCOUNT_HEADER_MAIN_NAME,
ACCOUNT_HEADER_MAIN_NAME_ENG, T12010_M.ACCOUNT_TYPE_CODE, T12013.ACCOUNT_TYPE_NAME FROM T12010_M LEFT JOIN T12013 ON T12010_M.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE ORDER BY ACCOUNT_HEADER_MAIN_ID DESC");
            return sql;
        }
        public DataTable GetAccountType()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT ACCOUNT_TYPE_CODE,ACCOUNT_TYPE_NAME FROM T12013 ORDER BY ACCOUNT_TYPE_ID ASC");
            return sql;
        }

        public string SaveData(T12010MData data)
        {
            string mgs = "";
            if (data.ACCOUNT_HEADER_MAIN_ID == 0)
            {
                var codeNo = Query($"select MAX(CAST( ACCOUNT_HEADER_MAIN_CODE AS numeric))+1 ACCOUNT_HEADER_MAIN_CODE FROM T12010_M").Rows[0]["ACCOUNT_HEADER_MAIN_CODE"].ToString();
                var save = Command($"INSERT INTO T12010_M (ACCOUNT_HEADER_MAIN_CODE,ACCOUNT_ECONO_MAIN_CODE, ACCOUNT_HEADER_MAIN_NAME,ACCOUNT_HEADER_MAIN_NAME_ENG,ACCOUNT_TYPE_CODE)VALUES('{codeNo}', '{data.ACCOUNT_ECONO_MAIN_CODE}', N'{data.ACCOUNT_HEADER_MAIN_NAME}','{data.ACCOUNT_HEADER_MAIN_NAME_ENG}','{data.ACCOUNT_TYPE_CODE}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12010_M SET ACCOUNT_ECONO_MAIN_CODE='{data.ACCOUNT_ECONO_MAIN_CODE}', ACCOUNT_HEADER_MAIN_NAME= N'{data.ACCOUNT_HEADER_MAIN_NAME}',ACCOUNT_HEADER_MAIN_NAME_ENG='{data.ACCOUNT_HEADER_MAIN_NAME_ENG}',ACCOUNT_TYPE_CODE= '{data.ACCOUNT_TYPE_CODE}' WHERE ACCOUNT_HEADER_MAIN_ID='{data.ACCOUNT_HEADER_MAIN_ID}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
