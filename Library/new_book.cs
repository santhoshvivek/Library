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
    public partial class new_book : Form
    {
        public new_book(string a, string b, string c, string d)
        {
            InitializeComponent();
            book.Text = a;
            title.Text = b;
            branch.Text = c;
            copy.Text = d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
           
            string branch_check = "select branch_id from library_branch where branch_id='" + branch.Text + "';";
            MySqlCommand cmd = new MySqlCommand(branch_check, con);
            int bran = Convert.ToInt16(cmd.ExecuteScalar());
            if (bran != 1)
            {
                MessageBox.Show("Branch Doesnot exist");
            }
            else
            {
                string insert_book = "Insert into book values('"+book.Text+"','"+title.Text+"');";
                MySqlCommand cmd2 = new MySqlCommand(insert_book, con);
                cmd2.ExecuteNonQuery();
                string insert_bookc = "Insert into book_copies values('" + book.Text + "','" + branch.Text + "','"+copy.Text+"');";
                MySqlCommand cmd3 = new MySqlCommand(insert_bookc, con);
                cmd3.ExecuteNonQuery();
            }
            con.Close();
            this.Close();
        }
    }
}
