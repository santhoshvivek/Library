using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Borrower a = new Borrower();
            a.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Availability a = new Availability();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            checkin b = new checkin();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            checkout c = new checkout();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loan_history d = new loan_history();
            d.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            branch_add f = new branch_add();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            add_book a = new add_book();
            a.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Fine a = new Fine();
            a.Show();
        }


    }
}