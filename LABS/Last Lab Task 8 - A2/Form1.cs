using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Last_Lab_Task_8___A2
{
    public partial class Form1 : Form
    {
        

        


        public List<descriptions> Ldescriptions = new List<descriptions>();
        int ct2 = 0;
        int ct = 0;
        bool hide_checkbox = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Switch Photos Form";
            StreamReader SR = new StreamReader("Z:\\VisualStudio 2022 preview saves\\MultiMedia CS232\\LABS\\Last Lab Task 8 - A2\\file.txt");
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();
                if (ct > 0)
                {
                    string[] temp = line.Split(',');
                    descriptions pnn = new descriptions();
                    pnn.name = temp[0];
                    pnn.description = temp[1];
                    pnn.img = temp[2];
                    Ldescriptions.Add(pnn);
                }
                ct++;
            }
            SR.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!hide_checkbox)
            {
                textBox1.Hide();
                hide_checkbox = true;
            }
            else
            {
                textBox1.Show();
                hide_checkbox = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ct2 > 0)
            {
                ct2--;
                textBox1.Text = Ldescriptions[ct2].description;
                pictureBox1.Image = Image.FromFile(Ldescriptions[ct2].img);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ct2 + 1 < Ldescriptions.Count)
            {
                ct2++;
                textBox1.Text = Ldescriptions[ct2].description;
                
                pictureBox1.Image = Image.FromFile(Ldescriptions[ct2].img);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Ldescriptions != null)
            {
                Form2 edit_Description = new Form2(Ldescriptions, ct2);

                //this.Hide();
                

                edit_Description.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBox1.Text = Ldescriptions[ct2].description;
            //pictureBox1.Image = Image.FromFile(Ldescriptions[ct2].img);

            textBox1.Text = Ldescriptions[ct2].description;
            string imgpath = Ldescriptions[ct2].img;
            if (imgpath != null && imgpath.Length > 0)
            {
                
                pictureBox1.Image = Image.FromFile(imgpath);
            }

            
            
        }
    }

    public class descriptions
    {
        public string description;
        public string name;
        public string img;
    }
}
