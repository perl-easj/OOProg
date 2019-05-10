using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UtilLib utilLib = new UtilLib();
            AsyncSpecificImplA implA = new AsyncSpecificImplA(utilLib);
            AsyncSpecificImplB implB = new AsyncSpecificImplB(utilLib);

            Console.WriteLine("testing implA");
            implA.AsyncMethodA();


            Console.WriteLine("testing implB");
            implB.AsyncMethodA();

            Console.WriteLine();
            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
