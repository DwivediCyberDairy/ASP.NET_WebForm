using pramodSourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pramodSourceSystem.Models.PL;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using pramodSourceSystem.App_Code;
using System.IO;
using ClosedXML.Excel;


namespace pramodSourceSystem.Form
{
    public partial class profile : System.Web.UI.Page
    {
        PL OBJ;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CollegeName();
                txtAddress.Text = GlobalSession.StudentAddress;
                txtmobile.Text = GlobalSession.MobileNo.ToString();
                txtDOB.Text = GlobalSession.DOB;
                ddlReletedCity.Text = GlobalSession.CityName;
                ddlCollegeName.SelectedValue = GlobalSession.CollegeName;
                ddlCategory.SelectedValue = GlobalSession.CourseName;
                ddlCourse.SelectedValue = GlobalSession.CourseCategory;
                txtAadhar.Text = GlobalSession.AadharNo;
                //StudentId = GlobalSession.StudentId;               
                txtFees.Text = GlobalSession.Fee;
                userPic.ImageUrl = "~/images/" + GlobalSession.PIC;
                txtmail.Text = GlobalSession.Email;


            }
            if (GlobalSession.Email == string.Empty)
            {
                GlobalSession.LogOut();
                Response.Redirect("Owl_Login1.aspx", false);
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
                ddlReletedCity.DataSource = dS.Tables[1];
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

        void ShowMessage(string Message, bool type)
        {
            lblmsg.Text = (type ? "" : "") + Message;
            lblmsg.CssClass = type ? "alertMsg success" : "alertMsg failed";

        }
        protected void edit_Click(object sender, EventArgs e)
        {

            if (update.Text == "Update")
            {


                txtAddress.Enabled = txtmobile.Enabled = txtDOB.Enabled = ddlCollegeName.Enabled = ddlReletedCity.Enabled = ddlCourse.Enabled = ddlCategory.Enabled = txtFees.Enabled = txtPIC.Enabled = true;

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

        protected void update_Click(object sender, EventArgs e)
        {
            if (update.Text == "Update")
            {
              
                string filename = GlobalSession.StudentId + "_" + Path.GetFileName(txtPIC.FileName);
                var filePath = Path.Combine(Server.MapPath("~/images/" + filename));
                string AttachFilePath = filePath + filename;
                int size = txtPIC.PostedFile.ContentLength;

                if (size > 0)
                {
                    if (size < 2097152)
                    {

                        txtPIC.SaveAs(filePath);
                        OBJ = new PL();
                        OBJ.Ind = 5;
                        OBJ.StudentId = Convert.ToInt32(Session["StudentId"]);
                        OBJ.PIC = filename;
                        OBJ.FolderName = filePath;
                        OBJ.Email = txtmail.Text;
                        OBJ.MobileNo = txtmobile.Text;
                        OBJ.AadharNo = txtAadhar.Text;
                        OBJ.DOB = Convert.ToDateTime(txtDOB.Text);
                        OBJ.StudentAddress = txtAddress.Text;
                        OBJ.ReletedCity = Convert.ToInt32(ddlReletedCity.SelectedValue);
                        OBJ.CollegeName = Convert.ToInt32(ddlCollegeName.SelectedValue);
                        OBJ.Category = Convert.ToInt32(ddlCategory.SelectedValue);
                        OBJ.Course = Convert.ToInt32(ddlCourse.SelectedValue);
                        OBJ.Fees = Convert.ToInt32(txtFees.Text);
                        ds = new DataSet();
                        ds = ShareCommanClass.CallApiPostDs("Student/Save", OBJ);
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "showAlert();", true);
                        Thread.Sleep(1000);

                    }
                    else
                    {
                        ShowMessage("Only allow  2 MB File size..", false);
                    }
                }
                else
                {
                    ShowMessage("Please Choose document", false);
                }

            }
            else
            {
                ShowMessage("Not Update", false);
            }

        }

        protected void xlStudent_Click(object sender, EventArgs e)
        {
            DataTable dt = CreateHeader();
            DataTable dts = BindGrid();

            if(dts.Rows.Count>0)
            {
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    DateTime date = Convert.ToDateTime(dts.Rows[i]["DOB"]);
                    string da = date.ToString("dd/MM/yyyy");
                    dt.Rows.Add(dts.Rows[i][0], dts.Rows[i][1], dts.Rows[i][2], dts.Rows[i][3], dts.Rows[i][4], dts.Rows[i][5], dts.Rows[i][6] = da, dts.Rows[i][7], dts.Rows[i][8], dts.Rows[i][9], dts.Rows[i][10]);

                }
            }

            XLWorkbook wb = new XLWorkbook();
            //var ws = wb.Worksheets.Add("MySheet");
            var ws = wb.Worksheets.Add(dt, "Table_Name");
            ws.Columns().AdjustToContents();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=dbrecordExecl.xlsx");
            MemoryStream ms = new MemoryStream();
            wb.SaveAs(ms);
            ms.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }


        DataTable CreateHeader()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[11]
            {
             new DataColumn("StudentId",typeof(string)),
              new DataColumn("NAME", typeof(string)),
              new DataColumn("EMAIL", typeof(string)),
              new DataColumn("MOBILE",typeof(string)) ,
              new DataColumn("Aadhar", typeof(string)),
              new DataColumn("Address", typeof(string)),
              new DataColumn("Date of Birth",typeof(string)), 
              new DataColumn("City",typeof(string)),
              new DataColumn("College",typeof(string)),
              new DataColumn("Cource",typeof(string)),
              new DataColumn("Category",typeof(string)),
            
            });
            return dt2;
        }

        DataTable BindGrid()
        {
            dt = new DataTable();
            dt = ShareCommanClass.CallApiGetDt("Student/BindGrid?Ind=3");           
            return dt;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}