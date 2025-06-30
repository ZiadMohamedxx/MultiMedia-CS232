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

namespace practice_for_the_makeup
{
    public partial class Form2 : Form
    {
        List<User>Lusers = new List<User>();
        int ct2;
        string fileName;
        public Form2(List<User> usersss,int ct)
        {
            InitializeComponent();
            ct2 = ct;
            Lusers = usersss;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                
                fileName = dlg.FileName;
                pictureBox1.Image = Image.FromFile(fileName);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                && textBox5.Text != "" && textBox6.Text != "") 
            {
                User pnn=new User();
               
                if(textBox4.Text==textBox3.Text)
                {
                    pnn.id = Lusers[Lusers.Count - 1].id+1;
                    pnn.password = textBox4.Text;
                    pnn.phone_number = textBox2.Text;
                    pnn.img_path = fileName;
                    pnn.email = textBox1.Text;
                    if(radioButton1.Checked==true)
                    {
                        pnn.gender = "male";
                    }
                    if (radioButton2.Checked == true)
                    {
                        pnn.gender = "female";
                    }
                    pnn.name = textBox6.Text;
                    Lusers.Add(pnn);
                }
                else
                {
                    MessageBox.Show("password does not match");
                }
                

                    StreamWriter SW = new StreamWriter("user.txt");
                
                for (int i = 0; i < Lusers.Count; i++)
                {
                    
                    SW.WriteLine(Lusers[i].id + "," + Lusers[i].name + "," + Lusers[i].email+","
                        + Lusers[i].phone_number + "," + Lusers[i].img_path + "," + Lusers[i].gender + ","
                        +Lusers[i].username + "," + Lusers[i].password);


                }

                SW.Close();



            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
