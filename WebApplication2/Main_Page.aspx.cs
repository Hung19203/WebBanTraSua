using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace WebApplication2
{
    public partial class Main_Page : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "select top 20 * from SANPHAM";
            DataTable dt = new EnforceModel().ExecuteSelect(query);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            query = "select * from SANPHAM";
            dt = new EnforceModel().ExecuteSelect(query);
            List<ItemCard> itemCards = new List<ItemCard>
            {
                new ItemCard(Label1, img1, Linkcard1),
                new ItemCard(Label2, img2, Linkcard2),
                new ItemCard(Label3, img3, Linkcard3),
                new ItemCard(Label4, img4, Linkcard4)
            };
            UpdateCard(dt, itemCards);
            itemCards.Clear();
        }
        

        public void UpdateCard(DataTable dt, List<ItemCard> items)
        {
            Random rd = new Random();
            foreach (ItemCard item in items)
            {
                int random = rd.Next(0, dt.Rows.Count - 1);
                item.Label.Text = dt.Rows[random]["TenSP"].ToString();
                item.Image.Src = "img/"+ dt.Rows[random]["Hinh"].ToString();
                item.Link.HRef = "ChiTietSanPham.aspx?masp=" + dt.Rows[random]["MaSP"].ToString();
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            Control btn = null;
            // Check if sender is Button or HtmlButton
            if (sender is Button)
                btn = sender as Button;
            else
                btn = (HtmlButton)sender;
            
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