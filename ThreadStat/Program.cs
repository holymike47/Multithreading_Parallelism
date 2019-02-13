using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadStat
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread pt = Thread.CurrentThread;
            pt.Name = "My_Primary";
            Console.WriteLine("Current Domain: "+Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of Context: "+Thread.CurrentContext.ContextID);
            Console.WriteLine("Thread Name: "+pt.Name);
            Console.WriteLine("Is Alive: "+pt.IsAlive);
            Console.WriteLine("Priority Level: "+pt.Priority);
            Console.WriteLine("Thread State: "+pt.ThreadState);
        }
    }
}
