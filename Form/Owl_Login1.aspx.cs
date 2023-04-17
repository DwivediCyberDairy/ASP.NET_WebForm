using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using pramodSourceSystem.Models.PL;
using pramodSourceSystem.Models;
    using System.Threading.Tasks;
using System.Threading;
using ClosedXML.Excel;
namespace pramodSourceSystem.Form
{
    public partial class Owl_Login1 : System.Web.UI.Page
    {
        //PL OBJ;
        //PLLog OBJLOG;
        //DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e) 
        {
            if (!Page.IsPostBack)
            {
               
               
            }
        }
      
        void ShowMessage(string Message, bool type)
        {
            lblmsg.Text = (type ? "" : "") + Message;
            lblmsg.CssClass = type ? "alertMsg success" : "alertMsg failed";

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                 PLLog OBJ = new PLLog();
                OBJ.Ind = 4;
                OBJ.UserId = Id.Text;
                OBJ.Password = New.Text;
                dt = new DataTable();
                dt = ShareCommanClass.CallApiPostDt("Student/LogFill", OBJ);
                if (Convert.ToString(dt.Rows[0]["Result"]) == "1")
                {
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(string), "uniqueKey", "alert('Test')", true);
                    //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:; ", true);
                    XLWorkbook wb = new XLWorkbook();
                   GlobalSession.UserName = Convert.ToString(dt.Rows[0]["StudentName"]);
                   GlobalSession.Email = Convert.ToString(dt.Rows[0]["Email"]);
                   GlobalSession.MobileNo = Convert.ToInt64(dt.Rows[0]["MobileNo"]);
                   GlobalSession.AadharNo = Convert.ToString(dt.Rows[0]["AadharNo"]);
                   GlobalSession.DOB = Convert.ToString(dt.Rows[0]["DOB"]);
                   GlobalSession.StudentAddress = Convert.ToString(dt.Rows[0]["StudentAddress"]);
                   GlobalSession.CollegeName = Convert.ToString(dt.Rows[0]["CollegeName"]);
                   GlobalSession.CityName = Convert.ToString(dt.Rows[0]["CityName"]);
                   GlobalSession.CourseName = Convert.ToString(dt.Rows[0]["CourseName"]);
                   GlobalSession.CourseCategory = Convert.ToString(dt.Rows[0]["CourseCategory"]);
                   GlobalSession.Fee = Convert.ToString(dt.Rows[0]["Fee"]);
                   GlobalSession.StudentId = Convert.ToString(dt.Rows[0]["StudentId"]);
                   GlobalSession.PIC = Convert.ToString(dt.Rows[0]["PicName"]);
                   this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "showAlert();", true);
                   Thread.Sleep(1000);
                   Response.AddHeader("REFRESH", "1;URL=profile.aspx");

                   // Response.Redirect("profile.aspx", true);
                }
                else
                {
                    ShowMessage(Convert.ToString(dt.Rows[0]["ResultMsg"]), false);
                  
                }
            }
            catch (Exception)
            {
                
                throw;
            }
             
        }
    }
}