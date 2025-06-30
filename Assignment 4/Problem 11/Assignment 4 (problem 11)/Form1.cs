using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4__problem_11_
{
    public partial class Form1: Form
    {

        public class CActor
        {
            public int x, y;
            public int w, h;
            public Color cl;

            public void drawyourself(Graphics g)
            {
                Pen p = new Pen(cl);
                Brush b = new SolidBrush(cl);
                g.FillEllipse(b, x, y, w, h);

            }
        }




        int circle1_x = 100;
        int circle1_y = 100;
        int circle1_width = 50;
        int circle1_height = 50;
        int dx;
        int dy;
        bool isdrag = false;
        int yold;
        int xold;
        int flag = 0;
        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
            this.Paint += Form1_Paint; 
            this.MouseDown += Form1_MouseDown;
            this.Load += Form1_Load;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
            this.MouseMove += Form1_MouseMove1;
        }

        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
           //
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isdrag==true)
            {
                dx = e.X - xold;
                dy = e.Y - yold;
                circle1_x += dx;
                circle1_y += dy;
                xold = e.X;
                yold = e.Y;
                drawscene();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isdrag = false;
            xold = 0;
            yold = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //drawscene();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (flag == 1)
            {
                if (e.X > circle1_x + 300 && e.X < circle1_x + 790 && e.Y > circle1_y && e.Y < circle1_y + 200)
                {


                    xold = e.X;
                    yold = e.Y;
                    isdrag = true;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                drawscene();
                flag = 1;
            }
        }

        void drawscene()
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Red);
            g.Clear(Color.White);

            //up
            g.FillEllipse(b, circle1_x+300, circle1_y, circle1_width, circle1_height);//1
            g.FillEllipse(b, circle1_x + 370, circle1_y, circle1_width , circle1_height );//2
            g.FillEllipse(b, circle1_x + 440, circle1_y, circle1_width , circle1_height );//3
            g.FillEllipse(b, circle1_x + 510, circle1_y, circle1_width , circle1_height );//4
            g.FillEllipse(b, circle1_x + 580, circle1_y, circle1_width , circle1_height );//5
            g.FillEllipse(b, circle1_x + 650, circle1_y, circle1_width , circle1_height );//6
            g.FillEllipse(b, circle1_x + 720, circle1_y, circle1_width , circle1_height );//7
            g.FillEllipse(b, circle1_x + 790, circle1_y, circle1_width , circle1_height );//8


            //right
             b = new SolidBrush(Color.Green);

            g.FillEllipse(b, circle1_x + 860, circle1_y+100, circle1_width , circle1_height);//1
            g.FillEllipse(b, circle1_x + 910, circle1_y+100, circle1_width , circle1_height);//2
            g.FillEllipse(b, circle1_x + 960, circle1_y + 100, circle1_width , circle1_height );//3
            g.FillEllipse(b, circle1_x + 1010, circle1_y+100, circle1_width , circle1_height );//4



            //left
            b = new SolidBrush(Color.Green);

            g.FillEllipse(b, circle1_x + 50, circle1_y + 100, circle1_width , circle1_height );//1
            g.FillEllipse(b, circle1_x + 100, circle1_y + 100, circle1_width , circle1_height );//2
            g.FillEllipse(b, circle1_x + 150, circle1_y + 100, circle1_width , circle1_height );//3
            g.FillEllipse(b, circle1_x + 200, circle1_y + 100, circle1_width , circle1_height );//4

            //t7t
            b = new SolidBrush(Color.Red);


            g.FillEllipse(b, circle1_x + 300, circle1_y+200, circle1_width , circle1_height );//1
            g.FillEllipse(b, circle1_x + 370, circle1_y+200, circle1_width , circle1_height );//2
            g.FillEllipse(b, circle1_x + 440, circle1_y + 200, circle1_width , circle1_height );//3
            g.FillEllipse(b, circle1_x + 510, circle1_y + 200, circle1_width , circle1_height );//4
            g.FillEllipse(b, circle1_x + 580, circle1_y + 200, circle1_width , circle1_height );//5
            g.FillEllipse(b, circle1_x + 650, circle1_y + 200, circle1_width , circle1_height );//6
            g.FillEllipse(b, circle1_x + 720, circle1_y + 200, circle1_width , circle1_height );//7
            g.FillEllipse(b, circle1_x + 790, circle1_y + 200, circle1_width , circle1_height );//8



        }

    }
}
