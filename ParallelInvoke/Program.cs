using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelInvoke
{
    class Program
    {
       
        static void PrintNum()
        {
            
            
                Console.WriteLine("Print(), Thread ID: " + Thread.CurrentThread.ManagedThreadId);
                int i = default;
                while (++i < 20) { Console.Write(i + " "); Thread.Sleep(300); }
                Console.WriteLine();
                Console.WriteLine("------------------------------");
                Thread.Sleep(300);
                
            
        }
        static void PrintAlpha()
        {
           
            
                Console.WriteLine("PrintAlpha(), Thread ID: " + Thread.CurrentThread.ManagedThreadId);
                char c = 'A';
                while (c <= 'Z') { Console.Write(c++ + " "); Thread.Sleep(300); }
                Console.WriteLine();
                
                Console.WriteLine("------------------------------");
                
            
        }
        static void Main(string[] args)
        {
            //for(int i=0;i<10;i++)
            Parallel.Invoke(
                ()=> PrintNum(),
                ()=>PrintAlpha()
                );
           // Task.Factory.StartNew(()=>PrintAlpha());
            Console.WriteLine("Thanks");
           // Console.ReadLine();
           
        }
    }
}
