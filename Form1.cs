using System.Reflection;

namespace BVNViewer
{
	public partial class Form1 : Form
	{
		List<BVN> bvns;
		int activeBVN = -1;

		public Form1()
		{
			InitializeComponent();
			bvns = new List<BVN>();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					BVN bvn = new BVN(openFileDialog1.FileName);
					bvns.Add(bvn);
					activeBVN = bvns.Count - 1;
					label1.Text = activeBVN.ToString();
					Text = bvns[activeBVN].BvnName;
				}
				catch (Exception ee)
				{
					MessageBox.Show(ee.Message);
				}
			}
			label2.Text = bvns.Count.ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (activeBVN >= 0)
			{
				if (bvns[activeBVN].BvnInfo != null) richTextBox1.Lines = bvns[activeBVN].BvnInfo!.ToArray();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int z = bvns[activeBVN].Except();
			label3.Text = z.ToString();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Type[] typelist = Assembly.GetExecutingAssembly().GetTypes().Where(ns => ns.Namespace == "BVNViewer").ToArray();

			foreach (Type type in typelist)
			{
				richTextBox2.AppendText("\r\n" + type.Name);
			}
			int z = 0;
			z++;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (activeBVN >= 0)
			{
				bvns[activeBVN].BvnName = textBox1.Text;
			}

		}
	}
}