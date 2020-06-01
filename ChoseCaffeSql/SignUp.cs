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
    
    public partial class SignUp : MyForm

    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Map map = new Map(this);
            map.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        public override void AddXandY(string x, string y)
        {
            textBox6.Text = x;
            textBox7.Text = y;
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
            content.Add("sur_name", $"'{textBox2.Text}'");
            if (content["sur_name"] == "''")
            {
                MessageBox.Show("Enter surName");
                return;
            }
            content.Add("login",$"'{textBox3.Text}'");
            if (content["login"] == "''")
            {
                MessageBox.Show("Enter login");
                return;
            }
            content.Add("password",$"'{textBox4.Text}'");
            if (content["password"].Length < 8 || content["password"].Length > 20)
            {
                MessageBox.Show("password should have between 8 and 20 elements");
                return;
            }
            if ("'"+textBox5.Text+"'" != content["password"])
            {
                MessageBox.Show("The passwords isn't the same");
                return;
            }
            Dictionary<string, string> contentLocation = new Dictionary<string, string>();
            contentLocation.Add("x",textBox6.Text);
            contentLocation.Add("y", textBox7.Text);
            if (contentLocation["x"] == "")
            {
                MessageBox.Show("Select your location");
                return;
            }
            string idLoc = AddDB(NamesTables["location"], contentLocation);
            content.Add("location_id", idLoc);
            string res = AddDB(NamesTables["visitor"], content);
            MessageBox.Show("Thank you to Sign Up your id is " + res);
            this.Close();
        }
    }
}
