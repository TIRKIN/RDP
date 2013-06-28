using System;

namespace RecursiveDescentParser
{
    class Program
    {               
        static void Main(string[] args)
        {
            Console.WriteLine("Invoer: " + args[0]);         
            Parser p = new Parser(args[0]);
            p.Parse();
        }

    }      
}
