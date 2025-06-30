using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_6__problem_17_
{
    public partial class Form1: Form
    {
        public class stars
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx;
            public int dy=1;
            public int iframes;
            public List<Bitmap>Lstars_imgs=new List<Bitmap>();

        }
        public class rocket
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx;
            public int dy=1;
            public int iframes;
            public List<Bitmap> Lrocket_imgs = new List<Bitmap>();

        }
        public class laser
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx;
            public int dy = 1;
            public int iframes;
            
        }
        List<laser> Llaser = new List<laser>();
        List<stars> Lstars = new List<stars>();
        List<rocket> Lrocket = new List<rocket>();
        Bitmap off;
        Timer tt= new Timer();
        int ct_tick = 0;

        int ct = 0;
        int ct_stars = 0;
        Color cl = Color.Yellow;
        public Form1()
        {
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;

            tt.Tick += Tt_Tick;
            tt.Start();
        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            if(ct_tick % 15 == 0)
            {
                createStars();
            }

            movestars();
            killstar();


            ct_tick++;
            DrawDouble(this.CreateGraphics());

            Llaser.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            craeteRocket();
            createStars();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {

                createLaser();
                ct_stars++;
                if (ct_stars % 2 == 0)
                {
                    cl = Color.Red;
                }
                else
                {
                    cl = Color.Yellow;
                }
                DrawDouble(this.CreateGraphics());
            }

            if(e.KeyCode == Keys.Right)
            {
                Lrocket[0].x += 10;
                DrawDouble(this.CreateGraphics());
            }

            if(e.KeyCode == Keys.Left)
            {
                Lrocket[0].x-=10;
                DrawDouble(this.CreateGraphics());
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDouble(e.Graphics);
        }

        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p = new Pen(cl,4);
            for (int i=0;i< Lstars.Count; i++)
            {
                stars ptrav = Lstars[i];
                g2.DrawImage(ptrav.Lstars_imgs[0], ptrav.x, ptrav.y);
            }
            for (int i = 0; i < Lrocket.Count; i++)
            {
                rocket ptrav=Lrocket[i];
                g2.DrawImage(ptrav.Lrocket_imgs[ptrav.iframes],ptrav.x,ptrav.y);
            }
            for (int i = 0; i < Llaser.Count; i++)
            {


                laser ptrav = Llaser[i];
                g2.DrawLine(p, ptrav.x, ptrav.y, ptrav.x, ptrav.y - 500);

                



            }
        }
        void DrawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createStars()
        {
            Random rr = new Random();


            stars pnn = new stars();
            pnn.Lstars_imgs = new List<Bitmap>();
            Bitmap pImg = new Bitmap("2.bmp");
            pImg.MakeTransparent(pImg.GetPixel(0, 0));
            pnn.Lstars_imgs.Add(pImg);
            pnn.x = rr.Next(0, this.ClientSize.Width-100);
            pnn.y = rr.Next(0, pnn.Lstars_imgs[0].Height+50);
            pnn.width = pImg.Width;  //3ashan n kill el stars using el laser
            pnn.height = pImg.Height;
            Lstars.Add(pnn);
        }
        void craeteRocket()
        {
            rocket pnn = new rocket();
            pnn.Lrocket_imgs = new List<Bitmap>();
            Bitmap pImg = new Bitmap("1.bmp");
            pImg.MakeTransparent(pImg.GetPixel(0, 0));
            pnn.Lrocket_imgs.Add(pImg);
            pnn.x = this.ClientSize.Width / 2;
            pnn.y = this.ClientSize.Height-200;
            Lrocket.Add(pnn);

        }

        void movestars()
        {
            for (int i = 0; i < Lstars.Count; i++) 
            {
                stars ptrav = Lstars[i];
                ptrav.y += 5*ptrav.dy;

            }


            

        }

        void createLaser()
        {
          

            laser pnn = new laser();
            pnn.x = Lrocket[0].x + (Lrocket[0].Lrocket_imgs[0].Width / 2); 
            pnn.y = Lrocket[0].y; 
            
            Llaser.Add(pnn);
        }
        
        void killstar()
        {
            for (int i = Llaser.Count - 1; i >= 0; i--)
            {
                laser l = Llaser[i];

                for (int j = Lstars.Count - 1; j >= 0; j--)
                {
                    stars s = Lstars[j];

                    
                    if (l.x >= s.x && l.x <= s.x + s.width &&
                        l.y >= s.y && l.y - 500 <= s.y + s.height)
                    {

                        Lstars.RemoveAt(j);

                        
                        break; 
                    }
                }
            }
        }
    }
}
