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
    public partial class SalaryEntry : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-82GF5NQ;Initial Catalog=HRM;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}