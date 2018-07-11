using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(@"C:\");                    //объявление экземпляра класса DirectoryInfo и путь с нужной папкой для открытия 

            DirectoryInfo[] dirinfos = dirinfo.GetDirectories();                   //Возвращает имена подпапок,

            foreach (DirectoryInfo dirinf in dirinfos)
            {
                Console.WriteLine(dirinf.Name);
            }




            ConsoleKeyInfo pressedButton = Console.ReadKey();            //Описывает клавиши консоли
            switch (pressedButton.Key)
            {
                case ConsoleKey.UpArrow:

            }
        }



        
    }


}