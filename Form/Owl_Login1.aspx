<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masterpage.Master" CodeBehind="Owl_Login1.aspx.cs" Inherits="pramodSourceSystem.Form.Owl_Login1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.3/dist/sweetalert2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.7.3/dist/sweetalert2.all.min.js"></script>
     <style>
        #Login
        {
            height:350px;
            width:300px;
            background-color:#2097cb;
            border:5px solid pink;
            margin-left:1000px;
          
        }

                .gst-ac-error {
            background: #f05050;
            color: #fff !important;
            text-align: center !important;
            width: auto;
            padding: 0 10px !important;
            border-radius: 4px;
            border: 1px solid #fff;
            position: absolute;
            Z-INDEX: 2;
            top: 0;
            right: 0;
            box-shadow: 0px 0px 5px 2px rgba(0,0,0,0.5);
        }
            .gst-ac-error::after {
                content: '';
                display: block;
                position: absolute;
                top: 100%;
                left: 50%;
                width: 0;
                Z-INDEX: 2;
                transform: translateX(-50%);
                height: 0;
                border-top: 10px solid #f05050;
                border-right: 10px solid transparent;
                border-bottom: 10px solid transparent;
                border-left: 10px solid transparent;
            }
        body
        {
           padding-top:100px;
          background-image:url("../images/Anup.jpg");
        }
    </style>
    <script>
        function myFunction() {
            debugger
            //var p = document.getElementById("#<%=New.ClientID%>");
            var p = document.getElementById("ContentPlaceHolder1_New");
            if (p.type === "password") {
                p.type = "text";
            }
            else {
                p.type = "password";
            }
        }

        </script>
    <script>
        function CheckPassword(inputtxt) {
            var passw = /^[A-Za-z]\w{7,14}$/;
            if (inputtxt.value.match(passw)) {
                alert('Correct, try another...')
                return true;
            }
            else {
                alert('Wrong...!')
                return false;
            }
        }
        function showAlert() {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Login successfully !!!',
                showConfirmButton: false,
                timer: 1500
            })
        }
    </script>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          
   
      <div  id="Login">
            <h3 style="text-align:center;"><span style="color:white">Login</span></h3>
            <hr />
        <asp:TextBox runat="server" ID="Id" CssClass="form-control" placeholder="Enter UserId" ValidationGroup="a1"></asp:TextBox><br /><br />
           <asp:RequiredFieldValidator ErrorMessage="Required..!!" runat="server" SetFocusOnError="true" ControlToValidate="Id" Display="Dynamic" CssClass="gst-ac-error" ValidationGroup="a1" Style="top:135px !important; right:575px!important"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator SetFocusOnError="true" ID="RegularExpressionValidator3" runat="server" Display="Dynamic" ValidationGroup="a1"
              ControlToValidate="Id" ErrorMessage="Invalid Email." ValidationExpression="[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}" CssClass="gst-ac-error" Style="top:130px !important; right:550px!important"></asp:RegularExpressionValidator>
        <asp:TextBox runat="server" ID="New" placeholder="Enter Password" CssClass="form-control" MaxLength="8" type="Password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"  onclick="CheckPassword(inputtxt)"></asp:TextBox><br /><br />
          <asp:CheckBox runat="server" onclick="myFunction()"  />Show Password<br /><br />
           <asp:RequiredFieldValidator ErrorMessage="Required..!!" runat="server" SetFocusOnError="true" ControlToValidate="New" Display="Dynamic" CssClass="gst-ac-error" ValidationGroup="a1" Style="top:210px !important; right:575px!important"></asp:RequiredFieldValidator>
       &nbsp&nbsp&nbsp&nbsp <asp:Button runat="server" ID="btnsave" CssClass="btn btn-success"  ValidationGroup="a1"  Text="LogIn" OnClick="btnsave_Click" /> <br />
        <asp:Label runat="server" ID="lblmsg" style="color:red"></asp:Label>
    </div>
</asp:Content>

  
