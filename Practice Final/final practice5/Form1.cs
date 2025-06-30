using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_practice5
{
    public partial class Form1 : Form
    {
        public class matrix
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int r;
            public int c;

        }
        public class ellipse
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int r;
            public int c;

        }
        List<ellipse>Lellipse=new List<ellipse>();
        matrix[,] Lmatrix = new matrix[4, 4];
        Bitmap off;

        int yb=100;
        int xb = 100;

        int wcell = 100;
        int hcell = 100;

        int r;
        int c;

        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            r = (e.Y - yb) / hcell;
            c=(e.X - xb) / wcell;


            drawellipse();

            drawdubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            creatematrix();
        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }
        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p = new Pen(Color.White, 3);
            Pen pen = new Pen(Color.Yellow, 6);
            Pen pen2 = new Pen(Color.Red, 6);
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    matrix ptrav = Lmatrix[r, c];
                    g2.DrawRectangle(p, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
                }
            }

            for(int i=0;i<Lellipse.Count;i++)
            {
                ellipse ptrav = Lellipse[i];
                g2.FillEllipse(Brushes.LightCoral, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            }

            //for (int i = 0; i < lsmallobjects.Count; i++)
            //{
            //    smallobject ptrav = lsmallobjects[i];
            //    g2.DrawImage(ptrav.img, ptrav.x, ptrav.y);
            //}

            //for (int r = 0; r < 3; r++)
            //{
            //    for (int c = 0; c < 3; c++)
            //    {
            //        matrixUP ptrav = Lmatrix_up[r, c];
            //        g2.DrawRectangle(pen, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            //    }
            //}

            //for (int r = 0; r < 3; r++)
            //{
            //    for (int c = 0; c < 3; c++)
            //    {
            //        matrixDown ptrav = Lmatrix_down[r, c];
            //        g2.DrawRectangle(pen, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            //    }
            //}

            //for(int i=0;i<Lline.Count;i++)
            //{
            //    line ptrav = Lline[Lline.Count-1];
            //    g2.DrawLine(pen2, ptrav.x1, ptrav.y1, ptrav.x2, ptrav.y2);
            //
            //}

            
        }

        void creatematrix()
        {
            int x;
            int y;
            y = yb;
            for (int r = 0; r < 4; r++)
            {

                x = xb;
                for(int c = 0;c < 4; c++)
                {
                    matrix pnn=new matrix();
                    pnn.x= x;
                    pnn.y= y;
                    pnn.w = wcell;
                    pnn.h = hcell;
                    Lmatrix[r, c] = pnn;
                    x += wcell;
                }
                y += hcell;
            }
        }

        void drawellipse()
        {
            ellipse pnn= new ellipse();
            pnn.c = c;
            pnn.r = r;
            pnn.x = Lmatrix[r, c].x + 20;
            pnn.y = Lmatrix[r, c].y + 20;
            pnn.w = 30;
            pnn.h = 30;
            Lellipse.Add(pnn);
            
        }
    }
}
