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
    public partial class TransferRecord : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-82GF5NQ;Initial Catalog=HRM;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartment();
                LoadDesignation();
                LoadDivision();
                LoadGrid();

            }
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
        private void LoadDivision()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblDivision", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlDividion.DataSource = dt;
            ddlDividion.DataTextField = "DivName";
            ddlDividion.DataValueField = "DivCode";
            ddlDividion.DataBind();
        }
        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select DesigCode,Designation from tblDesignation where DeptCode='" + ddlDept.SelectedValue + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlDesig.DataSource = dt;
            ddlDesig.DataTextField = "Designation";
            ddlDesig.DataValueField = "DesigCode";
            ddlDesig.DataBind();
        }
        protected void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select distinct e.EmpName," +
            " d.DeptName,di.DivName,dg.Designation  from tblEmployee e " +
            " inner join tblDepartment d on e.DeptCode=d.DeptCode " +
            " inner join tblDivision di on e.DivCode=di.DivCode " +
            " inner join tblSection s on e.SceCode=s.SceCode " +
            " inner join tblEmployeeType et on e.ETCode=et.ETCode " +
            " inner join tblDesignation dg on dg.DesigCode=e.DesigCode where e.EmpCode='" + txtEmpCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblEmpName.Text = dt.Rows[0]["EmpName"].ToString();
                lblEmpDept.Text = dt.Rows[0]["DeptName"].ToString();
                lblDesi.Text = dt.Rows[0]["Designation"].ToString();
                lblempDiv.Text = dt.Rows[0]["DivName"].ToString();


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string TransferAcciDate = (TransActive.FindControl("TextBox1") as TextBox).Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblTransferRecord(EmpCode,OldDeptCode,OldDesigCode,OldDivCode,NewDeptCode,NewDesigCode,NewDivCode,TRActiveDate) values('" + txtEmpCode.Text + "','" + ddlDept.SelectedValue + "','" + ddlDesig.SelectedValue + "','" + ddlDividion.SelectedValue + "','" + ddlDept.SelectedValue + "','" + ddlDesig.SelectedValue + "','" + ddlDividion.SelectedValue + "','" + TransferAcciDate + "')", con);
            SqlCommand cmd1 = new SqlCommand("update tblEmployee set DeptCode='" + ddlDept.SelectedValue + "',DesigCode='" + ddlDesig.SelectedValue + "',DivCode='" + ddlDividion.SelectedValue + "'  where EmpCode='" + txtEmpCode.Text + "'", con);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!!";
            LoadGrid();
            ClearAll();
            con.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string TransferAcciDate = (TransActive.FindControl("TextBox1") as TextBox).Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblTransferRecord set NewDeptCode='" + ddlDept.SelectedValue + "',NewDesigCode='" + ddlDesig.SelectedValue + "',NewDivCode='" + ddlDividion.SelectedValue + "',TRActiveDate='" + TransferAcciDate + "' where EmpCode='" + txtEmpCode.Text + "'", con);
            SqlCommand cmd1 = new SqlCommand("update tblEmployee set DeptCode='" + ddlDept.SelectedValue + "',DesigCode='" + ddlDesig.SelectedValue + "',DivCode='" + ddlDividion.SelectedValue + "'  where EmpCode='" + txtEmpCode.Text + "'", con);
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            Literal1.Text = "Data saved successfully!!!";
            LoadGrid();
            ClearAll();
            con.Close();
        }
        protected void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select EmpCode,OldDeptCode,OldDesigCode,OldDivCode,NewDeptCode,NewDesigCode,NewDivCode,TRActiveDate from tblTransferRecord", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select EmpName,OldDeptCode,OldDesignationCode,OldDivCode,NewDeptCode,NewDesigtnationCode,NewDivCode,TrActivateDate from tblTransferRecord where EmpCode='" + txtEmpCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblEmpName.Text = dt.Rows[0]["EmpName"].ToString();
            lblEmpDept.Text = dt.Rows[0]["OldDeptCode"].ToString();
            lblDesi.Text = dt.Rows[0]["OldDesignationCode"].ToString();
            lblempDiv.Text = dt.Rows[0]["OldDivCode"].ToString();
            ddlDept.SelectedValue = dt.Rows[0]["NewDeptCode"].ToString();
            ddlDesig.SelectedValue = dt.Rows[0]["NewDesigtnationCode"].ToString();
            ddlDividion.SelectedValue = dt.Rows[0]["NewDivCode"].ToString();
            (TransActive.FindControl("TextBox1") as TextBox).Text = dt.Rows[0]["TrActivateDate"].ToString();
        }
        private void ClearAll()
        {
            lblEmpName.Text = "";
            lblEmpDept.Text = "";
            lblDesi.Text = "";
            lblempDiv.Text = "";
            ddlDept.SelectedIndex = -1;
            ddlDesig.SelectedIndex = -1;
            ddlDividion.SelectedIndex = -1;
            (TransActive.FindControl("TextBox1") as TextBox).Text = "";
            txtEmpCode.Text = "";
            txtEmpCode.Focus();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}