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

        public void Clear()
        {
            _rootTokens.Clear();
            _scopeStack.Clear();
        }

        public string GetLatexString()
        {
            return LatexHelper.GetListLatex(_rootTokens);
        }
    }
}