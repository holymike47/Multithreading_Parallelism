using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AtomicLock
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = default;
            for(int i = 0; i < 10; i++)
            {
                Interlocked.Increment(ref n);
                Console.Write(n+" ");
                
            }
            Console.WriteLine();
            int j = Interlocked.Exchange(ref n, 1000);
            Console.WriteLine(n);
            int k = Interlocked.CompareExchange(ref n, 500, 1000);
            Console.WriteLine("n: "+n);
            Console.WriteLine("k: "+k);
        }
    }
}
