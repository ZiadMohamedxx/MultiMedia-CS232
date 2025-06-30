using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assiginment_5__Problem_15_.Form1;

namespace Assiginment_5__Problem_15_
{
    public partial class Form1: Form
    {
        public baskets pos = null;
        public class chicken
        {
            public int x;
            public int y;
            public int dx=1;
            public int dy = 1;
            public int width;
            public int height;
            public Bitmap chicken_img;
        }
        public class baskets
        {
            public int x;
            public int y;
            public int dx = 1;
            public int dy = 1;
            public int width;
            public int height;
            public Bitmap basket_img;
            public List<eggs> eggs_count = new List<eggs>();
        }
        public class eggs
        {
            public int x;
            public int y;
            public int dx = 1;
            public int dy = 1;
            public int width;
            public int height;
            public Bitmap egg_img;
        }

        List<chicken> Lchickens = new List<chicken>();
        List<eggs> Leggs = new List<eggs>();
        List<baskets> Lbaskets = new List<baskets>();

        public int xold = 0;
        public int yold = 0;
        public bool isdragging = false;
        public int dx = 0;
        public int dy = 0;
        Bitmap off;

        public Form1()
        {
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.KeyDown += Form1_KeyDown;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CreateEgg();

            }

            if (e.KeyCode == Keys.Down)
            {
                for (int i = 0; i < Lchickens.Count; i++)
                {
                    Lchickens[i].y += 10;
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < Lchickens.Count; i++)
                {
                    Lchickens[i].y -= 10;
                }
            }

            if (e.KeyCode==Keys.Right)
            {
                for(int i = 0; i < Lchickens.Count; i++)
                {
                   Lchickens[i].x += 10;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < Lchickens.Count; i++)
                {
                    Lchickens[i].x -= 10;
                }
            }
            DrawDouble(this.CreateGraphics());
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isdragging = false;
            yold = 0;
            xold = 0;
            
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdragging == true && pos != null) 
            {
                dx = e.X - xold;
                dy = e.Y - yold;

                pos.x += dx;
                pos.y += dy;


                for(int i = 0; i < pos.eggs_count.Count; i++)
                {
                   pos.eggs_count[i].x += dx;
                   pos.eggs_count[i].y += dy;
                }

                xold = e.X;
                yold = e.Y;



                DrawDouble(this.CreateGraphics());
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            

            for (int i = 0; i < Lbaskets.Count; i++)
            {
                baskets b = Lbaskets[i];
                if (e.X >= b.x && e.X <= b.x + b.basket_img.Width &&
                    e.Y >= b.y && e.Y <= b.y + b.basket_img.Height)
                {
                    isdragging = true;
                    pos= b;
                    xold = e.X;   
                    yold = e.Y;
                    break;

                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDouble(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;

            off = new Bitmap(this.ClientSize.Width, ClientSize.Height);

            CreateChicken();
            CreateBasket();
        }

        void DrawScene(Graphics g2)
        {
            
            
            g2.Clear(Color.Black);

            for (int j = 0; j < Leggs.Count; j++)
            {
                eggs ptrav = Leggs[j];

                g2.DrawImage(ptrav.egg_img, ptrav.x, ptrav.y);
            }

            for (int j = 0; j < Lbaskets.Count; j++)
            {
                baskets ptrav = Lbaskets[j];

                g2.DrawImage(ptrav.basket_img, ptrav.x, ptrav.y);
                

            }

            for (int j = 0; j < Lchickens.Count; j++)
            {
                chicken ptrav = Lchickens[j];

                g2.DrawImage(ptrav.chicken_img, ptrav.x, ptrav.y);
                
            }
        }

        void DrawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);

        }

        void CreateChicken()
        {
            chicken pnn = new chicken();
            pnn.chicken_img = new Bitmap("1.bmp");
            pnn.x = ClientSize.Width/2;
            pnn.y = 100;
            pnn.chicken_img.MakeTransparent(pnn.chicken_img.GetPixel(0, 0));
            Lchickens.Add(pnn);
        }
        void CreateEgg()
        {
            eggs pnn = new eggs();
            pnn.egg_img = new Bitmap("3.bmp");
            pnn.x = Lchickens[0].x;
            int nos_el_chicken = Lchickens[0].x + Lchickens[0].chicken_img.Width / 2;
            pnn.y = 0;
            for (int i = 0; i < Lbaskets.Count; i++)
            {
                baskets b = Lbaskets[i];
                if (nos_el_chicken >= b.x && nos_el_chicken <= b.x + b.basket_img.Width)
                {
                    pnn.y = b.y + b.basket_img.Height/2;
                    b.eggs_count.Add(pnn);
                }
                
            }
            if(pnn.y==0)
            {
                pnn.y = ClientSize.Height - 20;
            }

            pnn.egg_img.MakeTransparent(pnn.egg_img.GetPixel(0, 0));

            Leggs.Add(pnn);


        }
        void CreateBasket()
        {
            

            int basex = (ClientSize.Width / 2) - 200;
            int y = 300;

            for (int i = 0; i < 3; i++)
            {
                baskets pnn = new baskets();
                pnn.basket_img = new Bitmap("2.bmp");
                pnn.basket_img.MakeTransparent(pnn.basket_img.GetPixel(0, 0));
              

                pnn.x = basex + i * 200;
                pnn.y = y+300;

                Lbaskets.Add(pnn);
            }
        }
    }
}
