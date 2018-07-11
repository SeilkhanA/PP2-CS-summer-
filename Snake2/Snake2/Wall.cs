using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    public class Wall : GameObject                                         
    {
        public Wall()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            sign = '#';             //стенка будет знаком #
            GenerateLevel(1);       //вызов функции GenerateLevel
        }

        void GenerateLevel(int level)              // создадим функцию генерирующую уровни
        {
            string path = string.Format("Level{0}.txt", level); 


            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))    //используем файл
            { 
                using (StreamReader sr = new StreamReader(fs))
                {
                    for (int i = 0; i < 50; ++i)                                  //пробегаемся по вертикали по i
                    {
                        string line = sr.ReadLine();                              // 
                        for (int j = 0; j < 50; ++j)                              // пробегаемся по горизонтали по j
                        {
                            if (line[j] == '#')                                   // если по вертикали найдет #
                            {
                                
                                body.Add(new Point { X = j, Y = i });             // вывести в компиляторе эти решетки из файла 
                            }
                        }
                    }
                }
            }
        }
    }
}