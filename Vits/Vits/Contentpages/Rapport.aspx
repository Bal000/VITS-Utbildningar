<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rapport.aspx.cs" Inherits="Vits.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainDiv">
    <asp:Label ID="lblNamn" runat="server" CssClass="mainLabel">Namn:</asp:Label><br />
    <asp:Label ID="lblPnr" runat="server" CssClass="mainLabel">Pnr:</asp:Label><br />
    <asp:Label ID="lblAdress" runat="server" CssClass="mainLabel">Adress:</asp:Label>
   </div>


</asp:Content>
