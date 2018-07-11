using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class StackItem                           //объявили класс Stack FILO
    {
        //задаем параметры (поля) 
        DirectoryInfo dirInfo;      //свойства папки            
        int index;                  //индекс того на какой строке находимся

        public StackItem(DirectoryInfo dirInfo, int index)
        {
            this.dirInfo = dirInfo;
            this.index = index;
        }

        public void SetIndex(int index)   // функция работающая с установлением положение строки
        {
            if (index < 0)                           // если мы захотим уходить наверх то голубая строка не будет уходить и подниматься снизу
            {
                this.index = 0;                      // она будет стоять на нулевом (том же) месте 
            }
            else if (index >= dirInfo.GetDirectories().Length)    //если же наоборот уйдем вниз за пределы размера папки
            {
                this.index = dirInfo.GetDirectories().Length - 1;  // то он просто остнаовится на самом послднем 
            }
            else
            {
                this.index = index;                               //если же никакие вышеупомянутые условия не предвидятся, то просто передвигать
            }
        }





        public int GetIndex()     // функция, получающая этот индекс 
        {
            return index;           //этот индекс из функции описанной выше
        }




        public void SetDirInfo(DirectoryInfo dirInfo)      
        {
            this.dirInfo = dirInfo;
        }





        public DirectoryInfo GetDirInfo()
        {
            return dirInfo;
        }
    }
}

