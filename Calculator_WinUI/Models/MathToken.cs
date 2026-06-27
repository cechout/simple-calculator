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
        Fraction,
        SimpleFunction,
        Power,
        Root,
        Logarithm
    }


    public class MathToken
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }


        // constructor
        public MathToken(TokenType type, string value = "")
        {
            Type = type;
            Value = value;
        }

        public virtual string ToLatex() => Value;
    }


    // for sin, cos etc -> sin(x)
    public class FunctionToken : MathToken
    {
        public List<MathToken> ParameterTokens { get; } = new List<MathToken>();
        public FunctionToken(string functionName) : base(TokenType.SimpleFunction, functionName) { }

        public override string ToLatex()
        {
            string innerLatex = ParameterTokens.Count > 0 ? LatexHelper.GetListLatex(ParameterTokens) : "";
            return $"\\{Value}({innerLatex})";
        }
    }

    // for powers -> base^{exponent}
    public class PowerToken : MathToken
    {
        public List<MathToken> BaseTokens { get; set; } = new List<MathToken>();
        public List<MathToken> ExponentTokens { get; } = new List<MathToken>();
        public PowerToken() : base(TokenType.Power) { }

        public override string ToLatex()
        {
            string baseStr = BaseTokens.Count > 0 ? LatexHelper.GetListLatex(BaseTokens) : "?";
            string expStr = ExponentTokens.Count > 0 ? LatexHelper.GetListLatex(ExponentTokens) : " "; // a space lets the cursor flash at top
            return $"{baseStr}^{{{expStr}}}";
        }
    }

    // for roots -> \sqrt[index]{radicand}
    public class RootToken : MathToken
    {
        public List<MathToken> IndexTokens { get; } = new List<MathToken>(); // for root exponents
        public List<MathToken> RadicandTokens { get; } = new List<MathToken>();

        public RootToken() : base(TokenType.Root) { }

        public override string ToLatex()
        {
            string radStr = RadicandTokens.Count > 0 ? LatexHelper.GetListLatex(RadicandTokens) : " ";
            if (IndexTokens.Count > 0)
            {
                return $"\\sqrt[{LatexHelper.GetListLatex(IndexTokens)}]{{{radStr}}}";
            }
            return $"\\sqrt{{{radStr}}}"; // standard square root
        }
    }

    // for logarithms -> \log_{base}(x)
    public class LogarithmToken : MathToken
    {
        public List<MathToken> BaseTokens { get; } = new List<MathToken>();
        public List<MathToken> ParameterTokens { get; } = new List<MathToken>();

        public LogarithmToken() : base(TokenType.Logarithm) { }

        public override string ToLatex()
        {
            string baseStr = BaseTokens.Count > 0 ? LatexHelper.GetListLatex(BaseTokens) : "10"; // default base is 10
            string paramStr = ParameterTokens.Count > 0 ? LatexHelper.GetListLatex(ParameterTokens) : " ";
            return $"\\log_{{{baseStr}}}({paramStr})";
        }
    }

    // helper class for recursively generating token lists in LaTeX
    public static class LatexHelper
    {
        public static string GetListLatex(List<MathToken> tokens)
        {
            string latex = "";
            foreach (var t in tokens)
            {
                if (t.Type == TokenType.Operator)
                {
                    latex += t.Value switch
                    {
                        "*" => " \\cdot ",
                        "/" => " \\div ",
                        _ => $" {t.Value} "
                    };
                }
                else
                {
                    latex += t.ToLatex();
                }
            }
            return latex;
        }
    }
}
