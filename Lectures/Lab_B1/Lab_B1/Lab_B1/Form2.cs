using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_B1
{
    public partial class Form2 : Form
    {
        List<User> users2 = new List<User>();
        public Form2(List<User> U)
        {
            InitializeComponent();
            users2 = U;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }
    }
}
