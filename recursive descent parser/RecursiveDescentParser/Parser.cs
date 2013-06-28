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
        readonly LexicalScanner _lex;
        AbstractToken _current;
        readonly ParseNode _start = new ParseNode(ParseEnum.Start);
        ParseNode _currentNode;
        public Parser(String invoer)
        {
            _lex = new LexicalScanner(invoer);
            _currentNode = _start;
        }

        public ParseNode Parse()
        {
            _current = _lex.GetNextToken();
            try
            {
                Expressie();
            }
            catch (MatchException me)
            {
                Console.WriteLine(me.Message);
            }
            _start.printTree();
            Console.ReadLine();

            return _start;
        }

        private  void Expressie()
        {
            _currentNode.AddChild(new ParseNode(ParseEnum.Expression));
            _currentNode = _currentNode.getChildren()[_currentNode.getChildren().Count - 1];
            Term();
            Expacc();
            _currentNode = _currentNode.GetParent();    
        }

        private void Expacc()
        {
            _currentNode.AddChild(new ParseNode(ParseEnum.ExpressionAccent));
            _currentNode = _currentNode.getChildren()[_currentNode.getChildren().Count - 1];
            if (!_lex.EndOfInput)
            {
                if (_current is AddSub)
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.Operator, _current.GetValue()));
                    _current = _lex.GetNextToken();
                    Term();
                    Expacc();
                }
                else if (_current is Equals)
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.Equals));
                    _current = _lex.GetNextToken();
                    Expressie();
                }
                else
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.Empty));
                }
            }
            _currentNode = _currentNode.GetParent();
        }

        private void Term()
        {
            _currentNode.AddChild(new ParseNode(ParseEnum.Term));
            _currentNode = _currentNode.getChildren()[_currentNode.getChildren().Count - 1];
            Factor();
            Termacc();
            _currentNode = _currentNode.GetParent();
        }

        private void Termacc()                           
        {
            _currentNode.AddChild(new ParseNode(ParseEnum.TermAccent));
            _currentNode = _currentNode.getChildren()[_currentNode.getChildren().Count - 1];
            if (!_lex.EndOfInput)
            {
                if (_current is Operator)
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.Operator, _current.GetValue()));
                    _current = _lex.GetNextToken();
                    Factor();
                    Termacc();
                }
                else
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.Empty));
                }
            }
            _currentNode = _currentNode.GetParent();
        }

        private void Factor()
        {
            _currentNode.AddChild(new ParseNode(ParseEnum.Factor));
            _currentNode = _currentNode.getChildren()[_currentNode.getChildren().Count - 1];
            if (!_lex.EndOfInput)
            {
                if (_current is OpenParenthesis)
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.OpenParenthesis));
                    _current = _lex.GetNextToken();
                    Expressie();
                    if (_current is CloseParenthesis)
                    {
                    _currentNode.AddChild(new ParseNode(ParseEnum.CloseParenthesis));
                    _current = _lex.GetNextToken();
                    }
                }
                else if (_current is Variable)
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.Variable, _current.GetValue()));
                    _current = _lex.GetNextToken();
                }
                else if (_current is Number)
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.Number, _current.GetValue()));
                    _current = _lex.GetNextToken();                    
                }
                else
                {
                    Console.WriteLine("Syntaxfout.");
                    Stop();
                }
            }
            _currentNode = _currentNode.GetParent();
        }     

        private static void Stop()
        {
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
