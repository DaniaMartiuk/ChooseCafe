using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ChoseCaffeSql
{
    class SQLDataBase
    {
        string connectionString;
        SqlConnection connection;
        bool isConnectionOpen = false;
        /// <summary>
        /// Get True if connection to DB is open
        /// </summary>
        public bool IsConnectionOpen => isConnectionOpen;
        /// <summary>
        /// 
        /// </summary>
        public SqlConnection Connection => connection;
        /// <summary>
        /// 
        /// </summary>
        public string ConectionString => connectionString;
        /// <summary>
        /// Create object for used DB
        /// </summary>
        /// <param name="serverName">Name of Your DB Server</param>
        /// <param name="DBName">Name of Your Table on Server</param>
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
        /// <summary>
        /// 
        /// </summary>
        public void ConnectionOpen()
        {
            if (isConnectionOpen)
                return;
            ConectToDB();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            connection.Close();
            isConnectionOpen = false;
        }
        /// <summary>
        /// Add values to DB 
        /// </summary>
        /// <param name="sqlQuery">your sql query (insert)</param>
        /// <returns>return id of added values</returns>
        public string Insert(string sqlQuery)
        {
            
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
        public int Delete(string sqlQuery)
        {
            /*
             delete from table_name 
             where id > 1
             */

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            int n = command.ExecuteNonQuery();
            return n;
        }
        public int Update(string sqlQuery)
        {
            /*Update from table name set
             name = 'new_name',
             ...
             where condition
             */
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            int n = command.ExecuteNonQuery();
            return n;
        }
        public DataSet Select(string command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(command, connection));
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            adapter.Dispose();
            return dataSet;
        }
    }
}     