using System;
using LexicalAnalyzer;
using LexicalAnalyzer.Token;
using RecursiveDescentParser.ParseTree;

namespace RecursiveDescentParser
{
    public class Parser
    {
        private readonly LexicalScanner _lex;
        private AbstractToken _current;
        private readonly ParseNode _start = new ParseNode(ParseEnum.Start);
        private ParseNode _currentNode;

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

            return _start;
        }

        private void Expressie()
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
            if (_current is AddSub)
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.Operator, _current.GetValue()));
                if (!_lex.EndOfInput)
                {
                    _current = _lex.GetNextToken();
                }
                Term();
                Expacc();
            }
            else if (_current is Equals)
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.Equals));
                if (!_lex.EndOfInput)
                {
                    _current = _lex.GetNextToken();
                }
                Expressie();
            }
            else
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.Empty));
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
            if (_current is Operator)
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.Operator, _current.GetValue()));
                if (!_lex.EndOfInput)
                {
                    _current = _lex.GetNextToken();
                }
                Factor();
                Termacc();
            }
            else
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.Empty));
            }
            _currentNode = _currentNode.GetParent();
        }

        private void Factor()
        {
            _currentNode.AddChild(new ParseNode(ParseEnum.Factor));
            _currentNode = _currentNode.getChildren()[_currentNode.getChildren().Count - 1];
            if (_current is OpenParenthesis)
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.OpenParenthesis));
                _current = _lex.GetNextToken();
                Expressie();
                if (_current is CloseParenthesis)
                {
                    _currentNode.AddChild(new ParseNode(ParseEnum.CloseParenthesis));
                    if (!_lex.EndOfInput)
                    {
                        _current = _lex.GetNextToken();
                    }
                }
            }
            else if (_current is Variable)
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.Variable, _current.GetValue()));
                if (!_lex.EndOfInput)
                {
                    _current = _lex.GetNextToken();
                }
            }
            else if (_current is Number)
            {
                _currentNode.AddChild(new ParseNode(ParseEnum.Number, _current.GetValue()));
                if (!_lex.EndOfInput)
                {
                    _current = _lex.GetNextToken();
                }
            }
            else
            {
                Console.WriteLine("Syntaxfout.");
                Stop();
            }
            _currentNode = _currentNode.GetParent();
        }

        private void Stop()
        {
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
