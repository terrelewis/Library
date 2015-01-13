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
    public partial class ManageBookDetails : Form
    {
        public ManageBookDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBook f = new AddBook();
            f.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBook f = new UpdateBook();
            f.Visible = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteBook f = new DeleteBook();
            f.Visible = true;
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewBookDetails f = new ViewBookDetails();
            f.Visible = true;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewIssued f = new ViewIssued();
            f.Visible = true;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Return f=new Return();
            f.Visible = true;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainMenu f = new MainMenu();
            f.Visible = true;
            this.Close();
        }
    }
}
