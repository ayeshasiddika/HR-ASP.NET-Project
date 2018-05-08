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
    public partial class SalaryInformation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-82GF5NQ;Initial Catalog=HRM;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadGrid();

            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double grossAmount = Convert.ToDouble(txtSalary.Text);
            double basicAmount = grossAmount * .60;
            double houseRentAmount = grossAmount * .20;
            double medicalAmount = grossAmount * .10;
            double otherAllAmount = grossAmount * .10;

            lblGross.Text = grossAmount.ToString();
            lblBasic.Text = basicAmount.ToString();
            lblHRent.Text = houseRentAmount.ToString();
            lblMedical.Text = medicalAmount.ToString();
            lblOthersAll.Text = otherAllAmount.ToString();
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select* from tblSalary", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblSalary (EmpCode,Basic,HouseRent,Medical,OtherAllowance,Gross) " +
            " values('" + txtempCode.Text + "','" + lblBasic.Text + "','" + lblHRent.Text + "','" + lblMedical.Text + "','" + lblOthersAll.Text + "','" + lblGross.Text + "')", con);
            cmd.ExecuteNonQuery();
            //update employee current salary
            SqlCommand cmd2 = new SqlCommand("update tblEmployee set CurrentSalary='" + lblGross.Text + "' where EmpCode='" + txtempCode.Text + "'", con);
            cmd2.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!! ";
            con.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("update tblSalary set Basic='' where EmpCode='" + txtempCode.Text + "'", con);
            //cmd.ExecuteNonQuery();
            //Literal1.Text = "Data Updated successfully.";
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("delete from tblSalary where EmpCode='" + txtempCode.Text + "'", con);
            //cmd.ExecuteNonQuery();
            //Literal1.Text = "Data Deleted successfully!!!";
            //LoadGrid();
            //con.Close();
        }

        protected void txtempCode_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select distinct e.EmpCode, e.EmpName,e.Address,e.Email,e.JoiningDate,e.Contact, " +
               " d.DeptName,s.SecName,di.DivName,dg.Designation,et.EmployeeType from tblEmployee e " +
               " inner join tblDepartment d on e.DeptCode=d.DeptCode " +
               " inner join tblDivision di on e.DivCode=di.DivCode " +
               " inner join tblSection s on e.SceCode=s.SceCode " +
               " inner join tblEmployeeType et on e.ETCode=et.ETCode " +
               " inner join tblDesignation dg on e.DesigCode=dg.DesigCode where EmpCode='" + txtempCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblEmpName.Text = dt.Rows[0]["EmpName"].ToString();
                lblDept.Text = dt.Rows[0]["DeptName"].ToString();
            }
        }




    }
}