using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNViewer
{
	public abstract class _op_service
	{
		string lineop;
		
		public int Stringpos { get; }

		public _op_service(string inpl, int poz) { 
			lineop = inpl;
			Stringpos = poz;
		}
	}
}
