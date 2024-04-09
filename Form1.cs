using System.Reflection;

namespace BVNViewer
{
	public partial class Form1 : Form
	{
		List<BVN> bvns;
		int activeBVN = 0;

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
					activeBVN = bvns.Count;
					label1.Text = activeBVN.ToString();
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
			if (activeBVN > 0)
			{
				if (bvns[activeBVN - 1].bvnInfo != null) richTextBox1.Lines = bvns[activeBVN - 1].bvnInfo!.ToArray();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			int z = 0;
			z++;
			label3.Text = z.ToString();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Type[] typelist = Assembly.GetExecutingAssembly().GetTypes().Where(ns => ns.Namespace == "BVNViewer").ToArray();

			foreach (Type type in typelist)
			{
				richTextBox2.AppendText("\r\n"+type.Name);
			}
			int z = 0;
			z++;
		}
	}
}