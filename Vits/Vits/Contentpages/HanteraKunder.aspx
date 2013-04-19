<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HanteraKunder.aspx.cs" Inherits="Vits.HanteraKunder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentWrapper">
    <h1>Hantera kunder</h1>
    <br />
    <div class="OfficeList">
    <asp:Label ID="Label8" runat="server" Text="Lista över alla kundkontor:"></asp:Label>
        <asp:ListBox ID="OfficeList" runat="server" Height="250px" Width="199px">
        </asp:ListBox>
    
    </div>
    
    <div class="FormWrap">
            <div class="Form">
                <asp:Label ID="Label1" runat="server" Text="Namn:"></asp:Label><br />
                <asp:TextBox ID="Tbnamn" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="Organisations nummer:"></asp:Label><br />
                <asp:TextBox ID="Tborgnummer" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="Adress:"></asp:Label><br />
                <asp:TextBox ID="Tbadress" runat="server" Width="164px" Enabled="False"></asp:TextBox><br /><br />
                <asp:Button ID="btnAddOffice" runat="server" Text="Lägg till ny kund" 
                    Width="164px" onclick="btnAddOffice_Click" />
                <asp:Button ID="btnAvbryt" runat="server" Text="Avbryt" 
                    onclick="btnAvbryt_Click" Visible="False" Width="164px" />

            </div>
            <div class="Form">
                <asp:Label ID="Label4" runat="server" Text="Postnummer:"></asp:Label><br />
                <asp:TextBox ID="Tbzipcode" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="Stad:"></asp:Label><br />
                <asp:TextBox ID="Tbcity" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="Välj Land:"></asp:Label><br />
                <asp:DropDownList ID="ddLand" runat="server" Height="25px" Width="164px" 
                    Enabled="False"></asp:DropDownList><br /><br />
                <asp:Button ID="btnEditOffice" runat="server" Text="Ändra uppgifter" 
                    Width="164px" onclick="btnEditOffice_Click" />
                <asp:Button ID="btnSaveOffice" runat="server" Text="Spara ändringar" 
                    Width="164px" Visible="False" onclick="btnSaveOffice_Click" />
                <asp:Button ID="btnAddOffice2" runat="server" Text="Lägg till kund" 
                    Visible="False" Width="164px" />
            </div>
            <br />
        </div>
    
    <br />
</div>
<br />
<br />
</asp:Content>
