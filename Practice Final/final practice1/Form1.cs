using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_practice1
{
    public partial class Form1 : Form
    {
        public class ball
        {
            public int x;
            public int y;
            public int h;
            public int w;
            public int dx = 1;
            public Bitmap img;

        }
        public class line
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            
        }
        List<line> Llines = new List<line>();
        List<ball> Lballs = new List<ball>();
        Bitmap off;
        Timer tt = new Timer();
        int ct_tick=0;
        int xold=0;
        int yold=0;
        bool isdrag = true;
        int dx = 0;
        int dy = 0;
        

        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            WindowState = FormWindowState.Maximized;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            tt.Tick += Tt_Tick;
            tt.Start();
            

        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if(ct_tick % 10 == 0)
            {
                createLeftBalls();
            }
            moveLeftBalls();


            ct_tick++;
            drawdubb(this.CreateGraphics());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            line pnn=Llines[0];
            pnn.x1 = e.X;
            pnn.y1 = e.Y;

            pnn.x2 = e.X;
            pnn.y2 = e.Y+50;

            moveLeftBalls();
            
            drawdubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            line pnn =new line();
            pnn.x1 = e.X;
            pnn.y1 = e.Y;

            pnn.x2 = e.X;
            pnn.y2 = e.Y + 50;
            Llines.Add(pnn);
            drawdubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createLine();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p=new Pen(Color.Red, 3);

            for (int i = 0; i < Lballs.Count; i++)
            {
                ball ptrav = Lballs[i];
                g2.DrawImage(ptrav.img, ptrav.x, ptrav.y);
            }
            for (int i = 0; i < Llines.Count; i++)
            {
                line ptrav = Llines[i];
                g2.DrawLine(p,ptrav.x1,ptrav.y1,ptrav.x2,ptrav.y2);
            }
        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createLeftBalls()
        {

            ball pnn = new ball();
            Random RR = new Random();
            RR.Next(200, 600);
            pnn.x = 0;
            pnn.y = RR.Next(200, 600);
            pnn.img = new Bitmap("egg1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            Lballs.Add(pnn);

        }

        void moveLeftBalls()
        {
            for (int i = 0; i < Lballs.Count; i++)
            {
                ball ptrav = Lballs[i];
                ptrav.x += 10*ptrav.dx;
                
                  
            }
            stopballs();
        }
        void createLine()
        {
           line pnn=new line();

            pnn.x1 = 50;
            pnn.y1=0;
            pnn.x2 = 50;
            pnn.y2 = 50;

            Llines.Add(pnn);


        }

        void stopballs()
        {
            for (int i = 0; i < Lballs.Count; i++)
            {
                ball pnn = Lballs[i];
                for (int j = 0; j < Llines.Count; j++)
                {
                    line ptrav = Llines[j];

                    if (pnn.x + pnn.w >= ptrav.x1 && pnn.y > ptrav.y1 && pnn.y < ptrav.y2) 
                    {

                        pnn.dx = 0; 

                    }
                }
                    
            }
        }
    }
}
