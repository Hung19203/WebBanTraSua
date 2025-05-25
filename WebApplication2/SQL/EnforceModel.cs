using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace System
{
    public class EnforceModel
    {
        private ConnectModel Connect;
        public EnforceModel()
        {
            Connect = new ConnectModel();
            Connect.Initializing();
        }
        public EnforceModel(string connectionStrings)
        {
            Connect = new ConnectModel();
            Connect.Initializing(connectionStrings);
        }
        public DataTable ExecuteSelect(string queryStrings, Dictionary<string, object> parameters = null)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = queryStrings;
                command.Connection = Connect.DatabaseConnection();
                if (parameters != null)
                    foreach (KeyValuePair<string, object> value in parameters)
                        command.Parameters.Add(new SqlParameter(value.Key, value.Value));
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    using (DataTable table = new DataTable())
                    {
                        table.Clear();
                        Connect.OpenConnection();
                        adapter.Fill(table);
                        Connect.CloseConnection();
                        return table;
                    }
                }
            }
        }
 
        public void ExecuteUpdate(string queryStrings, Dictionary<string, object> parameters = null)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = queryStrings;
                command.Connection = Connect.DatabaseConnection();
                foreach (KeyValuePair<string, object> value in parameters)
                    command.Parameters.Add(new SqlParameter(value.Key, value.Value));
                Connect.OpenConnection();
                command.ExecuteNonQuery();
                Connect.CloseConnection();
            }
        }
    }
}