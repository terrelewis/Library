using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication6
{
    public partial class ViewBorrower : Form
    {
        public ViewBorrower()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewBorrower_Load(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "select * from library.borrower_details ;";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                // MySqlDataReader myReader;

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbDataset = new DataTable();
                sda.Fill(dbDataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbDataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dbDataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageBorrower f = new ManageBorrower();
            f.Visible = true;
            this.Close();
        }
    }
}
