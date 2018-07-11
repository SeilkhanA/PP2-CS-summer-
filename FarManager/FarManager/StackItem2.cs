using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class StackItem2
    {
        int index;






        public int Index                 // функция, описывающая работу индекса
        {

            get                         // присваиваю значение index
            {
                return index;          // с этим индексом будем работать как с value?
            }

           

            set
            {
                if(value < 0)            //Параметр value представляет передаваемое значение.
                {
                    index = 0;
                }
                else if (value >= DirInfo.GetFileSystemInfos().Length)
                {
                    index = DirInfo.GetFileSystemInfos().Length - 1;
                }
                else
                {
                    index = value;
                }
            }
        }

        public DirectoryInfo DirInfo               // почему здесь объявили??   
        {
            get;
            set;
        }
    }
}