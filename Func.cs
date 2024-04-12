using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNViewer
{
	public static class Func
	{
		//получаем имя объекта
		public static string? GetBVObject(string templine, int startpos, int endpos) 
		{ 
			string zzz = templine.Substring(startpos, endpos);
			if (zzz.Trim() == string.Empty) return null;
			return zzz;
		} 
		public static string? SetBVObject(string? inpline, string? storefield,ref string? storeline, int startpos, int colsymbols)
		{
			if (inpline is null ) return null;
			if (storeline is null) throw new ArgumentNullException("Ошибка 5. Попытка изменить название пустого имени");
			if (inpline.Length > colsymbols) throw new ArgumentOutOfRangeException("Ошибка 6. Вы задали слишком длинное имя, более "+colsymbols.ToString()+" символов");
			//целесообразно ли вводить новую переменную?
			string ss = inpline.PadRight(colsymbols, ' ');
			if (storefield is not null) storeline = storeline.Substring(0, startpos) + ss + storeline.Substring(startpos + colsymbols);
			//storeline = storeline.Replace(storefield, ss);
			return ss;
		}
	}
}
