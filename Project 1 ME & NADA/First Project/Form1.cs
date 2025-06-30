using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First_Project
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
            public List<int> jumpFrame = new List<int>();
            public int Ijump;
            public List<Bitmap> img = new List<Bitmap>();
        }

        MImage_hero hero = new MImage_hero();
        bool Right = false;

        void createHero()
        {
            hero.x = ClientSize.Width - 500;
            hero.y = ClientSize.Height - 500;
            for (int i = 0; i < 16; i++)
            {
                int ii = i + 1;
                Bitmap img = new Bitmap(ii + ".bmp");
                img.MakeTransparent(img.GetPixel(0, 0));
                if (i <= 7)
                {
                    hero.runLeftFrame.Add(i);
                }
                else
                {
                    hero.runRightFrame.Add(i);
                }
                hero.img.Add(img);
            }
            hero.IFrame = 0;
            hero.Ileft = 0;
            hero.Iright = 0;
            hero.Ijump = 0;
        }
        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                hero.x -= 10;
                hero.IFrame = hero.runLeftFrame[hero.Ileft];
                hero.Ileft++;
                if (hero.Ileft == hero.runLeftFrame.Count - 2)
                {
                    hero.Ileft = 0;
                }
                Right = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                Right = true;
                hero.x += 10;
                hero.IFrame = hero.runRightFrame[hero.Iright];
                hero.Iright++;
                if (hero.Iright == hero.runRightFrame.Count - 2)
                {
                    hero.Iright = 0;
                }
            }
            if (e.KeyCode == Keys.G)
            {
                if (Right)
                {
                    hero.IFrame = hero.runRightFrame[hero.runRightFrame.Count - 1];
                }
                else
                {
                    hero.IFrame = hero.runLeftFrame[hero.runLeftFrame.Count - 1];
                }
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            createHero();
        }

        void Drawscene(Graphics g2)
        {
            g2.Clear(Color.White);

            g2.DrawImage(hero.img[hero.IFrame], hero.x, hero.y);
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drawscene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}