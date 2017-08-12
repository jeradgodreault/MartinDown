using System;

namespace Godreault.MartinDownSharp.Services
{
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