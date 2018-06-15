using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Abhishek_vb_project2017MCA
{

    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        char gender;
         
        string name, blood, city, howof, address, weight, age, phone;

        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\sai\Documents\myDb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            reset();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (check() == 0)
            {
                initData();

                con.Open();

                SqlCommand cmd = new SqlCommand(@"INSERT INTO BloodRecords
                         (Name, [Phone number], Age, Gender, [Blood Group], Weight, City, [How Often you donate blood?], Address)
VALUES        ('" + name + "','" + phone + "','" + age + "','" + gender + "','" + blood + "','" + weight + "','" + city + "','" + howof + "','" + address + "')", con);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Done");
                    reset();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Phone number already exist!!");
                        textBox3.Focus();
                    }
                }

                con.Close();




            }
            else MessageBox.Show("Please fill all the fields!!");


        }


        public void initData()
        {

            name = textBox9.Text;

            phone = textBox3.Text;
            weight = textBox2.Text;
            age = textBox1.Text;


            gender = radioButton1.Checked ? 'M' : 'F';
            blood = comboBox1.Text;

            city = comboBox3.Text;
            howof = comboBox2.Text;
            address = richTextBox1.Text;

        }

        public int check()
        {
            int flag = 0;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.BackColor = Color.Red;
                flag = 1;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BackColor = Color.Red;
                flag = 1;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BackColor = Color.Red;
                flag = 1;
            }
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                textBox9.BackColor = Color.Red;
                flag = 1;
            }
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.BackColor = Color.Red;
                flag = 1;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {

                flag = 1;
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {

                flag = 1;
            }
            if (string.IsNullOrEmpty(comboBox3.Text))
            {

                flag = 1;
            }
            return flag;
        }

        public void reset()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox9.Clear();
            richTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            richTextBox1.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox9.BackColor = Color.White;


        }

        private void numberonly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

        }

        private void alpabetonly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT    *   FROM   BloodRecords  WHERE [Blood Group] ='" + comboBox4.Text + "' AND [City]='" + comboBox5.Text + "';", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();

            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
            }
            label14.Text = dataGridView1.RowCount.ToString() + " results showing for " + comboBox5.Text + " , " + comboBox4.Text + " blood group";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox8.Text))
            {
                con.Open();
                SqlCommand check = new SqlCommand(@"SELECT COUNT(*)   FROM   BloodRecords  WHERE [Phone number] ='" + textBox8.Text + "';", con);
                check.ExecuteNonQuery();


                if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                {
                    label27.Text = " Record found for " + textBox8.Text;
                    label27.Visible = true;
                    label28.Visible = true;
                    button6.Visible = true;
                    button7.Visible = true;

                }

                else MessageBox.Show("No record found!!!");
                con.Close();

            }
            else MessageBox.Show("Empty");
        }





        private void button8_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select * from BloodRecords", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            label14.Text = "";
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand del = new SqlCommand(@"DELETE FROM BloodRecords
                WHERE [phone number] ='" + textBox8.Text + "';", con);
                del.ExecuteNonQuery();
                MessageBox.Show("record Deleted!!");
                con.Close();

            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }

            label27.Text = "";
            label28.Visible = false;
            button6.Visible = false;
            button7.Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            label27.Text = "";
            label28.Visible = false;
            button6.Visible = false;
            button7.Visible = false;


            MessageBox.Show("you selected NOT to delete");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text))
            {
                sda = new SqlDataAdapter(@"SELECT *   FROM   BloodRecords  WHERE [Phone number] ='" + textBox7.Text + "';", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (Convert.ToInt32(dt.Rows.Count) > 0)
                {
                    
                    foreach (DataRow item in dt.Rows)
                    {
                        textBox5.Enabled = true;
                        textBox4.Enabled = true;
                        richTextBox2.Enabled = true;
                        textBox10.Enabled = true;
                        radioButton3.Enabled = true;
                        radioButton4.Enabled = true;
                        comboBox6.Enabled = true;
                        comboBox7.Enabled = true;
                        comboBox8.Enabled = true;
                        button4.Enabled = true;

                        textBox5.Text = item[2].ToString(); // age 
                        textBox4.Text = item[5].ToString(); // weight 
                        textBox6.Text = item[1].ToString(); // number
                        textBox10.Text = item[0].ToString(); // name
                        richTextBox2.Text = item[8].ToString(); //address

                        if (item[3].ToString() == "M")  //gender
                        {
                            radioButton4.Checked = true;
                        }
                        else radioButton3.Checked = true;

                        comboBox7.SelectedItem = item[4].ToString();    //group
                        comboBox6.SelectedItem = item[7].ToString();    //how often
                        comboBox8.SelectedItem = item[6].ToString();    //city
                    }
                }

                else MessageBox.Show("No record found!!!");
                con.Close();

            }
            else MessageBox.Show("Empty");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gender = radioButton4.Checked ? 'M' : 'F';
            con.Open();
            SqlCommand update = new SqlCommand(@"UPDATE       BloodRecords
SET                Name ='" + textBox10.Text + "', Age ='" + textBox5.Text + "', Gender ='" + gender + "', [Blood Group] ='"
                           + comboBox7.Text + "', Weight ='" + textBox4.Text + "', City ='" + comboBox8.Text + "', [How Often you donate blood?] ='" + comboBox6.Text + "', Address ='" + richTextBox2.Text + "'WHERE [phone number] ='" + textBox6.Text + "';", con);
            update.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("updated!!");




            textBox5.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox10.Clear();
            richTextBox2.Clear();
            comboBox7.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;

        }

    }
}
