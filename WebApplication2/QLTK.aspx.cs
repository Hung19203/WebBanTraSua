using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class QLTK : System.Web.UI.Page
    {
        LINK lk = new LINK();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            lk.sql_gridview("select * from TAIKHOAN", gdvSP);
        }
    }
}