using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1__problem2_
{
    public partial class Form1 : Form
    {
        int clickCount = 0;
        int decreasing = 1; //true
        public Form1()
        {
            this.Click += Form1_Click;
            BackColor = Color.Black;
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                if (decreasing == 1)
                {
                    Opacity -= 0.1;
                }
                else
                {
                    Opacity += 0.1;
                }

                clickCount++;

                if (clickCount == 9)
                {
                    clickCount = 0;
                    decreasing = -decreasing;
                }
            }
            else
            {
                MessageBox.Show("YA HABIBI DOOOOOS LEFT CLICK");
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
           
               
               
                
                
        }
    }
}
