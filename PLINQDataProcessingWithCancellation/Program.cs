using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PLINQDataProcessingWithCancellation
{
    class Program
    {
        private static CancellationTokenSource Ct = new CancellationTokenSource();
        static void ProcessData()
        {
            int[] ia = null;
            try
            {
                ia = Enumerable.Range(1, 100_000_000).ToArray<int>();
                int[] mod3 = (from num in ia.AsParallel().WithCancellation(Ct.Token) where num % 3 == 0 select num).ToArray();
                Console.WriteLine("Total: " + mod3.Count());
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----------Starting---------");
            Task.Factory.StartNew(()=>ProcessData());
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(300);
                if (i == 4) Ct.Cancel();
            }
            //ProcessData();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
