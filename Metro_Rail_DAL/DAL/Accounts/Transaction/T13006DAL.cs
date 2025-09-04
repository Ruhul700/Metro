using Metro_Rail_DAL.Shared.Accounts.Transaction;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Metro_Rail_DAL.DAL.Accounts.Transaction
{
    public class T13006DAL:CommonDAL
    {
        public DataTable GetSearchValue(T13006ParamList list)
        {
            var condition = "";
            if (list.T_RADIO_VALUE=="1")  { condition = $"T_MOBILE_NO='{list.T_SEARCH}'";   }
            if (list.T_RADIO_VALUE=="2")  { condition = $"T_NID_NO='{list.T_SEARCH}'";   }
            if (list.T_RADIO_VALUE=="3")  { condition = $"T_TIN_NO='{list.T_SEARCH}'";   }

            DataTable sql = new DataTable();
            sql = Query($"select T_SUPPLIER_ID, T_SUPPLIER_CODE, T_SUPPLIER_NAME, T_MOBILE_NO, T_TIN_NO, T_VAT_NO, T_NID_NO, T_ACCOUNT_NAME, T_ACCOUNT_NO, T_BANK_NAME, T_BRANCH, T_SUPPLIER_TYPE from T13010 where {condition} ");
            return sql;
        }
        public string SaveData(T13006Data data, string user)
        {
            var sms = "";
            int count = 0;
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            SqlTransaction objTrans = null;

            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
            {
                try
                {
                    //select SUM(DEBIT)-SUM(CREDIT) BALANCE from AT13002 where ACCOUNT_HEADER_CODE='109'
                    var aT13001 = data.SingleData;
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();
                    if (aT13001.VOUCHER_MASTER_ID == 0)
                    {
                        var voucherNo = Query($"SELECT MAX( CAST(VOUCHER_NO  AS INT))+1 VOUCHER_NO FROM AT13001 ").Rows[0]["VOUCHER_NO"].ToString();
                        var save_01 = $"INSERT INTO AT13001 (VOUCHER_NO, VOUCHER_DATE, CENTER_CODE,T_PROJECT_CODE, VAUCHER_TYPE_CODE,TRANSACTION_TYPE_CODE, PARTY_TYPE_CODE,PARTY_CODE,TOTAL_DEBIT,TOTAL_CREDIT,ENTRY_USER,ENTRY_DATE)VALUES('{voucherNo}', '{aT13001.VOUCHER_DATE}', '101','{aT13001.T_PROJECT_CODE}', '101', '102','101','101',{aT13001.TOTAL_DEBIT},{aT13001.TOTAL_CREDIT},'{user}','{date}')";
                        command_2(save_01, objConn, objTrans);
                        foreach (var i in data.ListData)
                        {
                            // var debit = i.DEBIT == 0 ? 00 : i.DEBIT;
                            var save02 = $"INSERT INTO AT13002 (VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,PARTY_CODE,DEBIT,CREDIT)VALUES('{voucherNo}', '{i.ACCOUNT_HEADER_CODE}', '{i.DEPARTMENT_CODE}', '{i.PURPOSE_CODE}', '{i.VOU_DESCRIPTION}', '101', {i.DEBIT}, {i.CREDIT})";
                            command_2(save02, objConn, objTrans);
                            count++;
                        }
                        if (data.ListData.Count() == count)
                        {
                            objTrans.Commit();
                            sms = "Save successfully-1";
                        }
                        else
                        {
                            objTrans.Rollback();
                            sms = "Do not Save-0";
                        }
                    }
                    else
                    {
                        DataTable pickAllData = Query_2($@"SELECT * FROM AT13002  WHERE VOUCHER_NO='{aT13001.VOUCHER_NO}'", objConn, objTrans);
                        //var newList=   pickAllData.Select($"VOUCHER_NO='{30}'").CopyToDataTable();

                        var save_01 = $"UPDATE AT13001 SET VOUCHER_DATE='{aT13001.VOUCHER_DATE}', T_PROJECT_CODE='{aT13001.T_PROJECT_CODE}', VAUCHER_TYPE_CODE='{aT13001.VAUCHER_TYPE_CODE}', TRANSACTION_TYPE_CODE ='{aT13001.TRANSACTION_TYPE_CODE}', PARTY_TYPE_CODE='{aT13001.PARTY_TYPE_CODE}', PARTY_CODE ='{aT13001.PARTY_CODE}', TOTAL_DEBIT='{aT13001.TOTAL_DEBIT}', TOTAL_CREDIT='{aT13001.TOTAL_CREDIT}' WHERE VOUCHER_NO='{aT13001.VOUCHER_NO}'";
                        command_2(save_01, objConn, objTrans);

                        var del = Command($"DELETE FROM AT13002 WHERE VOUCHER_NO ='{aT13001.VOUCHER_NO}'");
                        foreach (var i in data.ListData)
                        {
                            //var chk = Query_2($@"SELECT COUNT(*) T_COUNT FROM AT13002  WHERE VOUCHER_DETAILS_ID={i.VOUCHER_DETAILS_ID} AND VOUCHER_NO='{i.VOUCHER_NO}'", objConn, objTrans).Rows[0]["T_COUNT"].ToString();
                            //if (Convert.ToInt32(chk)==1)
                            //{
                            //    var update2 = $"UPDATE AT13002 SET ACCOUNT_HEADER_CODE='{i.ACCOUNT_HEADER_CODE}', DEPARTMENT_CODE='{i.DEPARTMENT_CODE}', PURPOSE_CODE='{i.PURPOSE_CODE}',VOU_DESCRIPTION='{i.VOU_DESCRIPTION}', DEBIT='{i.DEBIT}',CREDIT='{i.CREDIT}' WHERE VOUCHER_DETAILS_ID={i.VOUCHER_DETAILS_ID} AND VOUCHER_NO='{i.VOUCHER_NO}'";
                            //    command_2(update2, objConn, objTrans);
                            //}
                            //else
                            //{
                            var save02 = $"INSERT INTO AT13002 (VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,PARTY_CODE,DEBIT,CREDIT)VALUES('{aT13001.VOUCHER_NO}', '{i.ACCOUNT_HEADER_CODE}', '{i.DEPARTMENT_CODE}', '{i.PURPOSE_CODE}', '{i.VOU_DESCRIPTION}', '{i.PARTY_CODE}', '{i.DEBIT}', '{i.CREDIT}')";
                            command_2(save02, objConn, objTrans);
                            //}                           
                            count++;
                        }
                        if (data.ListData.Count() == count)
                        {
                            foreach (DataRow k in pickAllData.Rows)
                            {
                                var dtlId = k["VOUCHER_DETAILS_ID"].ToString();
                                var vouNo = k["VOUCHER_NO"].ToString();
                                var headCode = k["ACCOUNT_HEADER_CODE"].ToString();
                                var deptCode = k["DEPARTMENT_CODE"].ToString();
                                var purCode = k["PURPOSE_CODE"].ToString();
                                var desp = k["VOU_DESCRIPTION"].ToString();
                                var debit = k["DEBIT"].ToString();
                                var credit = k["CREDIT"].ToString();
                                var save02Bkp = $"INSERT INTO AT13002_bkp (VOUCHER_DETAILS_ID,VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,DEBIT,CREDIT)VALUES('{dtlId}', '{vouNo}', '{headCode}', '{deptCode}', '{purCode}', '{desp}', '{debit}','{credit}')";
                                command_2(save02Bkp, objConn, objTrans);
                            }
                            objTrans.Commit();
                            sms = "Update successfully-1";
                        }
                        else
                        {
                            objTrans.Rollback();
                            sms = "Do not Update-0";
                        }
                    }

                }
                catch (Exception ex)
                {
                    var kk = ex.Message;
                    objTrans.Rollback();
                }
                finally
                {
                    objConn.Close();
                }
            }
            return sms;
            
            // return sms;
        }
    }
}
