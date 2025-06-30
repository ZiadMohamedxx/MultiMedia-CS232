using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_3__problem_7_
{
    public partial class Form1: Form
    {
        int ct = 0;
        int R;
        int G;
        int B;


        List<Color> colors = new List<Color>();
        List<int> xValues = new List<int>();
        int colorIndex = -1;

        public Form1()
        {
            this.MouseDown += Form1_MouseDown;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (colors.Count > 0)
            {

                if (e.KeyCode == Keys.Up)
                {
                    if (colorIndex < colors.Count - 1)
                    {
                        colorIndex++;

                    }
                    else
                    {
                        colorIndex = 0; // lw akher color harg3o tani mn el awel

                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (colorIndex > 0)
                    {
                        colorIndex--;


                    }
                    else
                    {
                        colorIndex = colors.Count - 1; // lw awel color harg3o tani l akher color fel list

                    }


                    


                    /* for(int i=0;i<3;i++)
                     {
                         this.BackColor = colors[colorIndex];

                     }*/
                }
                this.BackColor = colors[colorIndex];
            }

            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                
                    if (e.X < 255) 
                    {
                        xValues.Add(e.X);
                    }
                

                if (xValues.Count == 3)
                {
                    this.Text = xValues[0] + " ," + xValues[1] + " ," + xValues[2];

                    Color pnn = Color.FromArgb(xValues[0], xValues[1], xValues[2]);
                    colors.Add(pnn); 
                    colorIndex = colors.Count - 1; //bakhood agdd color fel list
                    
                    xValues.Clear();
                }
            }
        
        }
    }
}
