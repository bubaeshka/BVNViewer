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
			SuspendLayout();
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(93, 103);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 0;
			label1.Text = "label1";
			// 
			// button1
			// 
			button1.Location = new Point(26, 398);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 1;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(325, 103);
			label2.Name = "label2";
			label2.Size = new Size(38, 15);
			label2.TabIndex = 2;
			label2.Text = "label2";
			// 
			// button2
			// 
			button2.Location = new Point(504, 400);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 3;
			button2.Text = "button2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// richTextBox1
			// 
			richTextBox1.Location = new Point(504, 88);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(256, 212);
			richTextBox1.TabIndex = 4;
			richTextBox1.Text = "";
			// 
			// button3
			// 
			button3.Location = new Point(433, 23);
			button3.Name = "button3";
			button3.Size = new Size(75, 23);
			button3.TabIndex = 5;
			button3.Text = "button3";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(513, 26);
			label3.Name = "label3";
			label3.Size = new Size(38, 15);
			label3.TabIndex = 6;
			label3.Text = "label3";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
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
	}
}