using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pramodSourceSystem.Models;
using pramodSourceSystem.Models.PL;
using System.Data;
using System.Data.SqlClient;
using pramodSourceSystem.App_Code;
using System.Threading;
namespace pramodSourceSystem.Form
{
    public partial class Registration : System.Web.UI.Page
    {
        PL OBJ;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Name.Text = GlobalSession.UserName;                
                CollegeName();              
            }

        }
        void CollegeName()
        {
            DataSet dS = new DataSet();
            dS = ShareCommanClass.CallApiGetDs("Student/BindDropDown?Ind=1");
            if (dS.Tables[0].Rows.Count > 0)
            {
                ddlCollegeName.DataSource = ViewState["College"] = dS.Tables[0];
                ddlCollegeName.DataTextField = "CollegeName";
                ddlCollegeName.DataValueField = "CollegeId";
                ddlCollegeName.DataBind();
                ddlCollegeName.Items.Insert(0, new ListItem("-- Select College Name -- ", "0"));
            }
            if (dS.Tables[1].Rows.Count > 0)
            {               
                ddlReletedCity.DataSource =dS.Tables[1];
                ddlReletedCity.DataTextField = "CityName";
                ddlReletedCity.DataValueField = "CityId";
                ddlReletedCity.DataBind();
                ddlReletedCity.Items.Insert(0, new ListItem("-- Select City-- ", "0"));
            }
            if (dS.Tables[2].Rows.Count > 0)
            {
                ddlCategory.DataSource = dS.Tables[2];
                ddlCategory.DataTextField = "CourseCategory";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
            if (dS.Tables[3].Rows.Count > 0)
            {
                ddlCourse.DataSource = ViewState["Course"] = dS.Tables[3];
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("--Select Cource--", "0"));
            }
           
        }

        void BindGrid()
        {
            dt = new DataTable();
            dt = ShareCommanClass.CallApiGetDt("Student/BindGrid?Ind=3");
            if (dt != null && dt.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dt.Rows[0]["StudentId"].ToString());
                Session["StudentId"] = id;
                ViewState["dt"] = dt;
                grvStudent.DataSource = dt;
                grvStudent.DataBind();
            }
        }
        //-----------------------------------------------------------------------------------------

        void ReletedCity()
        {
            dt = new DataTable();
            dt = ShareCommanClass.CallApiGetDt("Student/BindReletedCity?Ind=2");
            if (dt.Rows.Count > 0)
            {
                ViewState["City"] = dt;
                ddlReletedCity.DataSource = dt;
                ddlReletedCity.DataTextField = "CityName";
                ddlReletedCity.DataValueField = "CityId";
                ddlReletedCity.DataBind();
                ddlReletedCity.Items.Insert(0, new ListItem("-- Select City-- ", "0"));
                
            }
        }
        void ACategory()
        {
            dt = new DataTable();
            dt = ShareCommanClass.CallApiGetDt("Student/BindCategory?Ind=3");
            if (dt.Rows.Count > 0)
            {
                ViewState["dt"] = dt;
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CourseCategory";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
        }
        void Cource()
        {
            dt = new DataTable();
            dt = ShareCommanClass.CallApiGetDt("Student/BindCource?Ind=4");
            if(dt.Rows.Count>0)
            {
                ViewState["dt"] = dt;
                ddlCourse.DataSource = dt;
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("--Select Cource--", "0"));
            }
        }

