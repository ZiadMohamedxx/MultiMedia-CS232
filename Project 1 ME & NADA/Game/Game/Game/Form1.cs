using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        Bitmap off;
        public class MImage_hero
        {
            public int x, y, IFrame;
            public List<int> runLeftFrame = new List<int>();
            public int Ileft;
            public List<int> runRightFrame = new List<int>();
            public int Iright;
            public List<int> jumpRightFrame = new List<int>();
            public int IRjump;
            public List<int> jumpleftFrame = new List<int>();
            public int Iljump;
            public List<Bitmap> img = new List<Bitmap>();
        }
        public class SImage
        {
            public int x, y;
            public int dx;
            public Bitmap img;
        }
        public class Cline
        {
            public int x1, x2, y1, y2;
        }
        public class advancImg
        {
            public int x, y;
            public Bitmap img;
            public Rectangle rsc, rdis;
        }
        public class recbull
        {
            public int x, y, w, h;
            public string numbul;
        }

        public class door
        {
            public int x, y, w, h;
            public Bitmap img;

        }

        List<door> Ldoor = new List<door>();
        bool flag = false;
        Cline Llaser = new Cline();
        SImage face2 = new SImage();
        SImage face3 = null;
        SImage signboard = new SImage();
       
        advancImg Lworld = new advancImg();
        SImage key = new SImage();
        SImage ladder;
        Cline ladderline = new Cline();
        recbull rec = new recbull();
        int xscroll = 10;
        int yscroll = 0;
        int currx = 0;
        MImage_hero hero = new MImage_hero();
        bool Right = true;
        int posStart = 0;
        int posEnd = 0;
        Cline gravLine = new Cline();
        Timer tt = new Timer();
        SImage parrot;
        SImage face;
        List<SImage> Legg = new List<SImage>();
        List<SImage> Lfire = new List<SImage>();
        List<SImage> Lhearts = new List<SImage>();
        Cline lineparrot;
        bool jump = false;
        int CtJump = 0;
        int ct_tick = 0;
        int ctBull = 25;
        bool inladder = false;
        bool aboveladder = false;
        bool inladder_d = false;
        bool onetime = false;
        bool isGameOver = false;

        void createWorld()
        {
            Lworld.img = new Bitmap("background.png");
            Rectangle rcSrc = new Rectangle(0, 0, Lworld.img.Width / 5, Lworld.img.Height);
            //posEnd = rcSrc.Width * 8;
            Rectangle rcDst = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Lworld.rdis = rcDst;
            Lworld.rsc = rcSrc;
        }
        void createLinegrav()
        {
            gravLine.y1 = this.ClientSize.Height - 70;
            gravLine.y2 = this.ClientSize.Height - 70;
            gravLine.x1 = 0;
            gravLine.x2 = Lworld.img.Width;
        }
        void createline()
        {
            Cline pnn = new Cline();
            pnn.x1 =parrot.x;
            pnn.y1 = parrot.y + parrot.img.Height - 15;
            pnn.x2 = parrot.x + parrot.img.Width;
            pnn.y2 = parrot.y + parrot.img.Height - 15;
            lineparrot = pnn;
        }
        void createHero()
        {
            hero.x =500;
            hero.y = ClientSize.Height - 300;
            for (int i = 0; i < 24; i++)
            {
                int ii = i + 1;
                Bitmap img = new Bitmap(ii + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                if (i <= 7)
                {
                    hero.runLeftFrame.Add(i);
                }
                else if (i <= 15)
                {
                    hero.runRightFrame.Add(i);
                }
                else if (i <= 19)
                {
                    hero.jumpleftFrame.Add(i);
                }
                else
                {
                    hero.jumpRightFrame.Add(i);
                }
                hero.img.Add(img);
            }
            hero.IFrame = 8;
            hero.Ileft = 0;
            hero.Iright = 0;
            hero.Iljump = 0;
            hero.IRjump = 0;
        }
        void createrec()
        {
            rec.x = 30;
            rec.y = 30;
            rec.w = 230;
            rec.h = 30;
            rec.numbul = "Remaining bullets : ";
        }
        void movefire()
        {
            for (int i = 0; i < Lfire.Count; i++)
            {
                SImage ptrav = Lfire[i];
                ptrav.x += 20 * ptrav.dx;
                if (ptrav.x > this.ClientSize.Width || ptrav.x < 0)
                {
                    Lfire.Remove(ptrav);
                }
                else
                {
                    if (face != null)
                    {
                        if (ptrav.x >= face.x + face.img.Width && ptrav.x <= face.x
                            && ptrav.y >= face.y + face.img.Height && ptrav.y <= face.y) 
                        {
                            face = null;
                            Lfire.Remove(ptrav);
                            MessageBox.Show("Remmember \n" +
                                "2");
                        }
                        if (ptrav.x + ptrav.img.Width >= face.x +30 && ptrav.x + ptrav.img.Width <= face.x + face.img.Width
                            && ptrav.y + ptrav.img.Height >= face.y + 30 && ptrav.y + ptrav.img.Height <= face.y + face.img.Height)
                        {
                            face = null;
                            Lfire.Remove(ptrav);
                            MessageBox.Show("Remmember \n" +
                               "2");
                        }
                    }
                }
            }

        }
        void createfire()
        {
            if (Right)
            {
                SImage pnn = new SImage();
                pnn.x = hero.img[hero.IFrame].Width + hero.x;
                pnn.y = hero.y + 70;
                pnn.img = new Bitmap("1Fire.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                pnn.dx = 1;

                Lfire.Add(pnn);
            }
            else
            {
                SImage pnn = new SImage();
                pnn.x = hero.x;
                pnn.y = hero.y + 50;
                pnn.img = new Bitmap("1Fire.bmp");
                pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
                pnn.dx = -1;

                Lfire.Add(pnn);
            }
        }
        void createegg()
        {
            SImage pnn = new SImage();
            pnn.x = parrot.x;
            pnn.y = parrot.y + 50;
            pnn.img = new Bitmap("egg1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));


            Legg.Add(pnn);
        }
        void moveegg()
        {
            for (int i = 0; i < Legg.Count; i++)
            {
                SImage ptrav = Legg[i];
                ptrav.x -= 5;
                ptrav.y += 5;

                if (ptrav.x >= hero.x && ptrav.x <= hero.x + hero.img[hero.IFrame].Width
                    && ptrav.x + ptrav.img.Width >= ptrav.x && ptrav.x + ptrav.img.Width <= hero.x + hero.img[hero.IFrame].Width
                    && ptrav.y >= hero.y && ptrav.y <= hero.y + hero.img[hero.IFrame].Height
                    && ptrav.y + ptrav.img.Height >= ptrav.y && ptrav.y + ptrav.img.Height <= hero.y + hero.img[hero.IFrame].Height)
                {
                    removeheart();
                    Legg.Remove(ptrav);
                } 

                if (ptrav.x > this.ClientSize.Width)
                {
                    Legg.RemoveAt(i);
                    i--;
                }
            }

        }
        void createStaticenemy()
        {
            SImage pnn = new SImage();

            pnn.x = (this.ClientSize.Width ) - 100;
            pnn.y = 100;
            pnn.img = new Bitmap("e2.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            parrot = pnn;

        }
        void createface()
        {
            SImage pnn = new SImage();
            pnn.img = new Bitmap("facelaser.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            pnn.x = this.ClientSize.Width - 375;
            pnn.y = ladderline.y1 - pnn.img.Height - 250;

            face2 = pnn;
        }
        void createlaser()
        {
            Cline pnn = new Cline();

            pnn.x1 = this.ClientSize.Width - 300 ;
            pnn.x2 = this.ClientSize.Width - 300;
            pnn.y1 = face2.y + face2.img.Height - 50;
            pnn.y2 = pnn.y1 + 300;
            Llaser = pnn;

        }
        void createStaticenemy2()
        {
            SImage pnn = new SImage();

            pnn.x = this.ClientSize.Width - 200;
            pnn.y = this.ClientSize.Height - 200;
            pnn.img = new Bitmap("e1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            face = pnn;

        }
        void removeheart()
        {
            if (isGameOver)
            {
              return;

            }

            if (Lhearts.Count != 0)
            {
                Lhearts.RemoveAt(Lhearts.Count - 1);
            }
            else
            {
                if (Lhearts.Count == 0)
                {
                    isGameOver = true;
                    MessageBox.Show("GAME OVER !!!");
                    this.Close();
                }
            }
        }
        

        void createHeart()
        {
            SImage pnn = new SImage();

            pnn.x = 200;
            pnn.y = rec.y + rec.h ;
            pnn.img = new Bitmap("heart_cactus_100x100.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));

            Lhearts.Add(pnn);

            SImage pnn2 = new SImage();

            pnn2.x = 150;
            pnn2.y = rec.y + rec.h ;
            pnn2.img = new Bitmap("heart_cactus_100x100.bmp");
            pnn2.img.MakeTransparent(pnn2.img.GetPixel(0, 0));

            Lhearts.Add(pnn2);

            SImage pnn3 = new SImage();

            pnn3.x = 100;
            pnn3.y = rec.y + rec.h ;
            pnn3.img = new Bitmap("heart_cactus_100x100.bmp");
            pnn3.img.MakeTransparent(pnn3.img.GetPixel(0, 0));

            Lhearts.Add(pnn3);

            SImage pnn4 = new SImage();
            pnn4.x = 50;
            pnn4.y = rec.y + rec.h ;
            pnn4.img = new Bitmap("heart_cactus_100x100.bmp");
            pnn4.img.MakeTransparent(pnn4.img.GetPixel(0, 0));

            Lhearts.Add(pnn4);

            SImage pnn5 = new SImage();
            pnn5.x = 0;
            pnn5.y = rec.y + rec.h ;
            pnn5.img = new Bitmap("heart_cactus_100x100.bmp");
            pnn5.img.MakeTransparent(pnn5.img.GetPixel(0, 0));

            Lhearts.Add(pnn5);


        }
        void createladder()
        {
            ladder = new SImage();
            ladder.img = new Bitmap("ladder.bmp");
            ladder.img.MakeTransparent(ladder.img.GetPixel(0, 0));
            ladder.y = gravLine.y1 - ladder.img.Height;
            ladder.x = 700;

            ladderline.x1 = 0;
            ladderline.x2 = this.ClientSize.Width;
            ladderline.y1 = ladder.y;
            ladderline.y2 = ladder.y;


           key.x = 250;
           key.img = new Bitmap("keyleft.bmp");
           key.img.MakeTransparent(key.img.GetPixel(0, 0));
           key.y = gravLine.y1 - key.img.Height;

            createface();
            createlaser();
            whitestaticenemyafterlaser();
            create2doors();
        }

        void scrolling()
        {
            if (!Right)
            {
                if (hero.x <= 200 && posStart >= 50)
                {
                    Lworld.rsc.X -= xscroll;
                    posStart -= xscroll;
                    currx -= xscroll;
                    if (currx >= 650)
                    {
                        if (!flag)
                        {
                            createladder();
                            flag = true;
                        }
                    }
                    else
                    {
                        ladder = null;
                    }
                    if (face != null)
                    {
                        face.x += xscroll * 2;
                    }
                    parrot.x += xscroll * 2;
                    lineparrot.x1 += xscroll * 2;
                    lineparrot.x2 += xscroll * 2;
                    if (ladder != null)
                    {
                        ladder.x += xscroll * 2;

                        if (key != null)
                        {
                            key.x += xscroll * 2;
                        }

                        if (face2 != null)
                        {
                            face2.x += xscroll * 2;
                        }
                        if (face3 != null)
                        {
                            face3.x += xscroll * 2;
                        }
                       

                        if (Llaser != null)
                        {
                            Llaser.x1 += xscroll * 2;
                            Llaser.x2 += xscroll * 2;
                        }
                    }
                    if (signboard != null)
                    {
                        signboard.x += xscroll * 2;
                    }

                    createLinegrav();
                }
            }
            if (Right)
            {
                if (hero.x >= this.ClientSize.Width - 200)
                {
                    Lworld.rsc.X += xscroll;
                    posStart += xscroll;
                    currx += xscroll;
                    if (currx >= 650)
                    {
                        if (!flag)
                        {
                            createladder();
                            flag = true;
                        }
                    }
                    else
                    {
                        ladder = null;
                    }
                    if (face != null)
                    {
                        face.x -= xscroll * 2;
                    }
                    parrot.x -= xscroll * 2;
                    lineparrot.x1 -= xscroll * 2;
                    lineparrot.x2 -= xscroll * 2;
                    if (ladder != null)
                    {
                        ladder.x -= xscroll * 2;

                        if (key != null)
                        {
                            key.x -= xscroll * 2;
                        }

                        if (face2 != null)
                        {
                            face2.x -= xscroll * 2;
                        }
                        if (face3 != null)
                        {
                            face3.x -= xscroll * 2;
                        }
                       

                        if (Llaser != null)
                        {
                            Llaser.x1 -= xscroll * 2;
                            Llaser.x2 -= xscroll * 2;
                        }
                    }
                    if (signboard != null)
                    {
                        signboard.x -= xscroll * 2;
                    }

                    createLinegrav();

                }
            }
        }
        void grav()
        {
            if (!aboveladder || ladder == null) 
            {
                if (hero.y + hero.img[hero.IFrame].Height < gravLine.y1)
                {
                    hero.y += 10;
                }
                else
                {
                    onetime = false;
                }
                if (!onetime)
                {
                    if (gravLine.y1 - hero.y >= 350)
                    {
                        removeheart();
                        onetime = true;
                    }
                }
            }
            else
            {
                
                    if (hero.y + hero.img[hero.IFrame].Height < ladderline.y1 ) 
                    {
                        hero.y += 10;
                    }
                

            }
            
        }
        public Form1()
        {
            // this.Size = new Size(1100, 700);
            this.WindowState = FormWindowState.Maximized;
            MessageBox.Show("Arrows for hero movement \n" +
                "J for jump \n" +
                "G for fire \n" 
                );
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            tt.Tick += Tt_Tick;
            tt.Interval = 100;
            tt.Start();
           
        }
        private void Tt_Tick(object sender, EventArgs e)
        {
           
            if (ct_tick % 50 == 0)
            {
                createegg();
            }
            if (jump)
            {
                CtJump++;
                if (CtJump == 4)
                {
                    if (Right)
                    {
                        hero.IFrame = hero.runRightFrame[0];
                    }
                    else
                    {
                        hero.IFrame = hero.runLeftFrame[0];
                    }
                    jump = false;
                    CtJump = 0;
                    hero.Iljump = 0;
                    hero.IRjump = 0;
                }
                else
                {
                    if (Right)
                    {
                        hero.IRjump++;
                        hero.IFrame = hero.jumpRightFrame[hero.IRjump];
                        hero.x += 30;
                        hero.y -= 40;
                    }
                    else
                    {
                        hero.Iljump++;
                        hero.IFrame = hero.jumpleftFrame[hero.Iljump];
                        hero.x -= 30;
                        hero.y -= 40;
                    }
                }
            }
            if (inladder)
            {
                hero.y -= 5;
                if (hero.y + hero.img[hero.IFrame].Height <= ladder.y)
                {
                    inladder = false;
                    aboveladder = true;
                }
            }
            else if (inladder_d)
            {
                hero.y += 5;
                if (hero.y + hero.img[hero.IFrame].Height >= ladder.y + ladder.img.Height)
                {
                    aboveladder = false;
                    inladder_d = false;
                }
            }
            else
            {
                grav();
            }
            if (ladder != null)
            {
                if (hero.x >= ladder.x && hero.x <= ladder.x + ladder.img.Width)
                        
                {
                }
                else
                {
                    inladder = false;
                }
            }
            moveegg();
            movefire();
            this.Text = "" + currx;
            ct_tick++;
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!jump)
            {

                if (e.KeyCode == Keys.Left)
                {
                    if (hero.x >= 0)
                    {
                        Right = false;
                        hero.x -= 20;
                        hero.IFrame = hero.runLeftFrame[hero.Ileft];
                        hero.Ileft++;
                        if (hero.Ileft == hero.runLeftFrame.Count - 2)
                        {
                            hero.Ileft = 0;
                        }

                    }


                    if (face != null)
                    {
                        SImage ptrav = face;

                        int heroLeft = hero.x;
                        int heroRight = hero.x + hero.img[hero.IFrame].Width;

                        int faceLeft = ptrav.x;
                        int faceRight = ptrav.x + ptrav.img.Width;

                        if (heroRight >= faceLeft && heroLeft <= faceRight)
                        {
                            removeheart();

                            
                            if (ptrav.x < hero.x)
                            {
                                hero.x += 300;
                            }
                        }
                    }

                    if (ladder != null)
                    {
                        if (key != null)
                        {
                            SImage ptrav = key;

                            int heroLeft = hero.x;
                            int heroRight = hero.x + hero.img[hero.IFrame].Width;

                            int keyLeft = ptrav.x;
                            int keyRight = ptrav.x + ptrav.img.Width;

                            if (heroRight >= keyLeft && heroLeft <= keyRight)
                            {
                                
                                key = null;
                                Llaser = null;
                            }
                        }
                    }

                    scrolling();
                }

                if (e.KeyCode == Keys.Right)
                {
                    if (hero.x + hero.img[hero.IFrame].Width <= this.ClientSize.Width)
                    {
                        Right = true;
                        hero.x += 20;
                        hero.IFrame = hero.runRightFrame[hero.Iright];
                        hero.Iright++;
                        if (hero.Iright == hero.runRightFrame.Count - 2)
                        {
                            hero.Iright = 0;
                        }
                    }


                    if (face != null)
                    {
                        SImage ptrav = face;

                        
                        int heroLeft = hero.x;
                        int heroRight = hero.x + hero.img[hero.IFrame].Width;

                        
                        int faceLeft = ptrav.x;
                        int faceRight = ptrav.x + ptrav.img.Width;

                        
                        if (heroRight >= faceLeft && heroLeft <= faceRight)
                        {
                            removeheart();

                            
                            if (ptrav.x > hero.x)
                            {
                               
                                hero.x -= 300;
                            }
                            
                        }
                    }

                    if (face3 != null)
                    {
                        SImage ptrav = face3;


                        int heroLeft = hero.x;
                        int heroRight = hero.x + hero.img[hero.IFrame].Width;


                        int faceLeft = ptrav.x;
                        int faceRight = ptrav.x + ptrav.img.Width;


                        if (heroRight >= faceLeft && heroLeft <= faceRight)
                        {
                            removeheart();


                            if (ptrav.x > hero.x)
                            {

                                hero.x -= 300;
                            }

                        }

                    }


                    if (Llaser != null)
                    {
                       
                        int heroLeft = hero.x;
                        int heroRight = hero.x + hero.img[hero.IFrame].Width;
                        int heroTop = hero.y;
                        int heroBottom = hero.y + hero.img[hero.IFrame].Height;

                        
                        int laserTop;
                        int laserBottom;
                        if (Llaser.y1 < Llaser.y2)
                        {
                            laserTop = Llaser.y1;
                            laserBottom = Llaser.y2;
                        }
                        else
                        {
                            laserTop = Llaser.y2;
                            laserBottom = Llaser.y1;
                        }

                        int laserX = Llaser.x1; 

                       
                        if (heroBottom >= laserTop && heroTop <= laserBottom &&
                            laserX >= heroLeft && laserX <= heroRight)
                        {
                            removeheart();

                            if (laserX > hero.x)
                            {
                                hero.x -= 300;
                            }
                           
                        }
                    }







                    if (ladder != null)
                    {
                        if (key != null)
                        {
                            SImage ptrav = key;
                            if (ptrav.x <= hero.x && ptrav.x >= hero.x + hero.img[hero.IFrame].Width
                                && hero.x + hero.img[hero.IFrame].Width >= ptrav.x
                                && hero.x + hero.img[hero.IFrame].Width <= ptrav.x + ptrav.img.Width)
                            {
                                key = null;
                                Llaser = null;
                            }
                        }
                    }

                    scrolling();
                }
                if (e.KeyCode == Keys.G)
                {
                    if (Right)
                    {
                        hero.IFrame = hero.runRightFrame[hero.runRightFrame.Count - 1];
                        if (ctBull != 0)
                        {
                            ctBull--;
                            if (ctBull == 10)
                            {
                                MessageBox.Show("WARRNING \n" +
                                    "You only have 10 bullets left");
                            }
                            createfire();
                        }
                        if (ctBull == 0)
                        {
                            MessageBox.Show("You dont have bullets :( ");
                        }
                    }
                    else
                    {
                        hero.IFrame = hero.runLeftFrame[hero.runLeftFrame.Count - 1];
                        if (ctBull != 0)
                        {
                            ctBull--;
                            if (ctBull == 10)
                            {
                                MessageBox.Show("WARRNING \n" +
                                    "You only have 10 bullets left");
                            }
                            createfire();
                        }
                        if (ctBull == 0)
                        {
                            MessageBox.Show("You dont have bullets :( ");
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                if (Right)
                {
                    hero.IFrame = hero.jumpleftFrame[hero.Iljump];
                    jump = true;
                }
                else
                {
                    hero.IFrame = hero.jumpRightFrame[hero.IRjump];
                    jump = true;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                hero.y -= 20;
            }
            if (aboveladder)
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (hero.x >= ladder.x && hero.x <= ladder.x + ladder.img.Width)
                    {
                        inladder_d = true;
                    }
                }
            }
            if (ladder != null)
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (hero.x >= ladder.x && hero.x <= ladder.x + ladder.img.Width
                    && hero.y >= ladder.y && hero.y <= ladder.y + ladder.img.Height)
                    {
                        inladder = true;
                    }
                    else
                    {
                        inladder = false;
                    }
                }
            }
            moveegg();
            movefire();
            DrawDubb(this.CreateGraphics());


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            createWorld();
            createLinegrav();
            createHero();
            createStaticenemy();
            createStaticenemy2();
            createline();
            createrec();
            createHeart();
            createsignboard();
        }

        void Drawscene(Graphics g2)
        {
            g2.Clear(Color.White);
            Font f = new Font("Arial", 15, FontStyle.Bold);
            Pen p = new Pen(Color.SaddleBrown, 9);
            Pen pen_laser = new Pen(Color.DarkRed, 5);
            g2.DrawImage(Lworld.img, Lworld.rdis, Lworld.rsc, GraphicsUnit.Pixel);
            if (ladder != null)
            {
                g2.DrawImage(ladder.img, ladder.x, ladder.y);
                g2.DrawLine(p, ladderline.x1, ladderline.y1, ladderline.x2, ladderline.y2);
                if (key != null)
                {
                    g2.DrawImage(key.img, key.x, key.y);
                }
                if (Llaser != null)
                {
                    g2.DrawLine(pen_laser, Llaser.x1, Llaser.y1, Llaser.x2, Llaser.y2);
                }
                g2.DrawImage(face2.img, face2.x, face2.y);
            }
            g2.DrawImage(hero.img[hero.IFrame], hero.x, hero.y);
            g2.DrawRectangle(Pens.SaddleBrown, rec.x, rec.y, rec.w, rec.h);
            
            g2.DrawString(rec.numbul + ctBull, f, Brushes.White, rec.x + 5, rec.y +3);

           


            g2.DrawLine(p, lineparrot.x1, lineparrot.y1, lineparrot.x2, lineparrot.y2);
            

            g2.DrawImage(parrot.img, parrot.x, parrot.y);
            if (face != null)
            {
                g2.DrawImage(face.img, face.x, face.y);
            }
            for (int i = 0; i < Lfire.Count; i++)
            {
                SImage pnn = Lfire[i];
                g2.DrawImage(pnn.img, pnn.x, pnn.y);
            }
            for (int i = 0; i < Legg.Count; i++)
            {
                SImage pnn = Legg[i];
                g2.DrawImage(pnn.img, pnn.x, pnn.y);
            }
            for (int i = 0; i < Lhearts.Count; i++)
            {
                SImage pnn = Lhearts[i];
                g2.DrawImage(pnn.img, pnn.x, pnn.y);
            }
            if (face3 != null)
            {
                g2.DrawImage(face3.img, face3.x, face3.y);
            }
            if (signboard != null)
            {
                g2.DrawImage(signboard.img, signboard.x, signboard.y);
            }
            
            for(int i=0;i<Ldoor.Count;i++)
            {
                door ptrav= Ldoor[i];
                g2.DrawImage(ptrav.img,ptrav.x, ptrav.y);
            }


        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drawscene(g2);
            g.DrawImage(off, 0, 0);
        }
        void whitestaticenemyafterlaser()
        {
            SImage pnn = new SImage();

            pnn.x = this.ClientSize.Width - 200;
            pnn.y = 290;
            pnn.img = new Bitmap("e1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            face3 = pnn;

        }

        void createsignboard()
        {
            SImage pnn = new SImage();
            pnn.x = 50;
            pnn.y = gravLine.y1-200;
            pnn.img = new Bitmap("signboard.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            signboard = pnn;

        }

        void create2doors()
        {
            door pnn=new door();
            pnn.x = this.ClientSize.Width-200;
            pnn.y = gravLine.y1-200;
            pnn.img = new Bitmap("bab1_closed.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            Ldoor.Add(pnn);


            pnn = new door();
            pnn.x = this.ClientSize.Width - 200;
            pnn.y = ladderline.y1-205;
            pnn.img = new Bitmap("bab1_closed.png");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            Ldoor.Add(pnn);

        }
    }
}
