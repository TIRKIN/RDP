using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexicalAnalyzer;
using LexicalAnalyzer.Token;
using recursive_descent_parser.ParseTree;


namespace recursive_descent_parser
{
    public class Parser
    {
        LexicalScanner lex;
        AbstractToken current;
        ParseNode start = new ParseNode("S");
        ParseNode CurrentNode;
        public Parser(String invoer)
        {
            lex = new LexicalScanner(invoer);
            CurrentNode = start;
        }

        public void parse()
        {
            current = lex.GetNextToken();
            try
            {
                expressie();
            }
            catch (MatchException me)
            {
                Console.WriteLine(me.Message);
            }
            Console.WriteLine("Klaar met parsen.");
            Console.ReadLine();                    
        }

        private  void expressie()
        {                 
            Console.WriteLine("in expressie()");
            term();
            expacc();                    
        }

        private void expacc()
        {                     
            Console.WriteLine("in expacc()");
            if (!lex.EndOfInput)
            {
                if (current is AddSub)
                {
                    current = lex.GetNextToken();
                    term();
                    expacc();
                }
                else if (current is Equals)
                {
                    current = lex.GetNextToken();
                    expressie();
                }
                else
                {
                    term();
                    expacc();
                }
            }
        }

        private void term()
        {                       
            Console.WriteLine("in term()");
            factor();
            termacc();
        }

        private void termacc()                           
        {                   
            Console.WriteLine("in termacc()");
            if (!lex.EndOfInput)
            {
                if (current is Operator)
                {
                    current = lex.GetNextToken();
                    factor();
                    termacc();
                }
            }
        }

        private void factor()
        {                    
            Console.WriteLine("in factor()");
            if (!lex.EndOfInput)
            {
                if (current is OpenParenthesis)
                {
                    current = lex.GetNextToken();
                    expressie();
                }
                else if (current is CloseParenthesis)
                {
                    current = lex.GetNextToken();
                }
                else if (current is Variable)
                {
                    current = lex.GetNextToken();
                }
                else if (current is Number)
                {
                    current = lex.GetNextToken();                    
                }
                else
                {
                    Console.WriteLine("Syntaxfout.");
                    stop();
                }
            }
        }     

        private void stop()
        {
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
