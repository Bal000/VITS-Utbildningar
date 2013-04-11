<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapport.aspx.cs" Inherits="Vits.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainDiv">
       <div>
        <asp:Label ID="lblNamn" runat="server" CssClass="mainLabel">Namn:</asp:Label>
        <asp:Label ID="lblExempelNamn" runat="server">Erik Andersson</asp:Label><br />
        <asp:Label ID="lblPnr" runat="server" CssClass="mainLabel">Pnr:</asp:Label>
        <asp:Label ID="lblExPnr" runat="server">810306-7958</asp:Label><br />
        <asp:Label ID="lblAdress" runat="server" CssClass="mainLabel">Adress:</asp:Label>
        <asp:Label ID="lblExAdress" runat="server">Hovstagatan 71691 Örebro</asp:Label>
       </div>
    

    <div>
    <div>
        <asp:Label ID="Label1" runat="server" CssClass="mainLabel">Namn:</asp:Label>
        <asp:Label ID="Label2" runat="server">Erik Andersson</asp:Label><br />
        <asp:Label ID="Label3" runat="server" CssClass="mainLabel">Pnr:</asp:Label>
        <asp:Label ID="Label4" runat="server">810306-7958</asp:Label><br />
        <asp:Label ID="Label5" runat="server" CssClass="mainLabel">Adress:</asp:Label>
        <asp:Label ID="Label6" runat="server">Hovstagatan 71691 Örebro</asp:Label>
       </div>
    </div>
    <div>
    <div>
        <asp:Label ID="Label7" runat="server" CssClass="mainLabel">Namn:</asp:Label>
        <asp:Label ID="Label8" runat="server">Erik Andersson</asp:Label><br />
        <asp:Label ID="Label9" runat="server" CssClass="mainLabel">Pnr:</asp:Label>
        <asp:Label ID="Label10" runat="server">810306-7958</asp:Label><br />
        <asp:Label ID="Label11" runat="server" CssClass="mainLabel">Adress:</asp:Label>
        <asp:Label ID="Label12" runat="server">Hovstagatan 71691 Örebro</asp:Label>
       </div>
    </div>
    </div>


</asp:Content>
