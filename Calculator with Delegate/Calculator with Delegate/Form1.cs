using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_with_Delegate
{
    public delegate void MyDelegate(string text);

    public partial class Form1 : Form
    {
        Brain b;

        public Form1()
        {
            InitializeComponent();
            b = new Brain(DisplayResult);
        }

        public void DisplayResult(string text)
        {
            result.Text = text;
        }

        public void BtnPressed(object sender, EventArgs e)
        {
            b.Process((sender as Button).Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void button16_Click(object sender, EventArgs e)
        //{
        //    result.Clear();
        //}
    }
}