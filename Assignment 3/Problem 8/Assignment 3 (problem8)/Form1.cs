using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3__problem8_
{
    public partial class Form1: Form
    {
        int f = 1;
        int dir_x;
        int dir_y;
        List<Form1> LChildren = new List<Form1>();
        int x;



        public Form1()
        {
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
                
            if(e.KeyCode==Keys.Enter)
            {
                Form1 pnn ;

                pnn = new Form1();
                x = this.Location.X + this.ClientSize.Width + (LChildren.Count * pnn.ClientSize.Width);
                for (int i = 0; i < 8; i++) 
                {
                    if (i == 0) 
                    {
                        //foo2 left right
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Red;
                        pnn.dir_x = 1;
                        pnn.dir_y = 1;
                       
                        pnn.Location = new Point(x, this.Location.Y + this.ClientSize.Height - 260);
                        
                        
                    }
                    if (i == 1)
                    {
                        //t7t right right
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Black;
                        pnn.dir_x = -1;
                        pnn.dir_y = -1;
                       
                        pnn.Location = new Point(x+140, this.Location.Y + this.ClientSize.Height -115);
                        
                    }
                    if (i == 2)
                    {
                        //left foo2 left
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Aqua;
                        pnn.dir_x = -1;
                        pnn.dir_y = 1;
                        
                        pnn.Location = new Point(x-417, this.Location.Y + this.ClientSize.Height - 260);
                        
                        //
                    }
                    if (i == 3)
                    {
                        //left t7t left
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Blue;
                        pnn.dir_x = 1;
                        pnn.dir_y = -1;
                        
                        pnn.Location = new Point(x-550, this.Location.Y + this.ClientSize.Height - 120);
                        
                        //
                    }
                    if (i == 4)
                    {
                        //foo2 left center
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Black;
                        pnn.dir_x = -1;
                        pnn.dir_y = 0;
                        pnn.Location = new Point(x-283, this.Location.Y + this.ClientSize.Height - 405);
                        
                    }
                    if (i == 5)
                    {
                        //foo2 right center
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Red;
                        pnn.dir_x = 1;
                        pnn.dir_y = 0;
                        pnn.Location = new Point(x-140, this.Location.Y + this.ClientSize.Height - 405);
                       
                    }
                    if (i == 6)
                    {
                        //left t7t center
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Red;
                        pnn.dir_x = 1;
                        pnn.dir_y = 0;
                        pnn.Location = new Point(x - 283, this.Location.Y + this.ClientSize.Height +35);
                       
                    }
                    if (i == 7)
                    {
                        //right t7t
                        //btroo7 left
                        pnn = new Form1();
                        pnn.Show();
                        pnn.Size = new Size(150, 150);
                        pnn.BackColor = Color.Green;
                        pnn.dir_x = -1;
                        pnn.dir_y = 0;
                        pnn.Location = new Point((x - 140), this.Location.Y + this.ClientSize.Height +35);
                        
                    }
                   
                    LChildren.Add(pnn);

                }
            }
            if(e.KeyCode==Keys.NumPad1)
            {
                f = 1;
            }
            if(e.KeyCode==Keys.Space)
            {
                if (f == 0)
                {

                    for (int i = 0; i < LChildren.Count; i++)
                    {


                        if (LChildren[i].Location.Y > this.Height+
                            100|| LChildren[i].Location.Y < this.Location.Y)
                        {
                            LChildren[i].Location = new Point(LChildren[i].Location.X + LChildren[i].dir_x * 10, LChildren[i].Location.Y + LChildren[i].dir_y * 10);
                            if (LChildren[i].Location.X > x - 100 && LChildren[i].Location.Y== this.Location.Y + this.ClientSize.Height - 405)
                            {
                                LChildren[i].dir_x = -1;
                            }
                            if (LChildren[i].Location.X > x - 100 && LChildren[i].Location.Y==this.Location.Y + this.ClientSize.Height - 405) 
                            {
                                LChildren[i].dir_x = 1;
                            }
                            if (LChildren[i].Location.X < x - 283 && LChildren[i].Location.Y == this.Location.Y + this.ClientSize.Height + 35)
                            {
                                LChildren[i].dir_x = -1;
                            }
                            if (LChildren[i].Location.X > x - 140 && LChildren[i].Location.Y ==  this.Location.Y + this.ClientSize.Height +35)
                            {
                                LChildren[i].dir_x = 1;
                            }

                        }                        
                    }
                }
                else
                {
                    for (int i = 0; i < LChildren.Count; i++)
                    {
                        if (i == 0 || i == 1 || i == 2 || i == 3) 
                        {
                            LChildren[i].Location = new Point(
                                LChildren[i].Location.X + LChildren[i].dir_x * 10,
                                LChildren[i].Location.Y + LChildren[i].dir_y * 10);


                            if (LChildren[i].Location.Y<=this.Location.Y)
                            {
                                LChildren[i].dir_x *= -1;
                                LChildren[i].dir_y *= -1;
                            }

                            if (LChildren[i].Location.Y >= this.Height + LChildren[i].Height/2)
                            {
                                LChildren[i].dir_x *= -1;
                                LChildren[i].dir_y *= -1;
                            }
                            /*
                                if (i != j && LChildren[i].Location == LChildren[j].Location)
                                {
                                    LChildren[i].dir_x *= -1;
                                    LChildren[i].dir_y *= -1;
                                    LChildren[j].dir_x *= -1;
                                    LChildren[j].dir_y *= -1;
                                }
                            */
                        }
                    }



                }
            }
            if(e.KeyCode==Keys.NumPad2)
            {
                f = 0;
            }




            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
