<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="salaryCreate.aspx.cs" Inherits="HR_ASP_Project.salaryCreate" %>
<%@ Register src="Calender1.ascx" tagname="Calender1" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Create Salary</h2>
        <div class="col-md-5">
            <div class="form-group">
                <asp:Label ID="lblDate" CssClass="control-label" runat="server" Text="Select Date"></asp:Label>
                <uc1:Calender1 ID="calDate" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblMonth" runat="server" CssClass="control-label" Text="Select Month"></asp:Label>
                <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server" Width="220px">
                    <asp:ListItem> Choose</asp:ListItem>
                    <asp:ListItem>Jan</asp:ListItem>
                    <asp:ListItem>Feb</asp:ListItem>
                    <asp:ListItem>Mar</asp:ListItem>
                    <asp:ListItem>Apr</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>June</asp:ListItem>
                    <asp:ListItem>July</asp:ListItem>
                    <asp:ListItem>Aug</asp:ListItem>
                    <asp:ListItem>Sep</asp:ListItem>
                    <asp:ListItem>Oct</asp:ListItem>
                    <asp:ListItem>Nov</asp:ListItem>
                    <asp:ListItem>Dec</asp:ListItem>
                    
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblYear" runat="server" CssClass="control-label" Text="Select Year"></asp:Label>
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" Width="220px">
                    <asp:ListItem> Choose</asp:ListItem>
                    <asp:ListItem>2001</asp:ListItem>
                    <asp:ListItem>2002</asp:ListItem>
                    <asp:ListItem>2003</asp:ListItem>
                    <asp:ListItem>2004</asp:ListItem>
                    <asp:ListItem>2005</asp:ListItem>
                    <asp:ListItem>2006</asp:ListItem>
                    <asp:ListItem>2007</asp:ListItem>
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="Create Salary" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
   <style type="text/css">
       h2 {
            text-align: center;
            
        }
       .row{
           width: 500px;
            margin: 10px auto;
            margin-top: 50px;
       }
       
       
   </style>

</asp:Content>
