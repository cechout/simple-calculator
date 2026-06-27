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
            if (sign == "+" || sign == "-" || sign == "*" || sign == "/")
            {
                _inputManager.AddOperator(sign);
            }
            else
            {
                // "sign" (z.B. "7") wird hier übergeben und kommt im Manager als "digit" an
                _inputManager.AddNumber(sign);
            }

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