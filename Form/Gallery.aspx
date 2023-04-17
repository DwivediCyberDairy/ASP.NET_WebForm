<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="pramodSourceSystem.Form.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
    body {
    background-color: pink;
    padding-top:100px;
}

</style>
   <br />
   <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading" >
                <h3 style="text-align:center">Gallery</h3>
            </div>
            <img src="../images/footer.jpg" style="height:200px; width:200px;" />
             <img src="../images/India.jpg" style="margin-left:20px;padding-top:10px;" />
           
            <img src="../images/lotestempl.jpg" style="margin-left:20px;padding-top:10px;"/>
            <img src="../images/Anupam.jpg"  style="margin-left:20px;padding-top:10px; height:220px;width:220px;" />
            <br />
           <div class="panel-footer">
               <asp:Button runat="server" ID="btnsave" Text="Back" CssClass="btn-success" />
            </div>
        </div>
      
    </div>
</asp:Content>
