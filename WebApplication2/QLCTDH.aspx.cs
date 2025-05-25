using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class QLCTDH : System.Web.UI.Page
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
            lk.sql_gridview("select USERNAME, MaSP, SoLuong, GiaTien, (CASE TrangThai WHEN 'False' THEN N'Chưa thanh toán' ELSE N'Đã thanh toán' END) AS  TrangThai from CTHOADON", gdvSP);
        }
    }
}