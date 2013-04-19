<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HanteraAnvandare.aspx.cs" Inherits="Vits.Contentpages.HanteraAnvandare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="ContentWrapper">
    <h1>Lägg till användare</h1>
    <br />
    
    <div class="UserList">
    <asp:Label ID="Label8" runat="server" Text="Lista över alla användare:"></asp:Label>
    <asp:ListBox ID="UserList" runat="server" Height="250px" Width="199px"></asp:ListBox>
    </div>
    
    <div class="FormWrap">
        <div class="Form">
            <asp:Label ID="label1" runat="server" Text="Förnamn:"></asp:Label><br />
            <asp:TextBox ID="tbFirstName" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label2" runat="server" Text="Efternamn:"></asp:Label><br />
            <asp:TextBox ID="tbLastName" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label3" runat="server" Text="Adress:"></asp:Label><br />
            <asp:TextBox ID="tbAdress" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label4" runat="server" Text="Postnummer:"></asp:Label><br />
            <asp:TextBox ID="tbZipCode" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            
        </div>
        <div class="Form">
            <asp:Label ID="label5" runat="server" Text="Stad:"></asp:Label><br />
            <asp:TextBox ID="tbCity" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label6" runat="server" Text="Personnummer:"></asp:Label><br />
            <asp:TextBox ID="tbID" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label7" runat="server" Text="Emailadress:"></asp:Label><br />
            <asp:TextBox ID="tbEmail" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="Label9" runat="server" Text="Välj roll:"></asp:Label>

            <asp:RadioButtonList ID="radiobutton" runat="server" Enabled="False">
                <asp:ListItem Selected="True" Text="Konsult"></asp:ListItem>
                <asp:ListItem Text="Chef"></asp:ListItem>
            </asp:RadioButtonList><br />
        </div>
        <div class="ButtonDiv">
            <asp:Button ID="btnEditUser" runat="server" Text="Ändra uppgifter" 
                Width="164px" onclick="btnEditUser_Click" />
            <asp:Button ID="btnAddUser" runat="server" Text="Lägg till användare" 
                Width="164px" class="ButtonSpace" onclick="btnAddUser_Click"/>
            <br />
            <asp:Button ID="btnAvbryt" runat="server" Text="Avbryt" Width="164px" 
                onclick="btnAvbryt_Click" Visible="False" />
            <asp:Button ID="btnSave" runat="server" Text="Spara ändringar" Width="164px" 
                class="ButtonSpace" onclick="btnSave_Click" Visible="False"/>
            <asp:Button ID="btnAddUser2" runat="server" Text="Lägg till användare"  Width="164px"
                class="ButtonSpace" Visible="False" />
        </div>
        </div>
        </div>
 
    

</asp:Content>
