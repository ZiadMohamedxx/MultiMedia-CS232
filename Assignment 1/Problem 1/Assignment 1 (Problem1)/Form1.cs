using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_1__Problem1_
{
    public partial class Form1: Form
    {
       
        public Form1()
        {
            this.MouseMove += Form1_MouseMove;
           
        }

        

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int Q = this.Width / 4;
            this.Text = "" + e.Y;
            if (e.X > 0 && e.X < Q)
            {
                this.BackColor = Color.Red;
            }
            if (e.X > Q && e.X < 2*Q ) 
            {
                this.BackColor = Color.Blue;
            }
            if (e.X > Q*2 && e.X < 3*Q  )
            {
                this.BackColor = Color.Green;
            }
            if (e.X > Q*3 )  
            {
                this.BackColor = Color.Yellow;
            }




        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }
    }
}
