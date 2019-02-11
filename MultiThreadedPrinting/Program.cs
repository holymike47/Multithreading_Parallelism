using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadedPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer p = new Printer();
            Printer2 p2 = new Printer2();
            int[] ia = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            Thread[] ta = new Thread[10];
            for(int i = 0; i < ta.Length; i++)
            {
                //ta[i] = new Thread(new ThreadStart(p.PrintNumbers)) { Name = "Worker: " + (i+1) };
                ta[i] = new Thread(new ThreadStart(p2.PrintNumbers)) { Name = "Worker: " + (i + 1) };
            }
            foreach(Thread t in ta)
            {
                t.Start();
                
            }
            //Console.ReadLine();

        }
    }
}
