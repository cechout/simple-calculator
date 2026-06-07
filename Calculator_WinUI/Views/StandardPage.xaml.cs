using Microsoft.UI.Xaml.Controls;
using Calculator_WinUI.ViewModels;

namespace Calculator_WinUI.Views
{
    public sealed partial class StandardPage : Page
    {
        public StandardViewModel ViewModel { get; } // bridge to the ViewModel

        public StandardPage()
        {
            ViewModel = new StandardViewModel();
            this.InitializeComponent();
        }
    }
}