<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HanteraKunder.aspx.cs" Inherits="Vits.HanteraKunder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentWrapper">
    <h1>Hantera kunder</h1>
    <br />
    <div class="List">
    <asp:Label ID="Label8" runat="server" Text="Lista över alla kundkontor:"></asp:Label>
    <asp:Label ID="lblOfficeList" CssClass="ValidationLabel" runat="server" Text="Välj en kund!"
                Visible="False"></asp:Label>
        <asp:GridView ID="gwOffices" OnRowCommand="gwOffices_RowCommand" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="OID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="OID" SortExpression="OID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("OID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("OID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OrgNumber" SortExpression="OrgNumber" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OrgNumber") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("OrgNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Adress" SortExpression="Adress" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Adress") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Adress") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ZipCode" SortExpression="ZipCode" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ZipCode") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City" SortExpression="City" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CID" SortExpression="CID" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("CID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("CID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" Text="Visa" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString %>" 
            SelectCommand="SELECT * FROM [Office]"></asp:SqlDataSource>
    <br />
    
    </div>
    
    <div class="FormWrap">
    <br />
            <div class="Form">
                <asp:Label ID="Label1" runat="server" Text="Namn:"></asp:Label>
                <asp:Label ID="lblName" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbnamn" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="Organisations nummer:"></asp:Label>
                <asp:Label ID="lblOrgNr" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tborgnummer" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="Adress:"></asp:Label>
                <asp:Label ID="lblAddress" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbadress" runat="server" Width="164px" Enabled="False"></asp:TextBox><br /><br />
                

            </div>
            <div class="Form">
                <asp:Label ID="Label4" runat="server" Text="Postnummer:"></asp:Label>
                <asp:Label ID="lblZipCode" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbzipcode" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="Stad:"></asp:Label>
                <asp:Label ID="lblCity" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:TextBox ID="Tbcity" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="Välj Land:"></asp:Label>
                <asp:Label ID="lblCoutry" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
                <asp:DropDownList ID="ddlCountry" runat="server" Height="25px" Width="164px" 
                    Enabled="False" DataSourceID="SqlDataSource2" DataTextField="Name" 
                    DataValueField="CID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString %>" 
                    SelectCommand="SELECT * FROM [Country]"></asp:SqlDataSource>
                <br /><br />
<br />
            
                    <div class="Buttons">
                    <asp:Button ID="btnAddOffice" runat="server" Text="Lägg till ny kund" 
                    Width="164px" onclick="btnAddOffice_Click" />
                <asp:Button ID="btnAvbryt" runat="server" Text="Avbryt" 
                    onclick="btnAvbryt_Click" Visible="False" Width="164px" />
                <asp:Button ID="btnAddOffice2" runat="server" Text="Lägg till kund" 
                    Visible="False" Width="164px" onclick="btnAddOffice2_Click" />
                    </div>
                    <br />
            <br />
            </div>
            <br />
        </div>
    
    <br />
</div>
<br />
<br />
</asp:Content>
