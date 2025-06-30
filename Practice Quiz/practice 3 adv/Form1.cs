using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice_3_adv
{
    public partial class Form1 : Form
    {
        public class advImg
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int dx;
            public Rectangle rdst;
            public Rectangle rsrc;
            public Bitmap img;
        }
        public class basket
        {
            public int x1;
            public int y1;
            public int w;
            public int h;
            public int x2;
            public int y2;


        }
        List<basket> Lbasket = new List<basket>();
        List<advImg> Limgs = new List<advImg>();


        Bitmap off;
        int ct_tick = 0;
        Timer tt = new Timer();
        int lasty = 0;
        int flag = 0;
        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            WindowState = FormWindowState.Maximized;
            this.KeyDown += Form1_KeyDown;

            tt.Tick += Tt_Tick;
            tt.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < Limgs.Count; i++)
                {

                    advImg pnn = Limgs[i];
                    if (pnn.dx != 0)
                    {

                        pnn.x += 10;
                        pnn.rdst.X = pnn.x;
                       
                    }
                    
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < Limgs.Count; i++)
                {
                    advImg pnn = Limgs[i];
                    if (pnn.dx != 0)
                    {

                        pnn.x -= 10;
                        pnn.rdst.X = pnn.x;
                    }
                }
            }

            if (e.KeyCode == Keys.D)
            {
                movebasketright();
            }
            if (e.KeyCode == Keys.A)
            {
                movebasketleft();
            }
            if (e.KeyCode == Keys.W)
            {
                movebasketup();
            }
            if (e.KeyCode == Keys.S)
            {
                movebasketdown();
            }
        }

        private void Tt_Tick(object sender, EventArgs e)
        {

            if (ct_tick % 30 == 0)
            {
                createphoto();
            }
            movephoto();
           
            if(flag==1)
            {
                tt.Stop();

            }
            else
            {
                validation();
                
            }
                ct_tick++;
            drawdubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            //createphoto();
            lastpieceofphoto();
            createbasket();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.White);
            Pen p = new Pen(Color.Red, 5);

            for (int i = 0; i < Limgs.Count; i++)
            {
                advImg pnn = Limgs[i];
                g2.DrawImage(pnn.img, pnn.rdst, pnn.rsrc, GraphicsUnit.Pixel);
            }

            for (int i = 0; i < Lbasket.Count; i++)
            {
                basket ptrav = Lbasket[i];
                g2.DrawLine(p, ptrav.x1, ptrav.y1, ptrav.x2, ptrav.y2);
            }
        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createphoto()
        {
            lasty -= 50;
            advImg pnn = new advImg();

            pnn.x = this.ClientSize.Width / 2;
            pnn.y = 0;
            pnn.w = 500;
            pnn.h = 50;
            pnn.rdst = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.rsrc = new Rectangle(0, lasty, 500, 50);
            pnn.img = new Bitmap("2.png");
            pnn.dx = 1;
            Limgs.Add(pnn);
        }

        void movephoto()
        {
            for (int i = 1; i < Limgs.Count; i++)
            {
                advImg pnn = Limgs[i];
                pnn.y += 5 * pnn.dx;
                pnn.rdst.Y = pnn.y;
                if (pnn.y + pnn.h >= Limgs[i - 1].y)
                {
                    pnn.dx = 0;
                }

            }
        }

        void lastpieceofphoto()
        {
            advImg pnn = new advImg();

            pnn.x = this.ClientSize.Width / 2;
            pnn.y = 400;
            pnn.w = 500;
            pnn.h = 50;
            pnn.rdst = new Rectangle(pnn.x, pnn.y, pnn.w, pnn.h);
            pnn.rsrc = new Rectangle(0, 400, 500, 50);
            pnn.img = new Bitmap("2.png");
            pnn.dx = 0;
            lasty = 400;
            Limgs.Add(pnn);
        }

        void createbasket()
        {
            basket pnn = new basket();

            pnn.x1 = 200;
            pnn.x2 = 200;
            pnn.y1 = 700;
            pnn.y2 = 750;

            Lbasket.Add(pnn);

            pnn = new basket();

            pnn.x1 = 700;
            pnn.x2 = 700;
            pnn.y1 = 700;
            pnn.y2 = 750;

            Lbasket.Add(pnn);

            pnn = new basket();

            pnn.x1 = 200;
            pnn.x2 = 700;
            pnn.y1 = 750;
            pnn.y2 = 750;

            Lbasket.Add(pnn);

        }

        void movebasketright()
        {
            for (int i = 0; i < Lbasket.Count; i++)
            {
                basket ptrav = Lbasket[i];
                ptrav.x1 += 20;
                ptrav.x2 += 20;

            }
        }

        void movebasketleft()
        {
            for (int i = 0; i < Lbasket.Count; i++)
            {
                basket ptrav = Lbasket[i];
                ptrav.x1 -= 20;
                ptrav.x2 -= 20;

            }
        }

        void movebasketup()
        {
            for (int i = 0; i < Lbasket.Count; i++)
            {
                basket ptrav = Lbasket[i];

                ptrav.y1 -= 20;
                ptrav.y2 -= 20;
            }
        }
        void movebasketdown()
        {
            for (int i = 0; i < Lbasket.Count; i++)
            {
                basket ptrav = Lbasket[i];

                ptrav.y1 += 20;
                ptrav.y2 += 20;
            }
        }

        void validation()
        {
            bool allSameX = true;
            if (Limgs.Count > 0)
            {
                int x0 = Limgs[0].x;
                for (int j = 1; j < Limgs.Count; j++)
                {
                    if (Limgs[j].x != x0)
                    {
                        allSameX = false;
                        break;
                    }
                }
            }
            else
            {
                allSameX = false;
            }

            bool messageShown = false;
            for (int i=0;i<Lbasket.Count; i++)
            {
                basket pnn = Lbasket[i];
                for(int j=0;j<Limgs.Count; j++)
                {
                    advImg pnn2 = Limgs[j];
                    if (pnn.x1 <= pnn2.x + pnn2.w && pnn.x2 >= pnn2.x && pnn.y1 <= pnn2.y + pnn2.h && pnn.y2 >= pnn2.y&&allSameX)
                    {
                        flag = 1;
                        MessageBox.Show("You Win!");
                        messageShown = true;

                    }
                    else if (pnn.x1 <= pnn2.x + pnn2.w && pnn.x2 >= pnn2.x && pnn.y1 <= pnn2.y + pnn2.h && pnn.y2 >= pnn2.y && !allSameX)
                    {
                       
                        flag = 1;
                        MessageBox.Show("You Lose! Try Again!");
                        messageShown = true;
                        
                    }

                }
                

            }


            
        }
    }
}
