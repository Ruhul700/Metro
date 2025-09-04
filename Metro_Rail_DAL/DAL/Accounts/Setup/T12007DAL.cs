using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12007DAL:CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"select TRANSACTION_TYPE_CODE,TRANSACTION_TYPE_NAME from T12007 ORDER BY TRANSACTION_TYPE_ID DESC  ");
            return sql;
        }

        public string SaveData(T12007Data data)
        {
            string mgs = "";
            if (data.TRANSACTION_TYPE_CODE == "0")
            {
                var codeNo = Query($"select MAX(CAST( TRANSACTION_TYPE_CODE AS numeric))+1 TRANSACTION_TYPE_CODE FROM T12007").Rows[0]["TRANSACTION_TYPE_CODE"].ToString();
                var save = Command($"INSERT INTO T12007 (TRANSACTION_TYPE_CODE, TRANSACTION_TYPE_NAME)VALUES('{codeNo}', '{data.TRANSACTION_TYPE_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12007 SET TRANSACTION_TYPE_NAME= '{data.TRANSACTION_TYPE_NAME}' WHERE TRANSACTION_TYPE_CODE='{data.TRANSACTION_TYPE_CODE}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
