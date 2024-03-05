using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hm1_2
{
    public partial class Form1 : Form
    {
        double num1;
        double num2;
        double result;

        public Form1()
        {
            InitializeComponent();
        }


        //加号
        private void button1_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            result = num1 + num2;
        }

        //减号
        private void button2_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            result = num1 - num2;
        }

        //乘号
        private void button3_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            result = num1 * num2;
        }

        //除号
        private void button4_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            num2 = Convert.ToDouble(textBox2.Text);
            if (num2 != 0)
                result = num1 / num2;
            else
                throw new DivideByZeroException();
        }
        
        //计算结果
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label1.Text = "结果为" + Convert.ToString(result);
        }
    }
}