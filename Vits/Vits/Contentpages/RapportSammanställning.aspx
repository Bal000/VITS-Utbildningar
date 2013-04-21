<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RapportSammanställning.aspx.cs" Inherits="Vits.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Consult_ReportHeaderText">
            <h1 id="Consult_ReportHeader">
                Konsult Rapport</h1>
        </div>
    <div class="Consult_LeftContentWrapper">
        <asp:Panel CssClass="Consult_LeftContent" runat="server">
            <h1 class="Consult_DisBlock">
                KonsultInformation:</h1>
                <br />
            <asp:Label ID="lblFullname" CssClass="Consult_DisBlock" runat="server" Text="Namn"></asp:Label>
            <asp:Label ID="lblAdress" CssClass="Consult_DisBlock" runat="server" Text="Address"></asp:Label>
            <asp:Label ID="lblCity" CssClass="Consult_DisBlock" runat="server" Text="Stad"></asp:Label>
            <asp:Label ID="lblEmail" CssClass="Consult_DisBlock" runat="server" Text="Email"></asp:Label>
            <asp:Label ID="lblMiles" runat="server" CssClass="Consult_DisBlock">Rapporterade mil med egen bil:</asp:Label>
        </asp:Panel>

        <asp:Panel CssClass="Consult_LeftContent" runat="server">
        <h1 class="Consult_DisBlock">Avvikelser under uppdrag:</h1>
        <br />
            <asp:Label ID="lblCountry" CssClass="Consult_DisInline" runat="server" Text="Danmark"></asp:Label>
            <asp:Label ID="lblFromDate" CssClass="Consult_DisInline" runat="server" Text="2011-10-22"></asp:Label>
            <asp:Label ID="lblToDate" CssClass="Consult_DisInline" runat="server" Text="2011-10-27"></asp:Label>
        </asp:Panel>
        <asp:Panel CssClass="Consult_LeftContent" runat="server">
        </asp:Panel>
    </div>
    <div class="Consult_RightContentWrapper">
        <asp:Panel ID="Panel1" CssClass="Consult_RightContent" runat="server">
        <h1 id="Expense_Header">Utgifter under resa:</h1>
        <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Kvitto</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
    </div>
</asp:Content>
