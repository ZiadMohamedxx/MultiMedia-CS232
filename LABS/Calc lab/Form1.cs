using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calc_lab
{
    public partial class Form1: Form
    {
        int nmul = 0;
        int nsub = 0;
        int ndiv = 0;
        int nplus = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //number 2

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //multiply
            if (textBox2.Text != "")
            {
                 nmul= Convert.ToInt16(textBox2.Text);

            }
            else
            {
                MessageBox.Show("you must fill");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //plus
            if (textBox2.Text != "")
            {
                 nplus = Convert.ToInt16(textBox2.Text);

            }
            else
            {
                MessageBox.Show("you must fill");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //-
            if (textBox2.Text != "")
            {
                 nsub = Convert.ToInt16(textBox2.Text);

            }
            else
            {
                MessageBox.Show("you must fill");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //divide
            if (textBox2.Text != "")
            {
                 ndiv = Convert.ToInt16(textBox2.Text);

            }
            else
            {
                MessageBox.Show("you must fill");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //equal
            if (textBox2.Text != "" && textBox1.Text != "") 
            {
                
            }
            else
            {
               MessageBox.Show("you must fill");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //number 1
        }
    }
}



