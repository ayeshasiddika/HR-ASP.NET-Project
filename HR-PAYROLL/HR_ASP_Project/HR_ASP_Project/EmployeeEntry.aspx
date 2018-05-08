<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEntry.aspx.cs" Inherits="HR_ASP_Project.EmployeeEntry" %>

<%@ Register Src="~/Calender1.ascx" TagPrefix="uc1" TagName="Calender1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row" id="entry">
        <h2>Employee Entry</h2>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Employee Code</label>
                <div style="float:right;margin-right:280px;margin-top:25px;">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                </div>
                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label class="control-label">Employee Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Date Of Birth</label>
                <uc1:Calender1 runat="server" ID="CalenderDOB" />
            </div>
            <div class="form-group">
                <label class="control-label">Gender</label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" Width="210px">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Marital Status</label>
                <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="form-control" Width="210px">
                    <asp:ListItem>Single</asp:ListItem>
                    <asp:ListItem>Married</asp:ListItem>
                    <asp:ListItem>Divorced</asp:ListItem>
                    <asp:ListItem>Widowed </asp:ListItem>
                    <asp:ListItem>Remarried  </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Father Name</label>
                <asp:TextBox ID="txtFatherName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Mother Name</label>
                <asp:TextBox ID="txtMotherName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Contact</label>
                <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Nationality</label>
                <asp:TextBox ID="txtNationality" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Religion</label>
                <asp:TextBox ID="txtReligion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Blood Group</label>
                <asp:TextBox ID="txtBloodGroup" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label class="control-label">NID</label>
                <asp:TextBox ID="txtNid" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Joining Date</label>&nbsp;
                    <uc1:Calender1 runat="server" ID="CalenderJoinDate" />
            </div>
            <div class="form-group">
                <label class="control-label">Division</label>
                <asp:DropDownList ID="ddlDivision" runat="server" CssClass="form-control" Width="210px"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Section</label>
                <asp:DropDownList ID="ddlSection" runat="server" CssClass="form-control" Width="210px"></asp:DropDownList>

            </div>
            <div class="form-group">
                <label class="control-label">Department</label>
                <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control" Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged"></asp:DropDownList>

            </div>
            <div class="form-group">
                <label class="control-label">Designation</label>
                <asp:DropDownList ID="ddlDesig" runat="server" CssClass="form-control" Width="210px"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Employee Type</label>
                <asp:DropDownList ID="ddlEmpType" runat="server" CssClass="form-control" Width="210px"></asp:DropDownList>

            </div>

            <div class="form-group">
                <label class="control-label">Current Salary</label>
                <asp:TextBox ID="txtCrrntSalary" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        </div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
            
        </div>
     </div>
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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

    <style type="text/css">
         h2{
               text-align:center;
               margin-right:320px;
           }
        #entry {
            width: 100%;
            margin: 20px auto;
            margin-left:100px;
        }
    </style>

</asp:Content>
