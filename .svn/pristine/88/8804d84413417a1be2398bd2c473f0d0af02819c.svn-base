using Metro_Rail_DAL.Shared.Accounts.Transaction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Metro_Rail_DAL.DAL.Accounts.Transaction
{
    public class AT13001_SAVE
    {
        public bool CommandSave(T13001Data aT13001, List<T13002Data> aT13002Litst,string user)
        {
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            SqlTransaction objTrans = null;

            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
            {               
                
                try
                {                   
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();
                    var save_01 = $"INSERT INTO AT13001 (VOUCHER_NO, VOUCHER_DATE, CENTER_CODE,T_PROJECT_CODE, VAUCHER_TYPE_CODE,TRANSACTION_TYPE_CODE, PARTY_TYPE_CODE,PARTY_CODE,TOTAL_DEBIT,TOTAL_CREDIT,ENTRY_USER,ENTRY_DATE)VALUES('{aT13001.VOUCHER_NO}', '{aT13001.VOUCHER_DATE}', '101','{aT13001.T_PROJECT_CODE}', '{aT13001.VAUCHER_TYPE_CODE}', '{aT13001.TRANSACTION_TYPE_CODE}','{aT13001.PARTY_TYPE_CODE}','{aT13001.PARTY_CODE}',{aT13001.TOTAL_DEBIT},{aT13001.TOTAL_CREDIT},'{user}','{date}')";
                    SqlCommand objCmd1 = new SqlCommand(save_01, objConn, objTrans);
                    objCmd1.ExecuteNonQuery();
                    foreach (var i in aT13002Litst)
                    {
                       // var debit = i.DEBIT == 0 ? 00 : i.DEBIT;
                        var save02 = $"INSERT INTO AT13002 (VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,PARTY_CODE,DEBIT,CREDIT)VALUES('{aT13001.VOUCHER_NO}', '{i.ACCOUNT_HEADER_CODE}', '{i.DEPARTMENT_CODE}', '{i.PURPOSE_CODE}', '{i.VOU_DESCRIPTION}', '{i.PARTY_CODE}', {i.DEBIT}, {i.CREDIT})";
                        SqlCommand objCmd2 = new SqlCommand(save02, objConn, objTrans);
                        objCmd2.ExecuteNonQuery(); // Throws exception due to foreign key constraint 
                    }

                    objTrans.Commit();
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
            return true;
        }
        public bool CommandUpdate(T13001Data aT13001, List<T13002Data> aT13002Litst)
        {

            SqlTransaction objTrans = null;

            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
            {

                try
                {
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();
                    var save_01 = $"UPDATE AT13001 SET VOUCHER_DATE='{aT13001.VOUCHER_DATE}', T_PROJECT_CODE='{aT13001.T_PROJECT_CODE}', VAUCHER_TYPE_CODE='{aT13001.VAUCHER_TYPE_CODE}', TRANSACTION_TYPE_CODE ='{aT13001.TRANSACTION_TYPE_CODE}', PARTY_TYPE_CODE='{aT13001.PARTY_TYPE_CODE}', PARTY_CODE ='{aT13001.PARTY_CODE}', TOTAL_DEBIT='{aT13001.TOTAL_DEBIT}', TOTAL_CREDIT='{aT13001.TOTAL_CREDIT}' WHERE VOUCHER_NO='{aT13001.VOUCHER_NO}'";
                    SqlCommand objCmd1 = new SqlCommand(save_01, objConn, objTrans);
                    objCmd1.ExecuteNonQuery();
                    foreach (var i in aT13002Litst)
                    {
                        var save02 = $"INSERT INTO AT13002 (VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,PARTY_CODE,DEBIT,CREDIT)VALUES('{aT13001.VOUCHER_NO}', '{i.ACCOUNT_HEADER_CODE}', '{i.DEPARTMENT_CODE}', '{i.PURPOSE_CODE}', '{i.VOU_DESCRIPTION}', '{i.PARTY_CODE}', '{i.DEBIT}', '{i.CREDIT}')";
                        SqlCommand objCmd2 = new SqlCommand(save02, objConn, objTrans);
                        objCmd2.ExecuteNonQuery(); // Throws exception due to foreign key constraint 
                    }

                    objTrans.Commit();
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
            return true;
        }
    }
}
