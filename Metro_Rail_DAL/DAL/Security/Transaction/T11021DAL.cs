﻿using Metro_Rail_DAL.Shared.Security.Transaction;
using System;
using System.Data;


namespace Metro_Rail_DAL.DAL.Security.Transaction
{
    public class T11021DAL:CommonDAL
    {
        public DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt = Query("select LOGIN_ID,T_EMP_ID,T00001.T_USER_NAME T_USER_ID, T_USER_PASS,T_ROLE,T11104.T_ROLL_NAME, T11020.T_USER_NAME , T11020.T_USER_MOBILE,T_ACTIVE_FLAG from T00001 JOIN T11104 ON T00001.T_ROLE =T11104.T_ROLL_CODE JOIN T11020 ON T00001.T_EMP_ID =T11020.T_USER_CODE ORDER BY LOGIN_ID DESC");
            return dt;
        }
        public DataTable GetUserDetails()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_USER_CODE,T_USER_NAME,T_USER_MOBILE from T11020 ORDER BY T_USER_ID DESC");
            return dt;
        }
        public DataTable RollData()
        {
            DataTable dt = new DataTable();
            dt = Query("select T_ROLL_CODE, T_ROLL_NAME  from T11104 ");
            return dt;

        }        
        public string SaveData(T11021Data t11021)
        {
            string sms = "";
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            if (t11021.LOGIN_ID == 0)
            {
               
                var sa = Command($"INSERT INTO T00001 (T_EMP_ID,T_USER_NAME,T_USER_PASS,T_ROLE,T_ACTIVE_FLAG) VALUES('{t11021.T_EMP_ID}','{t11021.T_USER_NAME}','{t11021.T_USER_PASS}','{t11021.T_ROLE}','{t11021.T_ACTIVE_FLAG}')");
                if (sa == true)
                {
                    sms = "Save Successfully-1";
                }
                else
                {
                    sms = "Do not Save-0";
                }
            }
            else
            {
                var sa = Command($"UPDATE T00001 SET T_EMP_ID='{t11021.T_EMP_ID}',T_USER_NAME='{t11021.T_USER_NAME}',T_USER_PASS='{t11021.T_USER_PASS}',T_ROLE='{t11021.T_ROLE}',T_ACTIVE_FLAG='{t11021.T_ACTIVE_FLAG}' WHERE LOGIN_ID ='{t11021.LOGIN_ID}'");
                if (sa == true)
                {
                    sms = "Update Successfully-1";
                }
                else
                {
                    sms = "Do not Update-0";
                }
            }

            return sms;
        }

    }
}



