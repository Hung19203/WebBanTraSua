using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace BanGiay.Handle
{
    public partial class ActionMethod : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static bool isValidUserName(string username, string password)
        {
            QueryModel data = new QueryModel();
            Dictionary<String, Object> pValue = new Dictionary<string, object>();
            pValue.Add("USERNAME", username);
            pValue.Add("PASSWORD", password);
            DataTable dt = data.SelectTable("TAIKHOAN", pValue);
            return dt.Rows.Count > 0;
        }
        [WebMethod]
        public static bool isExsistUsername(string username)
        {
            QueryModel data = new QueryModel();
            DataTable dt = data.SelectTable("TAIKHOAN", "USERNAME", username);
            if (dt.Rows.Count == 0)
                return true;
            else
                return false;
        }
    }
}