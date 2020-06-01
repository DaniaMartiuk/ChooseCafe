using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChoseCaffeSql
{
    class SQLDataBase
    {
        string connectionString;
        SqlConnection connection;
        bool isConnectionOpen = false;
        public bool IsConnectionOpen => isConnectionOpen;
        public SqlConnection Connection => connection;
        public string ConectionString => connectionString;
        public SQLDataBase(string serverName, string DBName)
        {
            connectionString = @"Data Source="+serverName+ ";Initial Catalog="+DBName+";Integrated Security=True";
            connection = new SqlConnection(ConectionString);
            ConectToDB();
        }
        private void ConectToDB()
        {
            try
            {
                connection.Open();
                isConnectionOpen = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
        }
        public void ConnectionOpen()
        {
            if (isConnectionOpen)
                return;
            ConectToDB();
        }

        public void Close()
        {
            connection.Close();
            isConnectionOpen = false;
        }
        /// <summary>
        /// insert into tablename (content.columns) values (content.values)
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Insert(string tableName, Dictionary<string,string> content)
        {
            //"insert into tablename (name, age) otput values('Maria', 19)"
            // content = {
            //              "name": "'MAria'",
            //              "age": "19"
            //           }
            try
            {
                string keys = "", vals = "";
                foreach (string key in content.Keys)
                {
                    keys += key + ", ";
                    vals += content[key] + ", ";
                }
                string sqlQuery = "insert into " + tableName + " (" + keys.Substring(0, keys.Length - 2) +
                                  ") values (" + vals.Substring(0, vals.Length - 2) + ");";
                sqlQuery += "\nSELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader reader = command.ExecuteReader();
                string id="";
                while (reader.Read())
                {

                   id=   Convert.ToString(reader.GetValue(0));
                }
                reader.Close();
                return id;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
