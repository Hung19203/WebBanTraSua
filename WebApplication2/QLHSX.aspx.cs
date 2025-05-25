using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class QLHSX : System.Web.UI.Page
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
            lk.sql_gridview("select * from MAHANGSANPHAM", gdvSP);
        }

        protected void btnThemHSX_Click(object sender, EventArgs e)
        {
            string sql = "Insert into MAHANGSANPHAM (MaHang,TenHang) values (@MaHang,@TenHang)";

            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@MaHang", txtMaHang.Text.Trim()),
                new SqlParameter("@TenHang", txtTenHang.Text.Trim())
                
            };
            lk.sql_parameter(sql, list.ToArray()).ExecuteNonQuery();
            LoadData();
        }

        protected void btnLuuHSX_Click(object sender, EventArgs e)
        {
            string tex = txtMaHang.Text.ToString().Trim();
            string sql2 = "update MAHANGSANPHAM set TenHang=@TenHang where MaHang=@MaHang";
            List<SqlParameter> list = new List<SqlParameter>()
                    {
                        new SqlParameter("@MaHang", tex),
                        new SqlParameter("@TenHang", txtTenHang.Text.Trim())
                    };
            lk.sql_parameter(sql2, list.ToArray()).ExecuteNonQuery();
            LoadData();

        }

        protected void gdvHangSX_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            string ma = e.CommandArgument.ToString();
            if (command == "xoa")
            {

                string sql2 = "select * from MAHANGSANPHAM";
                DataTable dt = lk.DocTable(ma, sql2);
                string sql = "delete MAHANGSANPHAM where MaHang=@MaHang";
                List<SqlParameter> list = new List<SqlParameter>()
                {
                    new SqlParameter("@MaHang", ma)
                
                };
                lk.sql_parameter(sql, list.ToArray()).ExecuteNonQuery();
                LoadData();
            }
        }
    }
}