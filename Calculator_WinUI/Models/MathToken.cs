using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_WinUI.Models
{
    public enum TokenType
    {
        Number,
        Operator,
        Function,
        BracketOpen,
        BracketClose,
        Fraction 
    }

    internal class MathToken
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public MathToken(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
