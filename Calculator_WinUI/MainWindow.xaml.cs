using Microsoft.UI.Xaml;
using Calculator_WinUI.Pages; // WICHTIG: Damit er die Standard-Klasse findet!

namespace Calculator_WinUI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Sagt dem Frame, dass er direkt beim Start die Standard-Seite laden soll
            MainFrame.Navigate(typeof(Standard));
        }
    }
}