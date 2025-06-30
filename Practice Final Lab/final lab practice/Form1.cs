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
    public partial class Form1 : Form
    {
        int ct = 0;
        int flag = 0;
        public List<users> Lusers = new List<users>();
        public Form1()
        {
            InitializeComponent();
            
            this.Text = "Book Store";
            StreamReader SR = new StreamReader("Z:\\VisualStudio 2022 preview saves\\MultiMedia CS232\\Practice Final Lab\\Material\\New folder\\user.txt");
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();


                string[] temp = line.Split(',');
                users pnn = new users();

                pnn.id = Int16.Parse(temp[0]);
                pnn.name = temp[1];
                pnn.email = temp[2];
                pnn.phone = temp[3];
                pnn.img_path = temp[4];
                pnn.gender = temp[5];
                pnn.user_name = temp[6];
                pnn.password = temp[7];
                Lusers.Add(pnn);

                ct++;

            }
            SR.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form2 register = new Form2(Lusers,ct);
            register.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lusers.Count; i++)
            {
                users pnn = Lusers[i];

                if (pnn.user_name == textBox1.Text)
                {
                    if (pnn.password == textBox2.Text)
                    {
                        MessageBox.Show("Login Succesful");
                        Form3 book = new Form3();
                        book.Show();
                        this.Hide();
                        flag = 1;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    if (pnn.user_name != textBox1.Text && flag == 1) 
                    {

                        MessageBox.Show("User Not Found");
                       
                    }
                }
            }
        }
    }

    public class users
    {
        
        public string name;
        public string password;
        public string email;
        public string phone;
        public string img_path;
        public string gender;
        public string user_name;
        public int id;

    }
}
