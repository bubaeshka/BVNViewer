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

		public int Codeop { get; } //код операции, он не изменяется на протяжении жизни операции
		
		public int Stringpos { get; }

		public _op_service(string inpl, int poz) { 
			lineop = inpl;
			int tempi = 0;
			if (int.TryParse(inpl.Substring(7, 4), out tempi)) Codeop = tempi; else throw new ArgumentException("Ошибка 6. Неверный код операции");
			Stringpos = poz;
		}
	}
}