//--------------------------------------------------------------------------------------------------

        void ShowMessage(string Message, bool type)
        {
            lblmsg.Text = (type ? "" : "") + Message;
            lblmsg.CssClass = type ? "alertMsg success" : "alertMsg failed";

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Name.Text == "")
            {
                ShowMessage("Please Enter Student Name", false);
                Name.Focus();
            }
            else if (Email.Text == "")
            {
                ShowMessage("Please Enter EmailId ", false);
                Email.Focus();
            }
            else if (MobileNo.Text == "")
            {
                ShowMessage("Please Enter Mobile Number", false);
                MobileNo.Focus();
            }
            else if (AadharNo.Text == "")
            {
                ShowMessage("Please Enter Aadhar Number", false);
                AadharNo.Focus();
            }
            else if (DOB.Text == "")
            {
                ShowMessage("Please Enter DOB", false);
                DOB.Focus();
            }
            else if (StudentAddress.Text == "")
            {
                ShowMessage("Please Enter Student Address", false);
                StudentAddress.Focus();
            }
            else if (ddlReletedCity.SelectedValue == "")
            {
                ShowMessage("Please Select Releted City", false);
                ddlReletedCity.Focus();
            }
            else if (ddlCollegeName.SelectedValue == "")
            {
                ShowMessage("Please Select College Name", false);
                ddlCollegeName.Focus();
            }
            else if (ddlCategory.SelectedValue == "")
            {
                ShowMessage("Please Select Category", false);
                ddlCategory.Focus();
            }
            else if (ddlCourse.SelectedValue == "")
            {
                ShowMessage("Please Select Cource", false);
                ddlCourse.Focus();
            }
            else if (btnsave.Text == "Update")
            {
                OBJ = new PL();
                OBJ.Ind = 4;
                OBJ.StudentId = Convert.ToInt32(Session["id"]);
                OBJ.StudentName = Name.Text;
                OBJ.Email = Email.Text;
                OBJ.MobileNo = MobileNo.Text;
                OBJ.AadharNo = AadharNo.Text;
                OBJ.DOB = Convert.ToDateTime(DOB.Text);
                OBJ.StudentAddress = StudentAddress.Text;
                OBJ.ReletedCity = Convert.ToInt32(ddlReletedCity.SelectedValue);
                OBJ.CollegeName = Convert.ToInt32(ddlCollegeName.SelectedValue);
                OBJ.Category = Convert.ToInt32(ddlCategory.SelectedValue);
                OBJ.Course = Convert.ToInt32(ddlCourse.SelectedValue);
                OBJ.Fees = Convert.ToInt32(fees.Text);
                ds = new DataSet();
                ds = ShareCommanClass.CallApiPostDs("Student/Save", OBJ);
                if (ds.Tables[0].Rows[0]["SuccessCode"].ToString() == "1")
                {
                    ShowMessage(ds.Tables[0].Rows[0]["msg"].ToString(), true);
                    return;
                }
                else
                {
                    ShowMessage("Not Updated", false);
                    return;
                }
            }
            else
            {
                OBJ = new PL();
                OBJ.Ind = 2;
                OBJ.StudentId = Convert.ToInt32(Session["id"]);
                OBJ.StudentName = Name.Text;
                OBJ.Email = Email.Text;
                OBJ.MobileNo = MobileNo.Text;
                OBJ.AadharNo = AadharNo.Text;
                OBJ.DOB = Convert.ToDateTime(DOB.Text);
                OBJ.StudentAddress = StudentAddress.Text;
                OBJ.ReletedCity = Convert.ToInt32(ddlReletedCity.SelectedValue);
                OBJ.CollegeName = Convert.ToInt32(ddlCollegeName.SelectedValue);
                OBJ.Category = Convert.ToInt32(ddlCategory.SelectedValue);
                OBJ.Course = Convert.ToInt32(ddlCourse.SelectedValue);
               // OBJ.RegDT = DateTime.Now;
                OBJ.StudentStatus = 1;
                OBJ.Fees = Convert.ToInt32(fees.Text);
                OBJ.Password = pass.Text;
                ds = new DataSet();
                ds = ShareCommanClass.CallApiPostDs("Student/Save", OBJ);
                if (ds.Tables[0].Rows[0]["SuccessCode"].ToString() == "1")
                {
                    ShowMessage(ds.Tables[0].Rows[0]["msg"].ToString(), true);

                    MY_Email_Sender es = new MY_Email_Sender();
                    es.SendTo = OBJ.Email;
                    es.Subject = "Welcome to My Project";
                    es.Message = "Hye " + OBJ.StudentName + ",\nWelcome to Unversity Application Project. \nYou are successfully register in our web portal. \nYour user id is: " + OBJ.Email + " \nPassword is: " + OBJ.Password + "\n\n'<b>Note - if you are not Proceeding this action please change your credendials OR cantact to administrator </b>'\n\nRegrads\n\nTeam OCCPL ";
                    es.SendEmail();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "showAlert();", true);
                    Thread.Sleep(1500);
                    Response.AddHeader("REFRESH", "1;URL=Owl_Login1.aspx");
                    return;
                }
                else
                {
                    ShowMessage(" Email id already exists !!!", false);
                    return;
                }
            }
        }

       

        protected void ddlReletedCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["College"];
            int cid = int.Parse(ddlReletedCity.SelectedValue);
            var lst = dt.AsEnumerable().Where(row => Convert.ToInt16(row["ReletedCity"]) == cid).ToList();
            if (lst.Count > 0)
            {


                ddlCollegeName.Items.Clear();
                ddlCollegeName.DataSource = lst.CopyToDataTable();
                ddlCollegeName.DataTextField = "CollegeName";
                ddlCollegeName.DataValueField = "CollegeId";
                ddlCollegeName.DataBind();
                ddlCollegeName.Items.Insert(0, new ListItem("-- Select College Name -- ", "0"));
            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["Course"];
            int cid = int.Parse(ddlCategory.SelectedValue);
            var lst = dt.AsEnumerable().Where(row => Convert.ToInt16(row["RelatedCategory"]) == cid).ToList(); 
            if (lst.Count > 0)
            {
                ddlCourse.Items.Clear();
                ddlCourse.DataSource = lst.CopyToDataTable();
                ddlCourse.DataTextField = "CourseName";
                ddlCourse.DataValueField = "CourseId";
                ddlCourse.DataBind();
                ddlCourse.Items.Insert(0, new ListItem("-- Select Course Name -- ", "0"));
            }
        }

        protected void BtnShowEmpDetails_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

    }
}