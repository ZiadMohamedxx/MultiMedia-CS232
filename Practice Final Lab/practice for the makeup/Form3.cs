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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace practice_for_the_makeup
{
    public partial class Form3 : Form
    {
        List<books>Lcomedy=new List<books>();
        List<books>Lhorror=new List<books>();
        List<books>Lsceince=new List<books>();
        List<books>Lhistory=new List<books>();
        List<books>Lbooks=new List<books>();
        int count =0;
        List<books> pos;
        int i_pos;
        public Form3()
        {
            InitializeComponent();


            StreamReader SR = new StreamReader("books.txt");
            while (!SR.EndOfStream)
            {
                string line = SR.ReadLine();


                string[] temp = line.Split(',');
                books pnn = new books();
                pnn.id = Int16.Parse(temp[0]);
                pnn.img_path = temp[1];
                pnn. category= temp[2];
                pnn.status = temp[3];
                
                Lbooks.Add(pnn);

                count++;
            }
            SR.Close();

            for(int i=0;i<Lbooks.Count;i++)
            {
                books pnn = Lbooks[i];
                if(pnn.category=="comedy")
                {
                    Lcomedy.Add(pnn);
                }
                if (pnn.category == "Science Fiction")
                {
                    Lsceince.Add(pnn);
                }
                if (pnn.category == "History")
                {
                    Lhistory.Add(pnn);
                }
                if (pnn.category == "Horror")
                {
                    Lhorror.Add(pnn);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("signed out succfully");
            Form1 signin =new Form1();
            signin.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(i_pos<pos.Count-1)
            {
                i_pos++;
                pictureBox1.Image = Image.FromFile(pos[i_pos].img_path);
                label1.Text = pos[i_pos].status;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i_pos>0)
            {
                i_pos--;
                pictureBox1.Image = Image.FromFile(pos[i_pos].img_path);
                label1.Text = pos[i_pos].status;
            }
           
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                pos = Lcomedy;
                i_pos = 0;

            }
            if (radioButton2.Checked == true)
            {
                pos = Lsceince;
                i_pos = 0;

            }
            if (radioButton3.Checked == true)
            {
                pos = Lhistory;
                i_pos = 0;

            }
            if (radioButton4.Checked == true)
            {
                pos = Lhorror;
                i_pos = 0;

            }
            pictureBox1.Image = Image.FromFile(pos[i_pos].img_path);
            label1.Text = pos[i_pos].status;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                pos = Lcomedy;
                i_pos = 0;

            }
            if (radioButton2.Checked == true)
            {
                pos = Lsceince;
                i_pos = 0;

            }
            if (radioButton3.Checked == true)
            {
                pos = Lhistory;
                i_pos = 0;

            }
            if (radioButton4.Checked == true)
            {
                pos = Lhorror;
                i_pos = 0;

            }
            pictureBox1.Image = Image.FromFile(pos[i_pos].img_path);
            label1.Text = pos[i_pos].status;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                pos = Lcomedy;
                i_pos = 0;

            }
            if (radioButton2.Checked == true)
            {
                pos = Lsceince;
                i_pos = 0;

            }
            if (radioButton3.Checked == true)
            {
                pos = Lhistory;
                i_pos = 0;

            }
            if (radioButton4.Checked == true)
            {
                pos = Lhorror;
                i_pos = 0;

            }
            pictureBox1.Image = Image.FromFile(pos[i_pos].img_path);
            label1.Text = pos[i_pos].status;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                pos = Lcomedy;
                i_pos = 0;

            }
            if (radioButton2.Checked == true)
            {
                pos = Lsceince;
                i_pos = 0;

            }
            if (radioButton3.Checked == true)
            {
                pos = Lhistory;
                i_pos = 0;

            }
            if (radioButton4.Checked == true)
            {
                pos = Lhorror;
                i_pos = 0;

            }
            pictureBox1.Image = Image.FromFile(pos[i_pos].img_path);
            label1.Text = pos[i_pos].status;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(label1.Text== "Avilible")
            {
                MessageBox.Show("booked succefully");
                pos[i_pos].status = "booked";

                StreamWriter SW = new StreamWriter("books.txt");

                for (int i = 0; i < Lbooks.Count; i++)
                {

                    SW.WriteLine(Lbooks[i].id + "," + Lbooks[i].img_path + "," + Lbooks[i].category + ","
                        + Lbooks[i].status);


                }

                SW.Close();

            }
            else
            {
                MessageBox.Show("not available");
            }
        }
    }

    public class books
    {
        public string category;
        public string status;
        public string img_path;
        public int id;
    }
}
