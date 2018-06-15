using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Abhishek_vb_project2017MCA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {

            if (textBox1.Text == "abhi" && textBox2.Text == "abhi")
            {
                Form2 nextForm = new Form2();
                this.Hide();
                nextForm.ShowDialog();
                this.Close();

            }
            else
                MessageBox.Show("Invalid!!");
        }

        private void enterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }



    }
}
