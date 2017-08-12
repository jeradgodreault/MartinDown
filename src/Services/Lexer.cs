using System.Collections.Generic;

namespace Godreault.MartinDownSharp.Services
{
    internal static class Lexer
    {
        internal static IEnumerable<Token> GetTokens(string input)
        {
            var splitInput = input.Split(' ');
            var tokens = new List<Token>();

            for (int i = 0; i < splitInput.Length; i++)
            {
                var word = splitInput[i];
              
                if (IsWhiteSpace(word, splitInput.Length, i))
                {
                    tokens.Add(new Token(TokenType.SPACE));
                }                
                else if (IsWordEmphasized(word))
                {
                    tokens.Add(new Token(TokenType.ITALIC_START));
                    tokens.Add(new Token(TokenType.WORD, word.Substring(1, word.Length - 2)));
                    tokens.Add(new Token(TokenType.ITALIC_END));
                }
                else if (IsWordStrong(word)) 
                {
                    tokens.Add(new Token(TokenType.BOLD_START));
                    tokens.Add(new Token(TokenType.WORD, word.Substring(2, word.Length - 4)));
                    tokens.Add(new Token(TokenType.BOLD_END));
                }
                else if (IsWordEmphasizedAndStrong(word)) 
                {
                    tokens.Add(new Token(TokenType.BOLDITALIC_START));
                    tokens.Add(new Token(TokenType.WORD, word.Substring(3, word.Length - 6)));
                    tokens.Add(new Token(TokenType.BOLDITALIC_END));
                }
                else //must be a normal word.
                {
                    tokens.Add(new Token(TokenType.WORD, word));
                }

                //add a space character for the next word if its not already whitespace character
                if (!IsWhiteSpace(word, splitInput.Length, i) 
                    && i != splitInput.Length - 1) //unless its the last word in the array. 
                {
                    tokens.Add(new Token(TokenType.SPACE));
                }
            }
            return tokens;
        }

        private static bool IsWhiteSpace(string word, int arrayLength, int i) {
            //If there extra whitespace, then it will appear in the array as ""
            return word.Length == 0 && i != arrayLength - 1;
        }

        /// <summary>
        /// Determine if its bold. eg **H**
        /// </summary>
        private static bool IsWordStrong(string word)
        {
            return word.Length >= 5
                    && word[0] == '*' && word[1] == '*' && word[2] != '*'
                    && word[word.Length - 1] == '*' && word[word.Length - 2] == '*' && word[word.Length - 3] != '*';
        }

        /// <summary>
        /// Determine if its italics. eg. *H*
        /// </summary>
        private static bool IsWordEmphasized(string word) {
            return word.Length >= 3
                    && word[0] == '*' && word[1] != '*'
                    && word[word.Length - 1] == '*' && word[word.Length - 2] != '*';
        }

        /// <summary>
        /// Determine if its boldItalics. eg ***H***
        /// </summary>
        private static bool IsWordEmphasizedAndStrong(string word) 
        {
            return word.Length >= 7
                    && word[0] == '*' && word[1] == '*' && word[2] == '*' && word[3] != '*'
                    && word[word.Length - 1] == '*' && word[word.Length - 2] == '*' && word[word.Length - 3] == '*' && word[word.Length - 4] != '*';
        }
    }
}