using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursive_descent_parser
{
    class Program
    {               
        static void Main(string[] args)
        {
            Console.WriteLine("Invoer: " + args[0]); 
            int i = 0;                              
            char[] invoer = new char[args[0].Length];
            foreach (char c in args[0])           
            {
                invoer[i] = c;
                i++;
            }
            Parser p = new Parser(invoer);
            p.parse();
        }

    }      
}
