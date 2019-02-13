using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace Review2
{
    
    
    class Program
    {
        class Data
        {
           public int[] ia;
            public int[] print(object o) {
                Data data = o as Data;
                foreach(int i in data.ia) {
                    Console.WriteLine(i);
                   // Thread.Sleep(300);
                }
                Console.WriteLine("----------------------------------");
                return (from na in data.ia where na % 2 == 0 orderby na select na).ToArray();
            }

            
        }
        static void Run()
        {

            throw new Exception("Error:");
            //throw null;
            
        }


        private static string Download()
        {
            return "cool";
        }
        static void Main(string[] args)
        {
            Data d = new Data() { ia = new[] { 2, 3, 4, 5, 6, 7, 89, 23, 4, 5, 6 } };
            Task<int[]> t = new Task<int[]>(d.print, d);
            
            t.Start();
            foreach(int i in t.Result) Console.WriteLine(i);
            Task<string> t2 = Task.Factory.StartNew<string>(Download);
            Console.WriteLine(t2.Result);
            Task<int> t3 = Task.Run(()=>10*10);
            Console.WriteLine(t3.Result);
        }

        
    }
}
