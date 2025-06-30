using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace avanced_image_quiz_2
{
    public partial class Form1 : Form
    {
        public class advancedImag
        {
            public int w;
            public int h;
            public int x;
            public int y;
            public Rectangle rsrc;
            public Rectangle rdest;
            public Bitmap img;
        }

        List<advancedImag> Limage = new List<advancedImag>();
        Bitmap off;
        int xold = 0;
        int yold = 0;
        int dx = 0;
        int dy = 0;
        bool isdrag = false;
        public Form1()
        {
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Paint += Form1_Paint;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isdrag = false;
            xold = 0;
            yold = 0;
            drawdubb(this.CreateGraphics());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isdrag==true)
            {
                dx = xold-e.X;
                dy = yold-e.Y;

                Limage[0].rsrc.X += dx;
                Limage[0].rsrc.Y += dy;

                xold = e.X;
                yold = e.Y;

            }
            drawdubb(this.CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            xold = e.X;
            yold = e.Y;
            isdrag = true;

            drawdubb(this.CreateGraphics());

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Limage[0].rsrc.Y -= 10;
            }
            else if (e.KeyCode == Keys.Down)
            {
                Limage[0].rsrc.Y += 10;
            }
            else if (e.KeyCode == Keys.Left)
            {
                Limage[0].rsrc.X -= 10;
            }
            else if (e.KeyCode == Keys.Right)
            {
                Limage[0].rsrc.X += 10;
            }

            drawdubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off= new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createiadvancedimge();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.White);

            for (int i = 0; i < Limage.Count; i++) 
            {
               advancedImag pnn = Limage[i];
               g2.DrawImage(pnn.img, pnn.rdest, pnn.rsrc, GraphicsUnit.Pixel);
            }
        }
        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createiadvancedimge()
        {
            advancedImag pnn = new advancedImag();

            pnn.img = new Bitmap("1.bmp");
            pnn.rdest= new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            pnn.rsrc= new Rectangle(0, 0, pnn.img.Width-500, pnn.img.Height-100);

            Limage.Add(pnn);
        }
    }
}
