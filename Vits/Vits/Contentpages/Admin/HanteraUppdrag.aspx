<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HanteraUppdrag.aspx.cs" Inherits="Vits.Uppdrag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:scriptmanager ID="sm1" runat="server" EnablePartialRendering="true" />

<div class="ContentWrapper">
    <h1>HANTERA UPPDRAG</h1>
    <br />
    
    <div class="List">
        <asp:Label ID="Label1" runat="server" Text="Lista över alla uppdrag:"></asp:Label>
        <asp:Label ID="lblMissionList" CssClass="ValidationLabel" runat="server" Text="Välj ett uppdrag!"
                Visible="False"></asp:Label>
        <asp:GridView ID="gwMissions" onRowCommand="gwMissions_RowCommand" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="MID" DataSourceID="SqlDataSource1" >
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
                <asp:ButtonField ButtonType="Button" Text="Visa" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString2 %>" 
            SelectCommand="SELECT * FROM [Mission]"></asp:SqlDataSource>
        <br />
    </div>
    <div class="FormWrap">
    <br />
        <div class="Form">
            <asp:Label ID="Label3" runat="server" Text="Kundkontor:"></asp:Label>
            <asp:Label ID="lblCustomerOffice" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            <asp:DropDownList ID="ddOffice" runat="server" Width="164px" Enabled="False" 
                AppendDataBoundItems="True" DataSourceID="SqlDataSource2" 
                DataTextField="Name" DataValueField="OID" >
            </asp:DropDownList>
           
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString2 %>" 
                SelectCommand="SELECT * FROM [Office]"></asp:SqlDataSource>
           
            <br />
            <asp:Label ID="Label4" runat="server" Text="Chef för uppdraget:"></asp:Label>
            <asp:Label ID="lblManager" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label>
            <br />
            <asp:DropDownList ID="ddManager" runat="server" Width="164px" Enabled="False" 
                AppendDataBoundItems="True" DataSourceID="SqlDataSource3" 
                DataTextField="fullname" DataValueField="EID" >
            </asp:DropDownList>
           
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString2 %>" SelectCommand="select EID, firstname + ' ' + lastname as fullname
from employee
where manager = 1;"></asp:SqlDataSource>
           
            <br />
            <asp:Label ID="Label5" runat="server" Text="Beskrivning:"></asp:Label>
            <asp:Label ID="lblDescription" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            <asp:TextBox ID="tbDescription" runat="server" Width="164px" Enabled="False"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Uppdragskonsult:"></asp:Label>
            <asp:DropDownList ID="ddEmployee" runat="server" Enabled="False" Width="164px" 
                AppendDataBoundItems="True" DataSourceID="SqlDataSource4" 
                DataTextField="fullname" DataValueField="EID" >
            </asp:DropDownList>
            
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DATABASEVITSConnectionString2 %>" SelectCommand="select EID, firstname + ' ' + lastname as fullname
from employee;"></asp:SqlDataSource>
            
            <br />
            
        
        </div>
        <div class="Form">
            <asp:Label ID="Label2" runat="server" Text="Startdatum: "></asp:Label>
            <asp:Label ID="lblDate" CssClass="ValidationLabel" runat="server" 
                Visible="False"></asp:Label><br />
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="tbDate" runat="server" Width="164px" Enabled="False" 
                AutoPostBack="True"></asp:TextBox><br />

                <asp:Calendar ID="Calendar" runat="server" Enabled="False" 
                    onselectionchanged="Calendar_SelectionChanged"></asp:Calendar>

                </ContentTemplate>
                
             </asp:UpdatePanel>
          
            
                    
                
               
                <br />
                <br />
            <div class="Buttons">
                <asp:Button ID="btnAddMission" runat="server"  
                    Text="Lägg till uppdrag" Width="164px" 
                    onclick="btnAddMission_Click" />
            
                <asp:Button ID="btnAddMission2" runat="server"
                    Text="Lägg till uppdrag" Width="164px" onclick="btnAddMission2_Click" 
                    Visible="False" />
                
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
