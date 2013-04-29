<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HanteraAnvandare.aspx.cs" Inherits="Vits.Contentpages.HanteraAnvandare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<div class="ContentWrapper">
    <h1>Lägg till användare</h1>
    <br />
    
    <div class="List">
    <asp:Label ID="Label8" runat="server" Text="Lista över alla användare:"></asp:Label>
    <asp:Label ID="lblUserList" CssClass="ValidationLabel" runat="server" Text="Välj en användare!"
                Visible="False"></asp:Label>
    
    <br />
        <asp:GridView ID="gwUsers" runat="server" OnRowCommand="gwUsers_RowCommand" AutoGenerateColumns="False" 
            DataKeyNames="EID" DataSourceID="SqlDataSource3" >
            <Columns>
                <asp:TemplateField HeaderText="EID" SortExpression="EID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("EID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
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
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ZipCode") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ZipCode") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="IdNumber" SortExpression="IdNumber" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("IdNumber") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("IdNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Manager" SortExpression="Manager" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Manager") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Manager") %>' 
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" Text="Visa information" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString %>" 
            SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString %>" 
            SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString %>" 
            SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>
    </div>
    
    <div class="FormWrap">
    <br/ >
        <div class="Form">
            <asp:Label ID="label1" runat="server" Text="Förnamn:"></asp:Label>
            <asp:Label ID="lblFirstName" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="tbFirstName" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label2" runat="server" Text="Efternamn:"></asp:Label>
            
            <asp:Label ID="lblLastName" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            <asp:TextBox ID="tbLastName" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label3" runat="server" Text="Adress:"></asp:Label>
            
            <asp:Label ID="lblAdress" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="tbAdress" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label4" runat="server" Text="Postnummer:"></asp:Label>
            
            <asp:Label ID="lblZipCode" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            <asp:TextBox ID="tbZipCode" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            
        </div>
        <div class="Form">
            <asp:Label ID="label5" runat="server" Text="Stad:"></asp:Label>
            
            <asp:Label ID="lblCity" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="tbCity" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label6" runat="server" Text="Personnummer:"></asp:Label>
            
            <asp:Label ID="lblID" CssClass="ValidationLabel" runat="server" Visible="False"></asp:Label><br />
            <asp:TextBox ID="tbID" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="label7" runat="server" Text="Emailadress:"></asp:Label>
            
            <asp:Label ID="lblEmail" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label>
            <br />
            <asp:TextBox ID="tbEmail" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Label ID="Label9" runat="server" Text="Välj roll:"></asp:Label>
            
            <asp:Label ID="lblRole" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label>

            <asp:RadioButtonList ID="radiobutton" runat="server" Enabled="False">
                <asp:ListItem Selected="True" Text="Konsult"></asp:ListItem>
                <asp:ListItem Text="Chef"></asp:ListItem>
            </asp:RadioButtonList><br />
            <br />
            <div class="Buttons">
                <asp:Button ID="btnEditUser" runat="server" Text="Ändra uppgifter" 
                    Width="164px" onclick="btnEditUser_Click" />
                <asp:Button ID="btnAddUser" runat="server" Text="Lägg till användare" 
                    Width="164px"  onclick="btnAddUser_Click"/>
                <br />
                <asp:Button ID="btnAvbryt" runat="server" Text="Avbryt" Width="164px" 
                    onclick="btnAvbryt_Click" Visible="False" />
                <asp:Button ID="btnSave" runat="server" Text="Spara ändringar" Width="164px" 
                     onclick="btnSave_Click" Visible="False"/>
                <asp:Button ID="btnAddUser2" runat="server" Text="Lägg till användare"  Width="164px"
                     Visible="False" onclick="btnAddUser2_Click" /> 
            </div>
            <br />
            <br />

        </div>
             <br />
    
        </div>
         <br />
    
        </div>


</asp:Content>
