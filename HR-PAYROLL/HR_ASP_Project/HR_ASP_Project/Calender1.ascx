<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calender1.ascx.cs" Inherits="HR_ASP_Project.Calender1" %>
<style type="text/css">
    #TextBox1{
        float:left;
    }
    #ImageButton1{
        width:23px;
        margin-left:290px;
    }
    #Calendar1{
        margin-left:290px;
    }
</style>
<div class="form-group" style="width:320px;">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png" OnClick="ImageButton1_Click"/>
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
</div>
