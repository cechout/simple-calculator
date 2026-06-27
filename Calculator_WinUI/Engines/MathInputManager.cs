using System.Collections.Generic;
using System.Linq;
using Calculator_WinUI.Models;

namespace Calculator_WinUI.Engines
{
    public class MathInputManager
    {
        private List<MathToken> _tokens = new List<MathToken>(); // list of our custom math tokens
        private MathToken LastToken => _tokens.LastOrDefault();

        public void AddNumber(string numberString)
        {
            // if token is already number
            if (LastToken != null && LastToken.Type == TokenType.Number)
            {
                // prevents double commas
                if (numberString == "." && LastToken.Value.Contains(".")) return;

                LastToken.Value += numberString;
            }
            else
            {
                // if there was an operator there before, we start a new number token
                _tokens.Add(new MathToken(TokenType.Number, numberString));
            }
        }

        public void AddOperator(string op)
        {
            // no operator in the beginning
            if (LastToken == null) return;

            // if the user presses '+' but the last token was already '-', we swap the operator 
            if (LastToken.Type == TokenType.Operator)
            {
                LastToken.Value = op;
            }
            else if (LastToken.Type == TokenType.Number || LastToken.Type == TokenType.BracketClose)
            {
                // an operator may normally only be added after a number or a closing bracket
                _tokens.Add(new MathToken(TokenType.Operator, op));
            }
        }

        public string GetLatexString()
        {
            // wenn noch nichts getippt wurde, zeigen wir einfach eine 0
            if (_tokens.Count == 0) return "0";

            string latex = "";

            foreach (var token in _tokens)
            {
                if (token.Type == TokenType.Number)
                {
                    latex += token.Value;
                }
                else if (token.Type == TokenType.Operator)
                {
                    // we translate the raw c# symbols in clean LaTeX commands
                    switch (token.Value)
                    {
                        case "*":
                            latex += " \\cdot "; 
                            break;
                        case "/":
                            latex += " \\div ";
                            break;
                        case "+":
                            latex += " + ";
                            break;
                        case "-":
                            latex += " - ";
                            break;
                        default:
                            latex += token.Value;
                            break;
                    }
                }
                else if (token.Type == TokenType.BracketOpen)
                {
                    latex += "(";
                }
                else if (token.Type == TokenType.BracketClose)
                {
                    latex += ")";
                }
            }

            return latex;
        }

        public void Clear()
        {
            _tokens.Clear();
        }

        public void Backspace()
        {
            if (_tokens.Count == 0) return;

            if (LastToken.Type == TokenType.Number && LastToken.Value.Length > 1)
            {
                // if its a  number, we only cut the last digit
                LastToken.Value = LastToken.Value.Substring(0, LastToken.Value.Length - 1);
            }
            else
            {
                // if its an operators, function or single-digit number, the whole token gets cut
                _tokens.RemoveAt(_tokens.Count - 1);
            }
        }
    }
}