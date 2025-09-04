using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12010DAL:CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT ACCOUNT_HEADER_ID, ACCOUNT_HEADER_CODE,ACCOUNT_ECONO_CODE, ACCOUNT_HEADER_NAME, T12010.ACCOUNT_HEADER_MAIN_CODE,T12010_M.ACCOUNT_ECONO_MAIN_CODE , ACCOUNT_HEADER_NAME_ENG, T12010_M.ACCOUNT_HEADER_MAIN_NAME_ENG , T12010.ACCOUNT_TYPE_CODE, T12013.ACCOUNT_TYPE_NAME FROM T12010 LEFT JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE LEFT JOIN T12010_M ON T12010.ACCOUNT_HEADER_MAIN_CODE = T12010_M.ACCOUNT_HEADER_MAIN_CODE ORDER BY ACCOUNT_HEADER_ID DESC");
            return sql;
        }
        public DataTable GetAccountType()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT ACCOUNT_TYPE_CODE,ACCOUNT_TYPE_NAME FROM T12013 ORDER BY ACCOUNT_TYPE_ID ASC");
            return sql;
        }
        public DataTable GetMainHeader()
        {
            DataTable sql = new DataTable();
            sql = Query($"select ACCOUNT_HEADER_MAIN_CODE, ACCOUNT_ECONO_MAIN_CODE, T12010_M.ACCOUNT_TYPE_CODE, T12013.ACCOUNT_TYPE_NAME, ACCOUNT_HEADER_MAIN_NAME, ACCOUNT_HEADER_MAIN_NAME_ENG from T12010_M LEFT JOIN T12013 ON T12010_M.ACCOUNT_TYPE_CODE = T12013.ACCOUNT_TYPE_CODE");
            return sql;
        }
        public string SaveData(T12010Data data)
        {
            string mgs = "";
            if (data.ACCOUNT_HEADER_ID ==0)
            {
                var codeNo = Query($"select MAX(CAST( ACCOUNT_HEADER_CODE AS numeric))+1 ACCOUNT_HEADER_CODE FROM T12010").Rows[0]["ACCOUNT_HEADER_CODE"].ToString();
                var save = Command($"INSERT INTO T12010 (ACCOUNT_HEADER_CODE,ACCOUNT_ECONO_CODE,ACCOUNT_HEADER_MAIN_CODE, ACCOUNT_HEADER_NAME,ACCOUNT_HEADER_NAME_ENG,ACCOUNT_TYPE_CODE)VALUES('{codeNo}','{data.ACCOUNT_ECONO_CODE}','{data.ACCOUNT_HEADER_MAIN_CODE}', N'{data.ACCOUNT_HEADER_NAME}','{data.ACCOUNT_HEADER_NAME_ENG}','{data.ACCOUNT_TYPE_CODE}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12010 SET ACCOUNT_ECONO_CODE='{data.ACCOUNT_ECONO_CODE}',ACCOUNT_HEADER_MAIN_CODE='{data.ACCOUNT_HEADER_MAIN_CODE}', ACCOUNT_HEADER_NAME= N'{data.ACCOUNT_HEADER_NAME}',ACCOUNT_HEADER_NAME_ENG='{data.ACCOUNT_HEADER_NAME_ENG}',ACCOUNT_TYPE_CODE= '{data.ACCOUNT_TYPE_CODE}' WHERE ACCOUNT_HEADER_ID='{data.ACCOUNT_HEADER_ID}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
