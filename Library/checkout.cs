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
    public partial class checkout : Form
    {
        public checkout()
        {
            InitializeComponent();
        }
        public checkout(string a, string b, string c)
        {
            InitializeComponent();
            this.book.Text = a;
            this.branch.Text = b;
            this.title.Text = c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Home a = new Home();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string max_lend = "Select count(book_id) from book_loans where card_no='" + card.Text + "' group by card_no;";
            MySqlCommand cmd = new MySqlCommand(max_lend, con);
            int lend_check = Convert.ToInt16(cmd.ExecuteScalar());
            string book_avai = "select book_copies.no_of_copies-count(book_loans.card_no) from book_copies left outer join book_loans on book_copies.book_id = book_loans.book_id and book_copies.branch_id=book_loans.branch_id group by book_copies.book_id,book_copies.branch_id having (book_copies.book_id = '"+book.Text+"' and book_copies.branch_id = '"+branch.Text+"');";
            MySqlCommand cmd2 = new MySqlCommand(book_avai, con);
            int avai_check = Convert.ToInt16(cmd2.ExecuteScalar());
            string card_check = "select fname from borrower where card_no='"+card.Text+"';";
            MySqlCommand cmd3 = new MySqlCommand(card_check,con);

            if (cmd3.ExecuteScalar() == null)
            {
                MessageBox.Show("Invalid Card_no .");
            }

            else if (lend_check > 2)
            {
                MessageBox.Show("U already have three books in Your account . Pls return before Taking next book.");
            }
            else if (avai_check < 1)
            {
                MessageBox.Show(avai_check + " Book is not available at this branch");
            }
            else
            {
                string loan = "Insert into book_loans values ('" + book.Text + "','" + branch.Text + "','" + card.Text + "',curdate(),curdate()+14);";
                MySqlCommand cmd4 = new MySqlCommand(loan, con);
                cmd4.ExecuteNonQuery();
                string history = "Insert into history (card_no,book_id,branch_id,cout_date) values ('" + card.Text + "','" + book.Text + "','" + branch.Text + "',curdate());";
                MySqlCommand cmd5 = new MySqlCommand(history, con);
                cmd5.ExecuteNonQuery();
                MessageBox.Show("Book Loaned OUT");
            }
        }
    }
} 
