using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursive_descent_parser
{
    public class Parser
    {
        private char[] invoer;
        private int teken = 0;
        public Parser(char[] c)
        {
            invoer = c;
        }

        public void parse()
        {
            expressie();
            Console.WriteLine("Klaar met parsen.");
            Console.ReadLine();                    
        }

        private  void expressie()
        {                 
            Console.WriteLine("in expressie()");
            if (term() == 1)
            {
                expacc();
            }          
        }

        private void expacc()
        {                     
            Console.WriteLine("in expacc()");
            if (teken < invoer.Length)
            {
                if ((int)invoer[teken] == 43 || (int)invoer[teken] == 45)
                {
                    teken++;
                    term();
                    expacc();
                }
                else if ((int)invoer[teken] == 61)
                {
                    teken++;
                    expressie();
                }
                else
                {
                    term();
                    expacc();
                }
            }
        }

        private int term()
        {                       
            Console.WriteLine("in term()");
            if (factor() == 1)
            {
                if (termacc() == 1)
                {
                    return 1;
                }
            }            
            return 0;
        }

        private int termacc()                           
        {                   
            Console.WriteLine("in termacc()");
            if (teken < invoer.Length)
            {
                if ((int)invoer[teken] == 42 || (int)invoer[teken] == 47 || (int)invoer[teken] == 94)
                {
                    teken++;
                    if (factor() == 1)
                    {
                        termacc();
                    }
                }
            }
            return 1; 
        }

        private int factor()
        {                    
            Console.WriteLine("in factor()");
            if (teken < invoer.Length)
            {
                if ((int)invoer[teken] == 40)
                {
                    teken++;
                    expressie();
                }
                else if ((int)invoer[teken] == 41)
                {
                    teken++;
                    return 1;
                }
                else if (integer() == 1)
                {
                    teken++;
                    return 1;
                }
                else if (variabele() == 1)
                {
                    teken++;
                    return 1;
                }
                else
                {
                    Console.WriteLine("Syntaxfout op " + (teken + 1) + ".");
                    stop();
                }
            }
            return 0;
        }

        private int integer()
        {                    
            Console.WriteLine("in integer()");
            int i = (int)invoer[teken];
            if (i > 47 && i < 58)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int variabele()
        {                  
            Console.WriteLine("in variabele()");
            int i = (int)invoer[teken];
            if ((i > 64 && i < 91) || (i > 96 && i < 123))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void stop()
        {
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
