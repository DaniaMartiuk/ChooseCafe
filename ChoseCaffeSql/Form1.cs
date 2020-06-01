using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace ChoseCaffeSql
{
    public partial class Form1 : MyForm
    {
        public Form1()
        {
            InitializeComponent();
            Connection();
            
        }
            
        private void Insert()
        {

        }   
      



            // for your insetr request
        

        private void Connection()
        {
            MessageBox.Show(StatusDB());
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CloseDB();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UserOrOwner userOrOwner = new UserOrOwner();
            userOrOwner.Show();
        }
    }
}
