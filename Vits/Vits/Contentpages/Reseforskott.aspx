<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reseforskott.aspx.cs" Inherits="Vits.Contentpages.Reseforskott" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <div class="ContentWrapper">
    <h1>ANSÖK OM RESEFÖRSKOTT</h1>
    <br />
        <div class="FormWrapRF">
        <br />
            <div class="Form">
                <asp:Label ID="Label2" runat="server" Text="Uppdrag:"></asp:Label>
                
                <asp:Label ID="lblMission" CssClass="ValidationLabel" runat="server" Visible="False"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="164px">
                </asp:DropDownList>
                <asp:Label ID="lbl" runat="server" Text="Kostnad:"></asp:Label>
                <asp:Label ID="lblTotal" CssClass="ValidationLabel" runat="server" Visible="False"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="164px"></asp:TextBox>
            </div>
            <div class="Form">
                <asp:Label ID="Label3" runat="server" Text="Datum: "></asp:Label>
                <asp:Label ID="lblDate" CssClass="ValidationLabel" runat="server" Visible="False"></asp:Label><br />
                <asp:TextBox ID="tbDate" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Calendar ID="Calendar" runat="server" 
                    onselectionchanged="Calendar_SelectionChanged" Width="164px"></asp:Calendar>
                <br />
                <div class="Buttons">
                    <asp:Button ID="Send" runat="server" Text="Ansök" Width="164px" 
                        onclick="Send_Click" />
                </div>
                <br />
                <br />
            </div>
        <br />
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <br />
        


</asp:Content>
