using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_3_training
{
    public partial class Form1 : Form
    {
        public class recs
        {
            public int x;
            public int y;
            public int w;
            public int h;
        }
        public class photos
        {
            public int x;
            public int y;
            public int w;
            public int h;
            public Bitmap Img_inside_rec;
            public Rectangle rSrc;
            public Rectangle rDst;

        }

        

        List<photos>Lphotos = new List<photos>();
        List<recs>Lrecs = new List<recs>();



        Bitmap off;

        int xold = 0;
        int yold = 0;
        bool is_drag=false;
        int dx = 0;
        int dy = 0;

        recs catch_pos = null;
        photos catch_pos_imgs = null;


        public Form1()
        {
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.WindowState= FormWindowState.Maximized;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            xold = 0;
            yold = 0;
            is_drag = false;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(is_drag==true)
            {
                dx=e.X - xold;
                dy=e.Y - yold;



                catch_pos.x += dx;
                catch_pos.y += dy;

                catch_pos_imgs.rDst.X += dx;
                catch_pos_imgs.rDst.Y += dy;

                xold = e.X;
                yold = e.Y;
            }

            drawdubb(this.CreateGraphics());
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                


                for (int k = 0; k < Lrecs.Count; k++)
                {
                    recs pnn2 = Lrecs[k];
                    if (e.X >= Lrecs[k].x && e.Y >= pnn2.y
                        && e.X <= pnn2.w + pnn2.x && e.Y <= pnn2.y + pnn2.h)
                    {
                        xold = e.X;
                        yold = e.Y;
                        is_drag = true;

                        catch_pos = pnn2;
                        catch_pos_imgs = Lphotos[k];

                    }
                }


            }

            drawdubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right)
            {
                catch_pos_imgs.rSrc.X += 5;

            }

            if (e.KeyCode == Keys.Left)
            {
                catch_pos_imgs.rSrc.X -= 5;
            }

            if(e.KeyCode == Keys.Up)
            {
                catch_pos_imgs.rSrc.Y -= 5;

            }

            if (e.KeyCode == Keys.Down)
            {
                catch_pos_imgs.rSrc.Y += 5;

            }
            drawdubb(this.CreateGraphics());
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off=new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            createRecs();
            createimg();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawdubb(e.Graphics);
        }

        void drawscene(Graphics g2)
        {
            g2.Clear(Color.Black);
            Pen p=new Pen(Color.Yellow,5);

            for(int i=0;i<Lrecs.Count;i++)
            {
                recs ptrav = Lrecs[i];
                g2.DrawRectangle(p, ptrav.x, ptrav.y, ptrav.w, ptrav.h);
            }

            for(int i=0;i<Lphotos.Count;i++)
            {
                photos ptrav = Lphotos[i];
                g2.DrawImage(ptrav.Img_inside_rec, ptrav.rDst,ptrav.rSrc,GraphicsUnit.Pixel);
            }


        }

        void drawdubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscene(g2);
            g.DrawImage(off, 0, 0);
        }


        void createRecs()
        {

            recs pnn=new recs();

            pnn.x = 150;
            pnn.y = 100;
            pnn.w =300;
            pnn.h = 200;

            Lrecs.Add(pnn);


            recs pnn2 = new recs();

            pnn2.x = 225;
            pnn2.y = 175;
            pnn2.w = 300;
            pnn2.h = 200;

            Lrecs.Add(pnn2);

            recs pnn3 = new recs();

            pnn3.x = 338;
            pnn3.y = 263;
            pnn3.w = 300;
            pnn3.h = 200;

            Lrecs.Add(pnn3);




        }

        void createimg()
        {
            photos pnn = new photos();

            pnn.Img_inside_rec = new Bitmap("1.jpg");
            pnn.x = 150;
            pnn.y=100;
            pnn.w = 300;
            pnn.h = 200;
            pnn.rSrc = new Rectangle(pnn.x, pnn.y, pnn.Img_inside_rec.Width / 2, pnn.Img_inside_rec.Height / 2);
            pnn.rDst = new Rectangle(pnn.x, pnn.y, Lrecs[0].w, Lrecs[0].h);



            Lphotos.Add(pnn);

            photos pnn2 = new photos();

            pnn2.Img_inside_rec = new Bitmap("2.jpg");
            pnn2.x = 225;
            pnn2.y = 175;
            pnn2.w = 300;
            pnn2.h = 200;
            pnn2.rSrc = new Rectangle(pnn2.x, pnn2.y, pnn2.Img_inside_rec.Width / 2, pnn2.Img_inside_rec.Height / 2);
            pnn2.rDst = new Rectangle(pnn2.x, pnn2.y, Lrecs[1].w, Lrecs[1].h);
            Lphotos.Add(pnn2);

            photos pnn3 = new photos();

            pnn3.Img_inside_rec = new Bitmap("3.jpg");
            pnn3.x = 338;
            pnn3.y = 263;
            pnn3.w = 300;
            pnn3.h = 200;
            pnn3.rSrc = new Rectangle(pnn3.x, pnn3.y, pnn3.Img_inside_rec.Width / 3, pnn3.Img_inside_rec.Height / 3);
            pnn3.rDst = new Rectangle(pnn3.x, pnn3.y, Lrecs[2].w, Lrecs[2].h);
            Lphotos.Add(pnn3);


        }
    }
}
