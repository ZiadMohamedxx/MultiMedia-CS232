using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    public partial class Form1 : Form
    {
        float num_multiply;
        float num_plus;
        float num_sub;
        float num_divide;
        string input = "";
        char[] operators = { '/', '*', '+', '-' };
        //int firstOperatorIndex = -1;
        
        float result = 0;
        char op = ' ';
        List<string> history = new List<string>();


        public Form1()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {

            // * (multiply)

            

            input += "*";
            textBox1.Text = input;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 0
            input = input + "0";
            textBox1.Text = input;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 9
            input = input + "9";
            textBox1.Text = input;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            // +

            
                input += "+";
                textBox1.Text = input;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1
            input = input + "1";
            textBox1.Text = input;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // 2
            input = input + "2";
            textBox1.Text = input;
        }

        private void button13_Click(object sender, EventArgs e)
        {

            // 3
            input = input + "3";
            textBox1.Text = input;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //text box
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // 4
            input = input + "4";
            textBox1.Text = input;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 5
            input = input + "5";
            textBox1.Text = input;
        }

        private void button14_Click(object sender, EventArgs e)
        {

            // 6
            input = input + "6";
            textBox1.Text = input;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // 7
            input = input + "7";
            textBox1.Text = input;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 8
            input = input + "8";
            textBox1.Text = input;
        }












        private void button15_Click(object sender, EventArgs e)
        {
            // =

            bool error = false;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Invalid Expression");
                textBox1.Text = "";
                 error = true;   
            }

            //duplicate operators
            for (int k = 0; k < input.Length - 1; k++)
            {
                if ((input[k] == '+' || input[k] == '-' || input[k] == '*' || input[k] == '/') &&
                    (input[k + 1] == '+' || input[k + 1] == '-' || input[k + 1] == '*' || input[k + 1] == '/'))
                {
                    MessageBox.Show("Invalid Expression");
                    textBox1.Clear();
                    input = "";
                    error = true;
                    return;


                }
            }



            //awel or last operators
            if (input != "")
            {
                if (input[0] == '+' || input[0] == '-' || input[0] == '/' || input[0] == '*' || input[0] == '.' || input[input.Length - 1] == '+' || input[input.Length - 1] == '-' || input[input.Length - 1] == '*' || input[input.Length - 1] == '/' || input[input.Length - 1] == '.')
                {
                    MessageBox.Show("Invalid Expression");
                    textBox1.Clear();
                    input = "";
                    return;

                }







                string temp_input = input;
                for (int h = 0; h < operators.Length; h++)
                {

                    
                    string currentNumberleft_String = "";
                    string currentNumberright_String = "";

                    int i = 0;
                    int curi = 0;
                    while (i < input.Length && input[i] != operators[h])
                    {
                        if (input[i] == '/' || input[i] == '*' || input[i] == '+' || input[i] == '-')
                        {
                            currentNumberleft_String = "";
                            curi = i + 1;
                        }
                        else
                        {
                            currentNumberleft_String += input[i];
                        }
                        i++;
                    }
                   
                    if (i < input.Length && input[i] == operators[h])
                    {
                        i++;
                        while (i < input.Length && input[i] != '/' && input[i] != '*' && input[i] != '+' && input[i] != '-')
                        {
                            currentNumberright_String += input[i];
                            i++;
                        }

                        result = 0;
                        if (operators[h] == '+')
                        {
                            result = float.Parse(currentNumberleft_String) + float.Parse(currentNumberright_String);
                        }
                        else if (operators[h] == '-')
                        {
                            result = float.Parse(currentNumberleft_String) - float.Parse(currentNumberright_String);
                        }
                        else if (operators[h] == '*')
                        {
                            result = float.Parse(currentNumberleft_String) * float.Parse(currentNumberright_String);
                        }
                        else if (operators[h] == '/')
                        {
                            if (float.Parse(currentNumberright_String) == 0)
                            {
                                MessageBox.Show("Cannot divide by zero");
                                textBox1.Clear();
                                input = "";
                                error = true;
                                return;
                            }
                            result = float.Parse(currentNumberleft_String) / float.Parse(currentNumberright_String);

                        }
                        string newInput = "";
                        for (int j = 0; j < curi; j++)
                        {
                            newInput += input[j];
                        }
                        newInput += result.ToString();
                        for (int j = i; j < input.Length; j++)
                        {
                            newInput += input[j];
                        }
                        //MessageBox.Show(newInput);

                        input = newInput;
                        currentNumberleft_String = "";
                        currentNumberright_String = "";
                    }
                }
                if (error == false)
                {
                    history.Add(temp_input);
                    listBox1.Items.Add(temp_input);

                    input = "" + result;
                    textBox1.Text = input;
                }

            }

        }

        private void button16_Click(object sender, EventArgs e)
        {

            // -

            

            input += "-";
            textBox1.Text = input;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // . (float)
            input = input + ".";
            textBox1.Text = input;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            // clear

            if (textBox1.Text != "")
            {
                //textBox1.Clear();

                input = "";
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Nothing to clear");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            // divide

            
            
                input += "/";
                textBox1.Text = input;
            
        }

        private void button12_Click(object sender, EventArgs e)
        {

            // delete

            int length = input.Length;
            if (length > 0)
            {
                input = input.Remove(length - 1);
                textBox1.Text = input;
            }
            else
            {
                MessageBox.Show("Nothing to delete");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // list box

            if (listBox1.SelectedItem != null)
            {
                input = listBox1.SelectedItem.ToString();
                textBox1.Text = input;
                
            }


        }
    }
}