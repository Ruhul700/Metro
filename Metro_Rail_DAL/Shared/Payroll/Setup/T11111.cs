using System.Collections.Generic;

namespace Metro_Rail_DAL.Shared.Payroll.Setup
{
    public class T11111Data
    {
        public string T_ACTIVE_TAB { get; set; }
        //PERSONAL INFORMATION START
        public int T_EMP_ID { get; set; }
        public string T_EMP_CODE { get; set; }
        public string T_EMP_NAME { get; set; }
        public string T_EMP_MOBILE { get; set; }
        public string T_GENDER_CODE { get; set; }
        public string T_FATHER_NAME { get; set; }
        public string T_MOTHER_NAME { get; set; }
        public string T_RELIGION_CODE { get; set; }
        public string T_PRESENT_ADDRESS { get; set; }
        public string T_NID { get; set; }
        public string T_PERMANENT_ADDRESS { get; set; }
        public string T_DATE_OF_BIRTH { get; set; }
        //PERSONAL INFORMATION END

        //Job Infromation Start
        public string T_JOINING_DATE { get; set; }
        public string T_PRL_DATE { get; set; }
        public string T_DATE_OF_CONFIRMATION { get; set; }
        public string T_CADRE { get; set; }
        public string T_EMAIL_ADDRESS { get; set; }
        public string T_JOB_PHONE { get; set; }
        public string T_DESIGNATION_CODE { get; set; }
        public string T_EMP_DEPARTMENT_CODE { get; set; }
        public string T_JOB_ADDRESS { get; set; }
        //Job Infromation End             
        public string T_ER_CONTACT_NAME { get; set; }
        public string T_ER_CONTACT_RELATION { get; set; }
        public string T_ER_CONTACT_PHONE { get; set; }
        //FAMILY INFORMATION
        
        public string T_ENTRY_USER { get; set; }
        public string T_ENTRY_DATE { get; set; }
        public string T_UPDATE_USER { get; set; }
        public string T_UPDATE_DATE { get; set; }
    }
    public class Family
    {
        public string T_EMP_CODE { get; set; }
        public Spouse spouseInfo { get; set; }
        public List<ChildData> ChildList { get; set; }
    }
    public class Spouse
    {
        public string T_SPOUSE_NAME { get; set; }
        public string T_SPOUSE_NATIONALITY { get; set; }
        public string T_SPOUSE_NID { get; set; }
        public string T_SPOUSE_CONTACT { get; set; }
    }
    public class ChildData
    {
        public int T_CHILD_ID { get; set; }
        public string T_CHILD_CODE { get; set; }
        public string T_CHILD_NAME { get; set; }
        public string T_CHILD_GENDER { get; set; }
        public string T_CHILD_DOB { get; set; }
        public string T_CHILD_SCHOOL { get; set; }
        public string T_CHILD_CLASS { get; set; }
        public string T_CHILD_CERTIFICATE { get; set; }
    }
    public class EduData
    {
        public string T_EMP_CODE { get; set; }
        public List<Education> AcademicList { get; set; }
        public List<Education> ProfesList { get; set; }
    }
    public class Education
    {
        public string T_INSTITUTION_NAME { get; set; }
        public string T_GROUP_SUBJECT { get; set; }
        public string T_PASSING_YEAR { get; set; }
        public string T_RESULT { get; set; }
        public string T_DISTINCTION { get; set; }
        public string T_EDU_TYPE { get; set; }
    }
    
}
