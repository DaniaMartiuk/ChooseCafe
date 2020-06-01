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
    public partial class Map : MyForm
    {
        MyForm f;
        public Map(MyForm f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void panel1_MouseClick(object sender,MouseEventArgs e)
        {
            if (MessageBox.Show($"Location:\n{e.X},{e.Y}", "AddLocation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.AddXandY(e.X.ToString(), e.Y.ToString());
       
                this.Close();
            }
        }
    }
}
