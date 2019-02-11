using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SimpleMultiThreadApp
{
    class Data
    {
        public int[] ia;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Primary";
            Console.WriteLine("How many threads do you want, 1 or 2");
            int.TryParse(Console.ReadLine(), out int threads);
            Printer printer = new Printer();
            switch (threads)
            {
                case 1:
                    printer.PrintNumbers();
                    break;
                case 2:
                    Thread sec = new Thread(new ThreadStart(printer.PrintNumbers)){ Name = "Secondary"};
                    sec.Start();
                    break;
                case 3:
                    Thread tert = new Thread(new ParameterizedThreadStart(printer.PrintNumbers2)) { Name = "Tertiary" };
                    tert.Start(new Data() { ia = new int[]{ 2, 4, 6, 8, 10, 12 } });
                    break;
                default:
                    goto case 1;

            }// end switch
            Console.WriteLine();
            MessageBox.Show("Please i am busy on Thread: "+Thread.CurrentThread.Name);
            Console.ReadKey();
        }
    }
}
