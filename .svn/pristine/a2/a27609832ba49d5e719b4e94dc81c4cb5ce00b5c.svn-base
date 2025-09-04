using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12012DAL:CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT PURPOSE_CODE,PURPOSE_NAME FROM T12012 ORDER BY PURPOSE_ID DESC");
            return sql;
        }

        public string SaveData(T12012Data data)
        {
            string mgs = "";
            if (data.PURPOSE_CODE == "0")
            {
                var codeNo = Query($"select MAX(CAST( PURPOSE_CODE AS numeric))+1 PURPOSE_CODE FROM T12012").Rows[0]["PURPOSE_CODE"].ToString();
                var save = Command($"INSERT INTO T12012 (PURPOSE_CODE, PURPOSE_NAME)VALUES('{codeNo}', '{data.PURPOSE_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12012 SET PURPOSE_NAME= '{data.PURPOSE_NAME}' WHERE PURPOSE_CODE='{data.PURPOSE_CODE}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
