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
    public partial class loan_history : Form
    {
        public loan_history()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (card.Text == "" && book.Text == "" && title.Text == "" && branch.Text == "")
            {
                MessageBox.Show("Enter some search criteria");
            }
            else
            {
                String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
                MySqlConnection con = new MySqlConnection(conString);
                MySqlDataReader dr;
                con.Open();
                string query = "select * from history where book_id like '%" + book.Text + "%' and branch_id like '%" + branch.Text + "%' and card_no like '%" + card.Text + "%' and book_id in (select book_id from book where title like '%" + title.Text + "%')  ;";
                MySqlCommand cmd = new MySqlCommand(query, con);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
            }
        }
    }
}
/*\
 * select * from history where book_id like '%"+book.Text+"%' and branch_id like '%"+branch.Text+"%' and card_no like '%"+card.Text+"%' and book_id in (select book_id from book where title like '%"+title.Text+"%') and card_no in (select card_no from borrower where fname like '%"+name.Text+"%' or lname '%"+name.Text+"%');
*/