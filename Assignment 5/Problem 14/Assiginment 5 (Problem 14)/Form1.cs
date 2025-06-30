using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assiginment_5_Problem_14
{
    public partial class Form1 : Form
    {
        public class CMultipleImgActor
        {
            public int x;
            public int y;
            public List<Bitmap> hero_imgs;
            public int iframes;
            public int dy = 1;
        }

        public class rectangles
        {
            public int x;
            public int y;
            public int w;
            public int h;

        }
        public class eggs
        {
            public int x;
            public int y;
            public List<Bitmap> eggimgs = new List<Bitmap>();
            public int iframes;
            public int dx = 1;
        }
        public class coins
        {
            public int x;
            public int y;
            public Bitmap coin_img;

        }
        Bitmap off;

        int f = 0;

        List<rectangles> cActors_rec = new List<rectangles>();
        List<Bitmap> imgs = new List<Bitmap>();
        List<CMultipleImgActor> LActs = new List<CMultipleImgActor>();
        List<eggs> egg = new List<eggs>();
        List<coins> Lcoins = new List<coins>();

        public Form1()
        {
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.WindowState = FormWindowState.Maximized;
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Random rr = new Random();
            for (int i = 0; i < Lcoins.Count; i++)
            {
                if (e.X >= Lcoins[i].x && e.X <= Lcoins[i].x + Lcoins[i].coin_img.Width
                    && e.Y >= Lcoins[i].y && e.Y <= Lcoins[i].y + Lcoins[i].coin_img.Height)
                {
                    f = 0;
                    eggs eg = new eggs();
                    eg.x = Lcoins[i].x;
                    if (Lcoins[i].y > 300)
                    {
                        eg.y = Lcoins[i].y - 200;
                    }
                    else
                    {
                        eg.y = Lcoins[i].y + 200;
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        Bitmap egg_pic = new Bitmap("e" + (j + 1) + ".bmp");
                        egg_pic.MakeTransparent(egg_pic.GetPixel(0, 0));
                        eg.eggimgs.Add(egg_pic);
                    }
                    egg.Add(eg);
                    if (Lcoins[i].x > 706)
                    {
                        Lcoins[i].x = rr.Next(0, 706);
                        eg.dx = -1;
                    }
                    else if (Lcoins[i].x < 706)
                    {
                        Lcoins[i].x = rr.Next(850, 1500);
                        eg.dx = 1;
                    }
                }
            }
            DrawDouble(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < LActs.Count; i++)
                {
                    LActs[i].iframes = 0;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                for (int i = 0; i < egg.Count; i++)
                {
                    egg[i].x += (egg[i].dx) * 5;

                    egg[i].iframes++;

                    if (egg[i].iframes > 2)
                    {
                        egg[i].iframes = 0;
                    }

                    if (egg[i].x >= cActors_rec[0].w && egg[i].x <= cActors_rec[2].x)
                    {
                        if (f == 0)
                        {
                            MessageBox.Show("one of eggs reaches mickey");
                            CreateCoins();
                            f = 1;
                            for (int k = egg.Count - 1; k >= 0; k--)
                            {
                                egg.RemoveAt(k);
                            }
                            break;

                        }
                    }



                }
                DrawDouble(this.CreateGraphics());
            }
            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < LActs.Count; i++)
                {
                    LActs[i].iframes = 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                for (int i = 0; i < LActs.Count; i++)
                {
                    LActs[i].iframes = 2;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < LActs.Count; i++)
                {
                    LActs[i].iframes = 3;
                }

            }
            DrawDouble(this.CreateGraphics());

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDouble(this.CreateGraphics());

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            off = new Bitmap(this.ClientSize.Width, ClientSize.Height);



            CreateHero();
            CreateRec();
            CreateEggs();
        }

        void Drawscene(Graphics g2)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.DarkRed);
            g2.Clear(Color.Orange);

            for (int i = 0; i < cActors_rec.Count; i++)
            {
                g2.FillRectangle(brush, cActors_rec[i].x, cActors_rec[i].y, cActors_rec[i].w, cActors_rec[i].h);
            }


            for (int j = 0; j < egg.Count; j++)
            {
                eggs ptrav = egg[j];

                g2.DrawImage(ptrav.eggimgs[ptrav.iframes], ptrav.x, ptrav.y);
            }



            for (int i = 0; i < LActs.Count; i++)
            {
                CMultipleImgActor ptrav = LActs[i];


                g2.DrawImage(ptrav.hero_imgs[ptrav.iframes], ptrav.x, ptrav.y);

            }

            for (int k = 0; k < Lcoins.Count; k++)
            {
                coins ptrav = Lcoins[k];
                Pen pp = new Pen(Color.Red, 3);
                g2.DrawImage(ptrav.coin_img, ptrav.x, ptrav.y);
                if (ptrav.y > 300)
                {
                    g2.DrawLine(pp, ptrav.x + ptrav.coin_img.Width / 2, ptrav.y, ptrav.x + ptrav.coin_img.Width / 2, 430);
                }
                else
                {
                    g2.DrawLine(pp, ptrav.x + ptrav.coin_img.Width / 2, ptrav.y + ptrav.coin_img.Height, ptrav.x + ptrav.coin_img.Width / 2, 350);
                }

            }

        }

        void DrawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drawscene(g2);
            g.DrawImage(off, 0, 0);

        }

        void CreateRec()
        {
            rectangles pnn;
            pnn = new rectangles();

            pnn.x = 0;
            pnn.y = 350;
            pnn.h = 30;
            pnn.w = 706;

            cActors_rec.Add(pnn);
            pnn = new rectangles();

            pnn.x = 0;
            pnn.y = 430;
            pnn.h = 30;
            pnn.w = 706;

            cActors_rec.Add(pnn);
            pnn = new rectangles();

            pnn.x = 850;
            pnn.y = 350;
            pnn.h = 30;
            pnn.w = 800;

            cActors_rec.Add(pnn);
            pnn = new rectangles();

            pnn.x = 850;
            pnn.y = 430;
            pnn.h = 30;
            pnn.w = 800;

            cActors_rec.Add(pnn);

        }

        void CreateHero()
        {

            CMultipleImgActor pnn = new CMultipleImgActor();

            pnn.hero_imgs = new List<Bitmap>();
            pnn.x = this.ClientSize.Width / 2 -30 ;
            pnn.y = this.ClientSize.Height / 2 -20 ;
            for (int j = 0; j < 4; j++)
            {
                Bitmap pic = new Bitmap((j + 1) + ".bmp");
                pic.MakeTransparent(pic.GetPixel(0, 0));
                pnn.hero_imgs.Add(pic);
            }
            pnn.iframes = 0;
            LActs.Add(pnn);

        }

        void CreateEggs()
        {
            Random RR = new Random();


            for (int i = 0; i < 4; i++)
            {
                eggs pnn = new eggs();

                pnn.eggimgs = new List<Bitmap>();

                if (i < 2)
                {
                    pnn.dx = 1;
                }
                else
                {
                    pnn.dx = -1;
                }




                for (int j = 0; j < 3; j++)
                {
                    Bitmap egg_pic = new Bitmap("e" + (j + 1) + ".bmp");
                    egg_pic.MakeTransparent(egg_pic.GetPixel(0, 0));
                    pnn.eggimgs.Add(egg_pic);
                }
                if (i == 0)
                {
                    pnn.y = 415;
                    pnn.x = RR.Next(0, 300);
                    egg.Add(pnn);
                }
                if (i == 1)
                {
                    pnn.y = 335;
                    pnn.x = RR.Next(0, 300);
                    egg.Add(pnn);
                }
                if (i == 2)
                {
                    pnn.y = 415;
                    pnn.x = RR.Next(1300, 1500);
                    egg.Add(pnn);
                }
                if (i == 3)
                {
                    pnn.y = 335;
                    pnn.x = RR.Next(1300, 1500);
                    egg.Add(pnn);
                }



                egg.Add(pnn);



            }

        }

        void CreateCoins()
        {
            Random RR = new Random();

            for (int i = 0; i < 4; i++)
            {
                coins pnn = new coins();
                //pnn.coin_img = new List<Bitmap>();



                Bitmap coin_pic = new Bitmap("c" + (i + 1) + ".bmp");
                coin_pic.MakeTransparent(coin_pic.GetPixel(0, 0));
                pnn.coin_img = coin_pic;


                if (i == 0)
                {
                    pnn.y = 615;
                    pnn.x = RR.Next(0, 300);


                }
                if (i == 1)
                {
                    pnn.y = 135;
                    pnn.x = RR.Next(0, 300);

                }
                if (i == 2)
                {
                    pnn.y = 615;
                    pnn.x = RR.Next(1300, 1500);

                }
                if (i == 3)
                {
                    pnn.y = 135;
                    pnn.x = RR.Next(1300, 1500);

                }
                Lcoins.Add(pnn);
            }
        }
    }
}