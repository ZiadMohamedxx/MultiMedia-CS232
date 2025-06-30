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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace practice_for_the_makeup
{
    public partial class Form1 : Form
    {
        List<User> users = new List<User>();
        int count = 0;
        
        public Form1()
        {
            InitializeComponent();
            StreamReader SR = new StreamReader("user.txt");
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();


                string[] temp = line.Split(',');
                User user = new User();
                user.id = Int16.Parse(temp[0]);
                user.name = temp[1];
                user.email = temp[2];
                user.phone_number = temp[3];
                user.img_path = temp[4];
                user.gender = temp[5];
                user.username= temp[6];
                user.password = temp[7];
                users.Add(user);

                count++;
            }
            SR.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form2 signup = new Form2(users,count);
            signup.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag=0;
            for (int i = 0; i < users.Count; i++)
            {
                User pnn = users[i];
                if (pnn.username == textBox2.Text)
                {
                    flag = 1;
                }
            }

            if (flag == 1)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    User pnn = users[i];
                    if (pnn.username == textBox2.Text)
                    {
                        if (pnn.password == textBox1.Text) 
                        {
                            MessageBox.Show("login succefully");
                            this.Hide();
                            Form3 books = new Form3();
                            books.Show();

                        }
                        else
                        {
                            MessageBox.Show("password is incorrect");
                        }
                    }
                    



                }

            }
            else
            {
                MessageBox.Show("user not found");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //username

            if (textBox2.Text != "" && textBox1.Text != "") 
            {
                


                button1.Enabled=true;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //password
            if (textBox2.Text != "" && textBox1.Text != "")
            {


                button1.Enabled = true;
            }


        }
    }
    public class User
    {
        public int id;
        public string name;
        public string password;
        public string email;
        public string gender;
        public string phone_number;
        public string img_path;
        public string username;
    }
}
