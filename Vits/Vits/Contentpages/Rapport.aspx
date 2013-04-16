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
        <asp:Label ID="lblExAdress" runat="server">Hovstagatan 71691 Örebro</asp:Label><br /><br />

        <asp:Label ID="lblUppdrag" runat="server" CssClass="mainLabel">Välj Uppdrag:</asp:Label>
        <asp:DropDownList runat="server" id="ddlUppdrag">
            <asp:ListItem Value="">Företag, Ärendenummer</asp:ListItem>
            <asp:ListItem Value="">Microsoft, 69.186.703</asp:ListItem>
            <asp:ListItem Value="">Apple, 70.456.987</asp:ListItem>
            <asp:ListItem Value="">Double Hi-Tech Data, 23.615.765</asp:ListItem>
        </asp:DropDownList><br /><br />

        <asp:CheckBox ID="cbFardsatt" runat="server" 
               oncheckedchanged="cbFardsatt_CheckedChanged" AutoPostBack="true"/>
        <asp:Label ID="lblFardsatt" runat="server" CssClass="mainLabel">Välj Färdsätt:</asp:Label><br />
        <asp:DropDownList runat="server" id="ddlFardsatt" Enabled="false" 
               onselectedindexchanged="ddlFardsatt_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="Bil">Bil</asp:ListItem>
            <asp:ListItem Value="">Flyg</asp:ListItem>
            <asp:ListItem Value="">Båt</asp:ListItem>
            <asp:ListItem Value="">Taxi</asp:ListItem>
            <asp:ListItem Value="">Tåg</asp:ListItem>
            <asp:ListItem Value="">Övrigt</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblMiltal" runat="server" CssClass="mainLabel">Mil:</asp:Label>
        <asp:TextBox ID="txtMiltal" runat="server" CssClass="kortTxt" Enabled="false"></asp:TextBox>



       </div>
    <div>
        <asp:Label ID="lblSpec" runat="server" CssClass="mainLabel">Specificering:</asp:Label><br />
        <asp:TextBox ID="txtSpec" runat="server" CssClass="txtBoxRapport"></asp:TextBox><br />
        <asp:Label ID="lblFrom" runat="server" CssClass="mainLabel">From:</asp:Label><br />
        <asp:TextBox ID="txtFrom" runat="server" CssClass="txtBoxRapport"></asp:TextBox><br />
        <asp:Label ID="Tom" runat="server" CssClass="mainLabel">Tom:</asp:Label><br />
        <asp:TextBox ID="txtTom" runat="server" CssClass="txtBoxRapport"></asp:TextBox><br />
        <asp:Label ID="lblBelopp" runat="server" CssClass="mainLabel">Belopp:</asp:Label><br />
        <asp:TextBox ID="txtBelopp" CssClass="kortTxt" runat="server"></asp:TextBox>
        <asp:Label ID="lblMoms" runat="server" CssClass="mainLabel">Momssats:</asp:Label>
        <asp:DropDownList runat="server" id="ddlMoms">
            <asp:ListItem Value="">0%</asp:ListItem>
            <asp:ListItem Value="">6%</asp:ListItem>
            <asp:ListItem Value="">12%</asp:ListItem>
            <asp:ListItem Value="">25%</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="lblText" runat="server" CssClass="mainLabel">Text:</asp:Label><br />
        <asp:TextBox ID="txtText" runat="server" CssClass="txtBoxRapport"></asp:TextBox><br /><br />

        <asp:Button runat="server" ID="btnLaggTillKvitto" text="Lägg till kvitto/utgift" />
        
    </div>
    <div>
        <div>
            <asp:Label ID="lblRedovisadeUtgifter" runat="server" CssClass="mainLabel">Redovisade utgifter:</asp:Label><br />
       </div>
    </div>
    </div>


</asp:Content>
