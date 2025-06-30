using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1__problem3_
{
    public partial class Form1 : Form
    {
        int ct = 0;
        int pos_y;
        bool expect_foo2_wla_t7t = true;
        bool firstClick = true;
       
        public class cnode
        {
            public int x, y;
        }
        List<cnode> up = new List<cnode>();
        List<cnode> down = new List<cnode>();
        public Form1()
        {
            this.MouseClick += Form1_MouseClick;
            this.MouseDoubleClick += Form1_MouseDoubleClick;
            this.MouseDown += Form1_MouseDown;
            this.BackColor = Color.Teal;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


            if (firstClick == true) 
            {
                this.Text = "" + e.Y; 
                firstClick = false;
            }

            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < up.Count; i++)
                {
                    MessageBox.Show("X: " + up[i].x + " Y: " + up[i].y, "Up Click");
                }

                for (int k = 0; k < down.Count; k++)
                {
                    MessageBox.Show("X: " + down[k].x + " Y: " + down[k].y, "Down Click");
                }
            }
            else
            {
                cnode pnn = new cnode();
                pnn.x = e.X;
                pnn.y = e.Y;

                bool is_up;
                if (e.Y < this.ClientSize.Height / 2) // foo2 wla laa
                {
                    is_up = true;
                }
                else
                {
                    is_up = false;
                }


                bool error = false;
                if (expect_foo2_wla_t7t == true) 
                {
                    if (!is_up) 
                    {
                        error = true;
                    }
                    else
                    {
                        up.Add(pnn);
                        expect_foo2_wla_t7t = false; //el click t7t
                    }
                }
                else
                {
                    if (is_up) 
                    {
                        error = true;
                    }
                    else
                    {
                        down.Add(pnn);
                        expect_foo2_wla_t7t = true; //el click foo2
                    }
                }

                if (error) 
                {
                    MessageBox.Show("Error");

                    expect_foo2_wla_t7t = true;
                    firstClick = true;
                }
            }
        }








        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
    

