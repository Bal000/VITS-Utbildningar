<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Uppdrag.aspx.cs" Inherits="Vits.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="divWrapper">
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowdatabound="GridView1_RowDataBound" ShowHeaderWhenEmpty="True" 
            CellPadding="8" CssClass="UppdragGrid" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Center" Width="800px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" 
                HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
            <Columns>
                <asp:BoundField DataField="Mission.StartDate" HeaderText="Start datum" 
                    SortExpression="StartDate" >
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Mission.Description" HeaderText="Beskrivning" 
                    SortExpression="Description" >
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Status" SortExpression="Approved" 
                    DataField="TravelOrder.Approved" >
                <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Mission.EID" HeaderText="EID" SortExpression="EID" 
                    Visible="False" />
                <asp:BoundField DataField="Mission.MID" HeaderText="MID" SortExpression="MID" 
                    Visible="False" />
                <asp:BoundField DataField="TravelOrder.Answered" HeaderText="Answered" 
                    SortExpression="travelOrder.Answered" />
                <asp:BoundField DataField="TravelOrder.Sent" HeaderText="Sent" 
                    SortExpression="Sent" />
            </Columns>
        
            <EditRowStyle BackColor="#999999" Width="200px" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" BorderColor="Black" BorderStyle="Solid" 
                BorderWidth="2px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" 
                VerticalAlign="Middle" Width="200px" />
            <PagerStyle BackColor="#284775" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" 
                VerticalAlign="Middle" Width="200px" Font-Size="13pt" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        
        </asp:GridView>
    </div>


</asp:Content>
