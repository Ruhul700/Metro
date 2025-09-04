using Metro_Rail_DAL.Shared.Accounts.Transaction;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using System.Accounts_Management.Models;

namespace Metro_Rail_DAL.DAL.Accounts.Transaction
{
    public class T13001DAL: CommonDAL
    {
        public DataTable GetCenterData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT CENTER_CODE,CENTER_NAME FROM T12005");
         // var data=  ConvertToIenumerable(sql);
            return sql;
        }
        public DataTable GeProjectData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT T_PROJECT_CODE, T_PROJECT_NAME FROM T12003 ORDER BY T_PROJECT_ID");           
            return sql;
        }
        public DataTable GetVoucherData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT VAUCHER_TYPE_CODE,VAUCHER_TYPE_NAME FROM T12006");
            return sql;
        }
        public DataTable GetTransData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT TRANSACTION_TYPE_CODE,TRANSACTION_TYPE_NAME FROM T12007");
            return sql;
        }
        public DataTable GetPartyTypeData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT PARTY_TYPE_CODE,PARTY_TYPE_NAME FROM T12008");
            return sql;
        }
        public DataTable GetParty( string PtypeCode)
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT PARTY_TYPE_CODE,PARTY_CODE,PARTY_NAME FROM T12009");
            return sql;
        }   
        public DataTable GetActHeaderData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT ACCOUNT_HEADER_CODE,ACCOUNT_ECONO_CODE,ACCOUNT_HEADER_NAME FROM T12010");
            return sql;
        }
        public DataTable GetDepartmentData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT DEPARTMENT_CODE,DEPARTMENT_NAME FROM T12011");
            return sql;
        }
        public DataTable GetPurposeData()
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT PURPOSE_CODE,PURPOSE_NAME FROM T12012");
            return sql;
        }
        public string GetVoucherNo()
        {           
          var  sql = Query($"SELECT TOP 1 CAST(VOUCHER_NO  AS INT)+1 VOUCHER_NO FROM AT13001 ORDER BY CAST(VOUCHER_NO  AS INT)DESC").Rows[0]["VOUCHER_NO"].ToString();          
            return sql;
        }
        public DataTable GetAllVoucher(string date)
        {
            DataTable sql = new DataTable();
             sql = Query($"SELECT DISTINCT VOUCHER_MASTER_ID, VOUCHER_NO, VOUCHER_DATE, T12005.CENTER_NAME, T12005.CENTER_CODE,T12020.T_PROJECT_CODE,T12003.T_PROJECT_NAME,  T12006.VAUCHER_TYPE_NAME, T12006.VAUCHER_TYPE_CODE, T12007.TRANSACTION_TYPE_NAME, T12007.TRANSACTION_TYPE_CODE,T12007.TRANSACTION_TYPE_CODE, T12008.PARTY_TYPE_NAME,T12008.PARTY_TYPE_CODE, T12009.PARTY_NAME ,T12009.PARTY_CODE,TOTAL_DEBIT,TOTAL_CREDIT FROM AT13001 JOIN T12005 ON AT13001.CENTER_CODE =T12005.CENTER_CODE LEFT JOIN T12020 ON AT13001.T_PROJECT_CODE =T12020.T_PROJECT_CODE JOIN T12003 ON T12020.T_PROJECT_CODE =T12003.T_PROJECT_CODE  JOIN T12006 ON AT13001.VAUCHER_TYPE_CODE =T12006.VAUCHER_TYPE_CODE JOIN T12007 ON AT13001.TRANSACTION_TYPE_CODE =T12007.TRANSACTION_TYPE_CODE JOIN T12008 ON AT13001.PARTY_TYPE_CODE =T12008.PARTY_TYPE_CODE JOIN T12009 ON AT13001.PARTY_CODE =T12009.PARTY_CODE Where VOUCHER_DATE ='{date}' ORDER BY VOUCHER_MASTER_ID DESC");           
            return sql;
        }
        public string SaveData(T13001Data aT13001, List<T13002Data> aT13002Litst,string user)
        {
            var  sms = "";
            int count = 0;
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            SqlTransaction objTrans = null;

            using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString))
            {
                try
                {
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();
                    if (aT13001.VOUCHER_MASTER_ID==0)
                    {
                        var voucherNo = Query($"SELECT MAX( CAST(VOUCHER_NO  AS INT))+1 VOUCHER_NO FROM AT13001 ").Rows[0]["VOUCHER_NO"].ToString();
                        var save_01 = $"INSERT INTO AT13001 (VOUCHER_NO, VOUCHER_DATE, CENTER_CODE,T_PROJECT_CODE, VAUCHER_TYPE_CODE,TRANSACTION_TYPE_CODE, PARTY_TYPE_CODE,PARTY_CODE,TOTAL_DEBIT,TOTAL_CREDIT,ENTRY_USER,ENTRY_DATE)VALUES('{voucherNo}', '{aT13001.VOUCHER_DATE}', '101','{aT13001.T_PROJECT_CODE}', '{aT13001.VAUCHER_TYPE_CODE}', '{aT13001.TRANSACTION_TYPE_CODE}','{aT13001.PARTY_TYPE_CODE}','{aT13001.PARTY_CODE}',{aT13001.TOTAL_DEBIT},{aT13001.TOTAL_CREDIT},'{user}','{date}')";
                        command_2(save_01, objConn, objTrans);
                        foreach (var i in aT13002Litst)
                        {
                            // var debit = i.DEBIT == 0 ? 00 : i.DEBIT;
                            var save02 = $"INSERT INTO AT13002 (VOUCHER_NO, ACCOUNT_HEADER_CODE, DEPARTMENT_CODE, PURPOSE_CODE,VOU_DESCRIPTION,PARTY_CODE,DEBIT,CREDIT)VALUES('{voucherNo}', '{i.ACCOUNT_HEADER_CODE}', '{i.DEPARTMENT_CODE}', '{i.PURPOSE_CODE}', '{i.VOU_DESCRIPTION}', '{i.PARTY_CODE}', {i.DEBIT}, {i.CREDIT})";
                            command_2(save02, objConn, objTrans);
                            count++;
                        }
                        if (aT13002Litst.Count()==count)
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
                        DataTable pickAllData = Query_2($@"SELECT * FROM AT13002  WHERE VOUCHER_NO='{aT13001.VOUCHER_NO}'",objConn, objTrans);
                     //var newList=   pickAllData.Select($"VOUCHER_NO='{30}'").CopyToDataTable();

                        var save_01 = $"UPDATE AT13001 SET VOUCHER_DATE='{aT13001.VOUCHER_DATE}', T_PROJECT_CODE='{aT13001.T_PROJECT_CODE}', VAUCHER_TYPE_CODE='{aT13001.VAUCHER_TYPE_CODE}', TRANSACTION_TYPE_CODE ='{aT13001.TRANSACTION_TYPE_CODE}', PARTY_TYPE_CODE='{aT13001.PARTY_TYPE_CODE}', PARTY_CODE ='{aT13001.PARTY_CODE}', TOTAL_DEBIT='{aT13001.TOTAL_DEBIT}', TOTAL_CREDIT='{aT13001.TOTAL_CREDIT}' WHERE VOUCHER_NO='{aT13001.VOUCHER_NO}'";
                        command_2(save_01, objConn, objTrans);

                        var del = Command($"DELETE FROM AT13002 WHERE VOUCHER_NO ='{aT13001.VOUCHER_NO}'");
                        foreach (var i in aT13002Litst)
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
                        if (aT13002Litst.Count() == count)
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
            //AT13001_SAVE objSave = new AT13001_SAVE();
            //DataTable sql = Query($"SELECT VOUCHER_NO FROM AT13001 WHERE VOUCHER_NO ='{aT13001.VOUCHER_NO}'");
            //if (sql.Rows.Count>0)
            //{
            //    var del = Command($"DELETE FROM AT13002 WHERE VOUCHER_NO ='{aT13001.VOUCHER_NO}'");
            //    if (del==true)
            //    {
            //        var data = objSave.CommandUpdate(aT13001, aT13002Litst);
            //        if (data)
            //        {
            //            sms = "Updated successfully-1";
            //        }
            //    }
            //    else
            //    {
            //        sms="Do not Update-0";
            //    }
            //}
            //else
            //{
            //    var data = objSave.CommandSave(aT13001, aT13002Litst, user);
            //    if (data)
            //    {
            //        sms = "Save successfully-1";
            //    }
            //    else
            //    {
            //        sms = "Do not Save-0";
            //    }
            //}
           // return sms;
        }

        public DataTable GetVoucherDetails(string voucherCode)
        {
            DataTable sql = new DataTable();
            sql = Query($"SELECT VOUCHER_DETAILS_ID, VOUCHER_NO,VOU_DESCRIPTION,DEBIT,CREDIT,T12010.ACCOUNT_HEADER_CODE, T12010.ACCOUNT_HEADER_NAME,T12010.ACCOUNT_ECONO_CODE, T12011.DEPARTMENT_CODE, 12011.DEPARTMENT_NAME ,T12012.PURPOSE_CODE,T12012.PURPOSE_NAME FROM AT13002 JOIN T12010 ON AT13002.ACCOUNT_HEADER_CODE =T12010.ACCOUNT_HEADER_CODE JOIN T12011 ON AT13002.DEPARTMENT_CODE =T12011.DEPARTMENT_CODE JOIN T12012 ON AT13002.PURPOSE_CODE =T12012.PURPOSE_CODE  Where VOUCHER_NO ='{voucherCode}' ORDER BY VOUCHER_DETAILS_ID ASC");            
            return sql;
        }
        //private IEnumerable<T12001> ConvertToIenumerable(DataTable dataTable)
        //{
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        yield return new T12001
        //        {
        //           // CENTER_ID = Convert.ToInt32(row["CENTER_ID"]),
        //            CENTER_CODE = row["CENTER_CODE"].ToString(),
        //            CENTER_NAME = row["CENTER_NAME"].ToString(),
                    
        //        };
        //    }

        //}
        //private IEnumerable<voucherlist> ConvertTodf(DataTable dataTable)
        //{
        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        yield return new voucherlist
        //        {
        //            VOUCHER_NO = row["VOUCHER_NO"].ToString(),
        //            CENTER_CODE = row["CENTER_CODE"].ToString(),
        //            CENTER_NAME = row["CENTER_NAME"].ToString(),

        //        };
        //    }

        //}

       
    }
}
