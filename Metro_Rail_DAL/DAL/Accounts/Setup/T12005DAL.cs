using Metro_Rail_DAL.Shared.Accounts.Setup;
using System.Data;

namespace Metro_Rail_DAL.DAL.Accounts.Setup
{
    public class T12005DAL :CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT CENTER_CODE,CENTER_NAME FROM T12005 ORDER BY CENTER_ID DESC ");
            return sql;
        }

        public string SaveData(T12005Data data)
        {
            string mgs = "";
            if (data.CENTER_CODE == "0")
            {
                var codeNo = Query($"select MAX(CAST( CENTER_CODE AS numeric))+1 CENTER_CODE FROM T12005").Rows[0]["CENTER_CODE"].ToString();
                var save = Command($"INSERT INTO T12005 (CENTER_CODE, CENTER_NAME)VALUES('{codeNo}', '{data.CENTER_NAME}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12005 SET CENTER_NAME= '{data.CENTER_NAME}' WHERE CENTER_CODE='{data.CENTER_CODE}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
