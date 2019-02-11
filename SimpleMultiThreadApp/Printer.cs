using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleMultiThreadApp
{

    class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("PrintNumbers() is running on Thread: "+Thread.CurrentThread.Name);
            int i = 0;
            while (++i <= 10)
            {
                Console.Write(i+"\t");
                Thread.Sleep(300);
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------");
        }
        public void PrintNumbers2(object o)
        {
            Console.WriteLine("PrintNumbers2() is running on Thread: " + Thread.CurrentThread.Name);
            if(o is Data d)
            foreach(int i in d.ia)
            {
                Console.Write(i + "\t");
                Thread.Sleep(300);
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------");
        }
    }
}
