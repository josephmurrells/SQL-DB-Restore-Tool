namespace R4DBTool
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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 148);
            button1.Name = "button1";
            button1.Size = new Size(132, 36);
            button1.TabIndex = 1;
            button1.Text = "Restore Database";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(150, 148);
            button2.Name = "button2";
            button2.Size = new Size(132, 36);
            button2.TabIndex = 2;
            button2.Text = "Drop Database";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(270, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 101);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 4;
            label1.Text = "Database Name";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 75);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(270, 23);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(108, 15);
            label2.TabIndex = 6;
            label2.Text = "Output Folder Path";
            // 
            // button3
            // 
            button3.Location = new Point(288, 74);
            button3.Name = "button3";
            button3.Size = new Size(33, 23);
            button3.TabIndex = 7;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 187);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 8;
            label3.Text = "label3";
            label3.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 31);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(270, 23);
            textBox3.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 13);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 10;
            label4.Text = "Backup File Path";
            // 
            // button4
            // 
            button4.Location = new Point(288, 31);
            button4.Name = "button4";
            button4.Size = new Size(33, 23);
            button4.TabIndex = 11;
            button4.Text = "...";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(355, 211);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "SQL DB Restore Tool v1.0";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label2;
        private Button button3;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Button button4;
    }
}