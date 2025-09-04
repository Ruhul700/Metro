using Metro_Rail_DAL.Shared.Budget.Transaction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro_Rail_DAL.DAL.Budget.Transaction
{
   public class T12023DAL:CommonDAL
    {
        public DataTable GetAllProjectData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_PROJECT_CODE, T_PROJECT_NAME FROM T12003 ORDER BY T_PROJECT_ID  ");
            return sql;
        }        
        public DataTable GetHeaderData()
        {
            DataTable sql = new DataTable();
            sql = Query($"select T12010.ACCOUNT_HEADER_ID, T12010.ACCOUNT_HEADER_CODE, T12010.ACCOUNT_TYPE_CODE, T12010.ACCOUNT_ECONO_CODE, T12010.ACCOUNT_HEADER_NAME, T12013.ACCOUNT_TYPE_NAME from T12010 JOIN T12013 ON T12010.ACCOUNT_TYPE_CODE=T12013.ACCOUNT_TYPE_CODE WHERE ACCOUNT_HEADER_MAIN_CODE='117' ");
            return sql;
        }
        public DataTable GetAllData(string T_PROJECT_CODE)
        {
            DataTable sql = new DataTable();
            sql = Query($"select DISTINCT T_BUDGET_ID,T12020.T_PROJECT_CODE,T12003.T_PROJECT_NAME,T_BUDGET_CODE, T_ACCOUNT_HEADER_CODE,T12010.ACCOUNT_ECONO_CODE,T12010.ACCOUNT_HEADER_NAME, T_TOTAL_ADP_AMOUNT,T_TOTAL_RADP_AMOUNT, sum(AT13002.CREDIT) TOTAL_COLLECTION,'' T_FUND_COLLECT from T12020 JOIN T12003 ON T12020.T_PROJECT_CODE = T12003.T_PROJECT_CODE Join T12010 ON T12020.T_ACCOUNT_HEADER_CODE= T12010.ACCOUNT_HEADER_CODE left JOIN AT13001 ON T12020.T_PROJECT_CODE=AT13001.T_PROJECT_CODE left JOIN AT13002 ON AT13001.VOUCHER_NO = AT13002.VOUCHER_NO AND T12020.T_ACCOUNT_HEADER_CODE =AT13002.ACCOUNT_HEADER_CODE where T12020.T_PROJECT_CODE='{T_PROJECT_CODE}' group by T_BUDGET_ID,T12020.T_PROJECT_CODE,T12003.T_PROJECT_NAME,T_BUDGET_CODE, T_ACCOUNT_HEADER_CODE,T12010.ACCOUNT_ECONO_CODE,T12010.ACCOUNT_HEADER_NAME, T_TOTAL_ADP_AMOUNT,T_TOTAL_RADP_AMOUNT ");
            return sql;
        }
        public string SaveData(T12023Data data, string user)
        {
            string sms = "";
            int count = 0;
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            if (data.T12023List.Count()> 0)
            {                
                var voucherNo=Query($"SELECT MAX( CAST(VOUCHER_NO  AS INT))+1 VOUCHER_NO FROM AT13001 ").Rows[0]["VOUCHER_NO"].ToString();
                
                SqlTransaction objTrans = null;
                using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
                {
                    try
                    {
                        objConn.Open();
                        objTrans = objConn.BeginTransaction();                     
                       
                        foreach (var i in data.T12023List)
                        {
                            var save_01 = $"INSERT INTO AT13001 (VOUCHER_NO, VOUCHER_DATE, CENTER_CODE,T_PROJECT_CODE, VAUCHER_TYPE_CODE,TRANSACTION_TYPE_CODE, PARTY_TYPE_CODE,PARTY_CODE,TOTAL_DEBIT,TOTAL_CREDIT,ENTRY_USER,ENTRY_DATE)VALUES('{voucherNo}', '{date}', '101','{data.T_PROJECT_CODE}', '102', '102','101','101',{i.T_FUND_COLLECT},{i.T_FUND_COLLECT},'{user}','{date}')";
                            command_2(save_01, objConn, objTrans);
                            for (var k=0;k<2;k++)
                            {
                                if (k == 0)
                                {
                                    var save02 = $"INSERT INTO AT13002 (VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,DEBIT,CREDIT)VALUES('{voucherNo}', '{i.ddlActHead.ACCOUNT_HEADER_CODE}', '101', '101', 'Received Fund', '{i.T_FUND_COLLECT}', '00')";
                                    command_2(save02, objConn, objTrans);
                                }
                                else if(k==1)
                                {
                                    var save02 = $"INSERT INTO AT13002 (VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,DEBIT,CREDIT)VALUES('{voucherNo}', '{i.T_ACCOUNT_HEADER_CODE}', '101', '101', 'Received Fund', '00', '{i.T_FUND_COLLECT}')";
                                    command_2(save02, objConn, objTrans);
                                }                               
                            }
                            count++;
                        }
                        if (data.T12023List.Count()==count) {
                            objTrans.Commit();
                            sms = "Save Successfully-1";
                        } else
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
            }
            return sms;
        }
    }
}
