<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HanteraUppdrag.aspx.cs" Inherits="Vits.Uppdrag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="ContentWrapper">
    <h1>HANTERA UPPDRAG</h1>
    <br />
    <div class="List">
        <asp:Label ID="Label1" runat="server" Text="Lista över alla uppdrag:"></asp:Label>
        <asp:Label ID="lblMissionList" CssClass="ValidationLabel" runat="server" Text="Välj ett uppdrag!"
                Visible="False"></asp:Label>
        <asp:GridView ID="gwMissions" onRowCommand="gwUsers_RowCommand" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="MID" DataSourceID="SqlDataSource1" 
            onselectedindexchanged="gwMissions_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="MID" SortExpression="MID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("MID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("MID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OID" SortExpression="OID" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("OID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Manager" SortExpression="Manager" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Manager") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Manager") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="StartDate" SortExpression="StartDate" 
                    Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("StartDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" Text="Visa information" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString %>" 
            SelectCommand="SELECT * FROM [Mission]"></asp:SqlDataSource>
        <br />
    </div>
    <div class="FormWrap">
    <br />
        <div class="Form">
            <asp:Label ID="Label3" runat="server" Text="Kundkontor:"></asp:Label>
            <asp:Label ID="lblCustomerOffice" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            <asp:DropDownList ID="ddOffice" runat="server" Width="164px" Enabled="False">
            </asp:DropDownList><br />
            <asp:Label ID="Label4" runat="server" Text="Chef för uppdraget:"></asp:Label>
            <asp:Label ID="lblManager" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label>
            <br />
            <asp:DropDownList ID="ddManager" runat="server" Width="164px" Enabled="False">
            </asp:DropDownList><br />
            <asp:Label ID="Label5" runat="server" Text="Beskrivning:"></asp:Label>
            <asp:Label ID="lblDescription" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            <asp:TextBox ID="tbDescription" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
        </div>
        <div class="Form">
            <asp:Label ID="Label2" runat="server" Text="Startdatum: "></asp:Label>
            <asp:Label ID="lblDate" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            <asp:TextBox ID="tbDate" runat="server" Width="164px" Enabled="False"></asp:TextBox><br />
            <asp:Calendar ID="Calendar" runat="server" Enabled="False" 
                onselectionchanged="Calendar_SelectionChanged"></asp:Calendar>
            <br />
            <br />
            <div class="Buttons">
            <asp:Button ID="btnEditMission" runat="server" Text="Ändra" Width="164px" 
                    onclick="btnEditMission_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Spara" 
                    Visible="False" Width="164px" onclick="btnSave_Click" />
                <asp:Button ID="btnAddMission" runat="server"  
                    Text="Lägg till uppdrag" Visible="False" Width="164px" 
                    onclick="btnAddMission_Click" />
            
                <asp:Button ID="btnAddMission2" runat="server"
                    Text="Lägg till uppdrag" Width="164px" onclick="btnAddMission2_Click" />
                
                <asp:Button ID="btnAvbryt" runat="server" Text="Avbryt"
                    onclick="btnAvbryt_Click" Visible="False" Width="164px" />
            </div>
            <br />
            <br />
        </div>
        <br />
    </div>
    <br />
    <br />
</div>
</asp:Content>
