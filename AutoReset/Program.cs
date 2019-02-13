using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutoReset
{
    class Data { public int[] ia; }
    class Program
    {
        //waithandle to notify when other thread should run
        private static AutoResetEvent WaitHandle = new AutoResetEvent(false);
        static void Process(object o)
        {
            Console.WriteLine("In Process(): "+Thread.CurrentThread.Name);
            if(o is Data d)
            {
                foreach(int i in d.ia)
                {
                    Thread.Sleep(2000);
                    Console.Write(i + "\n");      
                }
                Console.WriteLine("-----------------");
                WaitHandle.Set();
            }
        }
        static void Main(string[] args)
        {
            Thread primary = Thread.CurrentThread;
            primary.Name = "Primary";
            Console.WriteLine("In Main(): "+primary.Name);
            Thread sec = new Thread(Process) { Name = "Secondary", IsBackground = false };
            sec.Start(new Data() { ia = new int[] { 10, 20, 30, 40, 50 } });
            //sec.Join();
           WaitHandle.WaitOne();
            Console.WriteLine("Secondary thread is done!");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thanks Mike "+primary.Name);
                Thread.Sleep(1000);

            }

        }
    }
}
