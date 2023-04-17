<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="pramodSourceSystem.Form.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.3/dist/sweetalert2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.3/dist/sweetalert2.all.min.js"></script>
    <style>
        #Img{
            height:100px;
            width:170px;
            border:3px solid pink;
            background-color:pink;
            margin-left:20px;
           
        }
        #o
        {
            height:140px;
            width:1000px;
            border:3px solid pink;
            background-color:#f3cfc0;
            margin-left:60px;
           
        }
         #p
        {
            height:400px;
            width:1000px;
            border:3px solid pink;
            background-color:white;
            margin-left:50px;
            
        }
       body
       {
           padding-top:100px;
       }
    </style>
    <script>
        function showAlert() {
            Swal.fire('Data Updated successfully !!! ')
        }

    </script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" >
                <h3 class="text-center">Profile</h3>
            </div>
             <hr />
            <div class="row">
                  <div id="o">
                <div class="col-sm-2" style="margin-top:5px;" >
                   <asp:Image ID="userPic"  runat="server" Style="height:125px;width:125px; border-radius:50%; border:2px solid #206bd4" />
                </div>
            <div class="col-sm-10">
                     <h3 class="text-danger">Welcome,<span><%=pramodSourceSystem.Models.GlobalSession.UserName %></span></h3>
                <h4>Application Id :&nbsp<asp:Label runat="server" ID="txtmail" Enabled="false" Style="color:#4eb9c8;"></asp:Label></h4>
                     <%-- <h4>Application Id:<span style="color:#38b3ca" id="txtmail"><%=pramodSourceSystem.Models.GlobalSession.Email %></span></h4>--%> 
                      <asp:FileUpload runat="server" ID="txtPIC" Enabled="false" />
                </div>
                
             </div>
            </div>
             <%--<div class="row">
                 <div id="o">
                 <div class="col-md-12 bg-danger">
                     <h3 class="text-danger">Welcome,<span><%=pramodSourceSystem.Models.GlobalSession.UserName %></span></h3>
                      <h4>Application Id:<span style="color:#38b3ca"><%=pramodSourceSystem.Models.GlobalSession.Email %></span></h4> 
                      <asp:FileUpload runat="server" ID="txtPIC" />
                 </div>
             </div>
             </div>--%>
            <br />
                <div id="p" style="padding:10px">
              <div class="row " >
               <div class="col-md-2">
                   <h4>Student Address</h4>
               </div>
               <div class="col-md-2">
                  
                   <asp:TextBox ID="txtAddress" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
               </div>
           </div>
                <div class="row " >
               <div class="col-md-2">
                   <h4>Mobile Number</h4>
               </div>
               <div class="col-md-2">
                  
                   <asp:TextBox ID="txtmobile" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
               </div>
           </div>
                 <div class="row " >
               <div class="col-md-2">
                   <h4>Date Of Birth</h4>
               </div>
                    
               <div class="col-md-2">
                  <%--<h4>Date Of Birth:  <span><%=pramodSourceSystem.Models.GlobalSession.DOB %></span></h4>--%>
                   <asp:TextBox ID="txtDOB" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
               </div>
           </div>
                <div class="row ">
                    <div class="col-md-2">
                        <h4>City Name</h4>
                    </div>
                    <div class="col-md-2">
                        <%--<h4>Aadhar Number: <span><%=pramodSourceSystem.Models.GlobalSession.AadharNo %></span> </h4>--%>
                        <asp:DropDownList runat="server" ID="ddlReletedCity" CssClass="form-control form-control-sm" Enabled="false" OnSelectedIndexChanged="ddlReletedCity_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row ">
                    <div class="col-md-2">
                        <h4>College Name</h4>
                    </div>
                    <div class="col-md-2">
                        <%--<h4>College Name : <span><%=pramodSourceSystem.Models.GlobalSession.CollegeName %></span></h4>--%>
                        <asp:DropDownList runat="server" ID="ddlCollegeName" CssClass="form-control form-control-sm" Enabled="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="row " >
               <div class="col-md-2">
                   <h4>Aadhar Number</h4>
               </div>
               <div class="col-md-2">
                       <%--<h4>Aadhar Number: <span><%=pramodSourceSystem.Models.GlobalSession.AadharNo %></span> </h4>--%>
                   <asp:TextBox ID="txtAadhar" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
               </div>
           </div>

                
                  <div class="row ">
                    <div class="col-md-2">
                        <h4>Course Category</h4>
                    </div>
                    <div class="col-md-2">
                        <%--<h4>Aadhar Number: <span><%=pramodSourceSystem.Models.GlobalSession.AadharNo %></span> </h4>--%>
                        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control form-control-sm" Enabled="false" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row ">
                    <div class="col-md-2">
                        <h4>Course Name</h4>
                    </div>
                    <div class="col-md-2">
                        <%--<h4>Aadhar Number: <span><%=pramodSourceSystem.Models.GlobalSession.AadharNo %></span> </h4>--%>
                        <asp:DropDownList runat="server" ID="ddlCourse" CssClass="form-control form-control-sm" Enabled="false"></asp:DropDownList>
                    </div>
                </div>


              


                <div class="row " >
               <div class="col-md-2">
                   <h4>Student Fees</h4>
               </div>
               <div class="col-md-2">
                       <%--<h4>Aadhar Number: <span><%=pramodSourceSystem.Models.GlobalSession.AadharNo %></span> </h4>--%>
                   <asp:TextBox ID="txtFees" CssClass="form-control form-control-sm" runat="server" Enabled="false"></asp:TextBox>
               </div>
           </div>


                <asp:HiddenField ID="StudentId" Value='<%#Eval("StudentId")%>' runat="server" />


            </div>
            <br />
            <div class="row">
                
                <div class="col-md-1">
                    <asp:Button runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-primary" OnClick="edit_Click" />
                </div>
                <div class="col-md-1">
                    <asp:Button runat="server" ID="update" Text="Update" CssClass="btn btn-success" OnClick="update_Click"  />
                </div>
                  <div class="col-md-1">
                    <asp:Button runat="server" ID="Button1" Text="print" CssClass="btn btn-primary" OnClick="xlStudent_Click"  />
                </div>
            </div>                                  
            <asp:Label runat="server" ID="lblmsg"></asp:Label>
           </div>
        
        </div>
</asp:Content>
