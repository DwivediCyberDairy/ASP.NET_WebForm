using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pramodSourceSystem.Models
{
    public class GlobalSession
    {
        public static void LogOut()
        {

            UserName = Email = AadharNo = DOB = StudentAddress = CollegeName = CityName = CourseName = CourseCategory=Fee=StudentId=PIC = string.Empty;
           MobileNo = Convert.ToInt64(0);
           
        }
       
        public static string UserName
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["UserName"]);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["UserName"] = value; }
        }
        public static string Email
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["Email"]);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["Email"] = value; }
        }
        public static string AadharNo
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["AadharNo"]);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["AadharNo"] = value; }
        }
        public static string DOB
        {
            get
            {

                try
                {
                    return Convert.ToString(HttpContext.Current.Session["DOB"]);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["DOB"] = value; }
        }
        public static string StudentAddress
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["StudentAddress"]);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["StudentAddress"] = value; }
        }
        public static string CollegeName
        {
            get
            {

                try
                {
                    return Convert.ToString(HttpContext.Current.Session["CollegeName"]);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["CollegeName"] = value; }
        }       
        public static Int64 MobileNo
        {
            get
            {
                try
                {
                    return Convert.ToInt64(HttpContext.Current.Session["EmpMobNo"].ToString());
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            set { HttpContext.Current.Session["EmpMobNo"] = value; }
        }
        public static string CityName
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["CityName"].ToString());
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["CityName"] = value; }
        }
        public static string CourseName
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["CourseName"].ToString());
                }
                catch (Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["CourseName"] = value; }
        }
        public static string CourseCategory
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["CourseCategory"].ToString());
                }
                catch(Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["CourseCategory"] = value; }
        }
        public static string Fee
        {
            get
            {
                try
                {
                    return Convert.ToString(HttpContext.Current.Session["Fee"].ToString());
                }
                catch(Exception)
                {
                    return "";
                }
            }
            set { HttpContext.Current.Session["Fee"] = value; }
        }
        public static string StudentId
        {
             get
            {
                 try
                 {
                     return Convert.ToString(HttpContext.Current.Session["StudentId"].ToString());
                 }
                 catch(Exception)
                 {
                     return "";
                 }
               
            }
            set { HttpContext.Current.Session["StudentId"] = value; }
        }
        public static string PIC
         {
             get
             {
                 try
                 {
                     return Convert.ToString(HttpContext.Current.Session["PIC"].ToString());
                 }
                 catch (Exception)
                 {
                     return "";
                 }

             }
             set { HttpContext.Current.Session["PIC"] = value; }
         }
    }
}