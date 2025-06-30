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

namespace final_lab_practice
{
    public partial class Form3 : Form
    {
        List<books>Lcomedy=new List<books>();
        List<books>Lhistory=new List<books>();
        List<books>Lhorror=new List<books>();
        List<books>Lscience=new List<books>();
        int ct=0;
        int icomedy = 0;
        int iscience_ficition = 0;
        int ihorror=0;
        int ihistory = 0;

        public Form3()
        {
            InitializeComponent();
            this.Text = "Book Store";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sign out

            MessageBox.Show("Sign out successfully");
            Form1 signin = new Form1();
            signin.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("Z:\\VisualStudio 2022 preview saves\\MultiMedia CS232\\Practice Final Lab\\Material\\New folder\\books.txt");
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();


                string[] temp = line.Split(',');
                books pnn = new books();

                pnn.category = temp[2];
                if (pnn.category == "comedy")
                {
                    pnn.id = Int16.Parse(temp[0]);
                    pnn.img_path = temp[1];

                    pnn.status = temp[3];


                    Lcomedy.Add(pnn);

                }
                if (pnn.category == "Science Fiction")
                {
                    pnn.id = Int16.Parse(temp[0]);
                    pnn.img_path = temp[1];


                    pnn.status = temp[3];
                    Lscience.Add(pnn);
                }
                if (pnn.category == "Horror")
                {
                    pnn.id = Int16.Parse(temp[0]);
                    pnn.img_path = temp[1];


                    pnn.status = temp[3];
                    Lhorror.Add(pnn);
                }
                if (pnn.category == "History")
                {
                    pnn.id = Int16.Parse(temp[0]);
                    pnn.img_path = temp[1];


                    pnn.status = temp[3];
                    Lhistory.Add(pnn);
                }

                ct++;

            }
            SR.Close();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //right

            if(radioButton1.Checked==true)
            {
                icomedy++;
                if (icomedy >= Lcomedy.Count)
                {
                    icomedy = 0;
                }
                    pictureBox1.Image = Image.FromFile(Lcomedy[icomedy].img_path);
               
                label3.Text = Lcomedy[icomedy].status;

            }
            if(radioButton2.Checked == true)
            {
               iscience_ficition++;
                if (iscience_ficition >= Lscience.Count)
                {
                    iscience_ficition = 0;
                }
                    pictureBox1.Image = Image.FromFile(Lscience[iscience_ficition].img_path);
               label3.Text= Lscience[iscience_ficition].status;
            }
            if (radioButton3.Checked == true)
            {
                ihistory++;
                if (ihistory >= Lhistory.Count)
                {
                    ihistory = 0;
                }
                    pictureBox1.Image = Image.FromFile(Lhistory[ihistory].img_path);

                label3.Text = Lhistory[ihistory].status;
            }
            if (radioButton4.Checked == true)
            {
                ihorror++;
                if (ihorror >= Lhorror.Count)
                {
                    ihorror = 0;
                }
                    pictureBox1.Image = Image.FromFile(Lhorror[ihorror].img_path);
                label3.Text = Lhorror[ihorror].status;


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //left

            if (radioButton1.Checked == true)
            {
                if(icomedy>0)
                {

                    icomedy--;
                }
                pictureBox1.Image = Image.FromFile(Lcomedy[icomedy].img_path);
                label3.Text = Lcomedy[icomedy].status;

            }
            if (radioButton2.Checked == true)
            {
                if (iscience_ficition > 0)
                {
                    iscience_ficition--;
                }
                pictureBox1.Image = Image.FromFile(Lscience[iscience_ficition].img_path);
                label3.Text = Lscience[iscience_ficition].status;
            }
            if (radioButton3.Checked == true)
            {
                if (ihistory > 0)
                {
                    ihistory--;
                }
                
                pictureBox1.Image = Image.FromFile(Lhistory[ihistory].img_path);
                label3.Text = Lhistory[ihistory].status;

            }
            if (radioButton4.Checked == true)
            {
                if (ihorror > 0)
                {
                    ihorror--;
                }
                
                pictureBox1.Image = Image.FromFile(Lhorror[ihorror].img_path);
                label3.Text = Lhorror[ihorror].status;

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(label3.Text== "Avilible")
            {
                MessageBox.Show("Book is available");
            }
            else
            {
                MessageBox.Show("Book is not available");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        public class books
        {
            public string category;
            public string status;
            public int id;
            public string img_path;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
