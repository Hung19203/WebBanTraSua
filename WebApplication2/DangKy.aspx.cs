using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class DangKy : System.Web.UI.Page
    {
        QueryModel conn = new QueryModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDK_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text;
            var pass = txtPass.Text;
            var email = txtEmail.Text;
            var sdt = txtSDT.Text;
            var diachi = txtDiaChi.Text;

            Dictionary<string, object> pValue = new Dictionary<string, object>();
            pValue.Add("USERNAME", user);
            pValue.Add("PASSWORD", pass);
            pValue.Add("EMAIL", email);
            pValue.Add("PHONE", sdt);
            pValue.Add("ADDRESS", diachi);

            conn.InsertTable("TAIKHOAN", pValue);

            Response.Write("<script>alert('Đăng ký thành công !')</script>");
        }
    }
}