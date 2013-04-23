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
                <asp:CheckBox ID="cbOwnCar" runat="server" OnCheckedChanged="cbOwnCar_CheckedChanged"
                    AutoPostBack="True" />
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
                <asp:Button ID="btnAddReceipt" runat="server" Text="Lägg till utgift" 
                    onclick="btnAddReceipt_Click" />
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
        <asp:Button ID="btnTract" runat="server" OnClick="btnTract_Click" Text="Lägg till" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnDataBinding="btnTract_Click"
                    UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="GWDiv">
                            <asp:Calendar ID="Calendar1" runat="server" CssClass="NoLineBreak" Height="45px"
                                Width="20px"></asp:Calendar>
                            <asp:GridView ID="gwTract" runat="server" Width="100%" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False" OnRowCommand="gwTract_RowCommand"
                                Font-Size="Small" EnableViewState="true">
                                <Columns>
                                    <asp:BoundField DataField="datum" HeaderText="Datum" />
                                    <asp:BoundField DataField="land" HeaderText="Land" />
                                    <%--<asp:BoundField DataField="kronor" HeaderText="Traktamente" />--%>
                                    <asp:TemplateField ShowHeader="false" HeaderText="Avdrag för Måltid">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                                                Font-Size="Small">
                                                <asp:ListItem Value="0">Ej avdrag</asp:ListItem>
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
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                            <asp:Button ID="Button2" runat="server" Text="Beräkna" OnClick="Button2_Click" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <%--Tvingar fram Post-back från Remove-knappen--%>
                        <asp:PostBackTrigger ControlID="gwTract" />
                    </Triggers>
                </asp:UpdatePanel>
    </div>
    <%--Avslutar ContentWrapper--%>
</asp:Content>
