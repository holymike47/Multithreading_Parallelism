using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace Review2
{
    delegate int Sum(int a, int b);
    [Synchronization]
    class Car:ContextBoundObject {
        public Car() {
            Console.WriteLine(Thread.CurrentContext.ContextID);
        }
    }
    class Program
    {
        static int mySum(int a, int b) => a + b;
        static void Main(string[] args)
        {
            Func<int, int, int> sum = new Func<int, int, int>(mySum);

            Console.WriteLine(sum.Invoke(3, 6));
            
            Console.WriteLine(Thread.CurrentContext.ContextID);
            new Car();
        }
    }
}
