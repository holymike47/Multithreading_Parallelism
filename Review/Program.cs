using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace Review
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;
            Console.WriteLine("Thread Priority: "+t.Priority);
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine("Application domain: "+ad+" Default? "+ad.IsDefaultAppDomain());
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("Context: "+ctx);
            Func<int, int, int> sum = (m, n) => {
                Console.WriteLine($"in Thread {Thread.CurrentThread.ManagedThreadId}, working behind........");
                Thread.Sleep(20000);
                Console.WriteLine($"in Thread {Thread.CurrentThread.ManagedThreadId}, returning........");
                return m + n;
                                                };
            Console.WriteLine("Main(), Thread Id: "+ Thread.CurrentThread.ManagedThreadId);
            //int s = sum.Invoke(10, 10);
            IAsyncResult r = sum.BeginInvoke(10, 20, null, null);
            while (!r.IsCompleted)
            {
                Console.WriteLine("Main(), Thread Id: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Do More work");
                Thread.Sleep(1000);
                Console.WriteLine("==================================");
            }
           /* while (false == r.AsyncWaitHandle.WaitOne(1000,true))
            {
                Console.WriteLine("Main(), Thread Id: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Do More work");
                Console.WriteLine("==================================");
            }*/
            
            int a = sum.EndInvoke(r);
            Console.WriteLine("Sum: "+a);
            Console.WriteLine("Main(), Thread Id: " + Thread.CurrentThread.ManagedThreadId);

        }
    }
}
