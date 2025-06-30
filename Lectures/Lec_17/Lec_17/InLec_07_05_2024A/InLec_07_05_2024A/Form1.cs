using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InLec_07_05_2024A
{
    public class CAdvImgActor
    {
        public Bitmap wrdl;
        public Rectangle rcDst, rcSrc;
    }
    public partial class Form1 : Form
    {
        List<CAdvImgActor> LWnds = new List<CAdvImgActor>();
        Bitmap off;

        int cx = 400;
        int cy = 200;

        bool isDrag = false;
        int XOld = -1;
        int YOld = -1;
        int iCurrWnd = -1;

        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.KeyDown += Form1_KeyDown;
        }

        void ShiftThem()
        {
            CAdvImgActor p1 = LWnds[LWnds.Count - 1];
            Rectangle rcDstLast = p1.rcDst;
            Bitmap imgLast = p1.wrdl;

            for (int i= LWnds.Count - 2; i >= 0; i--)
            {
                CAdvImgActor pPrev  = LWnds[i];
                p1.rcDst            = pPrev.rcDst;
                p1.wrdl             = pPrev.wrdl;
                p1                  = pPrev;
            }
            LWnds[0].rcDst = rcDstLast;
            LWnds[0].wrdl  = imgLast;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (iCurrWnd != -1)
            {
                CAdvImgActor ptrav = LWnds[iCurrWnd];
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        ptrav.rcSrc.X += 5;
                        break;
                    case Keys.Left:
                        ptrav.rcSrc.X -= 5;
                        break;
                    case Keys.Space:
                        ShiftThem();
                        break;
                }

                DrawDubb(this.CreateGraphics());
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            XOld = -1;
            YOld = -1;
        }

        int isHit(int XM , int YM )
        {
            //for (int i=0; i < LWnds.Count; i++)
            for (int i = LWnds.Count-1; i >= 0; i--)
            {
                CAdvImgActor ptrav = LWnds[i];
                int X = ptrav.rcDst.X;
                int Y = ptrav.rcDst.Y;

                if (        XM >= X && XM <= (X+ptrav.rcDst.Width)  
                    &&      YM >= Y && YM <= (Y + ptrav.rcDst.Height)
                    )
                {
                    return i;
                }
            }
            return -1;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            iCurrWnd = isHit(e.X , e.Y);
            if (iCurrWnd != -1)
            {
                XOld = e.X;
                YOld = e.Y;
                isDrag = true;

                CAdvImgActor ptrav = LWnds[iCurrWnd];
                LWnds.RemoveAt(iCurrWnd);
                LWnds.Add(ptrav);
                iCurrWnd = LWnds.Count - 1;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag)
            {
                int dx = e.X - XOld;
                int dy = e.Y - YOld;


                CAdvImgActor ptrav = LWnds[iCurrWnd];
                ptrav.rcDst.X += dx;
                ptrav.rcDst.Y += dy;


                XOld = e.X;
                YOld = e.Y;
                DrawDubb(this.CreateGraphics());
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width , ClientSize.Height);
            CreateWnds();
        }

        void CreateWnds()
        {
            int XB = 50;
            int YB = 80;
            int Margin = 50;
            for (int i=0; i < 3; i++)
            {
                CAdvImgActor pnn = new CAdvImgActor();
                pnn.wrdl = new Bitmap((i%3+1)+".jpg");
                pnn.rcDst = new Rectangle(XB+(Margin*i),YB + (Margin * i), cx,cy);
                pnn.rcSrc= new Rectangle(0,0,cx,cy);
                LWnds.Add(pnn);
            }
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            Pen Pn = new Pen(Color.Yellow , 5);
            for (int i=0; i < LWnds.Count; i++)
            {
                CAdvImgActor ptrav = LWnds[i];
                g.DrawImage(ptrav.wrdl, ptrav.rcDst, ptrav.rcSrc, GraphicsUnit.Pixel);
                g.DrawRectangle(Pn, ptrav.rcDst);
            }

        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off,0,0);
        }
    }
}
