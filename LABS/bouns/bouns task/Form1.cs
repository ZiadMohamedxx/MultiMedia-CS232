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

namespace bouns_task
{
    public partial class Form1 : Form
    {
        List<User> users = new List<User>();
        List<User>Loggedin= new List<User>();
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            StreamReader SR = new StreamReader("users.txt");
            while (!SR.EndOfStream)
            {

                string line = SR.ReadLine();
                if (count > 0)
                {

                    string[] temp = line.Split(',');
                    User user = new User();
                    user.id = Int16.Parse(temp[0]);
                    user.name = temp[1];
                    user.password = temp[2];
                    users.Add(user);
                }
                count++;
            }
            SR.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int i = 0; i < users.Count; i++)
            {
                User pnn = users[i];
                if (pnn.name == textBox1.Text)
                {
                    flag = 1;
                }
            }

            if (flag == 1)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    User pnn = users[i];
                    if (pnn.name == textBox1.Text)
                    {
                        if (pnn.password == textBox2.Text)
                        {
                            MessageBox.Show("login succefully");
                            Loggedin.Add(pnn);
                            StreamWriter SW = new StreamWriter("logged.txt");
                            SW.WriteLine("User_id,User_name,password");
                            for (int k = 0; k < Loggedin.Count; k++)
                            {
                                SW.WriteLine(Loggedin[k].id + "," + Loggedin[k].name + "," + Loggedin[k].password);
                            }

                            SW.Close();

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
    }
    public class User
    {
        public int id;
        public string name;
        public string password;
        
    }

    
}
