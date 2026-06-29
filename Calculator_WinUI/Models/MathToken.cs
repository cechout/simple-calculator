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

        public virtual string ToLatex() { return Value; }
    }


    // for sin, cos etc -> sin(x)
    public class FunctionToken : MathToken
    {
        public List<MathToken> ParameterTokens { get; } = new List<MathToken>();

        // explicitly calls the base class constructor to initialize the inherited fields (Type, Value) before
        // the derived class constructor block is executed, guaranteeing valid object state
        public FunctionToken(string functionName) : base(TokenType.SimpleFunction, functionName) { }

        public override string ToLatex()
        {
            string innerLatex;
            if (ParameterTokens.Count > 0) { innerLatex = LatexHelper.GetListLatex(ParameterTokens); }
            else { innerLatex = "?"; }

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
            string baseStr;
            if (BaseTokens.Count > 0) { baseStr = LatexHelper.GetListLatex(BaseTokens); }
            else { baseStr = "?"; }

            string expStr;
            if (ExponentTokens.Count > 0) { expStr = LatexHelper.GetListLatex(ExponentTokens); }
            else { expStr = "?"; }

            return $"{baseStr}^{{{expStr}}}";
        }
    }

    // for roots -> \sqrt[index]{radicand}
    public class RootToken : MathToken
    {
        public List<MathToken> IndexTokens { get; } = new List<MathToken>(); 
        public List<MathToken> RadicandTokens { get; } = new List<MathToken>();
        public RootToken() : base(TokenType.Root) { }

        public override string ToLatex()
        {
            string radStr;
            if (RadicandTokens.Count > 0) { radStr = LatexHelper.GetListLatex(RadicandTokens); }
            else { radStr = " "; }

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
            string baseStr;
            if (BaseTokens.Count > 0) { baseStr = LatexHelper.GetListLatex(BaseTokens); }
            else { baseStr = "?"; }

            string paramStr;
            if (ParameterTokens.Count > 0) { paramStr = LatexHelper.GetListLatex(ParameterTokens);  }
            else {  paramStr = " "; }

            return $"\\log_{{{baseStr}}}({paramStr})";
        }
    }

    // for fractions -> \frac{numerator}{denominator}
    public class FractionToken : MathToken
    {
        public List<MathToken> NumeratorTokens { get; } = new List<MathToken>(); 
        public List<MathToken> DenominatorTokens { get; } = new List<MathToken>(); 

        public FractionToken() : base(TokenType.Fraction) { }

        public override string ToLatex()
        {
            string numStr;
            if (NumeratorTokens.Count > 0) { numStr = LatexHelper.GetListLatex(NumeratorTokens); }
            else { numStr = " "; }

            string denStr;
            if (DenominatorTokens.Count > 0) { denStr = LatexHelper.GetListLatex(DenominatorTokens); }
            else { denStr = " "; }

            return $"\\frac{{{numStr}}}{{{denStr}}}";
        }
    }

    // helper class for recursively generating token lists in LaTeX
    public static class LatexHelper
    {
        public static string GetListLatex(List<MathToken> tokens)
        {
            string latex = "";
            foreach (var currentToken in tokens)
            {
                if (currentToken.Type == TokenType.Operator)
                {
                    latex += currentToken.Value switch
                    {
                        "*" => " \\cdot ",
                        "/" => " \\div ",
                        _ => $" {currentToken.Value} "
                    };
                }
                else
                {
                    latex += currentToken.ToLatex();
                }
            }
            return latex;
        }
    }
}
