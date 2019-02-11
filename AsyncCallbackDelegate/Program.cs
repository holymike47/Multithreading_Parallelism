using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;
namespace AsyncCallbackDelegate
{
    class Program
    {
        
        static bool IsDone = false;
        static void Completed(IAsyncResult r)
        {
            Console.WriteLine("Action Completed");
            Console.WriteLine("Called on Thread: "+Thread.CurrentThread.ManagedThreadId);
            AsyncResult ar = (AsyncResult)r;
            Func<int, int, int> sum = (Func<int, int, int>)ar.AsyncDelegate;
            Console.WriteLine("Result of computation: "+sum.EndInvoke(r));
            Console.WriteLine((string)r.AsyncState);
            IsDone = true;
        }
        static void Main(string[] args)
        {
            Func<int, int, int> sum = (m, n) =>
               {
                   Console.WriteLine("Sum Invoked on thread: " + Thread.CurrentThread.ManagedThreadId);
                   Thread.Sleep(10000);
                   return m + n;
               };
            IAsyncResult r = sum.BeginInvoke(10, 18, Completed, "Thanks Boss");
            while (!IsDone)
            {
                Console.WriteLine("Working on Main(), Thread Id: " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }

            
        }
    }
}
