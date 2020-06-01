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
    public partial class MyForm : Form
    {
        SQLDataBase db;
        public Dictionary<string, string> NamesTables = new Dictionary<string, string>();
      


        public MyForm()
        {
            InitializeComponent();
            db = new SQLDataBase(@"DESKTOP-L38SM9N\SQLEXPRESS", "ChooseCafe");
            NamesTables.Add("location", "locations");
            NamesTables.Add("kitchen", "kithcens");
            NamesTables.Add("owner", "owners");
            NamesTables.Add("product", "products");
            NamesTables.Add("visitor", "visitors");
            NamesTables.Add("bankcard", "bankcards");
            NamesTables.Add("restaurant", "restaurants");
            NamesTables.Add("food", "foods");
            NamesTables.Add("recipe", "recipes");
            NamesTables.Add("order", "orders");
            NamesTables.Add("list_food", "list_foods");

        }
        public virtual string AddDB(string tableName, Dictionary<string,string> content)
        {
            return db.Insert(tableName, content);
        }
        public virtual void CloseDB()
        {
            db.Close();
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
