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

		public string BvnName {
			get => bvnName!.Trim() ?? ""; //throw new Exception("Ошибка 4. Файл-проект не сущестует.");
			set => bvnName = setNameObject(value, bvnName, ref firstline, 20);
				/**
			{
				if (firstline is null) throw new ArgumentNullException("Попытка изменить название пустого BVN");
				if (value.Length > 20) throw new Exception("Вы задали слишком длинное имя, более 20 символов");
				//целесообразно ли вводить новую переменную?
				string ss = value.PadRight(20, ' ');
				if (bvnName is not null) firstline = firstline.Replace(bvnName, ss);
				bvnName = ss;
			} **/
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
							BvnName = getNameObject(firstline, 4, 20);
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
					else throw new Exception("Ошибка, это не BVN - файл! Код 2 - прочитана пустая строка.");
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
	