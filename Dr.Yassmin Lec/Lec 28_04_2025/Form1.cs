using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lec_28_04_2025
{
    public partial class Form1: Form
    {
        public class Balls
        {
            public int x, y;
            public int dx, dy;
            public int w;
            public int h;

        }
        public class lines
        {
            public int x;
            public int y;
            public int dx;
            public int dy;
            public int w;
            public int h;

        }
        List<lines> Llines = new List<lines>();

        List<Balls> Lballs = new List<Balls>();
        Bitmap off;
        bool isdrag= false;
        int xold;
        int yold;
        int flag = 0;
        public Form1()
        {
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.WindowState = FormWindowState.Maximized;

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

           
           Llines[0].x = e.X;
           Llines[0].y = e.Y;

            if(flag==1)
            {
                Llines[1].x = e.X;
                Llines[1].y = e.Y;
            }
           


                DrawDouble(this.CreateGraphics());
        }
               

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           DrawDouble(e.Graphics);
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (flag == 1)
                {
                    flag = 0;
                }
                else
                {
                    flag = 1;
                }
            }

            DrawDouble(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            drawline();

        }

        void DrawScene(Graphics g2)
        {
            Pen p = new Pen(Color.Yellow,5);
            
            g2.Clear(Color.Black);
            g2.DrawRectangle(p, (this.ClientSize.Width/2)-700, (this.ClientSize.Height/2)-300, 300,400);
            for(int i=0;i< Llines.Count; i++)
            {
                lines ptrav = Llines[i];
                g2.DrawLine(p, Llines[0].x, Llines[0].y-100, Llines[0].x, Llines[0].y+100);

                if (flag == 1)
                {
                    g2.DrawLine(p, Llines[1].x+100, Llines[1].y, Llines[1].x+100, Llines[1].y );
                    
                }
                
               
            }
           

        }
        void DrawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        void drawline()
        {
            lines pnn = new lines();
            pnn.x = 700;
            pnn.y =500;
            pnn.w = 800;
            pnn.h = 500;

            Llines.Add(pnn);
        }
    }
}
