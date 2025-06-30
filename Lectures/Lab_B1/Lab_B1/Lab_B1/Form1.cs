using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_B1
{
    public partial class Form1 : Form
    {
        List<User> users = new List<User>();
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            StreamReader SR = new StreamReader("Read.txt");
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Visible = false;
            }
            else
            {
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                User user = new User();
                if (users.Count > 0)
                {
                    user.id = users[users.Count - 1].id + 1;
                }
                else
                {
                    user.id = 1;
                }
                user.name = textBox1.Text;
                user.password = textBox2.Text;
                users.Add(user);

                StreamWriter SW = new StreamWriter("Read.txt");
                SW.WriteLine("User_ID,User_Name,Password");
                for (int i = 0; i < users.Count; i++)
                {
                    SW.WriteLine(users[i].id + "," + users[i].name + "," + users[i].password);
                }

                SW.Close();

                Form2 f2 = new Form2(users);
                f2.Show();
                this.Hide();
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
