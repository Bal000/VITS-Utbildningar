<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RapportIntro.aspx.cs" Inherits="Vits.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="Content">
        <div class="ContentWrapperIntro">
            <asp:Label ID="txtName" runat="server" Text="Name"></asp:Label><br />
            <asp:Label ID="txtEID" runat="server" Text="Eid"></asp:Label><br />
            <asp:Label ID="txtChooseMission" runat="server" Text="Välj uppdrag" CssClass="lblBold"></asp:Label><br />
            <asp:DropDownList ID="ddlChooseMission" runat="server">
                <asp:ListItem >Korv</asp:ListItem>
            </asp:DropDownList><br />
                <div class="ContentMissionInfo"> <%--Börjar uppdrags info rutan--%>
                <asp:Label ID="txtCustomer" runat="server" Text="Kund" CssClass="lblBold"></asp:Label><br />
                <asp:Label ID="txtCustomerInfo" runat="server" Text="inehåll"></asp:Label><br />

                <asp:Label ID="txtMissionDescription" runat="server" Text="Syfte" CssClass="lblBold"></asp:Label><br />
                <asp:Label ID="txtMissionDescriptionInfo" runat="server" Text="Innehåll" ></asp:Label><br />

                <asp:Label ID="txtMissionPeriod" runat="server" Text="Uppdragsperiod" CssClass="lblBold"></asp:Label><br />
                <asp:Label ID="txtMissionPeriodInfo" runat="server" Text="innehåll"></asp:Label><br />

                <asp:Label ID="MissionManager" runat="server" Text="Ansvarig" CssClass="lblBold"></asp:Label><br />
                <asp:Label ID="MissionManagerInfo" runat="server" Text="Innehåll"></asp:Label><br />
                </div> <%--Avslutar uppdrags info rutan--%>
                <asp:Button ID="btnTillRapport" runat="server" CssClass="btnAll" 
                Text="Fyll i rapport" onclick="btnTillRapport_Click" 
                 />
        </div>
    </div>
</asp:Content>
