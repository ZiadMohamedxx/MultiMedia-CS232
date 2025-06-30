using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_1_Practice
{

    public partial class Form1 : Form
    {

        public class balls
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int x_s;
            public int y_s;
            public string st;
            

        }
        public class lines
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int x2;
            public int y2;
        }

        public class hero
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int dx;
            public int dy;
            public Bitmap hero_img;
        }
        public class underline
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int x2;
            public int y2;
            public int dy;
            public int dx;
            
        }

        string s;
        List<balls> Lcircle = new List<balls>();
        List<lines>Llines = new List<lines>();
        List<hero>Lhero=new List<hero>();
        List<underline>Lunderline=new List<underline>();
        Bitmap off;
        Timer tt = new Timer();
        int xold = 0;
        int yold = 0;
        bool isdrag = false;
        int dx;
        int dy;

        public Form1()
        {
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            WindowState = FormWindowState.Maximized;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;

            tt.Start();
            tt.Tick += Tt_Tick;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdrag == true)
            {
                dx = xold - e.X;
                dy = yold - e.Y;

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isdrag = false;
            xold = 0;
            yold = 0;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            xold = e.X;
            yold = e.Y;
            isdrag = true;
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            movePlanes();

            moveUnderline();
            drawdubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            //createballs();
            createLine();
            createhero();
            createunderline();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Pink);
            

           

           /* Font f = new Font("Arial",15,FontStyle.Bold);
            for(int i=0;i<Lcircle.Count;i++)
            {
                balls ptrav = Lcircle[i];
                g2.FillEllipse(Brushes.Black,ptrav.x, ptrav.y, ptrav.w, ptrav.h);
                g2.DrawString(ptrav.st, f, Brushes.White, ptrav.x_s, ptrav.y_s);
            }*/
           Pen p=new Pen(Color.Black,6);
            for(int i=0;i<Llines.Count;i++)
            {
                lines ptrav = Llines[i];
                g2.DrawLine(p,ptrav.x,ptrav.y,ptrav.x2,ptrav.y2);

            }

            for(int i=0;i<Lhero.Count;i++)
            {
                hero ptrav = Lhero[i];
                g2.DrawImage(ptrav.hero_img,ptrav.x,ptrav.y,ptrav.w,ptrav.h);
            }

            for(int i=0;i<Lunderline.Count;i++)
            {
                underline ptrav = Lunderline[i];
                g2.DrawLine(p, ptrav.x, ptrav.y, ptrav.x2, ptrav.y2);

            }

        }

        void createballs()
        {
            for (int i = 0; i < 10;i++)
            {
                balls pnn =new balls();
                pnn.x = 100 + i * 200;
                pnn.y = this.ClientSize.Height / 2;
                pnn.w = 100;
                pnn.h = 100;
                pnn.x_s = pnn.x+pnn.w/2;
                pnn.y_s = pnn.y + pnn.h / 2;
                pnn.st = (i + 1).ToString();
                Lcircle.Add(pnn);

                


            }
        }

        void createLine()
        {
            lines pnn =new lines();

            pnn.x = this.ClientSize.Width/2;
            pnn.x2 = this.ClientSize.Width/2;
            pnn.y = 0;
            pnn.y2 = this.ClientSize.Height;

            Llines.Add(pnn);
        }

        void createhero()
        {
            hero pnn = new hero();
            pnn.hero_img = new Bitmap("1.bmp");
            pnn.hero_img.MakeTransparent(pnn.hero_img.GetPixel(0,0));
            pnn.x = 200;
            pnn.y = (this.ClientSize.Height / 2)-300;
            pnn.w = pnn.hero_img.Width;
            pnn.h = pnn.hero_img.Height;
            pnn.dx = 1;

            Lhero.Add(pnn);

            hero pnn2 = new hero();
            pnn2.hero_img = new Bitmap("1.bmp");
            pnn2.hero_img.MakeTransparent(pnn2.hero_img.GetPixel(0, 0));
            pnn2.x = (this.ClientSize.Width)-400;
            pnn2.y = (this.ClientSize.Height / 2) - 300;
            pnn2.w = pnn.hero_img.Width;
            pnn2.h = pnn.hero_img.Height;
            pnn2.dx = -1;

            Lhero.Add(pnn2);

        }

        void movePlanes()
        {

            for (int i = 0; i < Lhero.Count; i++)
            {
                hero pnn = Lhero[0];

                pnn.x += 10 * pnn.dx;
                if (pnn.x + pnn.hero_img.Width > this.ClientSize.Width / 2)
                {
                    pnn.dx = pnn.dx * -1;
                }

                if (pnn.x + pnn.hero_img.Width < 100)
                {

                    pnn.dx = pnn.dx * -1;
                }

                hero pnn2 = Lhero[1];

                pnn2.x += 10 * pnn2.dx;
                if (pnn2.x  < this.ClientSize.Width / 2)
                {
                    pnn2.dx = pnn2.dx * -1;
                }

                if (pnn2.x + pnn2.hero_img.Width > this.ClientSize.Width )
                {

                    pnn2.dx = pnn2.dx * -1;


                }
            }
        }

        void createunderline()
        {
            for (int i = 0; i < Lhero.Count; i++)
            {

                underline pnn = new underline();

                hero phero = Lhero[i];

                pnn.x = phero.x;
                pnn.x2 = phero.x;
                pnn.y = phero.hero_img.Height+phero.y;
                pnn.y2 = phero.hero_img.Height + phero.y + 200;
                pnn.dx = -1;

                Lunderline.Add(pnn);


                
            }
        }

        void moveUnderline()
        {
            for (int i = 0; i < Lunderline.Count; i++)
            {
                underline pnn = Lunderline[0];
                hero phero = Lhero[0];
                pnn.x += 10 * pnn.dx;
                pnn.x2 += 10 * pnn.dx;

                if (pnn.x  > (this.ClientSize.Width / 2) )
                {
                    pnn.dx = pnn.dx * -1;
                }

                if (pnn.x < 100)
                {

                    pnn.dx = pnn.dx * -1;
                }

                underline pnn2 = Lunderline[1];

                pnn2.x += 10 * pnn2.dx;
                pnn2.x2 += 10 * pnn2.dx;
                if (pnn2.x < this.ClientSize.Width / 2)
                {
                    pnn2.dx = pnn2.dx * -1;
                }

                if (pnn2.x  > this.ClientSize.Width)
                {

                    pnn2.dx = pnn2.dx * -1;


                }
            }
        }
    }
}
