using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2__problem6_
{
    public partial class Form1: Form
    {
        int ct=0;
        List<Form1> LChildren = new List<Form1>();
        bool isdragging = false;
        
        int dy;
        int dx;
        
        int xold = 0;
        int yold = 0;
        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isdragging==true)
            {
                dx = e.X - xold;
                dy = e.Y - yold;

                for(int i=0;i<LChildren.Count;i++)
                {
                    LChildren[i].Location = new Point(LChildren[i].Location.X, LChildren[i].Location.Y+dy);
                }

                xold = e.X;
                yold = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isdragging = false;
            xold = 0;
            yold = 0;

        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
          

            if(e.Button==MouseButtons.Left)
            {
                xold = e.X;
                yold = e.Y;
                isdragging = true;

            }

            if (e.Button == MouseButtons.Right)
            {
                Form1 pnn;
                
                //right
                if (ct%2 == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        pnn = new Form1();
                        pnn.Size = new Size(100, 100);
                        pnn.BackColor = Color.Red;
                        pnn.Show();
                        int x = this.Location.X + this.ClientSize.Width ;
                        if (i == 0)
                        {
                            pnn.Location = new Point(x, this.Location.Y + this.ClientSize.Height - 260);
                        }
                        if (i == 1)
                        {
                            pnn.Location = new Point(x, this.Location.Y + this.ClientSize.Height - 167);
                        }
                        if (i == 2)
                        {
                            pnn.Location = new Point(x, this.Location.Y + this.ClientSize.Height - 80);
                        }
                        if (i == 3)
                        {
                            pnn.Location = new Point(x, this.Location.Y + this.ClientSize.Height + 5);
                        }
                        LChildren.Add(pnn);
                    }
                    ct++;
                }




                else
                {
                    //left
                    
                    for (int i = 0; i < 4; i++)
                    {
                        pnn = new Form1();
                        pnn.Size = new Size(100, 100);
                        pnn.BackColor = Color.Orange;
                        pnn.Show();
                        int x = this.Location.X + this.ClientSize.Width ;
                        if (i == 0)
                        {
                            pnn.Location = new Point(x - 405, this.Location.Y + this.ClientSize.Height - 260);
                        }
                        if (i == 1)
                        {
                            pnn.Location = new Point(x - 405, this.Location.Y + this.ClientSize.Height - 167);
                        }
                        if (i == 2)
                        {
                            pnn.Location = new Point(x - 405, this.Location.Y + this.ClientSize.Height - 80);
                        }
                        if (i == 3)
                        {
                            pnn.Location = new Point(x - 405, this.Location.Y + this.ClientSize.Height + 5);
                        }
                        LChildren.Add(pnn);
                    }

                    ct++;
                }
                
            }
        }
    }
}
