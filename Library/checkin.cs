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
    public partial class checkin : Form
    {

        static String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlDataReader dr;
        public checkin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();

            Home a = new Home();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text == "" && card.Text == "" && name.Text == "")
            {
                MessageBox.Show("Enter some seearch criteria");
            }
            else
            {
                con.Open();
                String query = "select  book_loans.book_id , book.title , book_loans.card_no , book_loans.branch_id from book_loans , book , borrower where book_loans.book_id like '%" + id.Text + "%' and book_loans.card_no like '%" + card.Text + "%' and (borrower.fname like '%" + name.Text + "%'  or borrower.lname like '%" + name.Text + "%') and book.book_id= book_loans.book_id and book_loans.card_no = borrower.card_no;";
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

        

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row= dataGridView1.Rows[index];
            string w = row.Cells[0].Value.ToString();
            string x = row.Cells[1].Value.ToString();
            string y = row.Cells[2].Value.ToString();
            string z = row.Cells[3].Value.ToString();
            Final_checkin a = new Final_checkin(w, x, y, z);
            a.Show();
        }
        
    }
}

/* select  book_loans.book_id , book.book_title , book_loans.card_no , book_loans.branch_id 
 * from book_loans , book , borrower
 * where book_loans.book_id = 'id.text'
 * or book_loans.card_no = ' card_no.text'
 * and (borrower.fname like '%"+name.text+"%'  or borrower.lname like '%"+name.text+"%')
 * and book.book_id= book_loans.book_id and book_loans.card_no = borrower.card_no;

*/