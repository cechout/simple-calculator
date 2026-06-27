using Calculator_WinUI.Classes;
using Calculator_WinUI.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Calculator_WinUI.Engines;

namespace Calculator_WinUI.ViewModels
{
    public class StandardViewModel : INotifyPropertyChanged
    {
        private Calculate _calculator = new Calculate();
        private readonly MathInputManager _inputManager = new MathInputManager();

        // ui properties 
        private string _inputAndResultText = "0";
        public string InputAndResultText
        {
            get => _inputAndResultText;
            set
            {
                if (_inputAndResultText != value)
                {
                    _inputAndResultText = value;
                    OnPropertyChanged(); 
                }
            }
        }
        private string _calculationText = "";
        public string CalculationText
        {
            get => _calculationText;
            set
            {
                if (_calculationText != value)
                {
                    _calculationText = value;
                    OnPropertyChanged();
                }
            }
        }

        // commands
        public ICommand InputCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand BackspaceCommand { get; }


        // constructor
        public StandardViewModel()
        {
            InputCommand = new RelayCommand<string>(AddToTextBox);
            CalculateCommand = new RelayCommand<object>(_ => CalculateResult());
            ClearCommand = new RelayCommand<object>(_ => ClearAll());
            BackspaceCommand = new RelayCommand<object>(_ => Backspace());
        }


        private void AddToTextBox(string sign)
        {
            if (sign.StartsWith("cmd_"))
            {
                switch (sign)
                {
                    case "cmd_nav_right":
                        _inputManager.MoveRight();
                        break;

                    case "cmd_sqrt":
                        _inputManager.StartRoot(customIndex: false);
                        break;
                    case "cmd_root_n":
                        _inputManager.StartRoot(customIndex: true);
                        break;

                    case "cmd_pow_n":
                        _inputManager.StartPower();
                        break;
                    case "cmd_pow_2":
                        _inputManager.StartPower();
                        _inputManager.AddNumber("2");
                        _inputManager.MoveRight();
                        break;

                    case "cmd_sin":
                        _inputManager.StartFunction("sin");
                        break;
                    case "cmd_cos":
                        _inputManager.StartFunction("cos");
                        break;
                    case "cmd_tan":
                        _inputManager.StartFunction("tan");
                        break;

                    // TODO
                    case "cmd_shift":
                    case "cmd_frac":
                    case "cmd_log":
                        break;
                }
            }
            // old logic
            else if (sign == "+" || sign == "-" || sign == "*" || sign == "/")
            {
                _inputManager.AddOperator(sign);
            }
            else
            {
                _inputManager.AddNumber(sign);
            }

            // update UI
            InputAndResultText = _inputManager.GetLatexString();
        }

        private void CalculateResult()
        {
            CalculationText = InputAndResultText + "=";
        }

        private void ClearAll()
        {
            _inputManager.Clear();
            InputAndResultText = _inputManager.GetLatexString();
            CalculationText = "";
        }

        private void Backspace()
        {
            //_inputManager.Backspace();
            InputAndResultText = _inputManager.GetLatexString();
        }


        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}