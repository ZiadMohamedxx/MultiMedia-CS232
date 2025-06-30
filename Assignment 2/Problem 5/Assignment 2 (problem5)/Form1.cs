using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2__problem5_
{
    public partial class Form1: Form
    {
        int pos_x;
        int pos_y;
        bool check_drag = false;
        int r;
        int g;
        
        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            check_drag = false;
            pos_x = 0;
            pos_y = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (check_drag)
            {


                if (e.X >= pos_x)
                {
                    r = (e.X - pos_x);
                }
                else
                {
                    r = (pos_x - e.X);
                }


                if (e.Y >= pos_y)
                {
                    g = (e.Y - pos_y);
                }
                else
                {
                    g = (pos_y - e.Y);
                }
                if (r <= 255 && r >= 0 && g >= 0 && g <= 255)  
                {
                    this.BackColor = Color.FromArgb(r, g, 0);   

                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //BackColor = Color.FromArgb(0, 0, 0);
            if (e.Button==MouseButtons.Left)
            {
                pos_x = e.X;
                pos_y = e.Y;
                check_drag = true;
                //this.BackColor = Color.Black;

            }
        }
    }
}
