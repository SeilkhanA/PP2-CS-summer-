using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    enum VisualMode                //перечесление логически связанных констант     Перечисления - это статические
                                  //и константные данные, в процессе выполнения нельзя менять значения перечислений, 
                                  //нельзя расширять список, использование перечислений прозрачное и понятное, 
                                  //да и хранить такие данные дешевле, чем коллекции.

    {
        DIR,                                     //папка
        FILE_CONTENT                             //файл
    }


    class VisualOperations
    {
        public VisualMode VisualMode { get; set; }//1-DIR, 2-FILE_CONTENT       //????



        public static void ShowInnerFileSystemInfo(StackItem2 item)           //с помощью данной функции получаем информацию о том, что внутри открытого объекта(папки здесь)
        {
            Console.BackgroundColor = ConsoleColor.Black;     //цвет заднего плана
            Console.Clear();                                  //очищаем для предоставления места новым папкам и файлам после их открытия

            FileSystemInfo[] objects = item.DirInfo.GetFileSystemInfos();  //объекты (папки и файлы), принадлежащие FileSystem, создаем массив
                                                                           //FileInfo[] flinf = item.DirInfo.GetFiles();
                                                                           // FileInfo fiObject = flinf[item.Index];

            for (int i = 0; i < objects.Length; ++i)     //пробегаемся по массиву из объектов fileSytem до конца
            {
                if (objects[i] is DirectoryInfo)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (i == item.Index)                      //если индекс остановился на объекте 
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;       //Задаем цвет для объекта на котором мы остановились
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                FileInfo fileinfo = objects[i] as FileInfo;
                if (fileinfo != null)
                {
                    Console.WriteLine(fileinfo.CreationTime + "\t" +objects[i] + "\t " + "   -----   " + "\t" + fileinfo.Length / 1024 + " " + "KB");
                }

                //DirectoryInfo dinfo = objects[i] as DirectoryInfo;
                //if(dinfo != null)

                else
                {
                    Console.WriteLine(objects[i].CreationTime + " \t" + objects[i]);
                    //int count = dinfo.GetFiles().Length;
                }


            }
        }

        public static void ShowFileContent(string path)   //?? string path
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();




            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    Console.WriteLine(sr.ReadToEnd()); 
                }
            }
        }
    }
}
//DirectoryInfo dirin = objects[i] as DirectoryInfo;
//FileInfo[] size = dirin.GetFiles();
//long sum = 0;
//foreach (FileInfo f in size)
//{
//    sum = sum + f.Length;
//    Console.WriteLine(objects[i].Name + "         " + sum);
//}

//{
//    DirectoryInfo dirin = objects[i] as DirectoryInfo;
//    long sum = 0;
//    sum = sum + fileinfo.Length;
//    Console.WriteLine(objects[i].Name + "         " + sum);
//}



