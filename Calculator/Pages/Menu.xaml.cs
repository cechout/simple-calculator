using Calculator2.Classes;
using System.Windows;
using System.Windows.Controls;

namespace Calculator2.Pages
{
    public partial class Menu : Page
    {
        //Constructor
        public Menu()
        {
            InitializeComponent();
            SetButtons();
        }

        //Functions
        //SetButtons
        private void SetButtons()
        {
            if (Globals.CurrentPage == EnumPage.Currency)
            {
                Button_StandardEnabled.Visibility = Visibility.Collapsed;
                Button_StandardDisabled.Visibility = Visibility.Visible;

                Button_CurrencyEnabled.Visibility = Visibility.Visible;
                Button_CurrencyDisabled.Visibility = Visibility.Collapsed;
            }

            if (Globals.ErrorMessage == true)
            {
                Button_ErrorMessage.Visibility = Visibility.Visible;
            }
        }

        //Navigate
        private void Navigate(Enum targetPage)
        {
            Uri pageFunctionUri = new Uri("/Pages/" + targetPage.ToString() + ".xaml", UriKind.Relative);
            this.NavigationService.Navigate(pageFunctionUri);
        }

        //Header
        //Menu
        private void Click_Menu(object sender, RoutedEventArgs e) { Navigate(Globals.CurrentPage); }

        //Navigation Buttons
        //Standard + Currency
        private void CLick_Standard(object sender, RoutedEventArgs e) { Navigate(EnumPage.Standard); }
        private void Click_Currency(object sender, RoutedEventArgs e) { Navigate(EnumPage.Currency); }
    }
}
