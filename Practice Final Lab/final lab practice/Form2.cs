using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_lab_practice
{
    public partial class Form2 : Form
    {
        List<users>Luserss=new List<users>();
        int count = 0;
        string path;
        public Form2(List<users>Lusers2,int ct2)
        {
            
            InitializeComponent();
            this.Text = "Book Store";
            Luserss = Lusers2;
            count = ct2;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 signin = new Form1();
            signin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != ""
                && textBox7.Text != "") 
            {
                users pnn=new users();
                pnn.phone = textBox3.Text;
                pnn.email=textBox4.Text;
                pnn.name=textBox7.Text;
                if (radioButton1.Checked == true)
                {
                    pnn.gender = "male";

                }
                else
                {
                    if (radioButton2.Checked == true)
                    {
                        pnn.gender = "female";
                    }
                }
                pnn.password = textBox2.Text;
                pnn.user_name = textBox5.Text;
                pnn.id = count + 1;
                pnn.img_path = path;

                Luserss.Add(pnn);


                StreamWriter SW = new StreamWriter("Z:\\VisualStudio 2022 preview saves\\MultiMedia CS232\\Practice Final Lab\\Material\\New folder\\user.txt");

                for (int i = 0; i < Luserss.Count; i++)
                {
                    SW.WriteLine(Luserss[i].id + "," + Luserss[i].name + "," + Luserss[i].email + "," + Luserss[i].phone.ToString() + "," +
                        Luserss[i].img_path + "," + Luserss[i].gender + "," + Luserss[i].user_name + "," + Luserss[i].password);
                }

                SW.Close();
                
                if (textBox2.Text != textBox1.Text)
                {
                    MessageBox.Show("Password doesn't match");

                }
                else
                {
                    MessageBox.Show("Your Account Has Been Created Succefully");
                    Form3 books = new Form3();
                    books.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Fill The form");
            }

            
            


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = true;
            }
            else
            {
                if(checkBox1.Checked==false)
                {
                    button2.Enabled = false;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                path = dlg.FileName;
                pictureBox1.Image = Image.FromFile(path);
            }

        }
    }
}
