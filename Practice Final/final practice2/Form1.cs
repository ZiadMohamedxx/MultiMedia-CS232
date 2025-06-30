using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_practice2
{
    public partial class Form1 : Form
    {
        public class rec
        {
            public int x, y, w, h;
            public int dx;
            public int dy;
        }
        public class smallrec
        {
            public int x, y, w, h;
            public int dx;
            public int dy;
        }
        public class border
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public int dx;
            public int dy;
        }
        public class spaces
        {
            public int x1;
            public int y1;
            public int x2;
            public int y2;
            public int dy = 1;
           
        }
        public class smallboxesinside
        {
            public int w;
            public int h;
            public int x;
            public int y;
            public int dx;
            public int dy=1;
        }
        List<smallboxesinside> Lsmallboxesinside = new List<smallboxesinside>();
        List<spaces> Lspaces = new List<spaces>();
        List<border> Lborder = new List<border>();
        List<rec> Lrec = new List<rec>();
        List<smallrec> Lrec_small = new List<smallrec>();
        Bitmap off;
        Timer tt = new Timer();
        int ct_tick = 0;
        public bool isempty = true;
        public Form1()
        {
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            WindowState = FormWindowState.Maximized;
            tt.Tick += Tt_Tick;
            tt.Start();
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            createsmallrecs();
            createborder();
            
            drawdubb(this.CreateGraphics());
        }

        private void Tt_Tick(object sender, EventArgs e)
        {

            moveborder();
            movesmallrecs();
            movespaces();
            moveSmallBoxesInside();
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
            createRec();
            createSpaces();
            createSmallBoxesInside();
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Green);
            Pen pen = new Pen(Color.Yellow, 5);
            Brush brush = new SolidBrush(Color.Black);
            Pen p = new Pen(Color.Black, 3);
            Brush b = new SolidBrush(Color.Red);

            for (int i = 0; i < Lrec.Count; i++)
            {
                rec ptrav = Lrec[i];
                g2.DrawRectangle(pen, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            }
            for (int i = 0; i < Lrec_small.Count; i++)
            {
                smallrec ptrav = Lrec_small[i];
                g2.FillRectangle(brush, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            }
            for (int i = 0; i < Lborder.Count; i++)
            {
                border ptrav = Lborder[i];
                g2.DrawRectangle(pen, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            }
            for (int i = 0; i < Lspaces.Count; i++)
            {
                spaces ptrav = Lspaces[i];
                g2.DrawLine(p, ptrav.x1, ptrav.y1, ptrav.x2, ptrav.y2);

            }
            for (int i = 0; i < Lsmallboxesinside.Count; i++)
            {
                smallboxesinside ptrav = Lsmallboxesinside[i];
                g2.FillRectangle(b, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            }

        }
        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }

        void createRec()
        {
            rec pnn = new rec();

            pnn.x = this.ClientSize.Width / 3;
            pnn.y = this.ClientSize.Height / 2;
            pnn.w = 100;
            pnn.h = 100;

            Lrec.Add(pnn);
        }

        void createsmallrecs()
        {
            smallrec pnn = new smallrec();
            pnn.x = this.ClientSize.Width / 3;
            pnn.y = this.ClientSize.Height / 2;
            pnn.w = 50;
            pnn.h = 50;
            Lrec_small.Add(pnn);
        }

        void movesmallrecs()
        {
            for (int i = 0; i < Lrec_small.Count; i++)
            {


                smallrec pnn = Lrec_small[i];

               

                if (pnn.x + pnn.w >= this.ClientSize.Width-150 )
                {
                    
                    pnn.dx = 0;
                    pnn.dy = -1;
                    pnn.y += pnn.dy * 2;
                    for (int j = 0; j < Lspaces.Count; j++)
                    {
                        Lspaces[j].dy = 0;
                    }
                    for (int j = 0; j < Lsmallboxesinside.Count; j++)
                    {
                        Lsmallboxesinside[j].dy = 0;
                    }

                }
                else
                {
                    pnn.dx = 1;
                    pnn.dy = 0;
                    pnn.x += pnn.dx * 10;
                    
                }

            }
        }

        void createborder()
        {
            border pnn = new border();
            pnn.x = this.ClientSize.Width / 3;
            pnn.y = this.ClientSize.Height / 2;
            pnn.w = 51;
            pnn.h = 51;
            Lborder.Add(pnn);
        }

        void moveborder()
        {
            for (int i = 0; i < Lborder.Count; i++)
            {


                border pnn = Lborder[i];

                

                if (pnn.x + pnn.w >= this.ClientSize.Width - 150)
                {
                    
                    pnn.dx = 0;
                    pnn.dy = -1;
                    pnn.y += pnn.dy * 2;
                    Lspaces[i].dy = 0;
                    
                    for (int j = 0; j < Lspaces.Count; j++)
                    {
                        Lspaces[j].dy = 0;
                    }
                    for (int j = 0; j < Lsmallboxesinside.Count; j++)
                    {
                        Lsmallboxesinside[j].dy = 0;
                    }
                }
                else
                {
                    pnn.dx = 1;
                    pnn.dy = 0;
                    pnn.x += pnn.dx * 10;
                    
                }

            }
        }

        void createSpaces()
        {
            spaces pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 100;
            pnn.y1 = 200;
            pnn.y2 = 600;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 200;
            pnn.y2 = 200;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 250;
            pnn.y2 = 250;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 300;
            pnn.y2 = 300;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 350;
            pnn.y2 = 350;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 400;
            pnn.y2 = 400;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 450;
            pnn.y2 = 450;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 500;
            pnn.y2 = 500;

            Lspaces.Add(pnn);

            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 550;
            pnn.y2 = 550;

            Lspaces.Add(pnn);
            pnn = new spaces();
            pnn.x1 = this.ClientSize.Width - 100;
            pnn.x2 = this.ClientSize.Width - 150;
            pnn.y1 = 600;
            pnn.y2 = 600;

            Lspaces.Add(pnn);





        }

        void movespaces()
        {
            for (int i = 0; i < Lspaces.Count; i++)
            {
                spaces pnn = Lspaces[i];

                pnn.y1 += pnn.dy * 5;
                pnn.y2 += pnn.dy * 5;

                if (Lspaces[0].y2 >= this.ClientSize.Height || Lspaces[0].y1 <= 100)
                {
                    pnn.dy *= -1;
                }


            }
        }

        void createSmallBoxesInside()
        {
            smallboxesinside pnn = new smallboxesinside();
            pnn.x = this.ClientSize.Width - 150;
            pnn.y = this.ClientSize.Height - 240;
            pnn.w = 45;
            pnn.h = 45;
            
            Lsmallboxesinside.Add(pnn);

            pnn = new smallboxesinside();
            pnn.x = this.ClientSize.Width - 150;
            pnn.y = this.ClientSize.Height - 340;
            pnn.w = 45;
            pnn.h = 45;
            Lsmallboxesinside.Add(pnn);

            pnn = new smallboxesinside();
            pnn.x = this.ClientSize.Width - 150;
            pnn.y = this.ClientSize.Height - 490;
            pnn.w = 45;
            pnn.h = 45;
            Lsmallboxesinside.Add(pnn);

            isempty = false;
        }
        void moveSmallBoxesInside()
        {
            for (int i = 0; i < Lsmallboxesinside.Count; i++)
            {


                smallboxesinside pnn = Lsmallboxesinside[i];

                pnn.y += pnn.dy * 5;
                

                if (Lspaces[0].y2 >= this.ClientSize.Height || Lspaces[0].y1 <= 100)
                {
                    pnn.dy *= -1;
                }


            }
        }
    }
}
