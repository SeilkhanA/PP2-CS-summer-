using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace Snake2
{
    public class Snake : GameObject
    {
        public int Dx { get; set; }                       //??
        public int Dy { get; set; }                       //??

        private Food food;
        private Wall wall;
       

        bool ok = true;

        public void SetFood(Food food)
        {
            this.food = food;
        }

        public Snake()
        {

        }

        public Snake(Food food, Wall wall)                           // ??
        {
            this.food = food;
            this.wall = wall;
           
            /*
            Point p = new Point();                       // альтернативный способ опрежеления начальной точки откуда будет начинаться змейка
            p.X = 12;
            p.Y = 12;
            */
            body.Add(new Point { X = 12, Y = 12 });       // с какого места начинается змейка
            sign = 'o';                                   // тело змейки такого вида
        }

        public void Move(object sender, ElapsedEventArgs e)     // функция для движения 
        {

            if (HitWall(wall))
            {
                Console.Clear();
                Console.SetCursorPosition(20, 20);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("GAME OVER!!!");

                
                ok = false;
            }

            if (ok)
            { 
                Clear();

                for (int i = body.Count - 1; i > 0; --i)              // циклом пройдемся по телу от конца к началу
                {
                    body[i] = new Point { X = body[i - 1].X, Y = body[i - 1].Y };     // при съедании еды тело змейки будет  расти всегда от головы
                }

                body[0].X += Dx;                     // рост змейки по координатам Ох
                body[0].Y += Dy;                     // и Оу

                if (food.body[0].Equals(body[0]))     //если координата еды совпадет с координатой змейки
                {
                    body.Add(new Point { X = food.body[0].X, Y = food.body[0].Y });  // к телу змейки присоединим коордианту еду, на которую наткунулась змейка

                    food = new Food();                         // после съедания змейкой еды, нужно создать еду на новом месте
                    food.Draw();                               //этим Draw и будет создаваться новая еда

                }
                Draw();            //рисуется змейка
               
            }
            //Thread.Sleep(100);                            // скорость движения змйеки

                                 
        }
        public bool HitWall(Wall wall)
        {
            foreach (Point p in wall.body)
            {
                if (p.X == body[0].X && p.Y == body[0].Y)
                    return true;
            }
            return false;
        }

        //public bool HitSnake()
        //{
        //    for (int i = 1; i < body.Count; i++)
        //    {
        //        if (body[0].X == body[i].X && body[0].Y == body[i].Y)
        //            return true;
        //    }
        //    return false;
        //}


        public void Save()
            {
                using (FileStream fs = new FileStream("snake.xml", FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Snake));  //создаем сериализацию(процесс преобразования какого-либо объекта в поток байтов) сохраняет в рам или харде
                    xs.Serialize(fs, this);   //сериализовать файл в FileStream
                }
            }

            public Snake Load()
            {
                Snake res;         // чтобы змейку возвращать
                using (FileStream fs = new FileStream("snake.xml", FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Snake));
                    res = xs.Deserialize(fs) as Snake;
                }
                return res;
            }
        }
    }