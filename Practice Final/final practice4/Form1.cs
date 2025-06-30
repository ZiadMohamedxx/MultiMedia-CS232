using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_practice4
{
    public partial class Form1 : Form
    {
        public class matrix
        {

            public int x;
            public int y;
            public int w;
            public int h;
        }
        public class matrixDown
        {

            public int x;
            public int y;
            public int w;
            public int h;
        }
        public class matrixUP
        {

            public int x;
            public int y;
            public int w;
            public int h;
        }
        public class smallobject
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int r;
            public int c;
            public Bitmap img;
        }
        public class line
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
        }
        public class advImg
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public Rectangle DST;
            public Rectangle SRC;
            public Bitmap img;
        }
        List<advImg>Ladvimg=new List<advImg>();
        List<line>Lline=new List<line>();
        matrix[,] Lmatrix = new matrix[6, 7];
        matrixDown[,] Lmatrix_down = new matrixDown[3, 3];
        matrixUP[,] Lmatrix_up = new matrixUP[3, 3];
        List<smallobject> lsmallobjects = new List<smallobject>();
        int xb = 500;
        int yb = 100;

        int wcell = 100;
        int hcell = 100;

        int r = 0;
        int c = 0;



        Bitmap off;
        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            WindowState = FormWindowState.Maximized;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown1;

        }

        private void Form1_MouseDown1(object sender, MouseEventArgs e)
        {
            r=(e.Y-yb)/ hcell;
            c=(e.X-xb)/ wcell;

            createline();

            drawdubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }s

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                c = (e.X - xb) / wcell;
                r = (e.Y - yb) / hcell;

                createsmallobjects();
            }
            if (e.Button == MouseButtons.Right)
            {
                c = (e.X - xb) / wcell;
                r = (e.Y - yb) / hcell;

                for (int i = lsmallobjects.Count - 1; i >= 0; i--)
                {
                    smallobject ptrav = lsmallobjects[i];
                    if (ptrav.r == r && ptrav.c == c)
                    {
                        lsmallobjects.RemoveAt(i);
                        break;
                    }
                }
            }


            drawdubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            //creatematrix();
            //creatematrixdown();
            //creatematrixUP();
            createimage();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p = new Pen(Color.White, 3);
            Pen pen = new Pen(Color.Yellow, 6);
            Pen pen2 = new Pen(Color.Red, 6);
            //for (int r = 0; r < 6; r++)
            //{
            //    for (int c = 0; c < 7; c++)
            //    {
            //        matrix ptrav = Lmatrix[r, c];
            //        g2.DrawRectangle(p, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            //    }
            //}

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

            for(int i=0;i<Ladvimg.Count;i++)
            {
                advImg ptrav = Ladvimg[i];
                g2.DrawImage(ptrav.img, ptrav.DST, ptrav.SRC, GraphicsUnit.Pixel);
            }
        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }


        void creatematrix()
        {
            int x;
            int y;
            y = yb;
            for (int r = 0; r < 6; r++)
            {
                x = xb;
                //y = yb + r * hcell;
                for (int c = 0; c < 7; c++)
                {
                    //x = xb + c * wcell;
                    matrix pnn = new matrix();
                    pnn.x = x;
                    pnn.y = y;
                    pnn.w = wcell;
                    pnn.h = hcell;
                    Lmatrix[r, c] = pnn;
                    x+= wcell;
                }
                y += hcell;
            }


        }
        void createsmallobjects()
        {
            smallobject pnn = new smallobject();
            pnn.img = new Bitmap("egg1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.r = r;
            pnn.c = c;
            pnn.x = Lmatrix[r, c].x;
            pnn.y = Lmatrix[r, c].y;
            for (int i = 0; i < lsmallobjects.Count; i++)
            {
                smallobject ptrav = lsmallobjects[i];
                if (ptrav.r == pnn.r && ptrav.c == pnn.c)
                {
                    pnn.x += 20;
                    pnn.y += 20;
                }

            }
            lsmallobjects.Add(pnn);

        }

        void creatematrixdown()
        {
            int x;
            int y;
            int r_orginal = 3;
            int c_orginal = 4;
            for (int r = 0; r < 3; r++)
            {
                
                for (int c = 0; c < 3; c++)
                {
                    
                    matrixDown pnn = new matrixDown();
                    pnn.x = Lmatrix[r_orginal,c_orginal].x;
                    pnn.y = Lmatrix[r_orginal, c_orginal].y;
                    pnn.w = Lmatrix[r_orginal,c_orginal].w;
                    pnn.h = Lmatrix[r_orginal, c_orginal].h;

                    Lmatrix_down[r, c] = pnn;
                    c_orginal++;
                }
                r_orginal++;
                c_orginal = 4;
            }
        }

        void creatematrixUP()
        {
            int x;
            int y;
            for (int r = 0; r < 3; r++)
            {
                x = 0;
                y = yb + r * hcell;
                for (int c = 0; c < 3; c++)
                {
                    x = xb + c * wcell;
                    matrixUP pnn = new matrixUP();
                    pnn.x = x;
                    pnn.y = y;
                    pnn.w = wcell;
                    pnn.h = hcell;
                    Lmatrix_up[r, c] = pnn;
                }
            }
        }

        void createline()
        {
            line pnn=new line();

            pnn.x1 = Lmatrix_up[r, c].x;
            pnn.x2 = Lmatrix_down[r, c].x;


            pnn.y1 = Lmatrix_up[r, c].y;
            pnn.y2 = Lmatrix_down[r, c].y;

            Lline.Add(pnn);

            
        }

        void createimage()
        {
            advImg pnn=new advImg();
            pnn.img = new Bitmap("2.bmp");
            pnn.x = 500;
            pnn.y = 100;
            pnn.w= 30;
            pnn.h= 300;
            pnn.DST=new Rectangle(pnn.x,pnn.y,pnn.h,pnn.w);
            pnn.SRC=new Rectangle(pnn.x,pnn.y,pnn.h,pnn.w);
            Ladvimg.Add(pnn);

            pnn = new advImg();
            pnn.img = new Bitmap("2.bmp");
            pnn.x = 500;
            pnn.y = 200;
            pnn.w = 30;
            pnn.h = 300;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.h, pnn.w);
            pnn.SRC = new Rectangle(pnn.x, pnn.y, pnn.h, pnn.w);
            Ladvimg.Add(pnn);


        }
    }
}
