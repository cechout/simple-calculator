using Calculator_WinUI.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Calculator_WinUI.Views
{
    public sealed partial class CurrencyPage : Page
    {
        // connect to ViewModel
        public CurrencyViewModel ViewModel { get; }

        public CurrencyPage()
        {
            this.InitializeComponent();
            ViewModel = new CurrencyViewModel();
        }
    }
}