using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ЭкзаменПМ02
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(File.Create("log.txt")));
            Debug.AutoFlush = true;
            Class1 c1 = new Class1();
            c1.resh();
        }
    }
}
