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
using MySql.Data.Common;

namespace Library
{
   // private String server;
    //private String database;
    //private String uid;
    //private String password;
    public partial class Borrower : Form
    {
        string cno;
        
            static String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
            MySqlConnection con = new MySqlConnection(conString);
            MySqlDataReader dr;

        public Borrower()
        {

            InitializeComponent();
            
            
        }

        private void Register_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                String query = "Select card_no from borrower where fname ='" + fname.Text + "' and lname = '" + lname.Text + "' and address = '"+address.Text+"' ;";
                MySqlCommand cmd = new MySqlCommand(query, con);
                String check = Convert.ToString(cmd.ExecuteScalar());
                if (check != null)
                {
                    MessageBox.Show("U are already a member. Pls retrieve ur card number");
                }
                else
                {

                    String query1 = "Select (max(card_no)+1) from borrower;";
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);
                    cno = Convert.ToString(cmd1.ExecuteScalar());
                    String query2 = "INSERT INTO borrower VALUES('" + cno + "','" + fname.Text + "', '" + lname.Text + "', '" + address.Text + "','" + pno.Text + "');";
                    MySqlCommand cmd2 = new MySqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Successfully Inserted !");
                
                }
                
                con.Close();
            }
            catch (MySqlException a)
            {
                MessageBox.Show(Convert.ToString(a));
            }




        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void card_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pno_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fname.Text == "" && lname.Text == "" && address.Text == "" && pno.Text == "")
            {
                MessageBox.Show("Enter some criteria to search");
            }
            else
            {

                con.Open();
                String query = "Select * from borrower where fname like '%" + fname.Text + "%' and lname like '%" + lname.Text + "%' and address like '%" + address.Text + "%' and phone like '%" + pno.Text + "%';";
                MySqlCommand cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        
               
               
    }
}
