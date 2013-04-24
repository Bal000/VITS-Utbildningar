<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HanteraKunder.aspx.cs" Inherits="Vits.HanteraKunder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentWrapper">
    <h1>Hantera kunder</h1>
    <br />
    <div class="List">
    <asp:Label ID="Label8" runat="server" Text="Lista över alla kundkontor:"></asp:Label>
    <asp:Label ID="lblOfficeList" CssClass="ValidationLabel" runat="server" Text="Välj en kund!"
                Visible="False"></asp:Label>
    <br />
        <asp:ListBox ID="OfficeList" runat="server" Height="250px" Width="199px">
        </asp:ListBox>
    
    </div>
    
    <div class="FormWrap">
    <br />
            <div class="Form">
                <asp:Label ID="Label1" runat="server" Text="Namn:"></asp:Label>
                <asp:Label ID="lblName" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbnamn" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="Organisations nummer:"></asp:Label>
                <asp:Label ID="lblOrgNr" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tborgnummer" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="Adress:"></asp:Label>
                <asp:Label ID="lblAddress" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbadress" runat="server" Width="164px" Enabled="False"></asp:TextBox><br /><br />
                

            </div>
            <div class="Form">
                <asp:Label ID="Label4" runat="server" Text="Postnummer:"></asp:Label>
                <asp:Label ID="lblZipCode" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbzipcode" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="Stad:"></asp:Label>
                <asp:Label ID="lblCity" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbcity" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="Välj Land:"></asp:Label>
                <asp:Label ID="lblCoutry" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:DropDownList ID="ddlCountry" runat="server" Height="25px" Width="164px" 
                    Enabled="False"></asp:DropDownList><br /><br />
<br />
            
                    <div class="Buttons">
                    <asp:Button ID="btnAddOffice" runat="server" Text="Lägg till ny kund" 
                    Width="164px" onclick="btnAddOffice_Click" />
                <asp:Button ID="btnAvbryt" runat="server" Text="Avbryt" 
                    onclick="btnAvbryt_Click" Visible="False" Width="164px" />
                <asp:Button ID="btnEditOffice" runat="server" Text="Ändra uppgifter" 
                    Width="164px" onclick="btnEditOffice_Click" />
                <asp:Button ID="btnSaveOffice" runat="server" Text="Spara ändringar" 
                    Width="164px" Visible="False" onclick="btnSaveOffice_Click" />
                <asp:Button ID="btnAddOffice2" runat="server" Text="Lägg till kund" 
                    Visible="False" Width="164px" onclick="btnAddOffice2_Click" />
                    </div>
                    <br />
            <br />
            </div>
            <br />
        </div>
    
    <br />
</div>
<br />
<br />
</asp:Content>
