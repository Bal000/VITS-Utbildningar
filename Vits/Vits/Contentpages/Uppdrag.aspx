<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Uppdrag.aspx.cs" Inherits="Vits.Uppdrag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentWrapper">
    <h1>HANTERA Uppdrag</h1>
    <div class="MissionList">
        <asp:Label ID="Label1" runat="server" Text="Lista över alla uppdrag:"></asp:Label>
        <asp:ListBox ID="MissionList" runat="server" Height="250px" Width="199px"></asp:ListBox>
    </div>
    <div class="FormWrap">
        <div class="Form">
            <asp:Label ID="Label3" runat="server" Text="Kundkontor:"></asp:Label><br />
            <asp:DropDownList ID="ddOffice" runat="server" Width="164px" Enabled="False">
            </asp:DropDownList><br />
            <asp:Label ID="Label4" runat="server" Text="Chef för uppdraget:"></asp:Label><br />
            <asp:DropDownList ID="ddManager" runat="server" Width="164px" Enabled="False">
            </asp:DropDownList><br />
            <asp:Label ID="Label5" runat="server" Text="Beskrivning:"></asp:Label><br />
            <asp:TextBox ID="tbDescription" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
        </div>
        <div class="Form">
            <asp:Label ID="Label2" runat="server" Text="Startdatum: "></asp:Label><br />
            <asp:TextBox ID="tbDate" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Calendar ID="Calendar" runat="server" Enabled="False" 
                onselectionchanged="Calendar_SelectionChanged"></asp:Calendar>
        </div>
        <br />
        <div class="btnDiv">
            <asp:Button ID="btnEditMission" runat="server" Text="Ändra" Width="164px" 
                onclick="btnEditMission_Click" />
            <asp:Button ID="btnAddMission" class="ButtonSpace" runat="server" 
                Text="Lägg till uppdrag" Width="164px" onclick="btnAddMission_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Spara" 
                Visible="False" Width="164px" />
            <asp:Button ID="btnAddMission2" runat="server" 
                Text="Lägg till uppdrag" Visible="False" Width="164px" />
            <asp:Button ID="btnAvbryt" class="ButtonSpace" runat="server" Text="Avbryt" 
                onclick="btnAvbryt_Click" Visible="False" Width="164px" />
        </div>
    </div>
</div>
</asp:Content>
