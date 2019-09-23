using System;
using VidlyConsoleApp01.Examples;

namespace VidlyConsoleApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            var custExamples = new CustomerExamples();
            var codeTableExamples = new CodeTableExamples();
            var movieExamples = new MovieExamples();
            var aspNetExamples = new AspNetExamples();
            //custExamples.Example01();          
            //codeTableExamples.Example01();
            //codeTableExamples.Example02();
            //custExamples.Example02();
            //custExamples.Example03();
            //movieExamples.Example02();

            

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    } 
}
