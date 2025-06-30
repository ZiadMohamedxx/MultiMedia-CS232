using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dr.yasmin_test_quiz
{
    public partial class Form1: Form
    {
        public class cActors
        {
            public int x, y, w, h;
        }
        List<cActors> rectangles = new List<cActors>();
        public Form1()
        {
            
            this.MouseDown += Form1_MouseDown;
            this.WindowState = FormWindowState.Maximized;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {

            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            cActors pnn = new cActors();
            rectangles.Add(pnn);
            if (e.Button==MouseButtons.Left)
            {
               
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.Red);
                Random rr = new Random();
                int random_r = rr.Next(0,255);
                int random_g = rr.Next(0, 255);
                int random_b = rr.Next(0, 255);
                Brush b = new SolidBrush(Color.FromArgb(random_r,random_g,random_b));

                pnn.x = e.X;
                pnn.y = e.Y;
                pnn.w = 200;
                pnn.h = 50;
                g.FillRectangle(b,pnn.x ,pnn.y, pnn.w, pnn.h);

                
            }
            if(e.Button==MouseButtons.Right)
            {
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.Red);
                Brush b = new SolidBrush(Color.Black);
                for (int i = 0; i < rectangles.Count; i++)
                {
                    cActors ptrav = rectangles[i];

                    if (e.X >= ptrav.x && e.X <= ptrav.x + ptrav.w && e.Y >= ptrav.y && e.Y <= ptrav.y + ptrav.h)
                    {
                        int selected = i;
                        

                        MessageBox.Show("box number: " + selected);
                    }
                }
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
