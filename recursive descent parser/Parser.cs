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
        ParseNode start = new ParseNode(ParseEnum.Start);
        ParseNode CurrentNode;
        public Parser(String invoer)
        {
            lex = new LexicalScanner(invoer);
            CurrentNode = start;
        }

        public ParseNode parse()
        {
            current = lex.Peek();
            try
            {
                expressie();
            }
            catch (MatchException me)
            {
                Console.WriteLine(me.Message);
            }
            Console.WriteLine("Klaar met parsen.");
            start.printTree();
            Console.ReadLine();

            return start;
        }

        private  void expressie()
        {
            CurrentNode.AddChild(new ParseNode(ParseEnum.Expression));
            CurrentNode = CurrentNode.getChildren()[CurrentNode.getChildren().Count - 1];
            term();
            expacc();
            CurrentNode = CurrentNode.GetParent();    
        }

        private void expacc()
        {
            CurrentNode.AddChild(new ParseNode(ParseEnum.ExpressionAccent));
            CurrentNode = CurrentNode.getChildren()[CurrentNode.getChildren().Count - 1];
            if (!lex.EndOfInput)
            {
                if (current is AddSub)
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.Operator, current.GetValue()));
                    current = lex.GetNextToken();
                    term();
                    expacc();
                }
                else if (current is Equals)
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.Equals));
                    current = lex.GetNextToken();
                    expressie();
                }
                else
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.Empty));
                }
            }
            CurrentNode = CurrentNode.GetParent();
        }

        private void term()
        {
            CurrentNode.AddChild(new ParseNode(ParseEnum.Term));
            CurrentNode = CurrentNode.getChildren()[CurrentNode.getChildren().Count - 1];
            factor();
            termacc();
            CurrentNode = CurrentNode.GetParent();
        }

        private void termacc()                           
        {
            CurrentNode.AddChild(new ParseNode(ParseEnum.TermAccent));
            CurrentNode = CurrentNode.getChildren()[CurrentNode.getChildren().Count - 1];
            if (!lex.EndOfInput)
            {
                if (current is Operator)
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.Operator, current.GetValue()));
                    current = lex.GetNextToken();
                    factor();
                    termacc();
                }
                else
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.Empty));
                }
            }
            CurrentNode = CurrentNode.GetParent();
        }

        private void factor()
        {
            CurrentNode.AddChild(new ParseNode(ParseEnum.Factor));
            CurrentNode = CurrentNode.getChildren()[CurrentNode.getChildren().Count - 1];
            if (!lex.EndOfInput)
            {
                if (current is OpenParenthesis)
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.OpenParenthesis));
                    current = lex.GetNextToken();
                    expressie();
                    if (current is CloseParenthesis)
                    {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.CloseParenthesis));
                    current = lex.GetNextToken();
                    }
                }
                else if (current is Variable)
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.Variable, current.GetValue()));
                    current = lex.GetNextToken();
                }
                else if (current is Number)
                {
                    CurrentNode.AddChild(new ParseNode(ParseEnum.Number, current.GetValue()));
                    current = lex.GetNextToken();                    
                }
                else
                {
                    Console.WriteLine("Syntaxfout.");
                    stop();
                }
            }
            CurrentNode = CurrentNode.GetParent();
        }     

        private void stop()
        {
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
