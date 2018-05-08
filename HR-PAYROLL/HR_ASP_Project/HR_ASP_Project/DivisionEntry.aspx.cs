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
    public partial class DivisionEntry : System.Web.UI.Page
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
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblDivision where DivCode='" + txtDivisionCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtDivisionName.Text = dt.Rows[0]["DivName"].ToString();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblDivision", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblDivision values('" + txtDivisionCode.Text + "','" + txtDivisionName.Text + "')", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!!";
            ClearAll();
            LoadGrid();
            con.Close();
        }

        private void ClearAll()
        {
            txtDivisionCode.Text = "";
            txtDivisionName.Text = "";
            txtDivisionCode.Focus();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblDivision set DivName='" + txtDivisionName.Text + "' where DivCode='" + txtDivisionCode.Text + "'", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Updated successfully.";
            LoadGrid();
            ClearAll();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from tblDivision where DivCode='" + txtDivisionCode.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Deleted successfully";
            LoadGrid();
            ClearAll();
            con.Close();
        }
    }
}