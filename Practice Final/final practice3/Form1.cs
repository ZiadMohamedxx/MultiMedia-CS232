using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_practice3
{
    public partial class Form1 : Form
    {
        public class advImg
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public Rectangle DST;
            public Rectangle SRC;
            public Bitmap img;
        }
        public class ellipse
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx;
            public int dy;

        }
        List<advImg> LadvImgs = new List<advImg>();
        List<ellipse>Lellipse=new List<ellipse>();
        Bitmap off;
        int xscroll = 5;
        int yscroll = 5;
        int pos_x=0;
        int pos_y=0;
        int ct = 0;
        int flag_jump = 0;
        Timer tt=new Timer();
        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            WindowState = FormWindowState.Maximized;
            this.KeyDown += Form1_KeyDown;

            tt.Tick += Tt_Tick;
            tt.Start();

        }

        private void Tt_Tick(object sender, EventArgs e)
        {
                //movebullet();
            //if (flag_jump == 1)
            {
                if (ct < 4)
                {


                    ct++;
                    LadvImgs[LadvImgs.Count - 1].DST.Y -= 5;


                }
                else
                {
                    if(ct<8)
                    {

                        LadvImgs[LadvImgs.Count - 1].DST.Y += 5;
                        ct++;
                    }
                    else
                    {
                        ct = 0;
                        flag_jump = 0;
                    }
                }
            }
            if (flag_jump == 1)
            {
                ct++;
                if (ct > 20)
                {
                    flag_jump = 0;
                    ct = 0;
                }
            }
            else
            {

                move();
            }

            drawdubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (pos_y < 300)
            {


                if (e.KeyCode == Keys.Down)
                {
                    LadvImgs[0].SRC.Y += yscroll;
                    pos_y += yscroll;
                }
            }
            if (pos_x > 0)
            {


                if (e.KeyCode == Keys.Left)
                {
                    LadvImgs[0].SRC.X -= xscroll;
                    pos_x-=xscroll;

                }
            }
            if (pos_x < 200)
            {


                if (e.KeyCode == Keys.Right)
                {
                    LadvImgs[0].SRC.X += xscroll;
                    pos_x+=xscroll;
                }
            }
            if (pos_y > 0)
            {


                if (e.KeyCode == Keys.Up)
                {
                    LadvImgs[0].SRC.Y -= yscroll;
                    pos_y-=yscroll;
                }
            }

            if(e.KeyCode == Keys.Space)
            {
                flag_jump = 1;
            }
            if(e.KeyCode==Keys.G)
            {
                //createEllipse();
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
            createimg();
            createhero();
            createEllipse2();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Brush brush = new SolidBrush(Color.Red);

            for(int i=0;i<LadvImgs.Count;i++)
            {
                advImg ptrav=LadvImgs[i];
                g2.DrawImage(ptrav.img, ptrav.DST, ptrav.SRC, GraphicsUnit.Pixel);
            }
            for(int i=0;i<Lellipse.Count;i++)
            {
                ellipse ptrav=Lellipse[i];
                g2.FillEllipse(brush, ptrav.x, ptrav.y, ptrav.width, ptrav.height);
            }
        }
        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createimg()
        {
            advImg pnn = new advImg();

            pnn.img = new Bitmap("1.png");
            pnn.x = 0;
            pnn.y = 0;
            pnn.width =this.ClientSize.Width;
            pnn.height = this.ClientSize.Height;

            pnn.DST = new Rectangle(pnn.x,pnn.y,pnn.width,pnn.height);
            pnn.SRC = new Rectangle(pnn.x,pnn.y,pnn.img.Width-200,pnn.img.Height-200);

            LadvImgs.Add(pnn);
        }

        void createhero()
        {
            advImg pnn = new advImg();

            pnn.img = new Bitmap("2.bmp");
            pnn.x = 200;
            pnn.y = 300;
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.width = this.ClientSize.Width;
            pnn.height = this.ClientSize.Height;

            pnn.DST = new Rectangle(pnn.x, pnn.y-100, 250, 250);
            pnn.SRC = new Rectangle(pnn.x+200, pnn.y, 200 , 250);

            LadvImgs.Add(pnn);
        }

        void createEllipse()
        {
            ellipse pnn=new ellipse();
            pnn.x = 200;
            pnn.y = 300;
            pnn.width = 50;
            pnn.height = 50;
            Lellipse.Add(pnn);
        }

        void movebullet()
        {
            for(int i=0;i<Lellipse.Count;i++)
            {
                ellipse pnn = Lellipse[i];
                pnn.x += 10;
            }
        }

        void createEllipse2()
        {
            ellipse pnn = new ellipse();
            pnn.x = 600;
            pnn.y = 300;
            pnn.width = 50;
            pnn.height = 50;
            pnn.dy = 1;
            pnn.dx = 0;
            Lellipse.Add(pnn);
        }
        void move()
        {
            for(int i=0;i< Lellipse.Count;i++)
            {
                ellipse pnn=Lellipse[i];
                
                pnn.y += 10*pnn.dy;
                
                if(pnn.y+pnn.height>=600||pnn.y+pnn.height<=50)
                {

                    flag_jump = 1;
                    pnn.dy *= -1;
                        
                }
            }
        }
    }
}
