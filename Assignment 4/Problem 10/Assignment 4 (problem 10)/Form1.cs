using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4__problem_10_
{
    public partial class Form1: Form
    {
        public class CActor
        {
           public int x, y;
            public int w, h;
            public Color cl;
        
            public void drawyourself(Graphics g)
            {
                Pen p = new Pen(cl);
                Brush b = new SolidBrush(cl);
                g.FillEllipse(b, x, y, w, h);
                
            }
        }
        List<CActor> Lup = new List<CActor>();
        List<CActor> Ldown = new List<CActor>();
        //List<cnode> pnn = new List<cnode>();

        int pos_y;
        int pos_x;
        int flag = 0;
        int ct = 1;
        int sawa2 = -1;
        int sawa2_2 = -1;
        
        public Form1()
        {
            this.Paint += Form1_Paint;
            this.MouseDown += Form1_MouseDown;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {

                if (sawa2_2 < Ldown.Count - 1)
                {

                    sawa2_2++;
                    Ldown[sawa2_2].cl = Color.Gray;
                    Ldown[sawa2_2].drawyourself(this.CreateGraphics());

                    for (int i = 0; i < Ldown.Count; i++)
                    {
                        if (i != sawa2_2)
                        {
                            Ldown[i].cl = Color.Blue;
                            Ldown[i].drawyourself(this.CreateGraphics());
                        }
                    }
                }
               
            }
            if (e.KeyCode == Keys.Down)
            {
                if (sawa2_2 > 0) 
                {

                    sawa2_2--;
                    Ldown[sawa2_2].cl = Color.Gray;
                    Ldown[sawa2_2].drawyourself(this.CreateGraphics());

                    for (int i = 0; i < Ldown.Count; i++)
                    {
                        if (i != sawa2_2)
                        {
                            Ldown[i].cl = Color.Blue;
                            Ldown[i].drawyourself(this.CreateGraphics());
                        }
                    }
                }
                

            }
            if (e.KeyCode == Keys.Right)
            {
                if (sawa2 < Lup.Count - 1)
                {

                    sawa2++;
                    Lup[sawa2].cl = Color.Gray;
                    Lup[sawa2].drawyourself(this.CreateGraphics());

                    for (int i = 0; i < Lup.Count; i++)
                    {
                        if (i != sawa2)
                        {
                            Lup[i].cl = Color.Red;
                            Lup[i].drawyourself(this.CreateGraphics());
                        }
                    }
                }

                



            }
            if (e.KeyCode == Keys.Left)
            {
                if (sawa2 > 0)
                {

                    sawa2--;
                    Lup[sawa2].cl = Color.Gray;
                    Lup[sawa2].drawyourself(this.CreateGraphics());

                    for (int i = 0; i < Lup.Count; i++)
                    {
                        if (i != sawa2)
                        {
                            Lup[i].cl = Color.Red;
                            Lup[i].drawyourself(this.CreateGraphics());
                        }
                    }

                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           
            if(e.Button == MouseButtons.Left)
            {
                if (flag == 0)
                {
                    pos_x = e.X;
                    pos_y = e.Y;
                    DrawScene();
                    flag++;

                }
                
                if(pos_y<e.Y)//t7t
                {
                    if (ct == 2)
                    {
                        CActor pnn = new CActor();
                        pnn.cl = Color.Blue;
                        pnn.x = e.X;
                        pnn.y = e.Y;
                        pnn.w = 15;
                        pnn.h = 15;
                        pnn.drawyourself(this.CreateGraphics());
                        Ldown.Add(pnn);
                        ct = 1;
                    }
                    else
                    {
                        MessageBox.Show("Error YA Negm");
                    }
                }
                
                if(pos_y>e.Y)//foo2
                {
                    if (ct == 1)
                    {
                        CActor pnn = new CActor();
                        pnn.cl = Color.Red;
                        pnn.x = e.X;
                        pnn.y = e.Y;
                        pnn.w = 15;
                        pnn.h = 15;
                        pnn.drawyourself(this.CreateGraphics());
                        Lup.Add(pnn);
                        ct = 2;
                        
                    }
                    else
                    {
                        MessageBox.Show("Error YA Negm");
                    }



                }






            }

            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < Lup.Count; i++)
                {
                    MessageBox.Show("X: " + Lup[i].x + " Y: " + Lup[i].y, "Up Click");
                }

                for (int k = 0; k < Ldown.Count; k++)
                {
                    MessageBox.Show("X: " + Ldown[k].x + " Y: " + Ldown[k].y, "Down Click");
                }


            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawScene();
        }

        void DrawScene()
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.White);
            SolidBrush b = new SolidBrush(Color.White);
            g.Clear(Color.Black);
            g.DrawLine(p, 0, pos_y, this.Width, pos_y);
        }
    }
}
