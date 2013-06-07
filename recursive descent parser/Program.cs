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
            Parser p = new Parser(args[0]);
            p.parse();
        }

    }      
}
