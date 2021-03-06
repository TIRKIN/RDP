﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using LexicalAnalyzer.Token;

namespace LexicalAnalyzer
{
    public class LexicalScanner
    {
        private string _input;
        private int _counter;
        private ExpressionDictionary _dictionary;

        /// <summary>
        /// Construct a new Lexical Scanner with some input.
        /// </summary>
        /// <param name="input">Input string</param>
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
        /// <exception cref="MatchException">Thrown when the scanner cannot math the input.</exception>
        public AbstractToken GetNextToken()
        {
            // Loop through all tokens and check if they match the input string
            foreach (KeyValuePair<Type, string> pair in _dictionary)
            {
                // TODO: See if substring does not impose a to harsh performance drop
                Match match = Regex.Match(_input.Substring(_counter), pair.Value);

                if (match.Success)
                {
                    _counter += match.Value.Length;

                    if (pair.Key.IsSubclassOf(typeof(AbstractToken)))
                    {
                        // Create new instance of the specified type with the found value as parameter
                        AbstractToken token = (AbstractToken)Activator.CreateInstance(pair.Key, new object[] { match.Value, _counter - match.Value.Length }, null);

                        return token;    
                    }

                }
            }

            throw new MatchException(_input[_counter].ToString(CultureInfo.InvariantCulture), _counter);
        }

        /// <summary>
        /// Returns the next character without forwarding the streampointer.
        /// </summary>
        /// <returns>Token</returns>
        public AbstractToken Peek()
        {
            // Loop through all tokens and check if they match the input string
            foreach (KeyValuePair<Type, string> pair in _dictionary)
            {
                // TODO: See if substring does not impose a to harsh performance drop
                Match match = Regex.Match(_input.Substring(_counter), pair.Value);

                if (match.Success)
                {
                    if (pair.Key.IsSubclassOf(typeof(AbstractToken)))
                    {
                        // Create new instance of the specified type with the found value as parameter
                        AbstractToken token = (AbstractToken)Activator.CreateInstance(pair.Key, new object[] { match.Value, _counter }, null);

                        return token;
                    }

                }
            }

            throw new MatchException(_input[_counter].ToString(CultureInfo.InvariantCulture), _counter);
        }

        /// <summary>
        /// Checks whether the scanner is at the end of the input.
        /// </summary>
        public bool EndOfInput
        {
            get { return (_counter >= (_input.Length)); }
        }

        /// <summary>
        /// Return all the tokens in the inputstring.
        /// </summary>
        /// <returns>List of tokens</returns>
        public ICollection<AbstractToken> GetAllTokens()
        {
           List<AbstractToken> tokens = new List<AbstractToken>();

            while (!EndOfInput)
            {
                tokens.Add(GetNextToken());
            }

            return tokens;
        }
    }
}
