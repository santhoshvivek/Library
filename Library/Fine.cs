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
    public partial class Fine : Form
    {
        public Fine()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (card.Text == "" && bid.Text == "")
            {
                MessageBox.Show("Enter some criteria to search");
            }
            else
            {
                String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
                MySqlConnection con = new MySqlConnection(conString);
                MySqlDataReader dr;
                con.Open();
                string query = " Select fine.card_no,borrower.fname as first_name,borrower.lname as last_name,fine.book_id,fine.branch_id,fine.fine as fine_in_dollars from fine,borrower where fine.card_no like '%" + card.Text + "%' and fine.branch_id like '%" + bid.Text + "%' and fine.card_no = borrower.card_no;";
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
