using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BVNViewer
{
	//спасибо John Prick с киберфорума, научил
	static class opFactory
	{
		private static readonly Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(ns => ns.Namespace == "BVNViewer").ToArray();


		public static BVNop Create(string typeName, string inpLine)
		{ 
			var type = types.FirstOrDefault(t => t.Name == "_"+typeName+"op");
			if (type != null) return (BVNop)Activator.CreateInstance(type,inpLine)!;
			return new _op(inpLine);
		}
	}
}
