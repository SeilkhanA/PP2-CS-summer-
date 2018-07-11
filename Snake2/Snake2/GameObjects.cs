using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    public class GameObject
    {
        public List <Point> body = new List<Point>();         // создаем аналог вектора (List) для точек, из которых будет состоять тело змейки и еды
        public char sign;

        public void Clear()                     // функция очищения
        {
            foreach (Point p in body)           // для каждой точки в body
            {
                Console.SetCursorPosition(p.X, p.Y);   // устанавливаем позицию курсора точки по Ох и по Оу
                Console.Write(' ');                    // пробелом устанавливем очищание
            }
        }
        public void Draw()                      // функция "рисования" точек
        {
            foreach (Point p in body)          // для каждой точки в body
            {
                Console.SetCursorPosition(p.X, p.Y);   // устанавливаем позицию курсора точки по Ох и по Оу
                Console.Write(sign);                   // знаком sign будет происходить заполнение (рисование)
            }
        }
    }
}