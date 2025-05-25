using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class DataManager : System.Web.UI.Page
    {
        string BtnS = "BtnSa";
        string BtnX = "BtnXa";
        string n1 = "name";
        string gt2 = "gioitinh";
        string dc3 = "diachi";
        string sdt4 = "sdt";
        string l5 = "luong";
        private int section = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["section"] != null) { section = Int16.Parse(Request.QueryString["section"]); }
            C_Table(11, 8);
            Run_ShowT(section);         
        }

        public void C_Lable(SqlDataReader rdr)
        {
            int je = 1;         
            int count = 0;          
            while (rdr.Read())
            {
                count++;
            }
            for (int i = 0; i < count; i++)
            {
                if(i == 10 * je || je == 1)
                {
                    HyperLink hl = new HyperLink();
                    hl.Text = je.ToString();
                    hl.NavigateUrl = "DataManager.aspx?section = "+je.ToString();
                    Form.Controls.Add(hl);
                    je++;
                }
            }
        }

        public void C_Table(int row, int col)
        {
            Table1.Rows.Clear();
            for (int j = 0; j < row; j++)
            {
                TableRow tr = new TableRow();
                for (int i = 0; i < col; i++)
                {
                    TableCell tc = new TableCell();
                    tc.BorderColor = Color.Black;
                    tc.BorderStyle = BorderStyle.Solid;
                    tc.BorderWidth = 1;
                    tr.Cells.AddAt(i, tc);
                }
                Table1.Rows.AddAt(j, tr);
            }
            Table1.Rows[0].Cells[0].Text = n1;
            Table1.Rows[0].Cells[1].Text = gt2;
            Table1.Rows[0].Cells[2].Text = dc3;
            Table1.Rows[0].Cells[3].Text = sdt4;
            Table1.Rows[0].Cells[4].Text = l5;
        }

        public void show_Table(SqlDataReader rdr, int max, int section)
        {
            int je = 1;
            int i = 0;
            string[] madv = new string[max];
            string[] htdv = new string[max];
            string[] ngs = new string[max];
            string[] gt = new string[max];
            string[] dc = new string[max];
            string[] macd = new string[max];
            while (rdr.Read())
            {
                madv[i] = rdr["MADV"].ToString();
                htdv[i] = rdr["HOTENDV"].ToString();
                ngs[i] = rdr["NGAYSINH"].ToString();
                gt[i] = rdr["GIOITINH"].ToString();
                dc[i] = rdr["DIACHI"].ToString();
                macd[i] = rdr["MACD"].ToString();
                i++;               
            }
            for (int ia = (section - 1) * 10; ia < section * 10; ia++)
            {
                if (i > ia)
                {
                    Table1.Rows[je].Cells[0].Text = madv[je-1];
                    Table1.Rows[je].Cells[1].Text = htdv[je - 1];
                    Table1.Rows[je].Cells[2].Text = ngs[je - 1];
                    Table1.Rows[je].Cells[3].Text = gt[je - 1];
                    Table1.Rows[je].Cells[4].Text = dc[je - 1];
                    Table1.Rows[je].Cells[5].Text = macd[je - 1];
                    je++;
                }
            }

        }

        public void show_Table2(string nameid, string name, SqlDataReader rdr, int col, int section, int fundtion)
        {
            int je = 1;
            int i = 0;
            string[] madv = new string[100];
            while (rdr.Read())
            {
                madv[i] = rdr["MADV"].ToString();
                i++;
            }

            for (int ia = (section - 1) * 10; ia < section * 10; ia++)
            {
                if (i > ia)
                {
                    Button btn = new Button();
                    btn.ID = nameid + madv[ia];
                    btn.Text = name;
                    if (fundtion == 1) { btn.Click += new System.EventHandler(this.Edit); }
                    else { btn.Click += new System.EventHandler(this.Delete); }
                    Table1.Rows[je].Cells[col].Controls.Add(btn);
                    je++;
                }
            }

        }

        protected void Add_Value(object sender, EventArgs e)
        {
            string strCnn = "Data Source = localhost; Initial Catalog = QLDOANVIEN; User ID = sa; Password = 123";
            SqlConnection sqlCnn = new SqlConnection(strCnn);
            try
            {
                sqlCnn.Open();
                if (sqlCnn.State == ConnectionState.Open)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO DOANVIEN VALUE ('"+TextBox1.Text+ "','" + 
                        TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + 
                        TextBox6.Text+"')", sqlCnn);
                    command.ExecuteNonQuery();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string message = "Kết nối thất bại";
                    string title = "Thông báo";
                    Label7.Text = title + " " + message;
                }
                sqlCnn.Close();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Báo lỗi";
                Label7.Text = title + " " + message;
            }
        }



        private void Run_ShowT(int section)
        {
            string strCnn = "Data Source = localhost; Initial Catalog = QLDOANVIEN; User ID = sa; Password = 123";
            SqlConnection sqlCnn = new SqlConnection(strCnn);
            try
            {
                sqlCnn.Open();
                if (sqlCnn.State == ConnectionState.Open)
                {
                    SqlCommand command = new SqlCommand("select * from DOANVIEN", sqlCnn);
                    SqlDataReader reader = command.ExecuteReader();
                    C_Lable(reader);
                    reader.Close();
                    reader = command.ExecuteReader();
                    show_Table(reader, 100, section);
                    reader.Close();
                    reader = command.ExecuteReader();
                    show_Table2(BtnS,"Sửa", reader, 6, section, 1);
                    reader.Close();
                    reader = command.ExecuteReader();
                    show_Table2(BtnX, "Xóa", reader, 7, section, 2);
                    reader.Close();
                }
                else
                {
                    string message = "Kết nối thất bại";
                    string title = "Thông báo";
                    Label7.Text = title + " " + message;
                }
                sqlCnn.Close();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Báo lỗi";
                Label7.Text = title + " " + message;
            }
        }



        private void Delete(object sender, EventArgs e)
        {          
            Button btn = (Button)sender;
            string btnid = btn.ID;
            int found = btnid.IndexOf("V");
            int Tableid = Int16.Parse(btnid.Substring(found + 1));

            string strCnn = "Data Source = localhost; Initial Catalog = QLDOANVIEN; User ID = sa; Password = 123";
            SqlConnection sqlCnn = new SqlConnection(strCnn);
            try
            {
                sqlCnn.Open();
                if (sqlCnn.State == ConnectionState.Open)
                {
                    SqlCommand command = new SqlCommand("DELETE FROM DOANVIEN VALUE WHERE MADV LIKE '%" + Tableid + "'", sqlCnn);
                    command.ExecuteNonQuery();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string message = "Kết nối thất bại";
                    string title = "Thông báo";
                    Label7.Text = title + " " + message;
                }
                sqlCnn.Close();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Báo lỗi";
                Label7.Text = title + " " + message;
            }
        }

        private void Edit(object sender, EventArgs e)
        {          
            Button btn = (Button)sender;
            string btnid = btn.ID;
            int found = btnid.IndexOf("V");
            int Tableid = Int16.Parse(btnid.Substring(found + 1));

            string strCnn = "Data Source = localhost; Initial Catalog = QLDOANVIEN; User ID = sa; Password = 123";
            SqlConnection sqlCnn = new SqlConnection(strCnn);
            try
            {
                sqlCnn.Open();
                if (sqlCnn.State == ConnectionState.Open)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM DOANVIEN VALUE WHERE MADV LIKE '%" + Tableid + "'", sqlCnn);
                    SqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        TextBox1.Text = rdr["MADV"].ToString();
                        TextBox2.Text = rdr["HOTENDV"].ToString();
                        TextBox3.Text = rdr["NGAYSINH"].ToString();
                        TextBox4.Text = rdr["GIOITINH"].ToString();
                        TextBox5.Text = rdr["DIACHI"].ToString();
                        TextBox6.Text = rdr["MACD"].ToString();
                        TextBox1.Enabled = false;
                        Button1.Enabled = false;
                        Button2.Enabled = true;
                    }           
                }
                else
                {
                    string message = "Kết nối thất bại";
                    string title = "Thông báo";
                    Label7.Text = title + " " + message;
                }
                sqlCnn.Close();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Báo lỗi";
                Label7.Text = title + " " + message;
            }
        }

        private void Editing(object sender, EventArgs e)
        {          
            Button btn = (Button)sender;
            string btnid = btn.ID;
            int found = btnid.IndexOf("V");
            int Tableid = Int16.Parse(btnid.Substring(found + 1));

            string strCnn = "Data Source = localhost; Initial Catalog = QLDOANVIEN; User ID = sa; Password = 123";
            SqlConnection sqlCnn = new SqlConnection(strCnn);
            try
            {
                sqlCnn.Open();
                if (sqlCnn.State == ConnectionState.Open)
                {
                    SqlCommand command = new SqlCommand("UPDATE DOANVIEN SET HOTENDV='"+TextBox2.Text+ "' NGAYSINH='" + 
                        TextBox3.Text + "' GIOITINH='" + TextBox4.Text + "' DIACHI='" + TextBox5.Text + "' MACD='" + 
                        TextBox6.Text + "' WHERE MADV LIKE '%" + Tableid + "'", sqlCnn);
                        command.ExecuteNonQuery();                     
                        TextBox1.Enabled = true;
                        Button2.Enabled = false; 
                        Button1.Enabled = true;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    string message = "Kết nối thất bại";
                    string title = "Thông báo";
                    Label7.Text = title + " " + message;
                }
                sqlCnn.Close();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                string title = "Báo lỗi";
                Label7.Text = title + " " + message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Editing(sender, e);
        }
    }
}
    
