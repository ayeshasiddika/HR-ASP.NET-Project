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
    public partial class EmployeeType : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-82GF5NQ;Initial Catalog=HRM;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadGrid();

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblEmployeeType where ETCode='" + txtEmpTypeCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtEmpTypeName.Text = dt.Rows[0]["EmployeeType"].ToString();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblEmployeeType", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblEmployeeType values('" + txtEmpTypeCode.Text + "','" + txtEmpTypeName.Text + "')", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!!";
            ClearAll();
            LoadGrid();
            con.Close();
        }

        private void ClearAll()
        {
            txtEmpTypeCode.Text = "";
            txtEmpTypeName.Text = "";
            txtEmpTypeCode.Focus();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblEmployeeType set EmployeeType='" + txtEmpTypeName.Text + "' where ETCode='" + txtEmpTypeCode.Text + "'", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Updated successfully.";
            LoadGrid();
            ClearAll();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from tblEmployeeType where ETCode='" + txtEmpTypeCode.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Deleted successfully";
            LoadGrid();
            ClearAll();
            con.Close();
        }
    }
}