using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Godreault.MartinDown
{
    public class MarkDown
    {
        public string Transform(string input)
        {
            if (input == null || input == "" || input.Length == 1) 
            {
                return input;
            } 

            var output = new StringBuilder("");
            var tokens = Lexer.GetTokens(input);

            foreach (Token token in tokens)
            {
                output.Append((token.TokenType == TokenType.WORD) ? token.Content 
                : (token.TokenType == TokenType.BOLD_START) ? "<b>"
                : (token.TokenType == TokenType.BOLD_END) ? "</b>"
                : (token.TokenType == TokenType.ITALIC_START) ? "<i>"
                : (token.TokenType == TokenType.ITALIC_END) ? "</i>"
                : (token.TokenType == TokenType.BOLDITALIC_START) ? "<b><i>"
                : (token.TokenType == TokenType.BOLDITALIC_END) ? "</i></b>"
                : (token.TokenType == TokenType.SPACE) ? " "
                : (token.TokenType == TokenType.END_OF_LINE) ? ""
                : token.Content
                );

            }

            return output.ToString();
        }

        public static class Lexer
        {
            public static IEnumerable<Token> GetTokens(string input)
            {
                var splitInput = input.Split(' ');
                var tokens = new List<Token>();

                for(int i =0; i < splitInput.Length; i++)
                {
                    var word = splitInput[i];
                    int startIndex = 0;
                    int endIndex = word.Length - 1;

                    //If there extra whitespace, then it will appear in the array as ""
                    if (word.Length == 0 && i != splitInput.Length - 1)
                    {
                        tokens.Add(new Token(TokenType.SPACE));
                    }
                    //Determine if its italics. eg. *H*
                    else if (word.Length >= 3
                        && word[startIndex] == '*' && word[startIndex + 1] != '*'
                        && word[endIndex] == '*' && word[endIndex - 1] != '*')
                    {
                        tokens.Add(new Token(TokenType.ITALIC_START));
                        tokens.Add(new Token(TokenType.WORD, word.Substring(startIndex + 1, endIndex - 1)));
                        tokens.Add(new Token(TokenType.ITALIC_END));
                    }
                    // Determine if its bold. eg **H**
                    else if (word.Length >= 5
                        && word[startIndex] == '*' && word[startIndex + 1] == '*' && word[startIndex + 2] != '*'
                        && word[endIndex] == '*' && word[endIndex - 1] == '*' && word[endIndex - 2] != '*')
                    {
                        tokens.Add(new Token(TokenType.BOLD_START));
                        tokens.Add(new Token(TokenType.WORD, word.Substring(startIndex + 2, endIndex - 3)));
                        tokens.Add(new Token(TokenType.BOLD_END));
                    }
                    // Determine if its boldItalics. eg ***H***
                    else if (word.Length >= 7
                        && word[startIndex] == '*' && word[startIndex + 1] == '*' && word[startIndex + 2] == '*' && word[startIndex + 3] != '*'
                        && word[endIndex] == '*' && word[endIndex - 1] == '*' && word[endIndex - 2] == '*' && word[endIndex - 3] != '*')
                    {
                        tokens.Add(new Token(TokenType.BOLDITALIC_START));
                        tokens.Add(new Token(TokenType.WORD, word.Substring(startIndex + 3, endIndex - 5)));
                        tokens.Add(new Token(TokenType.BOLDITALIC_END));
                    }
                    else
                    {
                        tokens.Add(new Token(TokenType.WORD, word));
                    }

                    if (i != splitInput.Length - 1 && word.Length !=0) 
                    {
                        tokens.Add(new Token(TokenType.SPACE));
                    }
                }

                return tokens;
            }


        }

        public class Token
        {
            public TokenType TokenType { get; set; }
            public string Content { get; set; }

            public Token(TokenType tokenType)
            {
                TokenType = tokenType;
            }

            public Token(TokenType tokenType, String content)
            {
                TokenType = tokenType;
                Content = content;
            }
        }

        public enum TokenType
        {
            BOLD_START,
            BOLD_END,
            ITALIC_START,
            ITALIC_END,
            BOLDITALIC_START,
            BOLDITALIC_END,
            WORD,
            SPACE,
            END_OF_LINE,
        }
    }
}