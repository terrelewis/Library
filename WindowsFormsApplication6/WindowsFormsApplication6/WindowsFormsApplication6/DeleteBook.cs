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
    public partial class DeleteBook : Form
    {
        public DeleteBook()
        {
            InitializeComponent();
            fillCombo();
        }

        void fillCombo()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "select * from library.book_database ";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                // MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sname = myReader.GetString("book_id");
                    comboBox1.Items.Add(sname);

                }




                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "delete from library.book_database where book_id='"+(string)comboBox1.SelectedItem+"';";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Deleted");
                while (myReader.Read())
                {

                }




                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageBookDetails f = new ManageBookDetails();
            f.Visible = true;
            this.Close();
        }
    }
}
