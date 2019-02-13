using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAsync
{
    
    class Program
    {
         static string DoWork()
        {
            Console.WriteLine("working...");
            Thread.Sleep(5000);
            Console.WriteLine("OK...");
            return "i am done now!";
        }//
         static async Task<string> DoWorkAsync()
        {
            return await Task.Run(()=> {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("working...");
                    //Task.Delay(5000);
                    Console.WriteLine("OK...");
                }
                return "i am done now async";
            });
        }//
        static async Task VoidAsync()
        {
            await Task.Run(()=> {

                Console.WriteLine("working...");
                Thread.Sleep(5000);
                Console.WriteLine("Ok...");
            });
        }
        static async Task MultiAwait()
        {
            
            await Task.Run(() => { Thread.Sleep(2000); Console.WriteLine("Done with 1"); });
            await Task.Run(() => { Thread.Sleep(2000); Console.WriteLine("Done with 2"); });
            await Task.Run(() => { Thread.Sleep(2000); Console.WriteLine("Done with 3"); });
        }
        static void CallAsync()
        {
            string msg = DoWorkAsync().Result ;
            Console.WriteLine(msg);
            MultiAwait().Wait();
        }
        static async Task Main(string[] args)
        {
            //Task.Factory.StartNew(() => Console.WriteLine(DoWork()));
            string msg = "Test";
            //Console.WriteLine(DoWork());
             msg = await DoWorkAsync();
            //DoWork();
            await VoidAsync();
            //MultiAwait();
            //CallAsync();
            Console.WriteLine(msg);
            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}
