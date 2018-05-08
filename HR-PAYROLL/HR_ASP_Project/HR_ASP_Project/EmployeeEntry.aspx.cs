using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HR_ASP_Project
{
    public partial class EmployeeEntry : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-82GF5NQ;Initial Catalog=HRM;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadDepartment();
                LoadDesignation();
                LoadSection();
                LoadDivision();
                LoadEmployeeType();
                LoadGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string dateDOB = (CalenderDOB.FindControl("TextBox1") as TextBox).Text;
            string dateJoining = (CalenderJoinDate.FindControl("TextBox1") as TextBox).Text;
            SqlCommand cmd = new SqlCommand("Insert into tblEmployee (EmpCode,EmpName,Address,Email,DateOfBirth,Contact,Gender,JoiningDate,BloodGroup,MaritalStatus,FatherName,MotherName,DeptCode,DesigCode,SceCode,DivCode,ETCode,CurrentSalary) values('" + txtEmpCode.Text + "','" + txtName.Text + "','" + txtAddress.Text + "','" + txtEmail.Text + "','" + dateDOB + "','" + txtMobile.Text + "','" + ddlGender.SelectedValue + "','" + dateJoining + "','" + txtBloodGroup.Text + "','" + ddlMaritalStatus.SelectedValue + "','"+txtFatherName.Text+"','"+txtMotherName.Text+"','" + ddlDept.SelectedValue + "','" + ddlDesig.SelectedValue + "','" + ddlSection.SelectedValue + "','" + ddlDivision.SelectedValue + "','" + ddlEmpType.SelectedValue + "','" + txtCrrntSalary.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!!";
            LoadGrid();
            ClearAll();
            con.Close();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select e.EmpName,e.[Address],e.Email,e.Gender,DeptName,di.DivName,dg.Designation,se.SecName,e.CurrentSalary from tblEmployee e inner join tblDepartment d on e.DeptCode=d.DeptCode inner join tblDivision di on e.DivCode=di.DivCode inner join tblSection se on e.SceCode=se.SceCode inner join tblDesignation dg on e.DesigCode=dg.DesigCode inner join tblEmployeeType et on e.ETCode=et.ETCode", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string dateDOB = (CalenderDOB.FindControl("TextBox1") as TextBox).Text;
            string dateJoining = (CalenderJoinDate.FindControl("TextBox1") as TextBox).Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblEmployee set EmpName='" + txtName.Text + "',Address='" + txtAddress.Text + "',Gender='" + ddlGender.SelectedValue + "',Email='" + txtEmail.Text + "',Contact='" + txtMobile.Text + "',DateOfBirth='" + dateDOB + "',Religion='" + txtReligion.Text + "',Nationality='" + txtNationality.Text + "',NationalIDNo='" + txtNid.Text + "',MaritalStatus='" + ddlMaritalStatus.SelectedValue + "',FatherName='" + txtFatherName.Text + "',MotherName='" + txtMotherName.Text + "',BloodGroup='" + txtBloodGroup.Text + "',JoiningDate='" + dateJoining + "',CurrentSalary='" + txtCrrntSalary.Text + "',DivCode='" + ddlDivision.SelectedValue + "',SceCode='" + ddlSection.SelectedValue + "',DeptCode='" + ddlDept.SelectedValue + "',DesigCode='" + ddlDesig.SelectedValue + "',ETCode='" + ddlEmpType.SelectedValue + "' where EmpCode='" + txtEmpCode.Text + "'", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Updated successfully.";
            LoadGrid();
            ClearAll();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from tblEmployee where EmpCode='" + txtEmpCode.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Deleted successfully";
            LoadGrid();
            ClearAll();
            con.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblEmployee where EmpCode='" + txtEmpCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtName.Text = dt.Rows[0]["EmpName"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            (CalenderDOB.FindControl("TextBox1") as TextBox).Text = dt.Rows[0]["DateOfBirth"].ToString();
            txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
            txtMotherName.Text = dt.Rows[0]["MotherName"].ToString();
            ddlGender.Text = dt.Rows[0]["Gender"].ToString();
            ddlMaritalStatus.Text = dt.Rows[0]["MaritalStatus"].ToString();
            txtMobile.Text = dt.Rows[0]["Contact"].ToString();
            txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
            txtReligion.Text = dt.Rows[0]["Religion"].ToString();
            txtBloodGroup.Text = dt.Rows[0]["BloodGroup"].ToString();
            txtNid.Text = dt.Rows[0]["NationalIDNo"].ToString();
            (CalenderJoinDate.FindControl("TextBox1") as TextBox).Text = dt.Rows[0]["JoiningDate"].ToString();
            ddlDept.Text = dt.Rows[0]["DeptCode"].ToString();
            ddlDesig.Text = dt.Rows[0]["DesigCode"].ToString();
            ddlDivision.Text = dt.Rows[0]["DivCode"].ToString();
            ddlSection.Text = dt.Rows[0]["SceCode"].ToString();
            ddlEmpType.Text = dt.Rows[0]["ETCode"].ToString();
            txtCrrntSalary.Text = dt.Rows[0]["CurrentSalary"].ToString();
            
        }

       private void LoadDepartment()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblDepartment", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlDept.DataSource = dt;
            ddlDept.DataTextField = "DeptName";
            ddlDept.DataValueField = "DeptCode";
            ddlDept.DataBind();
        }
       private void LoadDesignation()
       {
           SqlDataAdapter sda = new SqlDataAdapter("Select * from tblDesignation", con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           ddlDesig.DataSource = dt;
           ddlDesig.DataTextField = "Designation";
           ddlDesig.DataValueField = "DesigCode";
           ddlDesig.DataBind();
       }
       private void LoadSection()
       {
           SqlDataAdapter sda = new SqlDataAdapter("Select * from tblSection", con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           ddlSection.DataSource = dt;
           ddlSection.DataTextField = "SecName";
           ddlSection.DataValueField = "SceCode";
           ddlSection.DataBind();
       }
       private void LoadDivision()
       {
           SqlDataAdapter sda = new SqlDataAdapter("Select * from tblDivision", con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           ddlDivision.DataSource = dt;
           ddlDivision.DataTextField = "DivName";
           ddlDivision.DataValueField = "DivCode";
           ddlDivision.DataBind();
       }
       private void LoadEmployeeType()
       {
           SqlDataAdapter sda = new SqlDataAdapter("Select * from tblEmployeeType", con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           ddlEmpType.DataSource = dt;
           ddlEmpType.DataTextField = "EmployeeType";
           ddlEmpType.DataValueField = "ETCode";
           ddlEmpType.DataBind();
       }
       public void ClearAll()
       {
           txtEmpCode.Text = "";
           txtName.Text = "";
           txtAddress.Text = "";
           txtEmail.Text = "";
           (CalenderDOB.FindControl("TextBox1") as TextBox).Text = "";
           txtFatherName.Text = "";
           txtMotherName.Text = "";
           ddlGender.Text = "";
           txtMobile.Text ="";
           txtNationality.Text = "";
           txtReligion.Text = "";
           txtBloodGroup.Text = "";
           txtNid.Text = "";
           (CalenderJoinDate.FindControl("TextBox1") as TextBox).Text = "";
           ddlDept.SelectedIndex=-1;
           ddlDesig.SelectedIndex = -1;
           ddlDivision.SelectedIndex = -1;
           ddlSection.SelectedIndex = -1;
           ddlEmpType.SelectedIndex = -1;
           ddlMaritalStatus.SelectedIndex = -1;
           txtCrrntSalary.Text = "";
       }

       protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
       {
           string com = "Select * from tblDesignation where DeptCode='" + ddlDept.SelectedValue + "'";
           SqlDataAdapter sda = new SqlDataAdapter(com, con);
           DataTable dt = new DataTable();
           sda.Fill(dt);
           ddlDesig.DataSource = dt;
           ddlDesig.DataBind();
           ddlDesig.DataTextField = "Designation";
           ddlDesig.DataValueField = "DesigCode";
           ddlDesig.DataBind();
           con.Close();
       }
        
    }
}