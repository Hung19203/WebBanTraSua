using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace WebApplication2
{
    public partial class QLSP : Page
    {
        LINK lk = new LINK();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDrop();
                LoadData();
            }
        }
        void FillDrop()
        {
            string sql = "select * from MAHANGSANPHAM";

            lk.sql_drop(sql, ddlHangSX, "TENHANG", "MAHANG");

        }
        void LoadData()
        {
            lk.sql_gridview("select * from SANPHAM", gdvSP);

            FillDrop();
        }


        protected void btnThemsp_Click1(object sender, EventArgs e)
        {
            string sTenfile = fulUpHinh.FileName;
            fulUpHinh.SaveAs(MapPath("~/img/" + sTenfile));
            string sql = "Insert into SANPHAM (MaSP,TenSP,GiaTien,ThanhPhan,Hinh,MaHang) values (@MaSP,@TenSP,@GiaTien,@Tphan,@Hinh,@MaHang)";

            List<SqlParameter> list = new List<SqlParameter>()
            {
                new SqlParameter("@MaSP", txtMaSP.Text.Trim()),
                new SqlParameter("@TenSP", txtTenSP.Text.Trim()),
                new SqlParameter("@GiaTien", txtGiaTien.Text.Trim()),
                new SqlParameter("@Tphan", txtThanhPhan.Text.Trim()),
                new SqlParameter("@Hinh", fulUpHinh.FileName.ToString()),
                new SqlParameter("@MaHang", ddlHangSX.SelectedValue)
            };

            lk.sql_parameter(sql, list.ToArray()).ExecuteNonQuery();
            LoadData();
        }

        protected void btnLuusp_Click(object sender, EventArgs e)
        {
            string id = txtMaSP.Text.ToString().Trim();
            string img = ImgName.Text;
            string sql1 = "update SANPHAM set TenSP=@TenSP,GiaTien=@GiaTien,ThanhPhan=@Tphan,Hinh=@Hinh,MaHang=@MaHang where MaSP=@MaSP";
            if (fulUpHinh.HasFile)
            {
                string pic = Server.MapPath("img/" + img);

                FileInfo file = new FileInfo(pic);
                if (file.Exists)
                    file.Delete();
                string sTenfile = fulUpHinh.FileName;
                fulUpHinh.SaveAs(MapPath("img/" + sTenfile));
                img = sTenfile;
            }
            List<SqlParameter> list = new List<SqlParameter>()
                    {
                        new SqlParameter("@MaSP", id),
                        new SqlParameter("@TenSP", txtTenSP.Text.Trim()),
                        new SqlParameter("@GiaTien", txtGiaTien.Text.Trim()),
                        new SqlParameter("@Tphan", txtThanhPhan.Text.Trim()),
                        new SqlParameter("@Hinh", img),
                        new SqlParameter("@MaHang", ddlHangSX.SelectedValue)
                    };

            lk.sql_parameter(sql1, list.ToArray()).ExecuteNonQuery();
            LoadData();
            gdvSP.EditIndex = -1;
        }

        protected void gdvSP_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName;
            string id = e.CommandArgument.ToString();
            if (command == "xoa")
            {
                string sql2 = "select * from SANPHAM where MaSP='" + id + "'";
                DataTable dt = lk.DocTable(id, sql2);
                string hinh = dt.Rows[0][5].ToString();

                string pic = Server.MapPath("~/img/" + hinh);
                FileInfo file = new FileInfo(pic);
                if (file.Exists)
                    file.Delete();
                string sql = "delete SANPHAM where MaSP=@MaSP";
                List<SqlParameter> list = new List<SqlParameter>()
                {
                    new SqlParameter("@MaSP", id)
                };
                lk.sql_parameter(sql, list.ToArray()).ExecuteNonQuery();
                LoadData();
            }
        }        
    }
}