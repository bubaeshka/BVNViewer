using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNViewer
{
	public static class Func
	{
		public static string getNameObject(string templine, int startpos, int endpos) { return templine.Substring(4, 20); } //получаем имя объекта
		public static string setNameObject(string inpline, string? storefield,ref string? storeline, int colsymbols)
		{
			if (storeline is null) throw new ArgumentNullException("Ошибка 5. Попытка изменить название пустого имени");
			if (inpline.Length > colsymbols) throw new Exception("Ошибка 6. Вы задали слишком длинное имя, более "+colsymbols.ToString()+" символов");
			//целесообразно ли вводить новую переменную?
			string ss = inpline.PadRight(20, ' ');
			if (storefield is not null) storeline = storeline.Replace(storefield, ss);
			return ss;
		}
	}
}
