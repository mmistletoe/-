using System.Runtime.CompilerServices;

namespace hm1_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            linkLabel5 = new LinkLabel();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 145);
            textBox1.Margin = new Padding(5, 4, 5, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 30);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 240);
            textBox2.Margin = new Padding(5, 4, 5, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(155, 30);
            textBox2.TabIndex = 2;
            // 
            // linkLabel5
            // 
            linkLabel5.AutoSize = true;
            linkLabel5.Location = new Point(740, 206);
            linkLabel5.Margin = new Padding(5, 0, 5, 0);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(46, 24);
            linkLabel5.TabIndex = 6;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "计算";
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(860, 206);
            label1.Name = "label1";
            label1.Size = new Size(63, 24);
            label1.TabIndex = 7;
            label1.Text = "";
            
            // 
            // button1
            // 
            button1.Location = new Point(533, 102);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 8;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(533, 165);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 9;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(533, 236);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 10;
            button3.Text = "*";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(533, 311);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 11;
            button4.Text = "/";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 635);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(linkLabel5);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Margin = new Padding(5, 4, 5, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private LinkLabel linkLabel5;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}