using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LexicalAnalyzer.Token;

namespace LexicalAnalyzer
{
    public class LexicalScanner
    {
        private string _input;
        private int _counter;
        private ExpressionDictionary _dictionary;

        public LexicalScanner(string input)
        {
            _input = input;
            _dictionary = new ExpressionDictionary();
        }

        public string Input
        {
            get { return _input; }
        }

        /// <summary>
        /// Retrieves the next token on the input line.
        /// 
        /// Throws expection if no token can be found.
        /// </summary>
        /// <returns>Token</returns>
        public AbstractToken GetNextToken()
        {
            foreach (KeyValuePair<Type, string> pair in _dictionary)
            {
                // TODO: See if substring does not impose a to harsh performance drop
                Match match = Regex.Match(_input.Substring(_counter), pair.Value);

                if (match.Success)
                {
                    _counter += match.Value.Length;

                    AbstractToken token = (AbstractToken) Activator.CreateInstance(pair.Key, new object[] {match.Value}, null);

                    return token;
                }
            }

            // TODO: Add some good error messages
            throw new Exception("Could not match input");
        }

        /// <summary>
        /// Checks whether the scanner is at the end of the input.
        /// </summary>
        public bool EndOfInput
        {
            get { return (_counter >= (_input.Length - 1)); }
        }
    }
}
