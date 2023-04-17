<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpage.Master" CodeBehind="Registration.aspx.cs" Inherits="pramodSourceSystem.Form.Registration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        
       
        #outer input
        {
             font-size:15px;
        }
        body
        {
         padding-top:100px;
        
        }
    </style>
    <script>
        function showAlert() {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Registration successfully!!!!',
                showConfirmButton: false,
                timer: 1500
            })
        }
    </script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
     <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.3/dist/sweetalert2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.3/dist/sweetalert2.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="row">
        <div class="col-lg-3 col-sm-3"></div>
    <div class="col-lg-6 col-sm-6" id="outer" style=" background-color:#d3d3d3 ;border:3px solid pink;" >
    <h3 style="color:#d95959; text-align:center">Fresh Registration For Academic Year 2022-23</h3>
        <hr />

  
    <div>
        <div class="row">
             <div class="col-lg-6 col-sm-6">
                  
                  <asp:TextBox runat="server" ID="Name" placeholder="Enter Student Name" class="form-control" TabIndex="1"></asp:TextBox><br /><br />
             </div>
             <div class="col-lg-6 col-sm-6">
                 <asp:TextBox runat="server" ID="Email" placeholder="Enter  Email Id" class="form-control" TabIndex="1"></asp:TextBox><br /><br />
             </div>
        </div>
   <div class="row">
       <div class="col-lg-6 col-sm-6">
            <asp:TextBox runat="server" ID="MobileNo" placeholder="Enter Mobile number" class="form-control" MaxLength="10" TabIndex="2"></asp:TextBox><br /><br />
       </div>
        <div class="col-lg-6 col-sm-6">
          <asp:TextBox runat="server" ID="AadharNo" placeholder="Enter Aadhar Number" class="form-control" TabIndex="3"></asp:TextBox><br /><br />
       </div>
   </div>
        
        <div class="row">
            <div class="col-lg-6 col-sm-6">
                 <asp:TextBox runat="server" ID="DOB" placeholder="Enter DOB" class="form-control" TextMode="Date" TabIndex="4"></asp:TextBox><br /><br />
            </div>
            <div class="col-lg-6 col-sm-6">
        <asp:TextBox runat="server" ID="StudentAddress" placeholder="Enter Student Address" class="form-control" TabIndex="5"></asp:TextBox><br /><br />
            </div>
        </div>
       <div class="row">
           <div class="col-lg-6 col-sm-6">
               <asp:TextBox runat="server" ID="fees" placeholder="Enter Student Fees" class="form-control" type="Number" TabIndex="6"></asp:TextBox><br /><br />
           </div>
            <div class="col-lg-6 col-sm-6">
                 <asp:DropDownList runat="server" ID="ddlReletedCity" class="form-control"  OnSelectedIndexChanged="ddlReletedCity_SelectedIndexChanged" AutoPostBack="true" TabIndex="7"></asp:DropDownList><br /><br />
           </div>
       </div>
       <div class="row">
           <div class="col-lg-6 col-sm-6">
               <asp:DropDownList runat="server" ID="ddlCollegeName" class="form-control" TabIndex="8"></asp:DropDownList><br /><br />
           </div>
           <div class="col-lg-6 col-sm-6">
<asp:DropDownList runat="server" ID="ddlCategory"  class="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" TabIndex="9"></asp:DropDownList><br /><br />
           </div>
       </div>
       <div class="row">
           <div class="col-lg-6 col-sm-6">
                <asp:DropDownList runat="server" ID="ddlCourse"  class="form-control" TabIndex="10"></asp:DropDownList><br /><br />
           </div>
            <div class="col-lg-6 col-sm-6">
                 <asp:TextBox runat="server" ID="pass" class="form-control" placeholder="Enter Password" MaxLength="8" type="password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" TabIndex="11"></asp:TextBox><br /><br />
           </div>
       </div>
        <div class="row">
             <div class="col-lg-6 col-sm-6">
                   <asp:TextBox runat="server" ID="Con" class="form-control" placeholder="Enter Confirm Password" MaxLength="8" type="password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" TabIndex="12"></asp:TextBox><br /><br />
             </div>
              <div class="col-lg-6 col-sm-6">
                  <asp:Button  runat="server" ID="btnsave" class="form-control" Text="Save" CssClass="btn btn-success" OnClick="btnsave_Click" TabIndex="13" />
                   <asp:Button runat="server" ID="ClearAll" Text="ClearAll"  CssClass="btn btn-danger" TabIndex="14" />
                    <asp:Button runat="server" Text="ShowAllRecourd" ID="BtnShowEmpDetails" CssClass="btn btn-primary" OnClick="BtnShowEmpDetails_Click" />
             </div>
        </div>
        
        <asp:Label runat="server" ID="lblmsg" style="color:red" TabIndex="15"></asp:Label>

       &nbsp&nbsp&nbsp&nbsp&nbsp <asp:LinkButton runat="server" ID="log" TabIndex="16" ><a href="Owl_Login1.aspx">LogIn</a></asp:LinkButton>
    </div>
        </div>

    </div>
 
        <!------------------------------------------------Grid View Start------------------------------------------------------------------------->

       <asp:GridView runat="server" ID="grvStudent" style="font-size:15px;" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"  CssClass="table table-bordered"  AutoGenerateEditButton="false" AutoGenerateColumns="false" ShowHeader="true" >
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="name1" CssClass="header" runat="server" Text='<%#Eval("StudentName")%>'></asp:Label>
                        <asp:HiddenField ID="StudentId" Value='<%#Eval("StudentId")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="email" CssClass="header" Text='<%#Eval("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MobileNo">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblemail" CssClass="header" Text='<%#Eval("MobileNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <%--<asp:TemplateField HeaderText="AadharNo">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblAadharNo" CssClass="header" Text='<%#Eval("AadharNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                 <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblAddress" CssClass="header" Text='<%#Eval("StudentAddress") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOB">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDOB" CssClass="header" Text='<%# Convert.ToDateTime(Eval("DOB")).ToString("dd/MM/yyyy") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="CityName">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCity" CssClass="header" Text='<%#Eval("CityName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText ="CollegeName">
                    <ItemTemplate>
                        <asp:Label ID="College" runat="server" CssClass="header" Text='<%#Eval("CollegeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText ="Course">
                    <ItemTemplate>
                        <asp:Label ID="lblCourse" runat="server" CssClass="header" Text='<%#Eval("CourseName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CourseCotegory">
                    <ItemTemplate>
                         <asp:Label ID="lblCotegory" runat="server" CssClass="header" Text='<%#Eval("CourseCategory") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button Text="Edit" runat="server" ID="grvStudent" CssClass="btn btn-success" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>'/>
                  
                  
                </ItemTemplate>
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                   
                    <asp:Button Text="Delete" runat="server" ID="Delete" CssClass="btn btn-danger" CommandName="Del" CommandArgument='<%# Container.DataItemIndex %>'/>
                  
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>

        </asp:GridView>
 
</asp:Content>


