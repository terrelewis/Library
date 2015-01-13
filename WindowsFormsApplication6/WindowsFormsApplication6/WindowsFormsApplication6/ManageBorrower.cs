using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class ManageBorrower : Form
    {
        public ManageBorrower()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBorrower f = new AddBorrower();
            f.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBorrower f = new UpdateBorrower();
            f.Visible = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteBorrower f = new DeleteBorrower();
            f.Visible = true;
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewBorrower f = new ViewBorrower();
            f.Visible = true;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainMenu f = new MainMenu();
            f.Visible = true;
            this.Close();
        }
    }
}
