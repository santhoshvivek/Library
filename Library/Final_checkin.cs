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

namespace Library
{
    public partial class Final_checkin : Form
    {
        static String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
        MySqlConnection con = new MySqlConnection(conString);
        
        checkin a = new checkin();

        public Final_checkin(string a, string b, string c, string d)
        {
            InitializeComponent();
            this.bookid.Text = a;
            this.title.Text = b;
            this.cardno.Text = c;
            this.branchid.Text = d;
        }

        //public Final_checkin()
        //{
         //   InitializeComponent();
            
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string due_check = "select datediff(Curdate(),due_date) from book_loans where book_id = '" + bookid.Text + "' and branch_id ='" + branchid.Text + "' and card_no ='" + cardno.Text + "';";
            MySqlCommand cmd1 = new MySqlCommand(due_check, con);
            int date_diff = Convert.ToInt32(cmd1.ExecuteScalar());
            String query = "delete from book_loans where book_id='"+bookid.Text+"' and branch_id='"+branchid.Text+"' and card_no ='"+cardno.Text+"';";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            if (date_diff > 0)
            {
                string fine_insert = "Insert into fine values('" + cardno.Text + "','" + bookid.Text + "'," + branchid.Text + "," + (date_diff * .10) + ");";
                MySqlCommand cmd2 = new MySqlCommand(fine_insert, con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Book has been checked in. Pls pay the fine fee of $" + (date_diff * .10) + " as you have turned it in late. You have been charged 10c per day ");

            }
            else
            {
                MessageBox.Show("Successfully Check In");
            }
            string history = "update history set cin_date = curdate() where book_id = '" + bookid.Text + "' and branch_id = '" + branchid.Text + "' and card_no = '" + cardno.Text + "';";
            MySqlCommand cmd3 = new MySqlCommand(history, con);
            cmd3.ExecuteNonQuery();
            con.Close();
            this.Close();

        }
    }
}

/*
*/