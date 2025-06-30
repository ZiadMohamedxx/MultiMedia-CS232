using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_4__problem_12_
{
    public partial class Form1: Form
    {

        int rectangle_x = 100;
        int rectangle_y = 100;
        int rectangle_width = 100;
        int rectangle_height = 100;

        int blockX_right = -1;
        int blockY_right = -1;
        int ct3 = 0;
        int blockSize = 40;
        int catch_right= 0;
        int catch_left = 0;
        Random RR = new Random();

        


        public Form1()
        {
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown; ;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                
                
                Graphics g = this.CreateGraphics();
                SolidBrush b = new SolidBrush(Color.Blue);
                g.FillEllipse(b, blockX_right + blockSize * ct3, blockY_right, rectangle_width - 60, rectangle_height - 60);

                if (blockX_right + blockSize * ct3 >= rectangle_x + rectangle_width + 300 + rectangle_width + 130)
                {
                    ct3 = 0;
                    blockY_right += blockSize;
                    blockX_right = rectangle_x + rectangle_width + 300;
                }
                ct3++;

                
                catch_right++;
                
            }
            if(e.KeyCode==Keys.Space)
            {

                if (catch_right == catch_left) 
                {
                    MessageBox.Show("correct");
                    
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
            }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawscene();
        }

        void drawscene()
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Yellow);
            SolidBrush b = new SolidBrush(Color.Orange);
            g.Clear(Color.Black);


            //left
            g.DrawRectangle(p, rectangle_x - 50, rectangle_y - 50, rectangle_width + 250, rectangle_height + 250);
            //right
            g.DrawRectangle(p, rectangle_x + 400, rectangle_y - 50, rectangle_width + 250, rectangle_height + 250);

            int v_left = RR.Next(30);
            catch_left = v_left;
            int blockX = rectangle_x - 30;
            int blockY = rectangle_y - 40;
            int ct=0;
            for (int i = 0; i < v_left; i++) 
            {
                ct++;
                g.FillRectangle(b, blockX + blockSize *ct, blockY, blockSize, blockSize);
                
                g.FillRectangle(Brushes.Black, blockX + blockSize * ct, blockY, 2, blockSize);

                g.DrawLine(Pens.Black, rectangle_x - 30, blockY, rectangle_x + rectangle_width + 200,blockY);
                
                if (blockX + blockSize *ct >= rectangle_x + rectangle_width+100) 
                {
                    ct = 0;
                    blockY += blockSize;
                }
                    
            }



            int v_right = RR.Next(10);
          
              catch_right = v_right;
             blockX_right = rectangle_x + rectangle_width + 300;
             blockY_right = rectangle_y - 40;
            int ct2 = 0;
            for (int i = 0; i < v_right; i++)
            {
                ct2++;
                g.FillRectangle(b, blockX_right + blockSize * ct2, blockY_right, blockSize, blockSize);

                g.FillRectangle(Brushes.Black, blockX_right + blockSize * ct2, blockY_right, 2, blockSize);

                g.DrawLine(Pens.Black, blockX_right, blockY_right, blockX_right + rectangle_width + 265, blockY_right);

                if (blockX_right + blockSize * ct2 >= blockX_right + rectangle_width + 130) 
                {
                    ct2 = 0;
                    blockY_right += blockSize;
                }

            }

            blockX_right = blockX_right + blockSize * (ct2 + 1);





        }
    }
}
