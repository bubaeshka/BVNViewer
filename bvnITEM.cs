using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BVNViewer
{
	//класс изделия
	public class bvnITEM
	{
		List<string>? textProgram;  //исходный текст программы, на всякий случай 

		string? firstlineItem; // первая строка со служебной информацией

		string? secondlineItem; //вторая строка со служебной информацией

		static readonly int[] serviceOp = { 3200 }; //список кодов операций со служебной информацией

		//номер Детали
		string? itemName;
		
		string ItemName 
		{ 
			get => itemName!.Trim() ?? throw new Exception("Ошибка 5. Деталь не существует");
			set 
			{
				
			} 
		}


		List<BVNop>? bVNops;

		List<_op_service>? opServices;

		//конструктор класса изделия
		public bvnITEM(List<string> param) 
		{  
			///////////////////////////////////////////////////////////////////////////////////////
			string getItemName(string templine) { return templine.Substring(7, 20); }


			///////////////////////////////////////////////////////////////////////////////////////
			textProgram = param;
			if (textProgram != null && textProgram.Count > 0)
			{
				int codeOperations = 0;
				for (int i = 0; i < textProgram.Count; i++)
				{
					if (i == 1 && textProgram[i - 1] != null)
					{
						firstlineItem = textProgram[i - 1];
						ItemName = getItemName(firstlineItem);
					}
					if (i == 2 && textProgram[i - 1] != null) secondlineItem = textProgram[i - 1];
					if (i > 2 && textProgram[i - 1] != null)
					{
						if (int.TryParse(textProgram[i - 1].Substring(7, 4), out codeOperations))
						{
							if (Array.IndexOf(serviceOp, codeOperations)== -1) 
							{
								//парсим операцию
								if (bVNops is null) bVNops = new List<BVNop>();
								////спасибо John Prick с киберфорума, научил
								bVNops.Add(opFactory.Create(codeOperations.ToString(), textProgram[i - 1]));
								
							} else
							{
								//парсим служебную информацию
								if (opServices is null) opServices = new List<_op_service>();
								opServices.Add(opFactory.Create(codeOperations.ToString(), textProgram[i-1], i));
							}
						}
					}
				}
			}
        }
	}
}
