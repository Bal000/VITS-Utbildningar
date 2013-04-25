<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reseorder.aspx.cs" Inherits="Vits.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="~/Styles/Reseorder.css" rel="stylesheet" type="text/css" />  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--Här börjar kod för Reseorder--%>
<div class="ContentWrapper">
<div class="InfoDiv"><%--Påbörjar uppdrag och land div.--%>
    <asp:Label ID="lblHeadlineMission" CssClass="Headline" runat="server" Text="Uppdrag:"></asp:Label>
    
    <asp:Label ID="lblMissionInfo" runat="server" Text="Information från databas"></asp:Label></br>
    <asp:Label ID="lblHeadlineCountry" CssClass="Headline" runat="server" Text="Land:"></asp:Label>
    
    <asp:Label ID="lblMissionCountry" runat="server" Text="Information från databas"></asp:Label>
</div> <%--Avslutar uppdrag och land div.--%>


<div class="TravelDiv"> <%--Börjar avres/ankomstdatum div.--%>
    
<div class="CalLeft">
    <asp:Label ID="lblTravelFromDate" CssClass="Headline" runat="server" Text="Avresedatum:"></asp:Label>
    <asp:Calendar ID="calendarFromDate" runat="server"></asp:Calendar>
    </br>
    <asp:TextBox ID="txtTravelFromDate" runat="server" Enabled="False"></asp:TextBox>
</div>

<div class="CalRight">
    <asp:Label ID="lblTravelToDate" CssClass="Headline" runat="server" Text="Ankomstdatum:"></asp:Label>
    <asp:Calendar ID="calendarToDate" runat="server"></asp:Calendar>
    </br>
    <asp:TextBox ID="txtTravelToDate" runat="server" Enabled="False"></asp:TextBox>
</div>

</div> <%--Avslutar avres/ankomstdatum div.--%>

<div class="PurposeDiv"> <%--Påbörjar ändamål div.--%>
    <asp:Label ID="lblPurpose" CssClass="Headline" runat="server" Text="Ändamål:"></asp:Label>
    </br>
    <asp:TextBox ID="txtPurpose" runat="server" TextMode="MultiLine" CssClass="txtBoxPurpose"></asp:TextBox>

</div> <%--Avslutar ändamål div.--%>


<div class="TravelMethodDiv"><%--Börjar färdsätt div.--%>
    <asp:Label ID="lblTravelMethod" CssClass="Headline" runat="server" Text="Färdsätt:"></asp:Label>
    <asp:CheckBoxList ID="cblTravelMethod" CssClass="cblTravelMethod" CellSpacing="40" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="Car">Egen bil</asp:ListItem>
        <asp:ListItem Value="Plane">Flyg</asp:ListItem>
        <asp:ListItem Value="Bus">Buss</asp:ListItem>
        <asp:ListItem Value="Train">Tåg</asp:ListItem>
        <asp:ListItem Value="Boat">Båt</asp:ListItem>
   
   </asp:CheckBoxList>


</div> <%--Avslutar färdsätt div.--%>

<div> <%--Börjar "SkickaKnapp" div--%>
    <asp:Button ID="btnSend" CssClass="btnSend" runat="server" Text="Skicka In" />
</div> <%--Avslutar "SkickaKnapp" div--%>
<div class="ClearFix"></div>
</div> <%--Avslutar ContentWrapper--%>

<%--Här slutar kod för reseorder--%>
</asp:Content>
