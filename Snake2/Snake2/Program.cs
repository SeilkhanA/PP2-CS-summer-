using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;                                      //Создает и контролирует поток, задает приоритет и возвращает статус.
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(50, 50);                    // размер консольного экрана  
            Console.CursorVisible = false;                    // невидимость курсора
            Console.SetBufferSize(50, 50);                    // размер движка консольного экрана

            Food food = new Food();                           // экзмепляр класса Food 
            Wall wall = new Wall();                           // экземпляр класса Wall
            Snake snake = new Snake(food,wall);       //food??     // экземпляр класса Snake

           



            wall.Draw();                                      // функция, рисующая стенку
            food.Draw();                                      // функция, рисующая еду

            System.Timers.Timer timer = new System.Timers.Timer(100);   
            timer.Elapsed += snake.Move;                     // сохраняет инфу о движении змейки 
            timer.Start();                                   // начнет сохранение, поток (все это работает на подобии THread, который здесь был до этого)

            while (true)
            {
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                switch (pressedButton.Key)
                {
                    case ConsoleKey.UpArrow:                   //при зажатии клавиши "Вверх"
                        snake.Dy = -1;                         //когда змейка движется наверх на -1 уменьшается (14,13,12,11)
                        snake.Dx = 0; 
                        break;
                    case ConsoleKey.DownArrow:                //при зажатии клавиши "Вниз"
                        snake.Dy = 1;
                        snake.Dx = 0;
                        break;
                    case ConsoleKey.LeftArrow:                //при зажатии клавиши "Влево"
                        snake.Dy = 0;
                        snake.Dx = -1;
                        break;
                    case ConsoleKey.RightArrow:               //при зажатии клавиши "Вправо"
                        snake.Dy = 0;
                        snake.Dx = 1;
                        break;
                    case ConsoleKey.Spacebar:

                        snake.Save();                     //  сериализация
                        break;

                    case ConsoleKey.Tab:

                        Console.Clear();
                        food.Draw();
                        wall.Draw();


                        timer.Stop();

                        timer.Elapsed -= snake.Move;      // выкидывает старые сохраненные змейки

                        snake = snake.Load();             // функция десериализации сохранненой змейки

                        snake.SetFood(food);  
                        
                        timer.Elapsed += snake.Move;      // после выкидывания инфы о стархы змейках, создает новые потоки
                        timer.Start();                   
                        break;
                }
                
            }
        }
    }
}