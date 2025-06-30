using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dr.Yassmin_Lec
{
    public partial class Form1: Form
    {
        List<Form1> my_forms = new List<Form1>();
        List<Color> cls = new List<Color>();
        List<StreamReader> lsr = new List<StreamReader>();
        List<string> mylines = new List<string>();
        bool ischiled = false;
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            cls.Add(Color.Red);
            cls.Add(Color.Yellow);
            cls.Add(Color.Blue);
            for (int i = 0; i <= 3; i++) 
            {
                StreamReader sr = new StreamReader("File" + i.ToString()+".txt");
                lsr.Add(sr);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                if (ischiled == true)
                {


                    for (int i = 0; i < 3; i++)
                    {
                        Form1 f = new Form1();
                        f.BackColor = cls[i];
                        f.ClientSize = new Size(300, 300);
                        List<string> ls = new List<string>();
                        while (!lsr[i].EndOfStream)
                        {
                            string s = lsr[i].ReadLine();
                            ls.Add(s);
                        }
                        f.mylines = ls;
                        f.ischiled = true;
                        f.Show();
                        my_forms.Add(f);


                    }
                }
                else
                {
                    string msg = "";
                    for (int k = 0; k < 3;k++)
                    {
                        msg += mylines[k];
                        msg += "\n";
                    }
                    MessageBox.Show(msg);
                }
            }
            else
            {
                if(e.Button==MouseButtons.Right)
                {
                    string msg = "";
                    for(int i=3;i<mylines.Count;i++)
                    {
                        msg += mylines[i];
                        msg += "\n";
                    }
                    MessageBox.Show(msg);
                }
            }
        }
    }
}
