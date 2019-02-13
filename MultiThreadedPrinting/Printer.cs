using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace MultiThreadedPrinting
{
    class Data
    {
        public int[] ia ;
       
    }

    class Printer
    {
        private object threadLock = new object();
        static ConsoleColor cc;
        public void PrintNumbers()
        {
            lock (threadLock)
            {
                Console.BackgroundColor = cc++;
                Console.WriteLine("\nPrintNumbers() is running on Thread: " + Thread.CurrentThread.Name + "\n");
                //Random r = new Random();
                int i = 0;
                while (++i <= 10)
                {
                    Console.WriteLine("(" + i + ")\tFrom: " + Thread.CurrentThread.Name + "\t");
                    Thread.Sleep(200);
                }
                Console.WriteLine();
                Console.WriteLine($"-----------{Thread.CurrentThread.Name} is done---------------");
                
            }
        }
        public void PrintNumbers2(object o)
        {
            Monitor.Enter(threadLock);
            try
            {
                Console.WriteLine("PrintNumbers2() is running on Thread: " + Thread.CurrentThread.Name);
                Random r = new Random();
                if (o is Data d)
                    foreach (int i in d.ia)
                    {
                        Console.Write(i + "\tFrom: " + Thread.CurrentThread.Name);
                        Thread.Sleep(1000 * r.Next(5));
                    }
                Console.WriteLine();
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Monitor.Exit(threadLock);
                
            }
        }
    }
    [Synchronization]
    class Printer2:ContextBoundObject
    {
        private object threadLock = new object();
        static ConsoleColor cc;
        public void PrintNumbers()
        {
           //lock (threadLock)
            {
               // Console.WriteLine("No Explicit Lock");
                Console.BackgroundColor = cc++;
                Console.WriteLine("\nPrintNumbers() is running on Thread: " + Thread.CurrentThread.Name + "\n");
                //Random r = new Random();
                int i = 0;
                while (++i <= 10)
                {
                    Console.WriteLine("(" + i + ")\tFrom: " + Thread.CurrentThread.Name + "\t");
                    Thread.Sleep(200);
                }
                Console.WriteLine();
                Console.WriteLine($"-----------{Thread.CurrentThread.Name} is done---------------");

            }
        }
        public void PrintNumbers2(object o)
        {
            Monitor.Enter(threadLock);
            try
            {
                Console.WriteLine("PrintNumbers2() is running on Thread: " + Thread.CurrentThread.Name);
                Random r = new Random();
                if (o is Data d)
                    foreach (int i in d.ia)
                    {
                        Console.Write(i + "\tFrom: " + Thread.CurrentThread.Name);
                        Thread.Sleep(1000 * r.Next(5));
                    }
                Console.WriteLine();
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Monitor.Exit(threadLock);

            }
        }
    }
}
