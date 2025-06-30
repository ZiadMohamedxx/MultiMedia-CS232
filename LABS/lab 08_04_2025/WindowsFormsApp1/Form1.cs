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

namespace WindowsFormsApp1
{
    public partial class Form1: Form
    {
        bool Small_meal = false;
        bool Mid_meal = false;
        bool Large_meal = false;
        bool check = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("single");
            comboBox1.Items.Add("combo");
            checkBox1.Checked = false;
            checkBox1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                MessageBox.Show("Please check the box");
            }


            if (checkBox1.Checked == true)
            {
                if (Small_meal == true)
                {
                    listBox1.Items.Add(textBox1.Text + ", Small, " + comboBox1.Text);
                }
                if (Mid_meal == true)
                {
                    listBox1.Items.Add(textBox1.Text + ", mid, " + comboBox1.Text);
                }
                if (Large_meal == true)
                {
                    listBox1.Items.Add(textBox1.Text + ", Large, " + comboBox1.Text);
                }



                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;

                

               
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Large_meal = false;
            Mid_meal = false;
            Small_meal = true;
            check = true;
            if (textBox1.Text != "" && textBox2.Text != "" && check == true && comboBox1.Text != "")
            {
                checkBox1.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Large_meal = false;
            Mid_meal = true;
            Small_meal = false;
            check = true;
            if (textBox1.Text != "" && textBox2.Text != "" && check == true && comboBox1.Text != "")
            {
                checkBox1.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Large_meal = true;
            Mid_meal = false;
            Small_meal = false;
            check = true;
            if (textBox1.Text != "" && textBox2.Text != "" && check == true && comboBox1.Text != "")
            {
                checkBox1.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && check == true && comboBox1.Text != "")
            {
                checkBox1.Enabled = true;
            }
        }
    }
}
