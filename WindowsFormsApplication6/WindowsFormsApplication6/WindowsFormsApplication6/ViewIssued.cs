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
    public partial class ViewIssued : Form
    {
        public ViewIssued()
        {
            InitializeComponent();
        }

        private void ViewIssued_Load(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "select * from library.borrowed_books ;";
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

        private void Back_Click(object sender, EventArgs e)
        {
            ManageBookDetails f = new ManageBookDetails();
            f.Visible = true;
            this.Close();
        }
    }
}
