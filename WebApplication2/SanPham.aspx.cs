using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SanPham : Page
    {
        QueryModel SQL = new QueryModel();
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (ClassSearch.storevalue != null)
            {           
                if (ClassSearch.storevalue.Rows.Count > 0)
                {
                    DataList1.DataSource = ClassSearch.storevalue;
                }
            }
            else
            { 
                DataList1.DataSource = SQL.SelectTable("SANPHAM");
            }
            DataList1.DataBind();
        }

        protected void filAll_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM");
            DataList1.DataBind();
        }
        protected void filAdidas_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM", "MaHang", "MH01");
            DataList1.DataBind();
        }
        protected void filJordan_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM", "MaHang", "MH02");
            DataList1.DataBind();
        }
        protected void filNike_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM", "MaHang", "MH03");
            DataList1.DataBind();
        }
        protected void filAcis_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM", "MaHang", "MH04");
            DataList1.DataBind();
        }
        protected void filPuma_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM", "MaHang", "MH05");
            DataList1.DataBind();
        }
        protected void filBitis_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM", "MaHang", "MH06");
            DataList1.DataBind();
        }
        protected void filConverse_Click(object sender, EventArgs e)
        {
            DataList1.DataSource = SQL.SelectTable("SANPHAM", "MaHang", "MH07");
            DataList1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DataListItem item = btn.NamingContainer as DataListItem;
            HiddenField hf = item.FindControl("HiddenField1") as HiddenField;
            if (Session["GioHang"] != null)
            {
                Dictionary<string, int> giohang = (Dictionary<string, int>)Session["GioHang"];
                bool isExsist = false;
                for (int i = 0; i < giohang.Count; i++)
                {
                    string indexID = giohang.ElementAt(i).Key;
                    int indexValue = (int)giohang.ElementAt(i).Value;
                    if (indexID.Equals(hf.Value))
                    {
                        giohang[indexID] += 1;
                        isExsist = true;
                    }
                }
                if (!isExsist)
                {
                    giohang.Add(hf.Value, 1);
                }
                isExsist = false;
            }
            else
            {
                Dictionary<string, int> giohang = new Dictionary<string, int>();
                giohang.Add(hf.Value, 1);
                Session["GioHang"] = giohang;
            }
            Response.Redirect(Page.Request.Url.ToString(), true);
        }      
    }
}