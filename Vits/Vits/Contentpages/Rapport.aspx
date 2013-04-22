<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Rapport.aspx.cs" Inherits="Vits.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentWrapper">
        <div class="ContentLeft">
            <%--Nedan samlar jag information om egen bil i en egen div för presentation inom ContentLeft--%>.
            <div class="CarDiv">
                <asp:Label ID="lblOwnCar" runat="server" Text="Egen bil" CssClass="lblBold"></asp:Label>
                <asp:CheckBox ID="cbOwnCar" runat="server" 
                    oncheckedchanged="cbOwnCar_CheckedChanged" AutoPostBack="True" />
                <asp:Label ID="lblMiles" runat="server" Text="Antal mil: " CssClass="lblBold" 
                    Visible="False"></asp:Label>
                <asp:TextBox ID="txtlOWnCar" runat="server" Visible="False"></asp:TextBox> 
                    
                <br />
            </div>
            <%--Nedan samlar jag information om Traktamenten i en egen div inom ContentLeft--%>
            <div class="SubsistenceDiv">
                <div class="ContentFooterLeft">
                    <asp:Label ID="lblFooterCountryLabel" runat="server" Text="Välj land:"></asp:Label><br />
                    <asp:DropDownList ID="ddlTractCountry" runat="server">
                    </asp:DropDownList>
                    <div id="CalendarFromDiv" class="CalendarFromDiv">
                        <asp:Label ID="lblFrom" runat="server" Text="Från:" CssClass="lblBold"></asp:Label><br />
                        <asp:Calendar ID="calFrom" runat="server" CssClass="NoLineBreak" Height="125px" 
                            Width="164px" onselectionchanged="calFrom_SelectionChanged">
                        </asp:Calendar>
                    </div>
                </div>
                <div class="ContentFooterRight">
                    <div id="CalendarToDiv" class="CalendarToDiv">
                        <asp:Label ID="lblTo" runat="server" Text="Till:" CssClass="lblBold"></asp:Label><br />
                        <asp:Calendar ID="calTo" runat="server" CssClass="NoLineBreak" 
                            onselectionchanged="calTo_SelectionChanged"></asp:Calendar>
                    </div>
                    <br />
                    <div class="BtnAddTract">
                    <asp:Button ID="BtnAddTract"  Text="Lägg till" runat="server"
                        Height="20px" Width="74px" />
                    </div>
                </div>
                <div id="GWDiv">
                    <asp:GridView ID="GWTract" runat="server" Height="157px" Width="477px">
                    </asp:GridView>
                </div>
            </div>
        
        <%--Nedan samlar jag information om Kvitton i en egen div inom ContentLeft.--%>
        <div class="ReceiptDiv">
            <asp:Label ID="txtCategory" runat="server" Text="Kategori" CssClass="lblBold"></asp:Label><br />
            <asp:DropDownList ID="ddlCategory" runat="server">
                <asp:ListItem>Dummy</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="txtDate" runat="server" Text="Datum" CssClass="lblBold"></asp:Label><br />
            <asp:TextBox ID="txtBoxDateFrom" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtBoxDateTo" runat="server"></asp:TextBox><br />
            <asp:Label ID="txtAmount" runat="server" Text="Belopp" CssClass="lblBold"></asp:Label><br />
            <asp:TextBox ID="txtBoxAmount" runat="server"></asp:TextBox><br />
            <asp:Label ID="txtCountry" runat="server" Text="Land" CssClass="lblBold"></asp:Label><br />
            <asp:DropDownList ID="ddlCountry" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="txtDescription" runat="server" Text="Beskrivning" CssClass="lblBold"></asp:Label><br />
            <asp:TextBox ID="txtBoxDescription" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAddReceipt" runat="server" Text="Lägg till utgift" />
        </div>
    </div>
    <div class="ContentRight">
        <asp:Label ID="txtExpenseList" runat="server" Text="Utgifts Lista:" CssClass="lblBold"></asp:Label>
        <asp:GridView ID="gvReciept" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Kategori" />
                <asp:BoundField HeaderText="Belopp" />
                <asp:ButtonField Text="Button" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblTotal" runat="server" Text="Totalt: " CssClass="lblBold"></asp:Label>
    </div>
    <p class="ClearFix">
    </p>
    </div>
    <%--Avslutar ContentWrapper--%>
</asp:Content>
