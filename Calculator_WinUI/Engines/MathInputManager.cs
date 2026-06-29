using System.Collections.Generic;
using System.Linq;
using Calculator_WinUI.Models;

namespace Calculator_WinUI.Engines
{
    public class MathInputManager
    {
        private readonly List<MathToken> _rootTokens = new List<MathToken>();

        // the stack that keeps track of which sublist we are currently writing to
        private readonly Stack<List<MathToken>> _scopeStack = new Stack<List<MathToken>>();

        // returns the top List<MathToken> from _scopeStack via Peek() if _scopeStack is not empty.
        // otherwise, returns _rootTokens when no nested scopes are active
        private List<MathToken> CurrentScope
        {
            get
            {
                if (_scopeStack.Count > 0)
                {
                    return _scopeStack.Peek();
                }
                else
                {
                    return _rootTokens;
                }
            }
        }

        // return last token from current scope
        private MathToken LastTokenInScope
        {
            get
            {
                return CurrentScope.LastOrDefault();
            }
        }


        // constructor
        public MathInputManager()
        {
            ResetToRoot();
        }


        // reset
        public void ResetToRoot()
        {
            _scopeStack.Clear();
        }

        // movement
        // (exits the current scope to the right; e.g. exits the exponent)
        public bool MoveRight()
        {
            if (_scopeStack.Count > 0)
            {
                _scopeStack.Pop();
                return true; // successfully moved one layer up
            }
            return false; // we are already at root layer
        }

        public void AddNumber(string digit)
        {
            if (LastTokenInScope != null && LastTokenInScope.Type == TokenType.Number)
            {
                if (digit == "." && LastTokenInScope.Value.Contains(".")) return;
                LastTokenInScope.Value += digit;
            }
            else
            {
                CurrentScope.Add(new MathToken(TokenType.Number, digit));
            }
        }

        public void AddOperator(string op)
        {
            if (LastTokenInScope == null) return;

            if (LastTokenInScope.Type == TokenType.Operator)
            {
                LastTokenInScope.Value = op;
            }
            else
            {
                CurrentScope.Add(new MathToken(TokenType.Operator, op));
            }
        }

        // creates a power x^y
        public void StartPower()
        {
            var powerToken = new PowerToken();

            // if there was a number on the left, we take it as the base for the power
            if (LastTokenInScope != null && (LastTokenInScope.Type == TokenType.Number || LastTokenInScope.Type == TokenType.BracketClose))
            {
                powerToken.BaseTokens.Add(LastTokenInScope);
                CurrentScope.RemoveAt(CurrentScope.Count - 1); 
            }

            CurrentScope.Add(powerToken);
            _scopeStack.Push(powerToken.ExponentTokens); // now we move the pointer to the exponent
        }

        // creates a root
        public void StartRoot(bool customIndex)
        {
            var rootToken = new RootToken();
            CurrentScope.Add(rootToken);

            if (customIndex)
            {
                _scopeStack.Push(rootToken.IndexTokens); 
            }
            else
            {
                _scopeStack.Push(rootToken.RadicandTokens); 
            }
        }

        // creates sin, cos, tan, ln
        public void StartFunction(string name)
        {
            var funcToken = new FunctionToken(name);
            CurrentScope.Add(funcToken);
            _scopeStack.Push(funcToken.ParameterTokens); 
        }

        // creates a fraction
        public void StartFraction()
        {
            var fracToken = new FractionToken();
            CurrentScope.Add(fracToken);

            _scopeStack.Push(fracToken.NumeratorTokens); // pointer is on numerator
        }

        // creates a logarithm
        public void StartLogarithm(bool customBase)
        {
            var logToken = new LogarithmToken();
            CurrentScope.Add(logToken);

            // we decide via the flag customBase wheter we want to point to the base or to the parameter after creation
            if (customBase)
            {
                _scopeStack.Push(logToken.BaseTokens); 
            }
            else
            {
                _scopeStack.Push(logToken.ParameterTokens); 
            }
        }


        public void Backspace()
        {
            // case 1: we are in an empty subsection (empty exponent or smth)
            // we delete the whole math token
            if (CurrentScope.Count == 0 && _scopeStack.Count > 0)
            {
                _scopeStack.Pop();
                if (CurrentScope.Count > 0)
                {
                    CurrentScope.RemoveAt(CurrentScope.Count - 1);
                }
                return;
            }

            // case 2: the current section has tokens 
            if (CurrentScope.Count > 0)
            {
                var lastToken = LastTokenInScope;

                // if token is multi-digit number
                if (lastToken.Type == TokenType.Number && lastToken.Value.Length > 1)
                {
                    lastToken.Value = lastToken.Value.Substring(0, lastToken.Value.Length - 1);
                }
                else
                {
                    // if token is single-digit number of function or whatever
                    CurrentScope.RemoveAt(CurrentScope.Count - 1);
                }
            }
        }

        public void Clear()
        {
            _rootTokens.Clear();
            _scopeStack.Clear();
        }

        public string GetLatexString()
        {
            if (_rootTokens.Count == 0) return "0";
            return LatexHelper.GetListLatex(_rootTokens);
        }
    }
}