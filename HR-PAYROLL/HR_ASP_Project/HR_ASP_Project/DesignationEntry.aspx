<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DesignationEntry.aspx.cs" Inherits="HR_ASP_Project.DesignationEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row col-md-12">
        <h2>Designation Entry</h2>
   
    <div id="entryTable">
        
        <div id="desigEntry">
            <div class="form-group">
                <label class="control-label">Designation Code</label>
                <div id="search">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                </div>
                <asp:TextBox ID="txtDesigCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Designation</label>
                <asp:TextBox ID="txtDesig" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                    <label class="control-label">Department</label>
                <div id="check">
                    <asp:Button ID="btnCheck" runat="server" Text="Check" CssClass="btn btn-info" OnClick="btnCheck_Click" />
                </div>
                    <asp:DropDownList ID="ddlDept" CssClass="form-control" runat="server" Width="200px" AutoPostBack="true"></asp:DropDownList>
                </div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
            </div>
        </div>
      

    </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />

        </asp:GridView>
    </div>
    <style type="text/css">
         h2{
               text-align:center;
               margin-right:50px;
           }
            .row{
                min-height:600px;
            }
            #search{
                margin-right:120px;
                margin-top:25px;
                float:right;
            }
            #entryTable{
                width:500px;
                margin:10px auto;
                margin-top:50px;
            }
            #desigEntry{
                width:400px;
                margin:10px auto;
                float:left; 
            }
           #check{
               float:right;
                margin-right:120px;
                margin-top:25px;
           }

        </style>
    

</asp:Content>
