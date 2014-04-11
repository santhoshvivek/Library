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
    public partial class add_book : Form
    {
        public add_book()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string Str = copy.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (isNum)
            {

                string id_check = "select count(*) from book where book_id = '" + book.Text + "';";
                MySqlCommand cmd4 = new MySqlCommand(id_check, con);
                int id_r = Convert.ToInt16(cmd4.ExecuteScalar());
                string tit_check = "select count(*) from book where title = '" + title.Text + "';";
                MySqlCommand cmd5 = new MySqlCommand(tit_check, con);
                int tit_r = Convert.ToInt16(cmd5.ExecuteScalar());
                if ((id_r + tit_r) > 0)
                {

                    string idtitle = "select count(book_id) from book where book_id = '" + book.Text + "' and title = '" + title.Text + "';";
                    MySqlCommand cmd1 = new MySqlCommand(idtitle, con);
                    int exist = Convert.ToInt16(cmd1.ExecuteScalar());
                    if (exist != 1)
                    {
                        MessageBox.Show("Book_ID and Title dont match");
                    }
                    else
                    {
                        string branch_check = "select branch_id from library_branch where branch_id='" + branch.Text + "';";
                        MySqlCommand cmd2 = new MySqlCommand(branch_check, con);
                        int bran = Convert.ToInt16(cmd2.ExecuteScalar());
                        if (bran != 1)
                        {
                            MessageBox.Show("Branch Doesnot exist");
                        }
                        else
                        {
                            string add_copy = "Update book_copies set no_of_copies = no_of_copies + '" + copy.Text + "' where book_id = '" + book.Text + "' and branch_id = '" + branch.Text + "' ;";
                            MySqlCommand cmd3 = new MySqlCommand(add_copy, con);
                            cmd3.ExecuteNonQuery();

                        }
                    }
                }
                else
                {
                    new_book a = new new_book(book.Text, title.Text, branch.Text, copy.Text);
                    a.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid No. of copies. Pls enter a integer.");
            }

            con.Close();

        }

        private void add_book_Load(object sender, EventArgs e)
        {

        }
    }
}
