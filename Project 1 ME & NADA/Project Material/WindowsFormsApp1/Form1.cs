using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class Hero
        {
            public int x, y;
            public int w, h;
            public Bitmap hero_img;
        }
        public class fire
        {
            public int x, y;
            public int w, h;
            public Bitmap fire_img;
        }
        public class line
        {
            public int x1, y1;
            public int x2, y2;
            public int w, h;

        }

        public class heart
        {
            public int x, y;
            public int w, h;
            public Bitmap heart_img;
        }

        List<Hero> Lhero = new List<Hero>();
        List<fire> Lfire = new List<fire>();
        List<line> Llines = new List<line>();
        List<heart> Lhearts = new List<heart>();
        Bitmap off;
        Timer tt = new Timer();
        int fire_ct = 0;
        int fire_secs = 20;
        int ct_tick = 0;
        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            WindowState = FormWindowState.Maximized;
            this.KeyDown += Form1_KeyDown;

            tt.Tick += Tt_Tick;
            tt.Start();
            tt.Interval =1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                removeheart();
            }
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            //movefire();
            //
            //if (ct_tick%10==0)
            //{
            //
            //    createfire();
            //}
            //
            //
            //ct_tick++;
            drawdubb(this.CreateGraphics());


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            //createline();
            //createStaticHero();
            createHeart();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p = new Pen(Color.SaddleBrown, 9);


            for (int i = 0; i < Llines.Count; i++)
            {
                line pnn = Llines[i];
                g2.DrawLine(p, pnn.x1, pnn.y1, pnn.x2, pnn.y2);
            }

            for (int i = 0; i < Lhero.Count; i++)
            {
                Hero pnn = Lhero[i];
                g2.DrawImage(pnn.hero_img, pnn.x, pnn.y, pnn.w, pnn.h);
            }

            for(int i = 0; i < Lfire.Count; i++)
            {
                fire pnn = Lfire[i];
                g2.DrawImage(pnn.fire_img, pnn.x, pnn.y);
            }

            for (int i = 0; i < Lhearts.Count; i++)
            {
                heart pnn = Lhearts[i];
                g2.DrawImage(pnn.heart_img, pnn.x, pnn.y);
            }       

        }
        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createStaticHero()
        {
            Hero pnn = new Hero();

            pnn.x = (this.ClientSize.Width / 2) + 200;
            pnn.y = 150;
            pnn.hero_img = new Bitmap("1.png");
            pnn.hero_img.MakeTransparent(pnn.hero_img.GetPixel(0, 0));
            pnn.w = 150;
            pnn.h = 150;
            Lhero.Add(pnn);

        }

        void createline()
        {
            line pnn = new line();
            pnn.x1 = (this.ClientSize.Width / 2) + 220;
            pnn.y1 = 250;
            pnn.x2 = (this.ClientSize.Width / 2) + 320;
            pnn.y2 = 250;
            Llines.Add(pnn);
        }

        void createfire()
        {
            fire pnn = new fire();
            pnn.x= (this.ClientSize.Width / 2) + 255;
            pnn.y = 245;
            pnn.fire_img = new Bitmap("1Fire.bmp");
            pnn.fire_img.MakeTransparent(pnn.fire_img.GetPixel(0, 0));
            

            Lfire.Add(pnn);
        }

        void movefire()
        {
            for (int i = 0; i < Lfire.Count; i++)
            {
                fire pnn = Lfire[i];
                //pnn.x -= 5;
                pnn.y += 5;

                if (pnn.x > this.ClientSize.Width)
                {
                    Lfire.RemoveAt(i);
                    i--;
                }
            }
        }


        void createHeart()
        {
            heart pnn = new heart();

            pnn.x = 250;
            pnn.y = 10;
            pnn.heart_img = new Bitmap("heart_cactus_100x100.png");
            pnn.heart_img.MakeTransparent(pnn.heart_img.GetPixel(0, 0));

            Lhearts.Add(pnn);

            heart pnn2 = new heart();

            pnn2.x = 200;
            pnn2.y = 10;
            pnn2.heart_img = new Bitmap("heart_cactus_100x100.png");
            pnn2.heart_img.MakeTransparent(pnn2.heart_img.GetPixel(0, 0));

            Lhearts.Add(pnn2);

            heart pnn3 = new heart();

            pnn3.x = 150;
            pnn3.y = 10;
            pnn3.heart_img = new Bitmap("heart_cactus_100x100.png");
            pnn3.heart_img.MakeTransparent(pnn3.heart_img.GetPixel(0, 0));

            Lhearts.Add(pnn3);

            heart pnn4 = new heart();
            pnn4.x = 100;
            pnn4.y = 10;
            pnn4.heart_img = new Bitmap("heart_cactus_100x100.png");
            pnn4.heart_img.MakeTransparent(pnn4.heart_img.GetPixel(0, 0));

            Lhearts.Add(pnn4);

            heart pnn5 = new heart();
            pnn5.x = 50;
            pnn5.y = 10;
            pnn5.heart_img = new Bitmap("heart_cactus_100x100.png");
            pnn5.heart_img.MakeTransparent(pnn5.heart_img.GetPixel(0, 0));

            Lhearts.Add(pnn5);


        }

        void removeheart()
        {
            Lhearts.RemoveAt(Lhearts.Count-1);
        }
    }
}
