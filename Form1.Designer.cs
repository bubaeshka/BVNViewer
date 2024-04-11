namespace BVNViewer
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
			openFileDialog1 = new OpenFileDialog();
			label1 = new Label();
			button1 = new Button();
			label2 = new Label();
			button2 = new Button();
			richTextBox1 = new RichTextBox();
			button3 = new Button();
			label3 = new Label();
			label4 = new Label();
			button4 = new Button();
			richTextBox2 = new RichTextBox();
			textBox1 = new TextBox();
			button5 = new Button();
			SuspendLayout();
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 23);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 0;
			label1.Text = "label1";
			// 
			// button1
			// 
			button1.Location = new Point(12, 415);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "Открыть";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(63, 23);
			label2.Name = "label2";
			label2.Size = new Size(38, 15);
			label2.TabIndex = 2;
			label2.Text = "label2";
			// 
			// button2
			// 
			button2.Location = new Point(12, 174);
			button2.Name = "button2";
			button2.Size = new Size(256, 23);
			button2.TabIndex = 3;
			button2.Text = "Получить BVNInfo";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// richTextBox1
			// 
			richTextBox1.Location = new Point(12, 74);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(256, 94);
			richTextBox1.TabIndex = 4;
			richTextBox1.Text = "";
			// 
			// button3
			// 
			button3.Location = new Point(650, 23);
			button3.Name = "button3";
			button3.Size = new Size(94, 23);
			button3.TabIndex = 5;
			button3.Text = "исключение";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(750, 27);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 6;
			label3.Text = "label3";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(12, 56);
			label4.Name = "label4";
			label4.Size = new Size(54, 15);
			label4.TabIndex = 7;
			label4.Text = "BVNInfo:";
			// 
			// button4
			// 
			button4.Location = new Point(604, 393);
			button4.Name = "button4";
			button4.Size = new Size(75, 23);
			button4.TabIndex = 8;
			button4.Text = "button4";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// richTextBox2
			// 
			richTextBox2.Location = new Point(604, 186);
			richTextBox2.Name = "richTextBox2";
			richTextBox2.Size = new Size(161, 201);
			richTextBox2.TabIndex = 9;
			richTextBox2.Text = "";
			// 
			// textBox1
			// 
			textBox1.Location = new Point(288, 244);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(100, 23);
			textBox1.TabIndex = 10;
			// 
			// button5
			// 
			button5.Location = new Point(407, 244);
			button5.Name = "button5";
			button5.Size = new Size(75, 23);
			button5.TabIndex = 11;
			button5.Text = "button5";
			button5.UseVisualStyleBackColor = true;
			button5.Click += button5_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(button5);
			Controls.Add(textBox1);
			Controls.Add(richTextBox2);
			Controls.Add(button4);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(button3);
			Controls.Add(richTextBox1);
			Controls.Add(button2);
			Controls.Add(label2);
			Controls.Add(button1);
			Controls.Add(label1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private OpenFileDialog openFileDialog1;
		private Label label1;
		private Button button1;
		private Label label2;
		private Button button2;
		private RichTextBox richTextBox1;
		private Button button3;
		private Label label3;
		private Label label4;
		private Button button4;
		private RichTextBox richTextBox2;
		private TextBox textBox1;
		private Button button5;
	}
}