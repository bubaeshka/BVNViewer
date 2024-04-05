using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace BVNViewer
{
	public class BVN
	{
		string? firstline; //первая строка со служебной информацией, относящейся ко всему файлу

		public List<string>? bvnInfo { get; } //список строк со служебной информацией для пользователя
		List<string>? tehbvnInfo { get; } ////список строк со служебной информацией технический, изначальный

		public List<bvnITEM>? bvnITEMs { get; } //список изделий в файле

		public int count { get; } //количество изделий в файле

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
				count = 0; 
				bool newProg = false; //признак начала новой программы
				List<string> templist = new List<string>(); //временный лист строк, для хранения программы
				do //цикл обработки файла
				{
					i++;  //счётчик строк 
					if (!sr.EndOfStream) //проверка на то что файл прочитан до конца
					{
						line = sr.ReadLine(); //читаем текущую строку
						if (line != null) //вдруг строка оказалась пустой? вызываем исключение. Надо ли?
						{
							if (i == 1) { firstline = line; continue; } //вытаскиваем первую строку со служебной информацией
							if (line.Substring(0, 6).IndexOf("BVINFO") != -1) //вытаскиваем служебную информацию bvinfo
							{
								if (bvnInfo == null)  //инициализируем поля класса
								{ 
									bvnInfo = new List<string>(); 
									tehbvnInfo = new List<string>();
								}
								tehbvnInfo!.Add(line);  //оба списка работают вместе, второй проверять на null необязательно
								bvnInfo.Add(line.Substring(7)); 
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
						else throw new Exception("Это не BVN - файл!");
					}
					if (line != null && (sr.EndOfStream || newProg)) //если программа новая или последняя а файле, нам нужно её создать
					{
						if (templist!.Count > 0) //это не первая строка первой программы
						{
							bvnITEM nbvi = new bvnITEM(new List<string>(templist)); //создаём программу и передаём её содержимое из временного списка копированием в новый 
							if (bvnITEMs == null) bvnITEMs = new List<bvnITEM>(); //если список программ ещё не создан, создаём его
							bvnITEMs.Add(nbvi); //добавляем в список программ только что созданную программу 
							templist.Clear(); //очищаем временный список для новой программы
							count++; //счётчик программ
						} 
						templist.Add(line); //добавляем первую найденную строку первой программы в новую программу
						newProg = false; //сбрасываем признак новой программы
					} 
				}
				while (!sr.EndOfStream); //поток файл кончился


				/*
				if ((firstline = sr.ReadLine()) == null) { throw new Exception("Это не BVN - файл!");  }
				string? line;
				int i = 0;
				int currentProgram, oldProgram = 0;
				List<string> templist = new List<string>();
				do
				{
					line = sr.ReadLine();
					if (line != null)
					{
						i++;
						if (line.IndexOf("BVINFO") != -1)
						{
							if (bvnInfo == null) { bvnInfo = new List<string>(); }
							bvnInfo.Add(line);
						}
						else if (line.IndexOf("00") != -1)
						{
							if (int.TryParse(line.Substring(0, 6), out currentProgram))
							{
								if (currentProgram != oldProgram)
								{
									bvnITEM nbvi = new bvnITEM(new List<string>(templist));
									if (bvnITEMs == null) bvnITEMs = new List<bvnITEM>();
									bvnITEMs.Add(nbvi);
									templist.Clear();
									templist.Add(line);

									oldProgram = currentProgram;
								}
								else templist.Add(line);

							}
							else { throw new Exception("Это не BVN - файл!"); };

						}
					} else
					{
						if (templist.Count>0) 
					}
				} while (line != null);
			*/
			}

		}
	}
}
	