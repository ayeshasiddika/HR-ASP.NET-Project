﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalaryInformation.aspx.cs" Inherits="HR_ASP_Project.SalaryInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row col-md-12">
        <h2>Salary Information</h2>
   
    <div id="entryTable">
        <div id="SalaryInfoEntry">
            <div class="form-group">
                <label class="control-label">Employee Code</label>
                <asp:TextBox ID="txtempCode" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtempCode_TextChanged"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Employee Name :</label>
                <asp:Label ID="lblEmpName" runat="server"  Text=""></asp:Label>
            </div>
            <div class="form-group">
                <label class="control-label">Department :</label>
                <asp:Label ID="lblDept" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <label class="control-label">Salary :</label>
                <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                <div id="calculate">
                    <asp:Button ID="btnCalculate" runat="server" CssClass="btn btn-block" Text="Calculate" OnClick="btnCalculate_Click" />
                </div>
            </div>
            <div class="form-group">
                <label class="control-label">Gross :</label>
                 <asp:Label ID="lblGross" runat="server" Text="" CssClass="control-label" style="color:#152df1;font-weight:bold;font-size:15px;"></asp:Label>
            </div>
             <div class="form-group">
                <label class="control-label">Basic :</label>
                 <asp:Label ID="lblBasic" runat="server" Text="" CssClass="control-label" style="color:#152df1;font-weight:bold;font-size:15px;"></asp:Label>
            </div>
             <div class="form-group">
                <label class="control-label">House Rent :</label>
                 <asp:Label ID="lblHRent" runat="server" Text="" CssClass="control-label" style="color:#152df1;font-weight:bold;font-size:15px;"></asp:Label>
            </div>
             <div class="form-group">
                <label class="control-label">Medical :</label>
                 <asp:Label ID="lblMedical" runat="server" Text="" CssClass="control-label" style="color:#152df1;font-weight:bold;font-size:15px;"></asp:Label>
            </div>
            <div class="form-group">
                    <label class="control-label">Others Allowance :</label>
                    <asp:Label style="color:#152df1;font-weight:bold;font-size:15px;" ID="lblOthersAll" runat="server"  Text="" CssClass="control-label"></asp:Label>
                </div>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"/>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click"/>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
            </div>
        </div>
        <div id="edit">
            <div class="form-group">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
            </div>
        </div>
        </div>
         <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    </div>
     <style type="text/css">
          h2 {
            text-align: center;
            margin-right: 50px;
        }
          #calculate{
              margin-top:10px;
          }
            .row{
                min-height:400px;
            }
            #entryTable{
                width:500px;
                margin:10px auto;
                margin-top:50px;
            }
            #SalaryInfoEntry{
                width:300px;
                margin:10px auto;
                float:left;
                
                
            }
            #edit {
                 width:100px;
                float:left;
                margin-top:35px;
                margin-left:-80px;
            }

        </style>
</asp:Content>
