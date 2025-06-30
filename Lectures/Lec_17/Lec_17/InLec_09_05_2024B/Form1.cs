using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InLec_09_05_2024B
{
    public class CAdvImgActor
    {
        public Bitmap wrld;
        public Rectangle rcDst, rcSrc;
    }

    public class CActor
    {
        public int X, Y;
        public int W, H;
    }
    public partial class Form1 : Form
    {
        Bitmap off;
        List<CAdvImgActor> LActs = new List<CAdvImgActor>();
        List<CActor> LRects = new List<CActor>();

        bool isDrag = false;
        int xOld = -1;
        int yOld = -1;

        bool isDragRect = false;
        int xOldRect = -1;
        int yOldRect = -1;

        Rectangle currentRect = new Rectangle(-1, -1, -1, -1);
        public Form1()
        {
            this.Size = new Size(600, 400);
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;

            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            xOld = -1;
            yOld = -1;


            if (isDragRect)
            {
                CActor pnn = new CActor();
                pnn.X = currentRect.X + LActs[0].rcSrc.X;
                pnn.Y = currentRect.Y + LActs[0].rcSrc.Y;
                pnn.W = currentRect.Width;
                pnn.H = currentRect.Height;
                LRects.Add(pnn);

            }
            isDragRect = false;
            xOldRect = -1;
            yOldRect = -1;
            currentRect.X = -1;

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                int dx = (e.X - xOld);
                int dy = (e.Y - yOld);
                this.Text = "dx = " + dx + " dy =  " + dy;
                int xa = LActs[0].rcSrc.X + dx + LActs[0].rcSrc.Width;
                int ya = LActs[0].rcSrc.Y + dy + LActs[0].rcSrc.Height;


                /////////////////////
                if (dx > 0)
                {
                    if (xa <= LActs[0].wrld.Width)
                        LActs[0].rcSrc.X += dx;
                }
                /////////////////////////////////
                if (dx < 0)
                {
                    if ((LActs[0].rcSrc.X + dx) >= 0)
                        LActs[0].rcSrc.X += dx;
                }
                /////////////////////////////////////
                if (dy > 0)
                {
                    if (ya <= LActs[0].wrld.Height)
                        LActs[0].rcSrc.Y += dy;
                }
                //////////////////////////////////////
                if (dy < 0)
                {
                    if ((LActs[0].rcSrc.Y + dy) >= 0)
                        LActs[0].rcSrc.Y += dy;
                }
                ////////////////////

                xOld = e.X;
                yOld = e.Y;

                DrawDubb(this.CreateGraphics());
            }

            if (isDragRect)
            {
                int dx = (e.X - xOldRect);
                int dy = (e.Y - yOldRect);

                currentRect.Width += dx;
                currentRect.Height += dy;

                xOldRect = e.X;
                yOldRect = e.Y;

                DrawDubb(this.CreateGraphics());
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
                xOld = e.X;
                yOld = e.Y;
            }
            else
            {
                isDragRect = true;
                currentRect = new Rectangle(e.X, e.Y, 1, 1);
                xOldRect = e.X;
                yOldRect = e.Y;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int xa = LActs[0].rcSrc.X + 5 + LActs[0].rcSrc.Width;
            int ya = LActs[0].rcSrc.Y + 5 + LActs[0].rcSrc.Height;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (xa <= LActs[0].wrld.Width)
                        LActs[0].rcSrc.X += 5;
                    break;
                case Keys.Left:
                    if ((LActs[0].rcSrc.X - 5) >= 0)
                        LActs[0].rcSrc.X -= 5;
                    break;
                case Keys.Down:
                    if (ya <= LActs[0].wrld.Height)
                        LActs[0].rcSrc.Y += 5;
                    break;
                case Keys.Up:
                    if ((LActs[0].rcSrc.Y - 5) >= 0)
                        LActs[0].rcSrc.Y -= 5;
                    break;

            }

            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            CreateIt();
        }

        void CreateIt()
        {
            CAdvImgActor pnn = new CAdvImgActor();
            pnn.wrld = new Bitmap("118346.bmp");
            pnn.rcSrc = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            pnn.rcDst = new Rectangle(0, 0, ClientSize.Width, ClientSize.Height);
            LActs.Add(pnn);
        }

        void DrawScene(Graphics g)
        {
            //g.Clear(Color.Black);
            for (int i = 0; i < LActs.Count; i++)
            {
                CAdvImgActor ptrav = LActs[i];
                g.DrawImage(ptrav.wrld, ptrav.rcDst, ptrav.rcSrc, GraphicsUnit.Pixel);
            }

            int XS = LActs[0].rcSrc.X;
            int YS = LActs[0].rcSrc.Y;

            Pen Pn = new Pen(Color.White, 5);
            for (int i = 0; i < LRects.Count; i++)
            {
                CActor ptrav = LRects[i];
                g.DrawRectangle(Pn, ptrav.X - XS, ptrav.Y - YS, ptrav.W, ptrav.H);
            }

            if (currentRect.X != -1)
                g.DrawRectangle(Pn, currentRect);

        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
