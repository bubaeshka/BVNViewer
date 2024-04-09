using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BVNViewer
{
	public abstract class BVNop
	{
		public int codeop { get; }

		string lineop { get; }

		protected decimal[] param;

		public BVNop(string inl) 
		{
			lineop = inl;
			param = new decimal[12];
			int tempcode;
			decimal temppar;
			if (int.TryParse(lineop.Substring(7,4), out tempcode)) 
			{
				codeop = tempcode;
				string[] news = Regex.Split(lineop, @"\s+");
				for (int i = 0; i < param.Length; i++)
				{
					if (decimal.TryParse(news[i + 2], CultureInfo.InvariantCulture, out temppar))  param[i] = temppar; 
						else throw new Exception("Ошибка в содержании BVN-файла. Код 3 - ошибка преобразования строки операции. ");  
				}

			} else
			{
				throw new Exception("Ошибка в содержании BVN - файла. Код 2 - операция некорректа.");
			}

		}
	}
}
