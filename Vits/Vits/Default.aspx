<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Vits._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div class="leftDiv">
   </div>
   <div class="centerDiv">
    <h2>
        vITs tjänsteresesystem
    </h2>
    <p>
        Var god logga in för att rapportera in resor,
        ansöka om reseförskott etc.
    </p>
        <asp:Button ID="btnLogin" runat="server" CssClass="btnLogin" Text="Logga in" 
           onclick="btnLogin_Click" />
           <asp:Label runat="server">hej</asp:Label>
   </div>
   <div class="rightDiv">
   </div>

</asp:Content>
