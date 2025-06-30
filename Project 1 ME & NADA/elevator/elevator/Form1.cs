using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elevator
{
    public partial class Form1 : Form
    {
        public class elevator
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int dx = 1;
            public int dy = 1;
            public int iframes;
            public List<Bitmap> elevator_img;
        }
        public class face
        {
            public int x;
            public int y;
            public int width;
            public int height;

            public Bitmap face_img;
        }

        public class laser
        {
            public int x1;
            public int y1;
            public int width;
            public int height;
            public int x2;
            public int y2;
        }
        public class lines
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            public int width;
            public int height;
        }
        List<laser> Llaser = new List<laser>();
        List<lines> Llines = new List<lines>();
        List<face> Lface = new List<face>();
        List<elevator> Lelevator = new List<elevator>();

        Bitmap off;
        Timer tt = new Timer();
        int ct_tick = 0;
        int Flag = 0;
        int ct_elevator = 0;
        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            WindowState = FormWindowState.Maximized;

            tt.Tick += Tt_Tick;
            tt.Start();

        }

        private void Tt_Tick(object sender, EventArgs e)
        {

            //if (Flag == 0)
            //{
            //    moveelevator();
            //
            //}
            //else
            //{
            //    ct_elevator++;
            //    if (ct_elevator >= 40)
            //    {
            //        ct_elevator = 0;
            //        Flag = 0;
            //    }
            //}
            //
            //   
            //drawdubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            //createelevator();
            createface();
            createlines();
            createlaser();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.White);
            Pen pen = new Pen(Color.Black, 7);
            Pen pen_laser = new Pen(Color.Red, 10);
            //for(int i=0;i<Lelevator.Count;i++)
            //{
            //    elevator ptrav=Lelevator[i];
            //    g2.DrawImage(ptrav.elevator_img[ptrav.iframes], ptrav.x, ptrav.y);
            //
            //}

            for (int i = 0; i < Lface.Count; i++)
            {
                face ptrav = Lface[i];
                g2.DrawImage(ptrav.face_img, ptrav.x, ptrav.y);
            }
            for (int i = 0; i < Llines.Count; i++)
            {
                lines ptrav = Llines[i];
                g2.DrawLine(pen, ptrav.x1, ptrav.y1, ptrav.x2, ptrav.y2);
            }
            for(int i=0; i < Llaser.Count; i++)
            {
                laser ptrav = Llaser[i];
                g2.DrawLine(pen_laser, ptrav.x1, ptrav.y1, ptrav.x2, ptrav.y2);
            }
        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);

        }

        void createelevator()
        {
            elevator pnn = new elevator();
            pnn.x = this.ClientSize.Width / 2;
            pnn.elevator_img = new List<Bitmap>();
            for (int i = 0; i < 2; i++)
            {
                Bitmap img = new Bitmap((i + 1) + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                pnn.elevator_img.Add(img);
            }
            //pnn.elevator_img=new Bitmap("1.bmp");
            //pnn.elevator_img.MakeTransparent(pnn.elevator_img.GetPixel(0, 0));
            pnn.y = 500;

            Lelevator.Add(pnn);
        }

        void moveelevator()
        {

            for (int i = 0; i < Lelevator.Count; i++)
            {
                elevator pnn = Lelevator[i];

                pnn.y += pnn.dy * 10;

                if (pnn.y + pnn.elevator_img[i].Height >= this.ClientSize.Height)
                {
                    pnn.dy = -1;
                    pnn.iframes = 1;

                    Flag = 1;


                }
                else
                {
                    if (pnn.y + pnn.elevator_img[i].Height <= 500)
                    {

                        pnn.dy = 1;

                        pnn.iframes = 0;

                        Flag = 1;


                    }
                }
                if (Flag == 0)
                {
                    pnn.iframes = 0;
                }
                else
                {
                    pnn.iframes = 1;
                }
            }


        }

        void createface()
        {
            face pnn = new face();
            pnn.x = 900;
            pnn.y = (this.ClientSize.Height / 2) - 100;
            pnn.face_img = new Bitmap("facelaser.bmp");

            Lface.Add(pnn);
        }

        void createlines()
        {
            lines pnn = new lines();
            pnn.x1 = 0;
            pnn.y1 = 700;
            pnn.x2 = this.ClientSize.Width;
            pnn.y2 = 700;
            pnn.width = 5;
            pnn.height = 5;
            Llines.Add(pnn);

            lines pnn2 = new lines();
            pnn2.x1 = 0;
            pnn2.y1 = 300;
            pnn2.x2 = this.ClientSize.Width;
            pnn2.y2 = 300;
            pnn2.width = 5;
            pnn2.height = 5;
            Llines.Add(pnn2);
        }

        void createlaser()
        {
            laser pnn=new laser();

            pnn.x1 = 975;
            pnn.x2 = 975;
            pnn.y1 = 400;
            pnn.y2 = 700;
            Llaser.Add(pnn);

        }
    }
}
