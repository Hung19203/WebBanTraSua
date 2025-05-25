using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace System
{
    public class QueryModel
    {
        private EnforceModel Enforce;
        public QueryModel()
        {
            Enforce = new EnforceModel();
        }
        public QueryModel(string connectionStrings)
        {
            Enforce = new EnforceModel(connectionStrings);
        }
        /* Select Query */
        public DataTable SelectTable(string tableName)  // Select all column on table
        {
            string queryStr = "select * from " + tableName;
            return Enforce.ExecuteSelect(queryStr);
        }
        public DataTable SelectTable(string tableName, string columnName, string value, string dateformatString = null) // Select all column on table with 1 condition
        {
            string queryStr = DateFormatString(dateformatString);
            queryStr += "select * from " + tableName + " where " + columnName + "= N'"+value+"'";
            Dictionary<string, object> param = new Dictionary<string, object>();
            //param.Add("@KEY", value);
            return Enforce.ExecuteSelect(queryStr, param);
        }

        public DataTable SelectTableSearch(string tableName, string columnName, string value, string dateformatString = null) // Select all column on table with 1 condition
        {
            string queryStr = DateFormatString(dateformatString);
            queryStr += "select * from " + tableName + " where " + columnName + " LIKE '%"+value+"%'";
            return Enforce.ExecuteSelect(queryStr);
        }     
        public DataTable SelectTable(string tableName, Dictionary<string, object> pKeyValue, string dateformatStrings = null)
        {
            string queryStr = DateFormatString(dateformatStrings);
            queryStr += "select * from " + tableName + " where ";
            // Create queryStrings
            string condCollect = "";
            foreach (KeyValuePair<string, object> value in pKeyValue)
                condCollect += value.Key.Trim().Substring(0, 1).Equals("@") ? splitString(value.Key.Trim(), 1, 1) + "=" + value.Key.Trim() + " AND " : value.Key.Trim() + "=@" + value.Key.Trim() + " AND ";
            queryStr += splitString(condCollect, 0, 4);
            // Create parameters
            Dictionary<string, object> pCondition = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> value in pKeyValue)
                pCondition.Add(value.Key.Trim().Substring(0, 1).Equals("@") ? value.Key.Trim() : "@" + value.Key.Trim(), value.Value);
            // Execute
            return Enforce.ExecuteSelect(queryStr, pCondition);
        }              
        /* Insert Query */       
        public void InsertTable(string tableName, Dictionary<string, object> pKeyValue, string dateformatString = null)   // Insert 1 row on table
        {
            // Query String Total
            string queryStr = DateFormatString(dateformatString);
            queryStr += "insert into " + tableName + "(";
            // Handle keys string
            string keyCollect = "";
            foreach(KeyValuePair<string, object> value in pKeyValue)
                keyCollect += (value.Key.Substring(0, 1).Equals("@") ? splitString(value.Key, 1, 1) : value.Key) + ", ";
            queryStr += splitString(keyCollect, 0, 1) + ") values(";
            // Handle parameters string
            string paramCollect = "";
            foreach (KeyValuePair<string, object> value in pKeyValue)
                paramCollect += (value.Key.Substring(0, 1).Equals("@") ? value.Key : "@" + value.Key) + ", ";
            queryStr += splitString(paramCollect, 0, 1) + ")";
            // Add parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> value in pKeyValue)
                parameters.Add(value.Key.Substring(0, 1).Equals("@") ? value.Key : "@" + value.Key, value.Value);
            // Execute
            Enforce.ExecuteUpdate(queryStr, parameters);
        }   
        /* Handing methods */
        public string splitString(string stringSplit, int numberDelFirst = 0, int numberDelLast = 0)   // split character superfluous
        {
            string ans = stringSplit.Trim();
            ans = ans.Substring(numberDelFirst, ans.Length - numberDelLast);
            return ans;
        }
        public string DateFormatString(string dateformatString)   // return string: set dateformat <format type>
        {
            if (dateformatString != null)
                return "set dateformat " + dateformatString + " ";
            return "";
        }
    }
}