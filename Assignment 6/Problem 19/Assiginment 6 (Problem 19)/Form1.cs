using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assiginment_6__Problem_19_
{
    public partial class Form1 : Form
    {
        public class grass
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx = 1;
            public int dy;
            public int iframes;

            public List<Bitmap> Grass_imgs = new List<Bitmap>();
        }
        public class helicopter
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx = 1;
            public int dy;
            public int iframes;
            public List<Bitmap> heli_imgs = new List<Bitmap>();
            public birds carriedbird = null;
        }
        public class birds
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx = 1;
            public int dy;
            public int iframes;
            public List<Bitmap> bird_imgs = new List<Bitmap>();
        }

        List<grass> Lgrass = new List<grass>();
        List<helicopter> Lheli = new List<helicopter>();
        List<birds> Lbirds = new List<birds>();
        List<birds> selectedBirds = new List<birds>();



        
        Bitmap off;
        
        Timer tt = new Timer();
        public Form1()
        {

            this.KeyDown += Form1_KeyDown;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            WindowState = FormWindowState.Maximized;
            tt.Tick += Tt_Tick;
            tt.Start();

        }

        private void Tt_Tick(object sender, EventArgs e)
        {

            moveGrass();
            movebirds();
            helicopter heli = Lheli[0];
            int next_bird = -20;

            for (int i = 0; i < selectedBirds.Count; i++)
            {
                birds b = selectedBirds[i];
                b.x = heli.x + next_bird;
                b.y = heli.y + heli.height + 80;
                next_bird += 40;
            }
            drawDouble(this.CreateGraphics());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createbirds();
            creategrass();
            createhelicopter();


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawDouble(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Lheli[0].y -= 10;

                drawDouble(this.CreateGraphics());
            }

            if (e.KeyCode == Keys.Down)
            {
                Lheli[0].y += 10;

                drawDouble(this.CreateGraphics());
            }

            if (e.KeyCode == Keys.Left)
            {
                Lheli[0].x -= 10;
                drawDouble(this.CreateGraphics());
            }

            if (e.KeyCode == Keys.Right)
            {
                Lheli[0].x += 10;
                drawDouble(this.CreateGraphics());
            }
            if (e.KeyCode == Keys.Space)
            {
                helicopter heli = Lheli[0];

                for (int i = 0; i < Lbirds.Count; i++)
                {
                    birds b = Lbirds[i];

                    
                    if (
                        (heli.x >= b.x - 100 && heli.x <= b.x + 100) &&
                        (heli.y >= b.y - 100 && heli.y <= b.y + 100)
                       )
                    {
                        
                        bool found = false;

                        for (int j = 0; j < selectedBirds.Count; j++)
                        {
                            if (selectedBirds[j] == b)
                            {
                                found = true;
                                break;
                            }
                        }

                        
                        if (found == false)
                        {
                            b.iframes = 1;
                            selectedBirds.Add(b);
                        }
                    }
                }

                    drawDouble(this.CreateGraphics());

            }
        }

        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.LimeGreen);

            for (int i = 0; i < Lgrass.Count; i++)
            {
                grass ptrav = Lgrass[i];
                g2.DrawImage(ptrav.Grass_imgs[ptrav.iframes], ptrav.x, ptrav.y);

            }

            for (int i = 0; i < Lheli.Count; i++)
            {
                helicopter ptrav = Lheli[i];
                g2.DrawImage(ptrav.heli_imgs[ptrav.iframes], ptrav.x, ptrav.y);
            }
            for (int i = 0; i < Lbirds.Count; i++)
            {
                birds ptrav = Lbirds[i];
                g2.DrawImage(ptrav.bird_imgs[ptrav.iframes], ptrav.x, ptrav.y);
            }

        }
        void drawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createhelicopter()
        {
            helicopter pnn = new helicopter();
            pnn.heli_imgs = new List<Bitmap>();
            Bitmap Pimg = new Bitmap("1.bmp");

            Pimg.MakeTransparent(Pimg.GetPixel(0, 0));
            pnn.heli_imgs.Add(Pimg);

            pnn.x = (this.ClientSize.Width / 2) - 100;
            pnn.y = 100;
            Lheli.Add(pnn);

        }

        void creategrass()
        {
            for (int i = 0; i < 6; i++)
            {


                grass pnn = new grass();
                pnn.Grass_imgs = new List<Bitmap>();
                Bitmap Pimg = new Bitmap("2.bmp");

                pnn.Grass_imgs.Add(Pimg);

                pnn.x = 270 * i;
                pnn.y = (this.ClientSize.Height / 2) + 300;
                Lgrass.Add(pnn);
            }

        }
        void createbirds()
        {
            for (int i = 0; i < 4; i++)
            {
                birds pnn = new birds();
                pnn.bird_imgs = new List<Bitmap>();
                Bitmap Pimg = new Bitmap("3.bmp");
                Pimg.MakeTransparent(Pimg.GetPixel(0, 0));
                pnn.bird_imgs.Add(Pimg);


                Pimg = new Bitmap("4.bmp");
                Pimg.MakeTransparent(Pimg.GetPixel(0, 0));
                pnn.bird_imgs.Add(Pimg);
                pnn.iframes = 0;
                pnn.x = 270 * (i + 1);
                pnn.y = (this.ClientSize.Height / 2) + 250;
                Lbirds.Add(pnn);
            }
        }

        void moveGrass()
        {
            for (int i = 1; i < Lgrass.Count - 1; i++)
            {
                grass ptrav = Lgrass[i];
                ptrav.x += 5 * ptrav.dx;
                if (ptrav.x + ptrav.Grass_imgs[0].Height >= 1300)
                {
                    ptrav.dx = -1;

                }
                if (ptrav.x + ptrav.Grass_imgs[0].Height <= 100)
                {
                    ptrav.dx = 1;

                }

            }

        }
        void movebirds()
        {
            for (int i = 0; i < Lbirds.Count; i++)
            {
                birds ptrav = Lbirds[i];
                ptrav.x += 5 * ptrav.dx;
                if (ptrav.x + ptrav.bird_imgs[0].Height >= 1300)
                {
                    ptrav.dx = -1;

                }
                if (ptrav.x + ptrav.bird_imgs[0].Height <= 100)
                {
                    ptrav.dx = 1;

                }

            }
        }
    }
}

