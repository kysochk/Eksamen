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
        /// пути и время(дни) перемещения
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
        /// <summary>
        /// Основной рабочий метод
        /// </summary>
        public void resh()
        {
            try
            {
                List<Struct> LPath;
                List<Struct> StQ = Input();//лист исходных данных 
                LPath = StQ.FindAll(x => x.p1 == StQ[MinElem(StQ)].p1);
                List<List<Struct>> LPathFunc = new List<List<Struct>>();
                foreach (Struct rb in LPath)
                {
                    CreatePath(StQ, rb);
                    LPathFunc.Add(Branches(StQ, a));
                    a = "";
                }

                Debug.WriteLine("Возможные пути: ");
                for (int i = 0; i < LPathFunc.Count; i++)
                {
                    foreach (Struct path in LPathFunc[i])
                    {
                        Debug.Write(path.p1 + " - " + path.p2);
                    }
                    Debug.WriteLine("");
                }


                int max = LPathFunc[0][0].length, maxind = 0;
                for (int i = 0; i < LPath.Count; i++)// подсчет стоимости путей
                {
                    if (LenFunc(LPathFunc[i]) >= max)// выбор самого большого
                    {
                        max = LenFunc(LPathFunc[i]);
                        maxind = i;
                    }
                }
                Debug.WriteLine("Критический путь (в днях):  " + max);
                Debug.WriteLine("Номер пути: " + maxind);
                vivod(LPathFunc, maxind, max);//Запись в файл решения
            }
            catch
            {
                Debug.WriteLine("Ошибка в модуле решения");
                Environment.Exit(1);


            }
        }

        /// <summary>
        /// Поиск начальной точки
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
        /// <summary>
        /// Чтение из файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Struct> Input()
        {
            try
            {
                Debug.WriteLine("Исходные данные:");
                List<Struct> StQ = new List<Struct>();
                using (StreamReader sr = new StreamReader(@"Ввод.csv"))
                {
                    while (sr.EndOfStream != true)
                    {
                        string[] s1 = sr.ReadLine().Split(';');
                        string[] s2 = s1[0].Split('-');
                        Debug.WriteLine(s2[0] + " - " + s2[1] + "; Day: " + s1[1]);
                        StQ.Add(new Struct { p1 = Convert.ToInt32(s2[0]), p2 = Convert.ToInt32(s2[1]), length = Convert.ToInt32(s1[1]) });
                    }
                }
                return StQ;
            }
            catch
            {
                List<Struct> StQ = new List<Struct>();
                Debug.WriteLine("Ошибка в модуле чтения");
                Environment.Exit(1);
                return StQ; //обход ошибки
            }
        }
        /// <summary>
        /// Метод построения пути 
        /// </summary>
        /// <param name="StQ"></param>
        /// <param name="minel"></param>
        /// <returns></returns>
        public int CreatePath(List<Struct> StQ, Struct minel)
        {
            try
            {
                int Lenght = 0;
                Struct MoveVar = StQ.Find(x => x.p1 == minel.p1 && x.p2 == minel.p2);
                a += MoveVar.p1.ToString() + "-" + MoveVar.p2.ToString();//переход
                if (MoveVar.p2 == StQ[MaxElem(StQ)].p2)
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
            catch
            {
                Debug.WriteLine("Ошибка в модуле построения путей");
                Environment.Exit(1);
                return 1;
            }
        }
        /// <summary>
        /// Поиск суммы длины пути
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
        /// <summary>
        /// Построение ветвлений 
        /// </summary>
        /// <param name="LPathFunc"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public List<Struct> Branches(List<Struct> StQ, string s)
        {
            try
            {
                List<List<Struct>> LBr = new List<List<Struct>>();
                string[] s1 = s.Split(';');
                foreach (string st1 in s1)
                {
                    if (st1 != "")
                    {
                        LBr.Add(new List<Struct>());
                        string[] s2 = st1.Split(',');
                        foreach (string str2 in s2)
                        {
                            if (str2 != "")
                            {
                                string[] str3 = str2.Split('-');
                                LBr[LBr.Count - 1].Add(StQ.Find(x => x.p1 == Convert.ToInt32(str3[0]) && x.p2 == Convert.ToInt32(str3[1])));
                            }
                        }
                    }
                }
                foreach (List<Struct> l in LBr)
                {
                    if (l[0].p1 != StQ[MinElem(StQ)].p1)
                    {
                        foreach (List<Struct> l1 in LBr)
                        {
                            if (l1[0].p1 == StQ[MinElem(StQ)].p1)
                            {
                                l.InsertRange(0, l1.FindAll(x => l1.IndexOf(x) <= l1.FindIndex(y => y.p2 == l[0].p1)));
                            }
                        }
                    }
                }
                int max = LBr[0][0].length, maxind = 0;
                for (int i = 0; i < LBr.Count; i++)
                {
                    if (LenFunc(LBr[i]) >= max)
                    {
                        max = LenFunc(LBr[i]);
                        maxind = i;
                    }
                }
                return LBr[maxind];
            }
            catch
            {
                List<List<Struct>> LBr = new List<List<Struct>>();
                Debug.WriteLine("Ошибка в модуле построения ветвей.");
                Environment.Exit(1);
                return LBr[1]; //обход ошибки


            }
        }
        /// <summary>
        /// Запись в файл
        /// </summary>
        /// <param name="LPathFunc"></param>
        /// <param name="maxind"></param>
        /// <param name="max"></param>
        public void vivod(List<List<Struct>> LPathFunc, int maxind, int max)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(@"Вывод.csv", false, Encoding.Default, 10))
                {
                    foreach (Struct Path in LPathFunc[maxind])
                    {
                        sr.Write(Path.p1 + " - " + Path.p2 + ";(" + Path.length + ") ");
                    }
                    sr.WriteLine("Длина " + max);
                }
            }
            catch
            {
                Debug.WriteLine("Запись в файл прервана.");
                Environment.Exit(1);

            }
        }


    }
}
