using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice4_adv
{
    public partial class Form1 : Form
    {
        public class advimag
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public Rectangle DST;
            public Rectangle SRC;
            public Bitmap img;

        }
        public class recs
        {
            public int x;
            public int y;
            public int w;
            public int h;
        }
        List<recs>Lrecs = new List<recs>();
        List<advimag> Limgs=new List<advimag>();

        Bitmap off;
        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                moverecsright();
                drawdubb(this.CreateGraphics());

            }
            if (e.KeyCode == Keys.Left)
            {
                moverecsleft();
                drawdubb(this.CreateGraphics());

            }
            if (e.KeyCode == Keys.Up)
            {
                
                movephotoup();

                drawdubb(this.CreateGraphics());
            }
            if (e.KeyCode == Keys.Down)
            {
                movephotodown();

                drawdubb(this.CreateGraphics());
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createrecs();
            createphoto();
        }
        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p=new Pen(Color.Green,2);

            for(int i=0;i<Lrecs.Count;i++)
            {
                recs ptrav= Lrecs[i];
                g2.DrawRectangle(p, ptrav.x, ptrav.y, ptrav.w,ptrav.h);
            }

            for(int i=0;i<Limgs.Count;i++)
            {
                advimag ptrav = Limgs[i];
                g2.DrawImage(ptrav.img,ptrav.DST,ptrav.SRC,GraphicsUnit.Pixel);
            }
        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }
        void moverecsright()
        {
            for (int i = 0; i < Lrecs.Count; i++)
            {
                recs ptrav = Lrecs[i];
                ptrav.x += 10;
                Limgs[i].DST.X += 10;

            }
        }
        void moverecsleft()
        {
            for (int i = 0; i < Lrecs.Count; i++)
            {
                recs ptrav = Lrecs[i];
                ptrav.x -= 10;
                Limgs[i].DST.X -= 10;
            }
        }

        void createrecs()
        {
            //1 left
            recs pnn = new recs();

            pnn.x = 200;
            pnn.y = 200;
            pnn.w = 50;
            pnn.h = 350;
            Lrecs.Add(pnn);

            //2 left
            pnn = new recs();

            pnn.x = 300;
            pnn.y = 220;
            pnn.w = 50;
            pnn.h = 300;
            Lrecs.Add(pnn);

            //3 left
            pnn = new recs();

            pnn.x = 400;
            pnn.y = 240;
            pnn.w = 50;
            pnn.h = 250;
            Lrecs.Add(pnn);

            //4 left
            pnn = new recs();

            pnn.x = 500;
            pnn.y = 260;
            pnn.w = 50;
            pnn.h = 200;
            Lrecs.Add(pnn);

            //5 left
            pnn = new recs();

            pnn.x = 600;
            pnn.y = 280;
            pnn.w = 50;
            pnn.h = 150;
            Lrecs.Add(pnn);

            //6 left
            pnn = new recs();

            pnn.x = 700;
            pnn.y = 300;
            pnn.w = 50;
            pnn.h = 100;
            Lrecs.Add(pnn);

            //6 right
            pnn = new recs();

            pnn.x = 800;
            pnn.y = 300;
            pnn.w = 50;
            pnn.h = 100;
            Lrecs.Add(pnn);

            //5 right
            pnn = new recs();

            pnn.x = 900;
            pnn.y = 280;
            pnn.w = 50;
            pnn.h = 150;
            Lrecs.Add(pnn);

            //4 right
            pnn = new recs();

            pnn.x = 1000;
            pnn.y = 260;
            pnn.w = 50;
            pnn.h = 200;
            Lrecs.Add(pnn);

            //3 right
            pnn = new recs();

            pnn.x = 1100;
            pnn.y = 240;
            pnn.w = 50;
            pnn.h = 250;
            Lrecs.Add(pnn);

            //2 right
            pnn = new recs();

            pnn.x = 1200;
            pnn.y = 220;
            pnn.w = 50;
            pnn.h = 300;
            Lrecs.Add(pnn);

            //1 right
            pnn = new recs();

            pnn.x = 1300;
            pnn.y = 210;
            pnn.w = 50;
            pnn.h = 350;
            Lrecs.Add(pnn);
        }



        void createphoto()
        {
            advimag pnn =new advimag();

            pnn.x = 200;
            pnn.y = 200;
            pnn.w = 50;
            pnn.h= 350;
            pnn.DST = new Rectangle(pnn.x,pnn.y,pnn.w,pnn.h);
            pnn.SRC = new Rectangle(0,0,pnn.w,pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 300;
            pnn.y = 220;
            pnn.w = 50;
            pnn.h = 300;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(50, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 400;
            pnn.y = 240;
            pnn.w = 50;
            pnn.h = 250;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(100, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 500;
            pnn.y = 260;
            pnn.w = 50;
            pnn.h = 200;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(150, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 600;
            pnn.y = 280;
            pnn.w = 50;
            pnn.h = 150;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(200, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 700;
            pnn.y = 300;
            pnn.w = 50;
            pnn.h = 100;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(250, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 800;
            pnn.y = 300;
            pnn.w = 50;
            pnn.h = 100;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(300, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 900;
            pnn.y = 280;
            pnn.w = 50;
            pnn.h = 150;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(350, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 1000;
            pnn.y = 260;
            pnn.w = 50;
            pnn.h = 200;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(400, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 1100;
            pnn.y = 240;
            pnn.w = 50;
            pnn.h = 250;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(450, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 1200;
            pnn.y = 220;
            pnn.w = 50;
            pnn.h = 300;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(500, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);

            pnn = new advimag();

            pnn.x = 1300;
            pnn.y = 200;
            pnn.w = 50;
            pnn.h = 350;
            pnn.DST = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.SRC = new Rectangle(550, 0, pnn.w, pnn.h);
            pnn.img = new Bitmap("1.png");
            Limgs.Add(pnn);




        }

        void movephotoup()
        {
            for (int i = 0; i < Limgs.Count; i++)
            {
                advimag pnn = Limgs[i];
                pnn.SRC.Y -= 10;


            }
        }

        void movephotodown()
        {
            for (int i = 0; i < Limgs.Count; i++)
            {
                advimag pnn = Limgs[i];
                pnn.SRC.Y += 10;


            }
        }
        
    }
}
