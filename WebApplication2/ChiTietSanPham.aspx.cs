using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace WebApplication2
{
    public partial class ChiTietSanPham : Page
    {       
        string masp = "";
        protected void btnThemVaoGioHang_Click(object sender, EventArgs e)
        {
            if (Session["GioHang"] != null)
            {
                Dictionary<string, int> giohang = (Dictionary<string, int>)Session["GioHang"];
                bool isExsist = false;
                for (int i = 0; i < giohang.Count; i++)
                {
                    string indexID = giohang.ElementAt(i).Key;
                    int indexValue = (int)giohang.ElementAt(i).Value;
                    if (indexID.Equals(masp))
                    {
                        giohang[indexID] += 1;
                        isExsist = true;
                    }
                }
                if (!isExsist)
                {
                    giohang.Add(masp, 1);
                }
                isExsist = false;
            }
            else
            {
                Dictionary<string, int> giohang = new Dictionary<string, int>();
                giohang.Add(masp, 1);
                Session["GioHang"] = giohang;
            }
            Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string ma = Request.QueryString["masp"].ToString();
            masp = ma;
            string query = "SELECT * FROM SANPHAM where SANPHAM.MaSP='" + ma + "'";            
            DataTable dt = new EnforceModel().ExecuteSelect(query);                  
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}