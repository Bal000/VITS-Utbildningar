<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Uppdrag.aspx.cs" Inherits="Vits.Uppdrag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentWrapper">
    <h1>Uppdrag</h1>
    <asp:Label ID="Label1" runat="server" Text="Välj uppdragskontor:"></asp:Label><br />
    <asp:DropDownList ID="ddlKontor" runat="server" Height="25px" Width="164px"></asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Välj chef för uppdraget:"></asp:Label><br />
    <asp:DropDownList ID="ddlChef" runat="server" Height="25px" Width="164px"></asp:DropDownList><br />
    <asp:Label ID="Label3" runat="server" Text="Skriv en kort beskrivning om uppdraget:"></asp:Label><br />
    <asp:TextBox ID="tbBeskrivning" runat="server" Width="164px" Height="20px"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="Välj ett startdatum för uppdraget:"></asp:Label>
    <br />
    <asp:TextBox ID="tbDatum" runat="server" Width="164px" Text="Inget datum valt" 
        Enabled="False" Height="20px"></asp:TextBox>
    <br />
    <asp:Calendar ID="Kalender" runat="server" 
        onselectionchanged="Kalender_SelectionChanged"></asp:Calendar>
    <br />
    <asp:Button ID="btnSkapaUppdrag" runat="server" Text="Skapa uppdrag" 
        Height="31px" Width="166px" onclick="btnSkapaUppdrag_Click" />
</div>
</asp:Content>
