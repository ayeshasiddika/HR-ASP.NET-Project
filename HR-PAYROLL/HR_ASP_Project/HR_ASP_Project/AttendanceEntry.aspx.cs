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
    public partial class AttendanceEntry : System.Web.UI.Page
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
            SqlDataAdapter sda = new SqlDataAdapter("Select * from tblAttendance where EmpCode='" + txtEmpCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlEmployee.SelectedValue = dt.Rows[0]["EmpCode"].ToString();
            (calAttendance.FindControl("TextBox1") as TextBox).Text = dt.Rows[0]["ATTDate"].ToString();
            txtInHour.Text = dt.Rows[0]["InHour"].ToString();
            txtInMinute.Text = dt.Rows[0]["InMinute"].ToString();
            txtOutHour.Text = dt.Rows[0]["OutHour"].ToString();
            txtOutMinute.Text = dt.Rows[0]["OutMinute"].ToString();
            ddlAttStatus.SelectedValue = dt.Rows[0]["ATTStatus"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var date = (calAttendance.FindControl("TextBox1") as TextBox).Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into tblAttendance(EmpCode,ATTDate,InHour,InMinute,OutHour,OutMinute,ATTStatus)values('" + ddlEmployee.SelectedValue + "','" + date + "','" + txtInHour.Text + "','" + txtInMinute.Text + "','" + txtOutHour.Text + "','" + txtOutMinute.Text + "','" + ddlAttStatus.SelectedValue + "')", con);
            cmd.ExecuteNonQuery();
            ClearAll();
            Literal1.Text = "Data save successfully.";
            LoadGrid();
            con.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var date = (calAttendance.FindControl("TextBox1") as TextBox).Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblAttendance set InHour='" + txtInHour.Text + "',InMinute='" + txtInMinute.Text + "',OutHour='" + txtOutHour.Text + "',OutMinute='" + txtOutMinute.Text + "',ATTStatus='" + ddlAttStatus.SelectedValue + "' where ATTDate='" + (calAttendance.FindControl("TextBox1") as TextBox).Text + "'", con);
            cmd.ExecuteNonQuery();
            ClearAll();
            Literal1.Text = "Data Updated successfully.";
            LoadGrid();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from tblAttendance where ATTDate='" + (calAttendance.FindControl("TextBox1") as TextBox).Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Literal1.Text = "Data Deleted successfully";
            ClearAll();
            LoadGrid();
            con.Close();
        }
        private void ClearAll()
        {

            ddlEmployee.SelectedIndex = -1;
            (calAttendance.FindControl("TextBox1") as TextBox).Text = "";
            txtInHour.Text = "";
            txtInMinute.Text = "";
            txtOutHour.Text = "";
            txtOutMinute.Text = "";
            ddlAttStatus.SelectedIndex = -1;
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select EmpCode,ATTDate,(InHour+':'+InMinute) as Intime, (OutHour+':'+OutMinute) as OutTime,ATTStatus from tblAttendance", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from tblEmployee where EmpCode='" + txtEmpCode.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlEmployee.DataSource = dt;
            ddlEmployee.DataBind();
            ddlEmployee.DataTextField = "EmpName";
            ddlEmployee.DataValueField = "EmpCode";
            ddlEmployee.DataBind();
        }
    }
}