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
    public partial class Availability : Form
    {
        public Availability()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Home a = new Home();
            a.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            string w = row.Cells[0].Value.ToString();
            string x = row.Cells[1].Value.ToString();
            string y = row.Cells[2].Value.ToString();
            checkout a = new checkout(x,w,y);
            a.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (title.Text == "" && book_id.Text == "" && author.Text == "")
            {
                MessageBox.Show("enter some search criteria !!! ");
            }
            else
            {
                String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
                MySqlConnection con = new MySqlConnection(conString);
                MySqlDataReader dr;
                con.Open();
                String query = "SELECT LIBRARY_BRANCH.Branch_id,a.book_id,a.title,BOOK_COPIES.No_of_copies as total ,( BOOK_COPIES.No_of_copies- COUNT(BOOK_LOANS.Book_id)) AS Available FROM (((Book as a INNER JOIN BOOK_COPIES ON a.Book_id = BOOK_COPIES.Book_id) INNER JOIN LIBRARY_BRANCH  ON BOOK_COPIES.Branch_id = LIBRARY_BRANCH.Branch_id) LEFT OUTER JOIN BOOK_LOANS  ON  BOOK_LOANS.Book_id=a.Book_id AND BOOK_LOANS.Branch_id = BOOK_COPIES.Branch_id) Where a.book_id in (select book_id from book_authors where author_name like '%" + author.Text + "%') GROUP BY book_copies.Branch_id,book_loans.book_id,a.title Having (a.book_id like '%" + book_id.Text + "%'and a.title like '%" + title.Text + "%') order by LIBRARY_BRANCH.Branch_id;";
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

