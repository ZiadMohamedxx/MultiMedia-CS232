using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2__problem4_
{
    public partial class Form1: Form
    {
        int f = 0;
        int dir_x;
        int dir_y;
        int x;
        List<Form1> LChildren = new List<Form1>();
        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Form1 pnn = new Form1();
                pnn.Show();
                pnn.Size = new Size(200, 200);

                 x = this.Location.X + this.ClientSize.Width + (LChildren.Count * pnn.ClientSize.Width);

                //pnn.Location = new Point(x, this.Location.Y + this.ClientSize.Height / 2);
                if(LChildren.Count%4==0)
                {
                    pnn.Text = "Right Bottom";
                    pnn.BackColor = Color.Teal;
                    pnn.dir_y = 0;
                    pnn.dir_x = -1;
                    
                    pnn.Location = new Point(x+dir_x,this.Location.Y+dir_y+this.ClientSize.Height);
                    //bttl3 foo2
                    //done
                }
                if(LChildren.Count % 4 == 1)
                {
                    pnn.Text = "Left Bottom";
                    pnn.BackColor = Color.Red;
                    pnn.dir_x = 0;
                    pnn.dir_y = -1;
                    pnn.Location = new Point((x-this.Width-350)+dir_x, this.Location.Y +dir_y+ this.ClientSize.Height);

                    //btroo7 right
                    //done
                }
                if(LChildren.Count % 4 ==2)
                {
                    pnn.Text = "Up Right";
                    pnn.BackColor = Color.Blue;
                    pnn.dir_x = 0;
                    pnn.dir_y = 1;

                    pnn.Location = new Point((x-this.Width-66)+dir_x, this.Location.Y+dir_y - this.ClientSize.Height / 2);
                    //btroo7 left
                    //done
                }
                if(LChildren.Count % 4 ==3)
                {
                    pnn.Text = "Up Left";
                    pnn.BackColor = Color.SpringGreen;
                    pnn.dir_x =1;
                    pnn.dir_y =-1;
                    pnn.Location = new Point((x - this.Width-719)+dir_x, this.Location.Y+dir_y - this.ClientSize.Height / 2);
                    //btnzel t7t
                    //done
                }
              


                LChildren.Add(pnn);
            }

            if(e.Button==MouseButtons.Right)
            {
                for(int i=0;i<LChildren.Count;i++)
                {
                    LChildren[i].Location=new Point(LChildren[i].Location.X + LChildren[i].dir_x*10, LChildren[i].Location.Y + LChildren[i].dir_y*10);


                    if (LChildren[i].Location.X<= (x - this.Width - 350) && LChildren[i].Location.Y >= this.Location.Y +  this.ClientSize.Height)
                    {
                        LChildren[i].dir_x = -1;
                        LChildren[i].dir_y = 0;
                        //btroo7 right done
                    }


                    else if (LChildren[i].Location.X<= (x - this.Width - 719) && LChildren[i].Location.Y <= this.Location.Y   - this.ClientSize.Height / 2)
                    {
                        LChildren[i].dir_x = 0;
                        LChildren[i].dir_y = -1;
                        //btnzel t7t done
                    }


                    else if (LChildren[i].Location.X<= (x - this.Width - 66) && LChildren[i].Location.Y <= this.Location.Y - this.ClientSize.Height /2)
                    {
                        LChildren[i].dir_x = 1;
                        LChildren[i].dir_y = 0;
                        //btroo7 left done
                    }


                    else if (LChildren[i].Location.X>= x-550  && LChildren[i].Location.Y >= this.Location.Y + this.ClientSize.Height)
                    {
                        LChildren[i].dir_x = 0;
                        LChildren[i].dir_y = 1;
                        //bttl3 foo2 done
                    }
             

                }

            }
        }
    }
}
