using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
   public class Point                                    // класс для работы точек
    {
        private int x;                              // точка по оси Ох
        private int y;                              // точка по оси Оу


        public int X
        {
            get
            {
                return x;
            }
            set                                      // установим
            {
                if (value >= 50)                     // если координата по Ох уйдет за пределы конца поля (=50)
                {
                    x = 0;                           // то мы должны вернуть его начальное положение (=0) 
                }
                else if (value < 0)                  // если координата по Ох уйдет за пределы начала поля (=0)
                {
                    x = 49;                          // то мы должны вернуть его конечное положение (<50)
                }
                else
                {
                    x = value;
                }
            }
        }
        public int Y                                  // делаем все тоже (как и с координатами Ох) для координат оси Оу
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 50)
                {
                    y = 0;
                }
                else if (value < 0)
                {
                    y = 49;
                }
                else
                {
                    y = value;
                }
            }
        }

        public override bool Equals(object obj)             // Eqauls - метод определяет, равен ли заданный объект текущему объекту  
        {
            Point a = obj as Point;
            return a.X == X && a.Y == Y;
        }
    }
}