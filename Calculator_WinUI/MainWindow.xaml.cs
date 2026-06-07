using Calculator_WinUI.Views; 
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Calculator_WinUI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            MainFrame.Navigate(typeof(StandardPage));
            NavView.SelectedItem = NavView.MenuItems[0];
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string itemTag = args.InvokedItemContainer.Tag.ToString();

            switch (itemTag)
            {
                case "Standard":
                    MainFrame.Navigate(typeof(StandardPage));
                    break;
                case "Currency":
                    MainFrame.Navigate(typeof(CurrencyPage));
                    break;
            }
        }
    }
}