using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BVNViewer.Func;

namespace BVNViewer
{
	//класс изделия
	public class bvnITEM
	{
		List<string>? textProgram;  //исходный текст программы, на всякий случай 

		string? firstlineItem; // первая строка со служебной информацией

		string? secondlineItem; //вторая строка со служебной информацией

		static readonly int[] serviceOp = { 3200, 3201, 3202 }; //список кодов операций со служебной информацией

		//номер Детали
		string? itemName;
		
		public string? ItemName 
		{ 
			get => itemName?.Trim() ?? throw new ArgumentNullException("Ошибка 5. Пустые имена недопустимы.");
			set => itemName = SetBVObject(value, itemName, ref firstlineItem, 7, 20);
		}

		string? typeName;
		public string? TypeName 
		{
			get => typeName?.Trim() ?? null;
			set => typeName = SetBVObject(value, typeName, ref firstlineItem, 35, 10);
		}

		string? profile; 
		public string? Profile 
		{
			get
			{
				int indf = -1;
				if (opServices is not null)
				{
					indf = opServices.FindIndex(t => t.Codeop == 3200);
					if (indf != -1) return ((_3200op_service)opServices[indf]).GetProfile();
				}
				if (profile is not null) return profile.Trim();
				return string.Empty;
			}
			
			set
			{
				if (value is null) profile = null;
				else
				{
					int indf = -1;
					if (opServices is not null)
					{
						indf = opServices.FindIndex(t => t.Codeop == 3200);
						if (indf != -1) ((_3200op_service)opServices[indf]).SetProfile(value);
					}
					else if (value.Length <= 2) profile = value.PadRight(2);
				}
			}
		}


		List<BVNop>? bVNops;

		List<_op_service>? opServices;

		//конструктор класса изделия
		public bvnITEM(List<string> param) 
		{  
			textProgram = param;
			if (textProgram != null && textProgram.Count > 0)
			{
				int codeOperations = 0;
				for (int i = 0; i < textProgram.Count; i++)
				{
					if (i == 1 && textProgram[i - 1] != null)
					{
						firstlineItem = textProgram[i - 1];
						ItemName = GetBVObject(firstlineItem, 7, 20);
						TypeName = GetBVObject(firstlineItem, 35, 10);
						Profile = GetBVObject(firstlineItem, 46, 2);
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
