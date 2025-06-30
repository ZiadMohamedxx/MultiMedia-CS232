using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_6__problem_18_
{
    public partial class Form1: Form
    {
        public class Rectangles
        {
            public int x;
            public int y;
            public int dx=1;
            public int dy=0;
            public int width;
            public int height;

        }
        public class ball
        {
            public int x;
            public int y;
            public int dx;
            public int dy;
            public int width;
            public int height;

        }
        public class lines
        {
            public int x;
            public int y;
            public int x2;
            public int y2;

        }

        List<Rectangles> Lrecs = new List<Rectangles>();
        List<ball> Lballs = new List<ball>();
        List<lines> Llines = new List<lines>();

        Bitmap off;
        Timer tt = new Timer();
        int flag = 0;


        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
            this.Load += Form1_Load;
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            tt.Tick += Tt_Tick;
            tt.Start();

        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            
            moveRecs();
            

            
            DrawDouble(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDouble(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createLines();
            createRectangles();
            createBall();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (flag == 0)
            {

                if (e.KeyCode == Keys.Up)
                {
                    Lballs[0].y -= 10;
                    DrawDouble(this.CreateGraphics());

                }

                if (e.KeyCode == Keys.Down)
                {
                    Lballs[0].y += 10;
                    DrawDouble(this.CreateGraphics());
                }

                if (e.KeyCode == Keys.Left)
                {
                    Lballs[0].x -= 10;
                    DrawDouble(this.CreateGraphics());
                }

                if (e.KeyCode == Keys.Right)
                {
                    Lballs[0].x += 10;
                    DrawDouble(this.CreateGraphics());
                }
            }

            for(int i=0;i < Lrecs.Count; i++)
            {
                Rectangles ptrav = Lrecs[i];
                if (Lballs[0].x + Lballs[0].width > ptrav.x 
                    && Lballs[0].x < ptrav.x + ptrav.width 
                    && Lballs[0].y + Lballs[0].height > ptrav.y 
                    && Lballs[0].y < ptrav.y + ptrav.height)
                {
                    tt.Stop();
                    flag = 1;
                }
                
            }
            for (int i = 0; i < Llines.Count; i++)
            {
                lines ptrav = Llines[i];
                if (
                     (ptrav.y == ptrav.y2 && //kol el horizontal lines
                      Lballs[0].y <= ptrav.y && Lballs[0].y + Lballs[0].height >= ptrav.y &&
                      ((Lballs[0].x + Lballs[0].width >= ptrav.x && Lballs[0].x <= ptrav.x) ||
                       (Lballs[0].x + Lballs[0].width >= ptrav.x2 && Lballs[0].x <= ptrav.x2) ||
                       (Lballs[0].x <= ptrav.x && Lballs[0].x + Lballs[0].width >= ptrav.x2) ||
                       (Lballs[0].x <= ptrav.x2 && Lballs[0].x + Lballs[0].width >= ptrav.x)))
                    )
                {
                    tt.Stop();
                    flag = 1;
                }

                if ((ptrav.x == ptrav.x2 && // kol el vertical lines
                      Lballs[0].x <= ptrav.x && Lballs[0].x + Lballs[0].width >= ptrav.x &&
                      ((Lballs[0].y + Lballs[0].height >= ptrav.y && Lballs[0].y <= ptrav.y) ||
                       (Lballs[0].y + Lballs[0].height >= ptrav.y2 && Lballs[0].y <= ptrav.y2) ||
                       (Lballs[0].y <= ptrav.y && Lballs[0].y + Lballs[0].height >= ptrav.y2) ||
                       (Lballs[0].y <= ptrav.y2 && Lballs[0].y + Lballs[0].height >= ptrav.y)))
                    )
                {
                    tt.Stop();
                    flag = 1;
                }
            }

        }

        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p = new Pen(Color.White, 4);

            for (int i = 0; i < Llines.Count; i++) 
            {
                lines ptrav = Llines[i];
                g2.DrawLine(p, ptrav.x, ptrav.y, ptrav.x2 , ptrav.y2 );
            }

            for (int i = 0; i < Lrecs.Count; i++)
            {
                Rectangles ptrav = Lrecs[i];
                g2.FillRectangle(Brushes.White, ptrav.x, ptrav.y, ptrav.width, ptrav.height);
            }

            for(int i=0;i< Lballs.Count; i++)
            {
                ball ptrav = Lballs[i];
                g2.FillEllipse(Brushes.Yellow, ptrav.x, ptrav.y, ptrav.width, ptrav.height);
            }

            

        }

        void DrawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createLines()
        {
            // left khales bel tool
            lines pnn = new lines();
            pnn.x = 300;
            pnn.y = 500;
            pnn.x2 = 300;
            pnn.y2 = 350;
            Llines.Add(pnn);
            //foo2 el line shemal bel 3ard
            lines pnn2 = new lines();
            pnn2.x = 500;
            pnn2.y = 350;
            pnn2.x2 = 300;
            pnn2.y2 = 350;
            Llines.Add(pnn2);

            //foo2 bel tool t7t el foo2 khakles bel 3ard left
            lines pnn3 = new lines();
            pnn3.x = 500;
            pnn3.y = 350;
            pnn3.x2 = 500;
            pnn3.y2 = 200;
            Llines.Add(pnn3);

            //foo2 bel 3ard
            lines pnn4 = new lines();
            pnn4.x = 900;
            pnn4.y = 200;
            pnn4.x2 = 500;
            pnn4.y2 = 200;
            Llines.Add(pnn4);

            //foo2 bel tool t7t el foo2 khakles bel 3ard right
            lines pnn5 = new lines();
            pnn5.x = 900;
            pnn5.y = 350;
            pnn5.x2 = 900;
            pnn5.y2 = 200;
            Llines.Add(pnn5);

            //foo2 el line right bel 3ard
            lines pnn6 = new lines();
            pnn6.x = 1100;
            pnn6.y = 350;
            pnn6.x2 = 900;
            pnn6.y2 = 350;
            Llines.Add(pnn6);


            //right khales bel tool
            lines pnn7 = new lines();
            pnn7.x = 1100;
            pnn7.y = 500;
            pnn7.x2 = 1100;
            pnn7.y2 = 350;
            Llines.Add(pnn7);


            //t7t el line right bel 3ard
            lines pnn8 = new lines();
            pnn8.x = 1100;
            pnn8.y = 500;
            pnn8.x2 = 900;
            pnn8.y2 = 500;
            Llines.Add(pnn8);


            lines pnn9 = new lines();
            pnn9.x = 900;
            pnn9.y = 500;
            pnn9.x2 = 900;
            pnn9.y2 = 650;
            Llines.Add(pnn9);

            lines pnn10 = new lines();
            pnn10.x = 900;
            pnn10.y = 650;
            pnn10.x2 = 500;
            pnn10.y2 = 650;
            Llines.Add(pnn10);


            lines pnn11 = new lines();
            pnn11.x = 500;
            pnn11.y = 500;
            pnn11.x2 = 500;
            pnn11.y2 = 650;
            Llines.Add(pnn11);


            lines pnn12 = new lines();
            pnn12.x = 500;
            pnn12.y = 500;
            pnn12.x2 = 300;
            pnn12.y2 = 500;
            Llines.Add(pnn12);
        }

        void createRectangles()
        {
            Rectangles pnn = new Rectangles();
            pnn.x = 505;
            pnn.y = 200;
            pnn.width = 150;
            pnn.height = 150;

            Lrecs.Add(pnn);

            Rectangles pnn2 = new Rectangles();
            pnn2.x = 745;
            pnn2.y = 500;
            pnn2.width = 150;
            pnn2.height = 150;

            Lrecs.Add(pnn2);
        }
        void createBall()
        {
            ball pnn = new ball();
            pnn.x = 400;
            pnn.y = 400;
            pnn.width = 40;
            pnn.height = 40;
            Lballs.Add(pnn);
        }

        void moveRecs()
        {
            for (int i = 0; i < Lrecs.Count; i++)
            {
                Rectangles ptrav = Lrecs[i];
                ptrav.x += 5*ptrav.dx;
                ptrav.y += 5*ptrav.dy;

                if(ptrav.x+ptrav.width>900&&ptrav.y + ptrav.height > 200)
                {
                    ptrav.dx = -1;
                    ptrav.dy = 0;
                }
                if(ptrav.x < 500 && ptrav.y < 200)
                {
                    ptrav.dx = 1;
                    ptrav.dy = 0;
                }
                if (ptrav.x + ptrav.width > 900 && ptrav.y < 500)
                {
                    ptrav.dx = 0;
                    ptrav.dy = 1;
                }
                if (ptrav.x<500&&ptrav.y+ptrav.height>=650)
                {
                    ptrav.dx = 0;
                    ptrav.dy = -1;
                }
                
            }
        }
    }
}
