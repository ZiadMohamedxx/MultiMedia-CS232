using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_5__problem_13_
{
    public partial class Form1: Form
    {
        bool isdragging = false;
        int xold = 0;
        int yold = 0;
        int dx = 0;
        int dy = 0;
        box pos = null;
        int ct = 9;
        public class box
        {
            public int x;
            public int y;
            public int width;
            public int height;
            public int location;

        }
        
        List<box> boxes = new List<box>();
        List<box> boxes2 = new List<box>();
        List<box> boxes3 = new List<box>();


        public Form1()
        {
            
            this.Paint += Form1_Paint;
            this.WindowState = FormWindowState.Maximized;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Load += Form1_Load1;

        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                box pnn = new box();

                pnn.x = 170 + (i * 10);
                pnn.y = 750 - (i * 50);
                pnn.width = 200 - (i * 20);
                pnn.height = 40;
                boxes.Add(pnn);

                pnn.location = 1;
            }

        }
        
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            if (isdragging == true)
            {
                
                //tower 2
                if (e.X >= 1000 && e.X <= 1040 && e.Y >= 400 && e.Y <= 900)
                {
                    int i = 0;
                    box check_middle_tower = null;
                    int location_el_Y = 99999;

                    while (i < boxes2.Count)
                    {
                        if (boxes2[i].location == 2 && boxes2[i].y < location_el_Y)
                        {
                            location_el_Y = boxes2[i].y;
                            check_middle_tower = boxes2[i];
                        }
                        i++;
                    }

                    if (check_middle_tower == null || pos.width < check_middle_tower.width)
                    {
                        if (check_middle_tower != null)
                        {
                            pos.x = check_middle_tower.x + 10;
                            pos.y = check_middle_tower.y - 50;
                        }
                        else
                        {
                            pos.x = 1010;
                            pos.y = 730;
                        }
                        if(pos.location == 1)
                        {
                            
                            ct--;
                            boxes.Remove(pos);
                        }
                        pos.location = 2;
                        boxes2.Add(pos);
                       
                    }
                    else
                    {
                       
                        int j = 0;
                        int min_y_pos_left = 99999;
                        box box_left = null;
                        while (j < boxes.Count)
                        {
                            if (boxes[j].location == 1 && boxes[j] != pos && boxes[j].y < min_y_pos_left)
                            {
                                min_y_pos_left = boxes[j].y;
                                box_left = boxes[j];
                            }
                            j++;
                        }

                        if (box_left != null)
                        {
                            pos.x = box_left.x + 10;
                            pos.y = box_left.y - 50;
                        }
                        else
                        {
                            pos.x = 270;
                            pos.y = 1100;
                        }

                        pos.location = 1;
                    }
                }

                //tower 3

                if (e.X >= 1200 && e.X <= 1240 && e.Y >= 400 && e.Y <= 900)
                {
                    int i = 0;
                    box check_middle_tower = null;
                    int location_el_Y = 999999;

                    while (i < boxes3.Count)
                    {
                        if (boxes3[i].location == 3 && boxes3[i].y < location_el_Y)
                        {
                            location_el_Y = boxes3[i].y;
                            check_middle_tower = boxes3[i];
                        }
                        i++;
                    }

                    if (check_middle_tower == null || pos.width < check_middle_tower.width)
                    {
                        if (check_middle_tower != null)
                        {
                            pos.x = check_middle_tower.x + 10;
                            pos.y = check_middle_tower.y - 50;
                        }
                        else
                        {
                            pos.x = 1210;
                            pos.y = 730;
                        }
                        if (pos.location == 1)
                        {
                            ct--;
                            boxes.Remove(pos);
                        }
                        pos.location = 3;
                        boxes3.Add(pos);
                        
                    }
                    else
                    {

                        int j = 0;
                        int min_y_pos_left = 99999;
                        box box_left = null;
                        while (j < boxes.Count)
                        {
                            if (boxes[j].location == 1 && boxes[j] != pos && boxes[j].y < min_y_pos_left)
                            {
                                min_y_pos_left = boxes[j].y;
                                box_left = boxes[j];
                            }
                            j++;
                        }

                        if (box_left != null)
                        {
                            pos.x = box_left.x + 10;
                            pos.y = box_left.y - 50;
                        }
                        else
                        {
                            pos.x = 270;
                            pos.y = 1100;
                        }

                        pos.location = 1;
                    }
                }

                if(e.X >= 250 && e.X <= 290 && e.Y >= 200 && e.Y <= 1150)
                {
                    int i = 0;
                    box check_middle_tower = null;
                    int location_el_Y = 999999;
                    while (i < boxes.Count)
                    {
                        if (boxes[i].location == 1 && boxes[i].y < location_el_Y)
                        {
                            location_el_Y = boxes[i].y;
                            check_middle_tower = boxes[i];
                        }
                        i++;
                    }
                    if (check_middle_tower == null || pos.width < check_middle_tower.width)
                    {
                        if (check_middle_tower != null)
                        {
                            pos.x = check_middle_tower.x + 10;
                            pos.y = check_middle_tower.y - 50;
                        }
                        else
                        {
                            pos.x = 270;
                            pos.y = 730;
                        }
                        
                        pos.location = 1;
                        boxes.Add(pos);
                        ct++;
                    }
                }


            }



            isdragging = false;
            xold = 0;
            yold = 0;
            
            
            Drawscene();

            





        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdragging == true)
            {
                dx = e.X - xold;
                dy = e.Y - yold;


                pos.x += dx;
                pos.y += dy;

                xold = e.X;
                yold = e.Y;

                Drawscene();
            }


        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            

            pos = null;

            // check the left tower
            for (int i = 0; i < boxes.Count; i++)
            {
                box b = boxes[i];
                if (b.x <= e.X && b.x + b.width >= e.X && b.y <= e.Y && b.y + b.height >= e.Y)
                {
                    xold = e.X;
                    yold = e.Y;
                    isdragging = true;
                    pos = b;
                    break;
                }
            }

            // check the middle tower 
            if (pos == null)
            {
                for (int i = 0; i < boxes2.Count; i++)
                {
                    box b = boxes2[i];
                    if (b.x <= e.X && b.x + b.width >= e.X && b.y <= e.Y && b.y + b.height >= e.Y)
                    {
                        xold = e.X;
                        yold = e.Y;
                        isdragging = true;
                        pos = b;
                        break;
                    }
                }
            }

            // check the right tower 
            if (pos == null)
            {
                for (int i = 0; i < boxes3.Count; i++)
                {
                    box b = boxes3[i];
                    if (b.x <= e.X && b.x + b.width >= e.X && b.y <= e.Y && b.y + b.height >= e.Y)
                    {
                        xold = e.X;
                        yold = e.Y;
                        isdragging = true;
                        pos = b;
                        break;
                    }
                }
            }






        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Drawscene();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        void Drawscene()
        {
            box cActor = new box();


            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Black);
            p.Width = 10;
            SolidBrush b = new SolidBrush(Color.Gray);
            g.Clear(Color.White);

            //first rectangle from the left
            g.DrawRectangle(p, 250, 200, 40, 950);
            g.FillRectangle(b, 250, 200, 40, 950);


            //second rectangle from the left
            g.DrawRectangle(p, 1000, 400, 40, 900);
            g.FillRectangle(b, 1000, 400, 40, 900);

            //third rectangle from the left
            g.DrawRectangle(p, 1200, 400, 40, 900);
            g.FillRectangle(b, 1200, 400, 40, 900);



            Pen pen = new Pen(Color.Black);
            pen.Width = 10;
            SolidBrush br = new SolidBrush(Color.Yellow);



            for (int i = 0; i < boxes.Count; i++)
            {

                g.DrawRectangle(pen, boxes[i].x, boxes[i].y, boxes[i].width, boxes[i].height);
                g.FillRectangle(br, boxes[i].x, boxes[i].y, boxes[i].width, boxes[i].height);

            }

            for (int i = 0; i < boxes2.Count; i++)
            {

                g.DrawRectangle(pen, boxes2[i].x, boxes2[i].y, boxes2[i].width, boxes2[i].height);
                g.FillRectangle(br, boxes2[i].x, boxes2[i].y, boxes2[i].width, boxes2[i].height);

            }
            for (int i = 0; i < boxes3.Count; i++)
            {

                g.DrawRectangle(pen, boxes3[i].x, boxes3[i].y, boxes3[i].width, boxes3[i].height);
                g.FillRectangle(br, boxes3[i].x, boxes3[i].y, boxes3[i].width, boxes3[i].height);

            }




        }
    }
}
