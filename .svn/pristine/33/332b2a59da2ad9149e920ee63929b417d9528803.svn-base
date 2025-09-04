using Metro_Rail_DAL.Shared.Budget.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Budget.Transaction
{
   public class T12020DAL:CommonDAL
    {
        public DataTable GetAllProjectData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_PROJECT_CODE, T_PROJECT_NAME FROM T12003 ORDER BY T_PROJECT_ID  ");
            return sql;
        }
        public DataTable GetAllPeriodData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_PERIOD_ID, T_PERIOD_CODE,T_PERIOD_NAME,T_PERIOD_START_DATE, T_PERIOD_END_DATE FROM T12002 ORDER BY T_PERIOD_ID DESC ");
            return sql;
        }
        public DataTable GetHeaderData()
        {
            DataTable sql = new DataTable();
            sql = Query($"select T12010.ACCOUNT_HEADER_ID, T12010.ACCOUNT_HEADER_CODE, T12010.ACCOUNT_TYPE_CODE, T12010.ACCOUNT_ECONO_CODE, T12010.ACCOUNT_HEADER_NAME, T12013.ACCOUNT_TYPE_NAME from T12010 JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE=T12013.ACCOUNT_TYPE_CODE ");
            return sql;
        }
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"select T12020.T_BUDGET_ID, T12020.T_BUDGET_CODE,T12020.T_PROJECT_CODE, T12020.T_BUDGET_NAME,T_ADP_GOB,T_ADP_PRO_HELP,T_TOTAL_ADP_AMOUNT,T_RADP_GOB, T_RADP_PRO_HELP,T_TOTAL_RADP_AMOUNT, T12020.T_PERIOD_CODE, T12002.T_PERIOD_NAME, T12003.T_PROJECT_NAME, T12003.T_PERIOD_START_DATE, T12003.T_PERIOD_END_DATE, T12010.ACCOUNT_HEADER_ID, T12010.ACCOUNT_HEADER_CODE, T12010.ACCOUNT_TYPE_CODE, T12010.ACCOUNT_HEADER_NAME, T12013.ACCOUNT_TYPE_NAME from T12020 JOIN T12003 ON T12020.T_PROJECT_CODE=T12003.T_PROJECT_CODE JOIN T12002 ON T12003.T_PERIOD_CODE=T12002.T_PERIOD_CODE JOIN T12010 ON T12020.T_ACCOUNT_HEADER_CODE=T12010.ACCOUNT_HEADER_CODE JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE=T12013.ACCOUNT_TYPE_CODE ORDER BY T_BUDGET_ID DESC ");
            return sql;
        }
        public string SaveData(T12020Data data,string user)
        {
            string mgs = "";
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            if (data.T_BUDGET_ID == 0)
            {
                //  var chk = Query($@"select case when (select count(*) from T12020 where T_ACCOUNT_HEADER_CODE = '{data.T_ACCOUNT_HEADER_CODE}')>0 then ( select DATEDIFF(day,CONVERT(date, '{date}' ,104) , CONVERT(date, T_PERIOD_END_DATE ,104)) from T12020 where T_ACCOUNT_HEADER_CODE = '{data.T_ACCOUNT_HEADER_CODE}' AND T_BUDGET_ID = (select MAX(T_BUDGET_ID) from T12020 where T_ACCOUNT_HEADER_CODE = '{data.T_ACCOUNT_HEADER_CODE}' ) ) else '0' end T_DIFF").Rows[0]["T_DIFF"].ToString();
                //  if (Convert.ToInt32(chk)>0){ return mgs = "Already Exist-0"; }
                var chk = Query($"select count(*)T_COUNT from T12020 where T_PROJECT_CODE='{data.T_PROJECT_CODE}' AND T_ACCOUNT_HEADER_CODE = '{data.T_ACCOUNT_HEADER_CODE}'").Rows[0]["T_COUNT"].ToString();
                if (Convert.ToInt32(chk) > 0) { return mgs = "Already Exist-0"; }
                var codeNo = Query($"select MAX(CAST( T_BUDGET_CODE AS numeric))+1 T_BUDGET_CODE FROM T12020").Rows[0]["T_BUDGET_CODE"].ToString();
                var save = Command($"INSERT INTO T12020 (T_BUDGET_CODE,T_PROJECT_CODE,T_BUDGET_NAME,T_PERIOD_CODE,T_ACCOUNT_HEADER_CODE, T_ADP_GOB,T_ADP_PRO_HELP,T_TOTAL_ADP_AMOUNT,T_RADP_GOB, T_RADP_PRO_HELP,T_TOTAL_RADP_AMOUNT,T_PERIOD_START_DATE,T_PERIOD_END_DATE,T_ENTRY_USER,T_ENTRY_DATE)VALUES('{codeNo}','{data.T_PROJECT_CODE}','{data.T_BUDGET_NAME}', '{data.T_PERIOD_CODE}', '{data.T_ACCOUNT_HEADER_CODE}','{data.T_ADP_GOB}','{data.T_ADP_PRO_HELP}','{data.T_TOTAL_ADP_AMOUNT}','{data.T_RADP_GOB}', '{data.T_RADP_PRO_HELP}','{data.T_TOTAL_RADP_AMOUNT}','{data.T_PERIOD_START_DATE}','{data.T_PERIOD_END_DATE}','{user}','{date}')");
                if (save) { mgs = "Save Successfully-1"; } else { mgs = " Do not Save-0"; }
            }
            else
            {
                var save = Command($"UPDATE T12020 SET T_PROJECT_CODE='{data.T_PROJECT_CODE}', T_BUDGET_NAME='{data.T_BUDGET_NAME}', T_PERIOD_CODE ='{data.T_PERIOD_CODE}',T_ACCOUNT_HEADER_CODE='{data.T_ACCOUNT_HEADER_CODE}', T_ADP_GOB='{data.T_ADP_GOB}',T_ADP_PRO_HELP='{data.T_ADP_PRO_HELP}',T_TOTAL_ADP_AMOUNT='{data.T_TOTAL_ADP_AMOUNT}',T_RADP_GOB='{data.T_RADP_GOB}', T_RADP_PRO_HELP='{data.T_RADP_PRO_HELP}',T_TOTAL_RADP_AMOUNT='{data.T_TOTAL_RADP_AMOUNT}',T_PERIOD_START_DATE='{data.T_PERIOD_START_DATE}',T_PERIOD_END_DATE='{data.T_PERIOD_END_DATE}' WHERE T_BUDGET_ID='{data.T_BUDGET_ID}'");
                if (save) { mgs = "Update Successfully-1"; } else { mgs = " Do not Update-0"; }
            }
            return mgs;
        }
    }
}
