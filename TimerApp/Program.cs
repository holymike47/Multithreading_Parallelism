using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace TimerApp
{
    class Data
    {
        private object myLock = new object();
        public string Name = default;
        public string Message = default;
        public void Print(object o)
        {
            Monitor.Enter(myLock);
            try
            {
                int i = default;
                while (++i <= 10)
                {
                    Console.WriteLine("Print(), Thread ID: " + Thread.CurrentThread.ManagedThreadId + ", Value(" + i + ") ");
                    Thread.Sleep(500);
                }
                Console.WriteLine("Message: "+((Data)o).Message);
                Console.WriteLine("-------------------------------");

            }
            finally
            {
                Monitor.Exit(myLock);
            }
        }
    }
    class Program
    {
 
        static void PrintTime(object o)
        {     
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Time: "+DateTime.Now+" From ==> "+((Data)o).Name);
            Console.WriteLine("-------------------------------");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main() "+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("***** Working with Timer type *****\n");

            Timer _ = new Timer(PrintTime, (new Data() { Name = "Mike" }),0,1000);
            //Console.WriteLine("Hit Enter key to terminate...");
            //Console.ReadLine();
            Data data = new Data() {Message="Thanks Mike" };
            //WaitCallback work = new WaitCallback(data.Print);
           for (int i = 0; i < 10; i++) ThreadPool.QueueUserWorkItem(data.Print, data);
            
            Console.ReadLine();
        }
    }
}
