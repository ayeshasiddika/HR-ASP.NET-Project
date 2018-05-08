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
    public partial class SectionEntry : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-82GF5NQ;Initial Catalog=HRM;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                LoadGrid();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblSection values('" + txtSectionCode.Text + "','" + txtSectionName.Text + "')", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!!";
            ClearAll();
            LoadGrid();
            con.Close();
        }

        private void ClearAll()
        {
            txtSectionCode.Text = "";
            txtSectionName.Text = "";
            txtSectionCode.Focus();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblSection", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblSection set SecName='" + txtSectionName.Text + "' where SceCode='" + txtSectionCode.Text + "'", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Updated successfully.";
            ClearAll();
            LoadGrid();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from tblSection where SceCode='" + txtSectionCode.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Deleted successfully";
            ClearAll();
            LoadGrid();
            con.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblSection where SceCode='" + txtSectionCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtSectionName.Text = dt.Rows[0]["SecName"].ToString();
        }
    }
}