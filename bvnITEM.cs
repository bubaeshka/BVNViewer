using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNViewer
{
	//класс изделия
	public class bvnITEM
	{
		List<string>? textProgram { get; } //исходный текст программы, на всякий случай 

		string? firstlineItem { get; } // первая строка со служебной информацией
		string?	secondlineItem { get; } //вторая строка со служебной информацией

		static readonly int[] serviceOp = { 3200 }; //список кодов операций со служебной информацией

		//конструктор класса изделия
		public bvnITEM(List<string> param) {  
			textProgram = param;
			if (textProgram != null && textProgram.Count > 0)
			{
				int codeOperations = 0;
				for (int i = 0; i < textProgram.Count; i++)
				{
					if (i == 1 && textProgram[i - 1] != null) firstlineItem = textProgram[i - 1];
					if (i == 2 && textProgram[i - 1] != null) secondlineItem = textProgram[i - 1];
					if (i > 2 && textProgram[i - 1] != null)
					{
						if (int.TryParse(textProgram[i - 1].Substring(8, 4), out codeOperations))
						{
							if (Array.IndexOf(serviceOp, codeOperations)== -1) 
							{
								//парсим операцию
							} else
							{
								//парсим служебную информацию
							}
						}
					}
				}
			}
        }
	}
}
