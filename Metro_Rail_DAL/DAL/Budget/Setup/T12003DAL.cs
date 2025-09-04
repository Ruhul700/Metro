using Metro_Rail_DAL.Shared.Budget.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Budget.Setup
{
    public class T12003DAL : CommonDAL
    {
        public DataTable GetAllPeriodData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_PERIOD_CODE,T_PERIOD_NAME FROM T12002 ORDER BY T_PERIOD_ID DESC ");
            return sql;
        }
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_PROJECT_ID, T_PROJECT_CODE, T12003.T_PERIOD_CODE,T12002.T_PERIOD_NAME, T_PROJECT_NAME,T12003.T_PERIOD_START_DATE, T12003.T_PERIOD_END_DATE FROM T12003 JOIN T12002 ON T12003.T_PERIOD_CODE=T12002.T_PERIOD_CODE  ORDER BY T_PERIOD_ID DESC ");
            return sql;
        }
        public string SaveData(T12003Data data)
        {
            string mgs = "";
            if (data.T_PROJECT_ID == 0)
            {
                var codeNo = Query($"select MAX(CAST( T_PROJECT_CODE AS numeric))+1 T_PROJECT_CODE FROM T12003").Rows[0]["T_PROJECT_CODE"].ToString();
                var save = Command($"INSERT INTO T12003 (T_PROJECT_CODE,T_PERIOD_CODE,T_PROJECT_NAME,T_PERIOD_START_DATE,T_PERIOD_END_DATE)VALUES('{codeNo}','{data.T_PERIOD_CODE}', '{data.T_PROJECT_NAME}', '{data.T_PERIOD_START_DATE}','{data.T_PERIOD_END_DATE}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12003 SET T_PERIOD_CODE='{data.T_PERIOD_CODE}', T_PROJECT_NAME ='{data.T_PROJECT_NAME}',T_PERIOD_START_DATE='{data.T_PERIOD_START_DATE}',T_PERIOD_END_DATE='{data.T_PERIOD_END_DATE}' WHERE T_PROJECT_ID='{data.T_PROJECT_ID}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
