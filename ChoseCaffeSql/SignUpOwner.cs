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
    public partial class SignUpOwner : MyForm
    {
        public SignUpOwner()
        {
            InitializeComponent();
        }

        private void SignUpOwner_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> content = new Dictionary<string, string>();
            content.Add("name", "'" + textBox1.Text + "'");
            if (content["name"] == "''")
            {
                MessageBox.Show(text: "Enter name");
                return;
            }
            content.Add("surname", $"'{textBox2.Text}'");
            if (content["surname"] == "''")
            {
                MessageBox.Show("Enter surName");
                return;
            }
            content.Add("login", $"'{textBox3.Text}'");
            if (content["login"] == "''")
            {
                MessageBox.Show("Enter login");
                return;
            }
            content.Add("password", $"'{textBox4.Text}'");
            if (content["password"].Length < 8 || content["password"].Length > 20)
            {
                MessageBox.Show("password should have between 8 and 20 elements");
                return;
            }
            if ("'" + textBox5.Text + "'" != content["password"])
            {
                MessageBox.Show("The passwords isn't the same");
                return;
            }
            string resId = AddDB(tableNames.owner, content);
            if(resId != null)
            {
                MessageBox.Show("Thank youre registered \nyour id is " + resId);
                this.Close();
            }
        }
    }
}
