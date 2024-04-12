using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using static BVNViewer.Func;

namespace BVNViewer
{
	public class BVN
	{
		string? firstline; //первая строка со служебной информацией, относящейся ко всему файлу

		//название BVN-файла
		private string? bvnName;

		public string? BvnName {
			get => bvnName!.Trim() ?? throw new ArgumentNullException("Ошибка 4. Файл-проект не сущестует.");
			set => bvnName = SetBVObject(value, bvnName, ref firstline, 4, 20);
		} 

		public List<string>? BvnInfo { get; } //список строк со служебной информацией для пользователя

		List<string>? tehbvnInfo;  ////список строк со служебной информацией технический, изначальный

		public List<bvnITEM>? bvnITEMs; //список изделий в файле

		public int Сount { get; } //количество изделий в файле

		//конструктор - парсер файла
		public BVN(string filename)
		{
			//установка кодировки для корректного отображения кириллицы 1251 - необходим пакет NuGet
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			//читаем файл
			using (StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("windows-1251")))
			{
				string? line = null;
				int i = 0, currentProgram = 0, oldProgram = 0;
				Сount = 0; 
				bool newProg = false; //признак начала новой программы
				List<string> templist = new List<string>(); //временный лист строк, для хранения программы
				do //цикл обработки файла
				{
					i++;  //счётчик строк 		
					line = sr.ReadLine(); //читаем текущую строку
					if (line != null) //вдруг строка оказалась пустой? вызываем исключение. Надо ли?
					{
						//вытаскиваем первую строку со служебной информацией
						if (i == 1) 
						{
							firstline = line;
							BvnName = GetBVObject(firstline, 4, 20);
							continue; 
						} 
						if (line.Substring(0, 6).IndexOf("BVINFO") != -1) //вытаскиваем служебную информацию bvinfo
						{
							if (BvnInfo == null)  //инициализируем поля класса
							{ 
								BvnInfo = new List<string>(); 
								tehbvnInfo = new List<string>();
							}
							tehbvnInfo!.Add(line);  //оба списка работают вместе, второй проверять на null необязательно
							BvnInfo.Add(line.Substring(7)); 
							continue; //строки bvinfo не содержат код программ
						}
						if (int.TryParse(line.Substring(0, 6), out currentProgram)) //есть ли номер текущей программы в строке?
						{
							if (currentProgram != oldProgram) //это новая программа?
							{
								newProg = true; 
								oldProgram = currentProgram;
							} else templist.Add(line); //это данные уже известной найденной программы
						}

					}
					else throw new ArgumentNullException("Ошибка, это не BVN - файл! Код 2 - прочитана пустая строка.");
					if (line != null && (sr.EndOfStream || newProg)) //если программа новая или последняя а файле, нам нужно её создать
					{
						if (templist!.Count > 0) //это не первая строка первой программы
						{
							bvnITEM nbvi = new bvnITEM(new List<string>(templist)); //создаём программу и передаём её содержимое из временного списка копированием в новый 
							if (bvnITEMs == null) bvnITEMs = new List<bvnITEM>(); //если список программ ещё не создан, создаём его
							bvnITEMs.Add(nbvi); //добавляем в список программ только что созданную программу 
							templist.Clear(); //очищаем временный список для новой программы
							Сount++; //счётчик программ
						} 
						templist.Add(line); //добавляем первую найденную строку первой программы в новую программу
						newProg = false; //сбрасываем признак новой программы
					} 
				}
				while (!sr.EndOfStream); //поток файл кончился
			}
		}

		public int Except() {
			int xxx = 0;
			return xxx;
		}
	}
}
	