using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4__problem_9_
{
    public partial class Form1: Form
    {

       
       
        int yold = -1;
        int xold = -1;// awel click


        int ynew = -1;// tani click
        int xnew = -1;
        bool firstClick = true;

        int pos_xnew=6;
        int pos_ynew=6;

        int small_rectangle_width = 5;
        int small_rectangle_height = 5;

        public Form1()
        {
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown; ;  
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Left)
            {
               

                if (firstClick)
                {
                    yold = e.Y;
                    xold = e.X;

                    drawscene();
                    firstClick = false;
                }
                else
                {
                    
                    xnew = e.X;
                    ynew = e.Y;
                    
                    int x = xold;
                    int y = yold;


                    drawscene();
                    firstClick = true;

                    
                    
                }
                

                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawscene();
        }

        void drawscene()
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 5);
            Brush b = new SolidBrush(Color.Blue);
            g.Clear(Color.White);


           
            if(firstClick==true)
            {
                
                g.Clear(Color.White);
                g.FillRectangle(b, xold, yold, small_rectangle_height, small_rectangle_width);

            }
            else
            {
                int pos_xold = xold;
                int pos_yold = yold;
                int width = xnew - xold;
                int height = ynew - yold;

                if (width < 0)
                {
                    pos_xold = xnew;
                    width = -width;
                }
                if (height < 0)
                {
                    pos_yold = ynew;
                    height = -height;
                }

               g.FillRectangle(b, pos_xold, pos_yold, width, height);
            }
        }

    }
}
