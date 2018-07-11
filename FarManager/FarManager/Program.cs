using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack <StackItem2> history = new Stack <StackItem2>();      // Stack 


            StackItem2 item = new StackItem2 { DirInfo = new DirectoryInfo(@"C:\"), Index = 0 };  // элемент класса StackItem2 это папка С
                                               //get                               //set
                    

            // item можно еще увидеть в классе VisualOperations, там оно используется для того, чтобы в указанном пути (С:\) именно тут рассматривать папки 



            VisualOperations visualOperations = new VisualOperations();       // вызовим класс Visual Operations (в этом классе происходят работа с содержимым папки и файла)


            visualOperations.VisualMode = VisualMode.DIR;           //?????




            history.Push(item);              // заполняет Stack <StackItem2> объектами из указанной папки (его пути в экземпляре item (C:\))




            bool isOK = true;

            while (isOK)
            {

                if (visualOperations.VisualMode == VisualMode.DIR)      // если мы открыли папку
                {
                    VisualOperations.ShowInnerFileSystemInfo(history.Peek());    // ?? начинаем пробегаться и показывать все содержимое этой папки с заданием цвета
                }


                ConsoleKeyInfo pressedButton = Console.ReadKey();            //ожидай команды связанной с клавишами(вверх,вниз)


                switch (pressedButton.Key)                                   //switch — это оператор управления, выбирающий раздел switch для выполнения из списка кандидатов.
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().Index = history.Peek().Index - 1;
                        break;


                    case ConsoleKey.DownArrow:
                        history.Peek().Index = history.Peek().Index + 1;
                        break;


                    case ConsoleKey.Enter:
                        StackItem2 item2 = new StackItem2();


                        StackItem2 topItem = history.Peek();               //верхний элемент стэка это верхний элемент



                        FileSystemInfo[] info = topItem.DirInfo.GetFileSystemInfos();


                        FileSystemInfo fsObject = info[topItem.Index];


                        string path = fsObject.FullName;


                        if (fsObject is DirectoryInfo)
                        {
                            item2.DirInfo = new DirectoryInfo(path);
                            item2.Index = 0;
                            history.Push(item2);
                            
                        }


                        else if (fsObject is FileInfo)               // если данный объект является файлом
                        {
      
                            visualOperations.VisualMode = VisualMode.FILE_CONTENT;
                            VisualOperations.ShowFileContent(path);
                            
                        }
                        break;



                    case ConsoleKey.Backspace:                   //при нажимании на кнопку возврата назад


                        if (visualOperations.VisualMode == VisualMode.FILE_CONTENT)     //если мы находимся в файле
                        {
                            visualOperations.VisualMode = VisualMode.DIR;              //то таким образом должны будем вепнуться обратно в папку
                        }
                        else
                        {
                            history.Pop();              //
                        }
                        break;
                   
                    case ConsoleKey.Escape:           //принажатии на еск просто выходим из программы
               
                        isOK = false;                //вся составляющая команд не являестся больше децствительными
                        break;
                }
            }
        }
    }
}
