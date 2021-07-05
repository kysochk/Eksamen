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
            /// <summary>
            /// Поиск начальной точки.Путем взятия самого маленького элемента из первого столбца, которого нет во втором
            /// </summary>
            /// <param name="StQ"></param>
            /// <returns></returns>

            public int MinElem(List<Struct> StQ)
            {
                int min = StQ[0].p1, minind = 0;
                foreach (Struct Path in StQ)
                {
                    if (Path.p1 <= min)
                    {
                        min = Path.p1;
                        minind = StQ.IndexOf(Path);
                    }
                }
                return minind;
            }
            /// <summary>
            /// Поиск конечной точки
            /// </summary>
            /// <param name="StQ"></param>
            /// <returns></returns>
            public int MaxElem(List<Struct> StQ)
            {
                int min = StQ[0].p2, maxind = 0;
                foreach (Struct Path in StQ)
                {
                    if (Path.p2 >= min)
                    {
                        min = Path.p1;
                        maxind = StQ.IndexOf(Path);
                    }
                }
                return maxind;
            }

        }

    }
}
