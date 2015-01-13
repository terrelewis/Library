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
    public partial class Return : Form
    {
        DateTime dt;
        int year;
                    int month;
                    int day;
                    int fine;
        public Return()
        {
            InitializeComponent();
            fillCombo1();
            fillCombo2();

        }

        void fillCombo1()
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
                    string scopies = myReader.GetString("no_of_copies");
                    int i = int.Parse(scopies);
                    
                        comboBox1.Items.Add(sname);

                }




                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void fillCombo2()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "select * from library.borrower_details ";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                // MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    string sname = myReader.GetString("card_no");
                    comboBox2.Items.Add(sname);

                }




                myConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      public  void retdate()
        {

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "select * from library.borrowed_books where book_id='" + (string)comboBox1.SelectedItem + "'and card_no="+(string)comboBox2.SelectedItem+";";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                //// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = cmdDataBase.ExecuteReader();
                string sno;

               while (myReader.Read())
                {
                     sno = myReader.GetString("due_date");
                     dt = Convert.ToDateTime(sno);
                     year = dt.Year;
                     month = dt.Month;
                     day = dt.Day;
                     MessageBox.Show(year.ToString() + month.ToString() + day.ToString());

                }

                

                myConn.Close();

                DateTime dt1 = System.DateTime.Now;
                int year1 = dt1.Year;
                int month1 = dt1.Month;
                int day1 = dt1.Day;
                int ret = year * 10000 + month * 100+ day;
                int ret1 = year1 * 10000 + month1 * 100 + day1;
                if (ret1 > ret)
                {
                    fine = (ret1-ret) * 10;
                   // MessageBox.Show("You have been fined " + fine.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }





        }

        void retfine()
        {

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "select * from library.borrower_details where card_no='" + (string)comboBox2.SelectedItem + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                //// MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;

                myConn.Open();

                myReader = cmdDataBase.ExecuteReader();
                string fine1;
                int fineold;
                while (myReader.Read())
                {
                    fine1 = myReader.GetString("fine");
                     fineold= int.Parse(fine1);
                     fine += fineold;
                }

                

                myConn.Close();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        
        
        }

        void finecal()
        {

            retfine();
            try
            {

                string myConnection = "datasource=localhost;port=3306;username=root;password=dbms";
                string query = "update library.borrower_details set fine=" + fine.ToString() + " where card_no='" + (string)comboBox2.SelectedItem + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;


                myConn.Open();
                myReader = cmdDataBase.ExecuteReader();



                MessageBox.Show("Returned");

                while (myReader.Read())
                { }



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
               
                string query = "delete from library.borrowed_books where book_id='"+(string)comboBox1.SelectedItem+"' and card_no='"+(string)comboBox2.SelectedItem+"';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                // MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand cmdDataBase = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;

                myConn.Open();
                //  DataSet ds = new DataSet();
                myReader = cmdDataBase.ExecuteReader();
                myConn.Close();
                retdate();
                finecal();


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
