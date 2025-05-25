using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace System
{
    public class LINK
    {
        //string strConn = WebConfigurationManager.ConnectionStrings["QLBANGIAYConnectionString"].ConnectionString;
        string strConn = "Data Source=.;Initial Catalog=QLBANTRASUA;Integrated Security=True";
        private EnforceModel Enforce = new EnforceModel();
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            return conn;
        }
        public void sql_gridview(string sql,GridView gv)
        {
            DataTable dt = Enforce.ExecuteSelect(sql);            
            gv.DataSource = dt;
            gv.DataBind();
        }       
        public void sql_drop(string sql,DropDownList ddl,string text,string value)
        {
            DataTable dt = Enforce.ExecuteSelect(sql);
            ddl.DataSource = dt;
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }
        public SqlCommand sql_parameter(string sql,SqlParameter[] parameter) {

            SqlCommand cmd = new SqlCommand(sql, Connect());
            cmd.Parameters.AddRange(parameter);
            return cmd;
        }
        public DataTable DocTable(string MAHS,string sql)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(sql, Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}