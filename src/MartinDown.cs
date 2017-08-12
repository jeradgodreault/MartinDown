using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Godreault.MartinDownSharp.Services;

namespace Godreault.MartinDownSharp
{
    public class MartinDown
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
                : (token.TokenType == TokenType.BOLD_START) ? "<strong>"
                : (token.TokenType == TokenType.BOLD_END) ? "</strong>"
                : (token.TokenType == TokenType.ITALIC_START) ? "<em>"
                : (token.TokenType == TokenType.ITALIC_END) ? "</em>"
                : (token.TokenType == TokenType.BOLDITALIC_START) ? "<strong><em>"
                : (token.TokenType == TokenType.BOLDITALIC_END) ? "</em></strong>"
                : (token.TokenType == TokenType.SPACE) ? " "
                : (token.TokenType == TokenType.END_OF_LINE) ? ""
                : token.Content
                );

            }

            return output.ToString();
        }
    }
}