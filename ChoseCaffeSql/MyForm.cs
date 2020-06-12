using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChoseCaffeSql
{
    public struct TableNames
    {
        public string location, kitchen, owner, product, visitor, bankcard, restaurant, food, recipe, order, list_food;
    }
    public partial class MyForm : Form
    {
        SQLDataBase db;
        public Dictionary<string, string> NamesTables = new Dictionary<string, string>();
        public TableNames tableNames;
        public MyForm()
        {
            InitializeComponent();
            db = new SQLDataBase(@"DESKTOP-L38SM9N\SQLEXPRESS", "ChooseCafe");
            tableNames.location = "locations";
            tableNames.kitchen = "kitchens";
            tableNames.owner = "owners";
            tableNames.product = "products";
            tableNames.visitor = "visitors";
            tableNames.bankcard  = "bankcards";
            tableNames.restaurant = "restaurants";
            tableNames.food = "foods";
            tableNames.recipe = "recipes";
            tableNames.order = "orders";
            tableNames.list_food = "list_foods";

        }
        /// <summary>
        /// Add values to Data Base
        /// </summary>
        /// <param name="tableName">Name of table in Data Base</param>
        /// <param name="content">Values for add in table (Key: name of Column, Value: Data in Column)</param>
        /// <returns>return id of added values or null if Error</returns>
        public virtual string AddDB(string tableName, Dictionary<string,string> content)
        {
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
                string id = db.Insert(sqlQuery);
                return id;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return null;
            }
         }
        public virtual DataSet SelectDB(string tableName,IEnumerable<string> columns = null,IEnumerable<string> conditions = null)
        {
            try
            {
                
                string command = "select ";
                if (columns != null)
                {
                    foreach (string col in columns)
                    {
                        command += col + ", ";
                    }
                    command = command.Substring(0, command.Length - 2);
                }else
                {
                    command += "* ";
                }
                command += $"from {tableName}";
                if(conditions != null)
                {
                    command += " where ";
                    foreach (string cond in conditions)
                    {
                        command += cond + ", ";
                    }
                    command = command.Substring(0, command.Length - 2);
                }
                command += ";";

                return db.Select(command);
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public virtual void CloseDB()
        {
            db.Close();
        }
        public virtual string DeleteDB(string tabl_name,IEnumerable<string> condition)
        {
            try
            {
                string command = $"delete from {tabl_name} where ";
                foreach (string cond in condition) {
                    command += $"{cond}, ";
                }
                command = command.Substring(0, command.Length - 2) + ";";
                return Convert.ToString(db.Delete(command));
                /*delete from table_name where condition*/
            }
            catch(Exception e) {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public virtual string UpdateDB(string tabl_name,Dictionary<string,string> set,IEnumerable<string> condition)
        {
            try
            {
                string command = $"update {tabl_name} set ";
                foreach(string col in set.Keys)
                {
                    command += $"{col} = {set[col]}, ";
                }
                command = command.Substring(0, command.Length - 2);
                command += "where ";
                foreach(string cond in condition)
                {
                    command += $"{cond}, ";
                }
                command = command.Substring(0, command.Length - 2) + ";";
                /*update tablename set column = newvalue,... where condition,...*/
                return Convert.ToString(db.Update(command));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error");
                return null;
            }
        }
        public virtual string StatusDB()
        {
            return "Connection "+db.Connection.State.ToString();
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            
        }

        public virtual void AddXandY(string x, string y)
        {
            MessageBox.Show(x + ", " + y);
        }
    }
}
