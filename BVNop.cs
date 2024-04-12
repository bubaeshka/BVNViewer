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
		public int Codeop { get; } //код операции, он не изменяется на протяжении жизни операции

		string lineop; 

		protected decimal[] param;

		public BVNop(string inl) 
		{
			lineop = inl;
			//param = new decimal[12];
			int tempcode;
			decimal temppar;
			if (int.TryParse(lineop.Substring(7,4), out tempcode)) 
			{
				Codeop = tempcode;
				string[] news = Regex.Split(lineop, @"\s+");
				param = new decimal[news.Count()-3];
				for (int i = 0; i < param.Length; i++)
				{
					if (decimal.TryParse(news[i + 2], CultureInfo.InvariantCulture, out temppar))  param[i] = temppar; 
						else throw new ArgumentException("Ошибка в содержании BVN-файла. Код 3 - ошибка преобразования строки операции. ");  
				}

			} else
			{
				throw new ArgumentException("Ошибка в содержании BVN - файла. Код 2 - операция некорректа.");
			}

		}
	}
}
