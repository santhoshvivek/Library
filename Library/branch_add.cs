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
    public partial class branch_add : Form
    {
        static String conString = "User Id=root;password=sand1991;Persist Security Info=True;server=localhost;database=library";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlDataReader dr;
        
        public branch_add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ID.Text == "" && BName.Text == "" && Address.Text == "")
            {
                MessageBox.Show("Enter some criteria to search");
            }
            else
            {
                con.Open();
                string search = "select * from library_branch where branch_id like '%" + ID.Text + "%' and branch_name like '%" + BName.Text + "%' and address like '%" + Address.Text + "%';";
                MySqlCommand cmd1 = new MySqlCommand(search, con);
                dr = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string id_check = "Select count(*) from library_branch where branch_id = '" + ID.Text + "';";
            MySqlCommand cmd2 = new MySqlCommand(id_check, con);
            int check = Convert.ToInt16(cmd2.ExecuteScalar());
            if (check == 0)
            {
                string name_check = "select count(*) from library_branch where branch_name = '" + BName.Text + "';";
                MySqlCommand cmd3 = new MySqlCommand(name_check, con);
                int check_n = Convert.ToInt16(cmd3.ExecuteScalar());
                if (check_n == 0)
                {
                    string address_check = "select count(*) from library_branch where address = '" + Address.Text + "';";
                    MySqlCommand cmd4 = new MySqlCommand(address_check, con);
                    int check_a = Convert.ToInt16(cmd4.ExecuteScalar());
                    if (check_a == 0)
                    {
                        string insert = "Insert into library_branch values('" + ID.Text + "','" + BName.Text + "','" + Address.Text + "');";
                        MySqlCommand cmd5 = new MySqlCommand(insert, con);
                        cmd5.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("This address is already has a branch ");
                    }

                }
                else
                {
                    MessageBox.Show("This name is already used up .. .Pls choose an unique name for the branch ");
                }

            }
            else
            {
                MessageBox.Show("ID is used up pls enter a different integer value ");
            }

            con.Close();
        }
    }
}
