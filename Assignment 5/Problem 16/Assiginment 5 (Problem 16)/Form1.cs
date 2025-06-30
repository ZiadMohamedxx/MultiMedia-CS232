using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assiginment_5__Problem_16_
{
    public partial class Form1 : Form
    {
        public class player
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int iframes;
            public int dx;
            public int dy = 1;
            public List<Bitmap> player_img;
            public balls carriedBall = null;


        }
        public class balls
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public Bitmap ball_img;

        }
        int last_ball = 0;


        List<player> Lplayers = new List<player>();
        List<balls> Lballs = new List<balls>();

        Bitmap off;
        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            WindowState = FormWindowState.Maximized;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDouble(this.CreateGraphics());
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                for (int i = 0; i < Lplayers.Count; i++)
                {
                    Lplayers[i].y -= (Lplayers[i].dy) * 10;

                    Lplayers[i].iframes++;

                    if (Lplayers[i].iframes > 7)
                    {
                        Lplayers[i].iframes = 0;
                    }
                    if (Lplayers[i].carriedBall != null)
                    {
                        Lplayers[i].carriedBall.y -= (Lplayers[i].dy) * 10;
                    }
                }
                DrawDouble(this.CreateGraphics());
            }



            if (e.KeyCode == Keys.Down)
            {

                for (int i = 0; i < Lplayers.Count; i++)
                {
                    Lplayers[i].y += (Lplayers[i].dy) * 10;

                    Lplayers[i].iframes++;

                    if (Lplayers[i].iframes > 7)
                    {
                        Lplayers[i].iframes = 0;
                    }
                    if (Lplayers[i].carriedBall != null)
                    {
                        Lplayers[i].carriedBall.y += (Lplayers[i].dy) * 10;
                    }
                }
                DrawDouble(this.CreateGraphics());
            }


            if (e.KeyCode == Keys.Space)
            {

                for (int i = 0; i < Lplayers.Count; i++)
                {

                    player p = Lplayers[i];
                    if (p.x <= 550 + 400 &&
                        p.x >= 550 &&
                        p.y + p.player_img[p.iframes].Height >= 600 &&
                        p.y <= 600 + 200)
                    {
                        if (last_ball < Lballs.Count && p.carriedBall == null)
                        {
                            p.carriedBall = Lballs[last_ball];
                            Lballs[last_ball].x = p.x;
                            Lballs[last_ball].y = p.y + p.player_img[p.iframes].Height - 20;
                            last_ball++;

                            break;
                        }
                    }

                }

                DrawDouble(this.CreateGraphics());
            }



            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < Lplayers.Count; i++)
                {

                    player p = Lplayers[i];
                    if (p.x <= 550 + 400 &&
                        p.x >= 550 &&
                        p.y + p.player_img[p.iframes].Height >= 0 &&
                        p.y + p.player_img[p.iframes].Height <= 200)
                    {
                        Lplayers[0].carriedBall = null;
                    }
                }
            }







        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, ClientSize.Height);

            CreatePlayer();
            CreateBall();

        }

        void DrawDouble(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        void DrawScene(Graphics g2)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Orange);
            g2.Clear(Color.Yellow);


            g2.FillRectangle(brush, 550, 0, 400, 200);

            SolidBrush brush2 = new SolidBrush(Color.Green);
            g2.FillRectangle(brush2, 550, 600, 400, 200);


            for (int j = 0; j < Lplayers.Count; j++)
            {
                player ptrav = Lplayers[j];

                g2.DrawImage(ptrav.player_img[ptrav.iframes], ptrav.x, ptrav.y);
            }




            for (int j = 0; j < Lballs.Count; j++)
            {
                balls ptrav = Lballs[j];

                g2.DrawImage(ptrav.ball_img, ptrav.x, ptrav.y);

            }


        }

        void CreatePlayer()
        {
            player pnn = new player();

            pnn.player_img = new List<Bitmap>();

            for (int i = 0; i < 8; i++)
            {
                Bitmap Player_img = new Bitmap(("w" + (i + 1)) + ".bmp");
                Player_img.MakeTransparent(Player_img.GetPixel(0, 0));
                pnn.player_img.Add(Player_img);
                pnn.y = 200;
                pnn.x = 800;
            }
            pnn.iframes = 0;
            Lplayers.Add(pnn);



        }

        void CreateBall()
        {
            Random RR = new Random();
            int Random = RR.Next(1, 15);
            int ball_x = 555;

            for (int i = 0; i < Random; i++)
            {
                ball_x += 20;
                balls pnn = new balls();
                pnn.ball_img = new Bitmap("ball2.bmp");
                pnn.ball_img.MakeTransparent(pnn.ball_img.GetPixel(0, 0));

                pnn.x = ball_x;
                pnn.y = 605;


                Lballs.Add(pnn);
            }


        }

    }
}
