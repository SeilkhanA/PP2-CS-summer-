using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    public class Food : GameObject
    {
        public Food()
        {

            sign = '*';                         // еда будет в виде "@"
            
            Random rnd = new Random();          // Представляет генератор псевдослучайных чисел, то есть устройство, которое выдает последовательность чисел, отвечающую определенным статистическим критериям случайности.
            body.Clear();                       // добавить новую еду в рандомном месте после съедания змейкой
            Point x = new Point { X = rnd.Next(0, 49), Y = rnd.Next(0, 49) };     
            body.Add(x); //добавл. точку еды в рандомном месте в интервале от 0-49(поле)}
            }
        }
    }