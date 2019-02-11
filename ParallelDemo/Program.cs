using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ParallelDemo
{
    class Program
    {
        static object MyLock = new object();
        static void Print()
        {
            lock (MyLock)
            {
                Console.WriteLine("Print(), Thread ID: " + Thread.CurrentThread.ManagedThreadId);
                int i = default;
                while (++i < 20) Console.Write(i + " ");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[] ia = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Parallel.ForEach<int>(ia, (i) => Console.Write(i+" "));
            //foreach (int i in ia) Console.Write(i + " ");
            for(int i=0;i<10;i++)
            Task.Factory.StartNew(()=>Print());
            Console.ReadLine();
    
            Console.WriteLine();
        }
    }
}
