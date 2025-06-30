using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Last_Lab_Task_8___A2
{
    public partial class Form2 : Form
    {
        List<descriptions> Ldescriptions;
        int ct;

       
       
        public Form2(List<descriptions> Ldescriptions2, int ct2)
        {

            Ldescriptions = Ldescriptions2;
            ct= ct2;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Ldescriptions[ct].description;
            pictureBox1.Image = Image.FromFile(Ldescriptions[ct].img);
            this.Text = ("Edit Form");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Ldescriptions[ct].description = textBox2.Text;
                StreamWriter SW = new StreamWriter("Z:\\VisualStudio 2022 preview saves\\MultiMedia CS232\\LABS\\Last Lab Task 8 - A2\\file.txt");
                SW.WriteLine("name,description,path");
                for (int i = 0; i < Ldescriptions.Count; i++)
                {
                    SW.WriteLine(Ldescriptions[i].name + "," + Ldescriptions[i].description + "," + Ldescriptions[i].img);
                }

                SW.Close();
                MessageBox.Show("Description Has Been Changed Successfully");
                this.Close();
            }
        }
    }
}
