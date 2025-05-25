using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
    public partial class GioHang : Page
    {        
        long tongtienDB = 0;
        DataTable shop;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GioHang"] != null)
            {
                double tong=0;

                string query = "select MaSP, Hinh, TenSP, GiaTien, ThanhPhan from SANPHAM where ";

                Dictionary<string, int> giohang = (Dictionary<string, int>)Session["GioHang"];
                foreach (KeyValuePair<string, int> value in giohang)
                {
                    query += "MaSP='" + value.Key + "' or ";
                }
                query = query.Trim().Substring(0, query.Length - 3);
               
                shop = new EnforceModel().ExecuteSelect(query);
                shop.Columns.Add("Soluong");
                shop.Columns[shop.Columns.Count - 1].ColumnName = "SoLuong";
                shop.Columns.Add("Thanhtien");
                shop.Columns[shop.Columns.Count - 1].ColumnName = "ThanhTien";

                for (int i = 0; i < giohang.Count; i++)
                {
                    shop.Rows[i]["SoLuong"] = giohang.ElementAt(i).Value.ToString().Trim();
                    shop.Rows[i]["ThanhTien"] = string.Format("{0:0,0}",Convert.ToInt32(shop.Rows[i]["GiaTien"]) * Convert.ToInt32(shop.Rows[i]["SoLuong"]));
                    tong += double.Parse(shop.Rows[i]["ThanhTien"].ToString());

                }
                tongtienDB = (long)tong;
                string tong1 = string.Format("{0:0,0 đ}",tong);
                lblTong.Text = tong1.Trim();
                GridView1.DataSource = shop;
                GridView1.DataBind();
                //Visible
                btnThanhToan.Visible = true;
                lblTitle.Visible = true;
                hplMuaTiep.Visible = true;

                lblTrangThai.Visible = false;
                hplMua.Visible = false;               
            }
            else
            {
                lblTrangThai.Text = "Giỏ hàng của bạn đang trống!";
                btnThanhToan.Visible = false;
                lblTitle.Visible = false;
                hplMuaTiep.Visible = false;
            }
        }

        

        

        protected void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (Session["AccountLogin"] == null)
            {
                Response.Write("<div class='alert alert-danger' role='alert'>Bạn chưa đăng nhập! </div>");
            }
            else
            {
                DataTable user = (DataTable)Session["AccountLogin"];
                // lưu vào hóa đơn
                Dictionary<string, object> pValue = new Dictionary<string, object>();
                pValue.Add("USERNAME", user.Rows[0]["USERNAME"].ToString().Trim());
                pValue.Add("TongTien", tongtienDB);
                pValue.Add("Ngay", DateTime.Now);
                new QueryModel().InsertTable("HOADON", pValue);
                // lưu vào chi tiết hóa đơn
                foreach (DataRow dr in shop.Rows)
                {
                    Dictionary<string, object> childHD = new Dictionary<string, object>();
                    childHD.Add("USERNAME", user.Rows[0]["USERNAME"].ToString().Trim());
                    childHD.Add("MaSP", dr["MaSP"].ToString().Trim());
                    childHD.Add("SoLuong", dr["SoLuong"]);
                    childHD.Add("GiaTien", dr["GiaTien"]);
                    childHD.Add("TrangThai", false);

                    new QueryModel().InsertTable("CTHOADON", childHD);
                }
                // Làm rỗng session
                Session["GioHang"] = null;
                Response.Write("<div class='alert alert-success' role='alert'>Bạn đã thanh toán thành công! </div>");
                Response.Redirect(Page.Request.Url.ToString(), true);
                
            }
        }

        protected void btnXoaGH_Click(object sender, EventArgs e)
        {
            HtmlButton btn = (HtmlButton)sender;
            GridViewRow gridRow = (GridViewRow)btn.NamingContainer;
            int rowIndex = gridRow.RowIndex;
            shop.Rows.RemoveAt(rowIndex);
            Dictionary<string, int> giohang = (Dictionary<string, int>)Session["GioHang"];
            giohang.Remove(giohang.ElementAt(rowIndex).Key);
            if (giohang.Count <= 0)
            {
                Session["GioHang"] = null;
            }
            else
                Session["GioHang"] = giohang;
            Response.Redirect(Request.Url.ToString());
        }
    }
}