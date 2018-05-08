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
    public partial class DesignationEntry : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-82GF5NQ;Initial Catalog=HRM;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadDropdown();
                LoadGrid();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblDesignation values('" + txtDesigCode.Text + "','" + txtDesig.Text + "','" + ddlDept.Text + "')", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!!";
            ClearAll();
            LoadGrid();
            con.Close();
        }
        private void loadDropdown()
        {
            string com = "Select * from tblDepartment";
            SqlDataAdapter sda = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlDept.DataSource = dt;
            ddlDept.DataBind();
            ddlDept.DataTextField = "DeptName";
            ddlDept.DataValueField = "DeptCode";
            ddlDept.DataBind();
            con.Close();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select d.Designation,de.DeptName from tblDesignation d inner join tblDepartment de on d.DeptCode=de.DeptCode", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblDesignation set Designation='" + txtDesig.Text + "',DeptCode='"+ddlDept.SelectedValue+"' where DesigCode='" + txtDesigCode.Text + "'", con);
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Updated successfully.";
            LoadGrid();
            ClearAll();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from tblDesignation where DesigCode='" + txtDesigCode.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Deleted successfully";
            LoadGrid();
            ClearAll();
            con.Close();
        }

        

        
        private void ClearAll()
        {
            txtDesigCode.Text = "";
            txtDesig.Text = "";
            ddlDept.SelectedIndex = -1;
            txtDesigCode.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblDesignation where DesigCode='" + txtDesigCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtDesig.Text = dt.Rows[0]["Designation"].ToString();
            ddlDept.Text = dt.Rows[0]["DeptCode"].ToString();
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select d.Designation,de.DeptName from tblDesignation d inner join tblDepartment de on d.DeptCode=de.DeptCode where d.DeptCode='" + ddlDept.SelectedValue + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        
    }
}