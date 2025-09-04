using Metro_Rail_DAL.Shared.Budget.Transaction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Metro_Rail_DAL.DAL.Budget.Transaction
{
    public class T12021DAL : CommonDAL
    {
        public DataTable GetAllData()
        {
            DataTable sql = new DataTable();
            sql = Query($"select T12020.T_BUDGET_ID, T12020.T_BUDGET_CODE,T12020.T_PROJECT_CODE, T12020.T_BUDGET_NAME,CASE WHEN T_RADP_GOB =0 THEN T_ADP_GOB WHEN T_REAPROPN =0 THEN T_RADP_GOB ELSE T_REAPROPN END T_ADP_GOB,T_ADP_PRO_HELP,T_TOTAL_ADP_AMOUNT,T_RADP_GOB, T_RADP_PRO_HELP,T_TOTAL_RADP_AMOUNT,CASE WHEN T_ADP_GOB =0 THEN '1'WHEN T_RADP_GOB =0 THEN '2' WHEN T_REAPROPN =0 THEN '3' ELSE '4' END T_GOB_STATUS,COALESCE(T_REAPROPN,0) T_REAPROPN,CASE WHEN T_RADP_GOB =0 THEN (T_ADP_GOB+T_ADP_PRO_HELP) WHEN T_REAPROPN =0 THEN (T_RADP_GOB+T_ADP_PRO_HELP) ELSE (COALESCE(T_REAPROPN,0)+T_ADP_PRO_HELP) END T_TOTAL_AMOUNT, T12020.T_PERIOD_CODE, T12002.T_PERIOD_NAME, T12003.T_PROJECT_NAME, T12003.T_PERIOD_START_DATE, T12003.T_PERIOD_END_DATE, T12010.ACCOUNT_HEADER_ID, T12010.ACCOUNT_HEADER_CODE,T12010.ACCOUNT_ECONO_CODE, T12010.ACCOUNT_TYPE_CODE, T12010.ACCOUNT_HEADER_NAME, T12013.ACCOUNT_TYPE_NAME,'0' T_STATUS from T12020 JOIN T12003 ON T12020.T_PROJECT_CODE=T12003.T_PROJECT_CODE JOIN T12002 ON T12003.T_PERIOD_CODE=T12002.T_PERIOD_CODE JOIN T12010 ON T12020.T_ACCOUNT_HEADER_CODE=T12010.ACCOUNT_HEADER_CODE JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE=T12013.ACCOUNT_TYPE_CODE ORDER BY T_BUDGET_ID DESC ");
            return sql;
        }
        public string SaveData(List<T12021Data> data, string user)
        {
            string sms = "";
            bool save = false;
            int count = 0;
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            SqlTransaction objTrans = null;
            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
            {
                try
                {
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();
                    foreach (var i in data)
                    {
                        if (i.T_GOB_STATUS == "1" && i.T_NEW_GOB>0) { save = Command($"UPDATE T12020 SET  T_ADP_GOB='{i.T_NEW_GOB}' WHERE T_BUDGET_ID='{i.T_BUDGET_ID}'"); }
                        else if (i.T_GOB_STATUS == "2" && i.T_NEW_GOB > 0) { save = Command($"UPDATE T12020 SET  T_RADP_GOB='{i.T_NEW_GOB}' WHERE T_BUDGET_ID='{i.T_BUDGET_ID}'"); }
                        else if (i.T_GOB_STATUS == "3" && i.T_NEW_GOB > 0) { save = Command($"UPDATE T12020 SET  T_REAPROPN='{i.T_NEW_GOB}' WHERE T_BUDGET_ID='{i.T_BUDGET_ID}'"); }
                        if (i.T_ADP_PRO_HELP > 0) { save = Command($"UPDATE T12020 SET  T_ADP_PRO_HELP='{i.T_ADP_PRO_HELP}' WHERE T_BUDGET_ID='{i.T_BUDGET_ID}'"); }
                       // save = Command($"UPDATE T12020 SET  T_ADP_GOB='{i.T_ADP_GOB}',T_ADP_PRO_HELP='{i.T_ADP_PRO_HELP}',T_RADP_GOB='{i.T_RADP_GOB}',T_REAPROPN='{i.T_REAPROPN}' WHERE T_BUDGET_ID='{i.T_BUDGET_ID}'");
                        if (save) { sms = "Update Successfully-1"; count++; } else { sms = " Do not Update-0"; }
                    }

                    if (data.Count() == count)
                    {
                        objTrans.Commit();
                        sms = "Save Successfully-1";
                    }
                    else
                    {
                        objTrans.Rollback();
                        sms = "Do not Save-0";
                    }
                }

                catch (Exception ex)
                {
                    var kk = ex.Message;
                    objTrans.Rollback();
                    sms = "Do not Save-0";
                }
                finally
                {
                    objConn.Close();
                }
            }
            return sms;
        }

        public DataTable GetSetBudgetReport()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_ADP_GOB,T_ADP_PRO_HELP, T_TOTAL_ADP_AMOUNT, T_RADP_GOB, T_RADP_PRO_HELP, T_TOTAL_RADP_AMOUNT, COALESCE(T_REAPROPN,0) T_REAPROPN, CASE WHEN T_RADP_GOB =0 THEN (T_ADP_GOB+T_ADP_PRO_HELP) WHEN T_REAPROPN =0 THEN (T_RADP_GOB+T_ADP_PRO_HELP) ELSE (COALESCE(T_REAPROPN,0)+T_ADP_PRO_HELP) END T_TOTAL_AMOUNT, T12002.T_PERIOD_NAME, T12003.T_PROJECT_NAME, T12010_M.ACCOUNT_HEADER_MAIN_NAME, T12010.ACCOUNT_ECONO_CODE, T12010.ACCOUNT_HEADER_NAME, T12013.ACCOUNT_TYPE_NAME FROM T12020 JOIN T12003 ON T12020.T_PROJECT_CODE=T12003.T_PROJECT_CODE JOIN T12002 ON T12003.T_PERIOD_CODE=T12002.T_PERIOD_CODE JOIN T12010 ON T12020.T_ACCOUNT_HEADER_CODE=T12010.ACCOUNT_HEADER_CODE JOIN T12010_M ON T12010.ACCOUNT_HEADER_MAIN_CODE =T12010_M.ACCOUNT_HEADER_MAIN_CODE JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE=T12013.ACCOUNT_TYPE_CODE ORDER BY T_BUDGET_ID DESC ");
            return sql;
        }
    }
}
