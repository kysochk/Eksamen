using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЭкзаменПМ02
{
    class Class1
    {
        public string a;
        /// <summary>
        /// пути и стоимость перемещения
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
          

        }
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
        /// <summary>
        /// Чтение из файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Struct> Input()
    {
        Debug.WriteLine("\n\nЧтение:");
        List<Struct> StQ = new List<Struct>();
        using (StreamReader sr = new StreamReader("Ввод.csv"))
        {
            while (sr.EndOfStream != true)
            {
                string[] s1 = sr.ReadLine().Split(';');
                string[] s2 = s1[0].Split('-');
                Debug.WriteLine(s2[0] + " - " + s2[1] + "; " + s1[1]);
                StQ.Add(new Struct { p1 = Convert.ToInt32(s2[0]), p2 = Convert.ToInt32(s2[1]), length = Convert.ToInt32(s1[1]) });
            }
        }
        return StQ;
    }
        /// <summary>
        /// Метод построения пути Работает рекурсивно
        /// </summary>
        /// <param name="StQ"></param>
        /// <param name="minel"></param>
        /// <returns></returns>
        public int CreatePath(List<Struct> StQ, Struct minel)
        {
            int Lenght = 0;
            Struct MoveVar = StQ.Find(x => x.p1 == minel.p1 && x.p2 == minel.p2);//возможные варианты передвижения
            a += MoveVar.p1.ToString() + "-" + MoveVar.p2.ToString();//передижение
            if (MoveVar.p2 == StQ[MaxElem(StQ)].p2)//местонахождение
            {
                a += ";";
                return MoveVar.length;
            }
            else
            {
                for (int i = 0; i < StQ.Count; i++)//стоимость перемещения
                {
                    if (StQ[i].p1 == MoveVar.p2)
                    {
                        a += ",";
                        Lenght = CreatePath(StQ, StQ[i]) + MoveVar.length;
                    }
                }
            }
            return Lenght;
        }
        /// <summary>
        /// Сумма длины пути
        /// </summary>
        /// <param name="StQ"></param>
        /// <returns></returns>
        public int LenFunc(List<Struct> StQ)
        {
            int Lenght = 0;
            foreach (Struct rb in StQ)
            {
                Lenght += rb.length;
            }
            return Lenght;
        }

    }
}
