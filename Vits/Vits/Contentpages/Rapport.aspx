<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Rapport.aspx.cs" Inherits="Vits.WebForm1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="~/Styles/Rapport.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="ContentWrapper">
        <div class="ContentLeft">
            <%--Nedan samlar jag information om egen bil i en egen div för presentation inom ContentLeft--%>.
            <div class="CarDiv">
                <asp:Label ID="lblOwnCar" runat="server" Text="Egen bil" CssClass="lblBold"></asp:Label>
                <asp:CheckBox ID="cbOwnCar" runat="server" />
                <asp:Label ID="lblMiles" runat="server" Text="Antal mil: " CssClass="lblBold" Visible="False"></asp:Label>
                <asp:TextBox ID="txtlOWnCar" runat="server" Visible="False"></asp:TextBox>
                <br />
            </div>
            <%--Nedan samlar jag information om Kvitton i en egen div inom ContentLeft.--%>
            <div class="ReceiptDiv">
                <asp:Label ID="txtCategory" runat="server" Text="Kategori" CssClass="lblBold"></asp:Label><br />
                <asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem>Dummy</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="txtDate" runat="server" Text="Datum" CssClass="lblBold"></asp:Label><br />
                <asp:TextBox ID="txtBoxDate" runat="server"></asp:TextBox><br />
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
            <asp:UpdatePanel ID="UpdatePanel2" OnDataBinding="btnAddReceipt_Click" runat="server">
            <ContentTemplate>
            <asp:GridView ID="gvReciept" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" AutoGenerateColumns="False">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField HeaderText="Belopp" DataField="Sum" />
                    <asp:BoundField DataField="Description" HeaderText="Beskrivning" 
                        SortExpression="Description" />
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Ändra" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Ta bort" />
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
            </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Label ID="lblTotal" runat="server" Text="Totalt: " CssClass="lblBold"></asp:Label>
        </div>
        <p class="ClearFix">
        </p>
        <%--Nedan samlar jag information om Traktamenten--%>
        <div class="SubsistenceDiv">
            <div id="tractLeft">
                <asp:Label ID="lblFooterCountryLabel" runat="server" Text="Välj land" CssClass="lblBold"></asp:Label>
                <br />
                <asp:DropDownList ID="ddlTractCountry" runat="server">
                </asp:DropDownList>
                                
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnDataBinding="btnTract_Click"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="tractRightUp">
                        <div id="startdatum">
                            <asp:Label ID="lblFrom" runat="server" CssClass="lblBold" Text="Startdatum:"></asp:Label>
                        </div>
                        <div id="stoppdatum">
                            <asp:Label ID="lblTo" runat="server" CssClass="lblBold" Text="Stoppdatum:"></asp:Label>
                        </div>
                    </div>
                    <div id="tractRight">
                        <div id="calFromDiv">
                        <asp:Calendar ID="calFrom" runat="server" BackColor="White" 
                                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                            Font-Size="8pt" ForeColor="Black" height="180px" Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                        </div>
                        <div id="calToDiv">
                        <asp:Calendar ID="calTo" runat="server" BackColor="White" 
                                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana"
                            Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                            <NextPrevStyle VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#808080" />
                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" />
                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                        </div>
                        <div id="divBtnTract">
                            <asp:Button ID="btnTract" runat="server" OnClick="btnTract_Click" Text="Lägg till" CssClass="btnTract" />
                        </div>
                    </div>
                    <p class="clearBoth"></p>

                    <div id="gwDiv">
                        <asp:GridView ID="gwTract" runat="server" Width="100%" AutoGenerateColumns="False"
                                OnRowCommand="gwTract_RowCommand" Font-Size="Small" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="datum" HeaderText="Datum" />
                                    <asp:BoundField DataField="land" HeaderText="Land" />
                                    <%--<asp:BoundField DataField="kronor" HeaderText="Traktamente" />--%>
                                    <asp:TemplateField ShowHeader="false" HeaderText="Avdrag för Måltid">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                                Font-Size="Small">
                                                <asp:ListItem Value="0" Selected="True">Ej avdrag</asp:ListItem>
                                                <asp:ListItem Value="1">Frukost</asp:ListItem>
                                                <asp:ListItem Value="2">Lunch eller Middag</asp:ListItem>
                                                <asp:ListItem Value="3">Lunch och Middag</asp:ListItem>
                                                <asp:ListItem Value="4">Frukost, Lunch och Middag</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="false" HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="Button1" runat="server" Text="Ta bort" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                CommandName="remove" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        
                        <asp:Button ID="Button2tmp" runat="server" Text="Beräkna" OnClick="Button2tmp_Click" />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <%--Tvingar fram Post-back från Remove-knappen--%>
                    <asp:PostBackTrigger ControlID="gwTract" />
                    <asp:PostBackTrigger ControlID="btnTract" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <%--Avslutar ContentWrapper--%>
</asp:Content>