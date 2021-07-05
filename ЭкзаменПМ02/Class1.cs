using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЭкзаменПМ02
{
    class Class1
    {
        /// <summary>
        /// Структура путей и стоимости перемещения
        /// </summary>
        public struct Struct
        {
            public int p1;
            public int p2;
            public int length;
            public override string ToString()
            {
                return p1.ToString() + " - " + p2.ToString() + " " + length.ToString();
            }
        }

    }
}
