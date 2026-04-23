using Calculator2.Classes;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Calculator2.Pages
{
    public partial class Currency : Page
    {        
        ConvertCurrency ConvertCurrency1;

        private EnumCurrency Currency1;
        private EnumCurrency Currency2;

        //Constructor
        public Currency()
        {
            InitializeComponent();

            Globals.CurrentPage = EnumPage.Currency;

            Currency1 = EnumCurrency.EUR;
            Currency2 = EnumCurrency.USD;
        }         

        //Page_Loaded is called when the constructor of the class PageCurrencyConverter is finished
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {            
            Refresh();
        }

        //Functions
        //Refresh
        private void Refresh()
        {
            try
            {
                //in the constructor of ConvertCurrency1 an object of GetCurrencyData is created to open the website in the constructor
                ConvertCurrency1 = new ConvertCurrency();

                UpdateCurrencyRate();

                Globals.ErrorMessage = false;
            }
            catch (Exception)
            {
                Globals.CurrentPage = EnumPage.Standard;
                Globals.ErrorMessage = true;

                Uri pageFunctionUri = new Uri("/Pages/menu.xaml", UriKind.Relative);
                this.NavigationService.Navigate(pageFunctionUri);
            }
        }

        //Update CurrencyRate
        private void UpdateCurrencyRate()
        {
            string currencyRate = ConvertCurrency1.GetCurrencyRate(Currency1, Currency2);
            TextBlock_CurrencyRate.Text = "1 " + Currency1 + " = " + Convert.ToString(currencyRate) + " " + Currency2;
        }

        //Header
        //Menu
        private void MenuClick(object sender, RoutedEventArgs e)
        {
            Uri pageFunctionUri = new Uri("/Pages/Menu.xaml", UriKind.Relative);
            this.NavigationService.Navigate(pageFunctionUri);
        }

        //Selection Borders
        //Currency1 + Currency2
        private void Click_SelectionCurrency1(object sender, RoutedEventArgs e)
        {
            Border_SelectionCurrency1.Visibility = Visibility.Visible;
        }

        private void Click_SelectionCurrency2(object sender, RoutedEventArgs e)
        {
            Border_SelectionCurrency2.Visibility = Visibility.Visible;
        }

        private void Click_CurrencyEuro(object sender, RoutedEventArgs e) { SetCurrencyButtons(EnumCurrency.EUR, "Europe-Euro", Button_Currency1EuroEnabled, Button_Currency1EuroDisabled, Button_Currency2EuroEnabled, Button_Currency2EuroDisabled); }
        private void Click_CurrencyDollar(object sender, RoutedEventArgs e) { SetCurrencyButtons(EnumCurrency.USD, "United States-Dollar", Button_Currency1DollarEnabled, Button_Currency1DollarDisabled, Button_Currency2DollarEnabled, Button_Currency2DollarDisabled); }        
        private void Click_CurrencyPound(object sender, RoutedEventArgs e) { SetCurrencyButtons(EnumCurrency.GBP, "Great Britain-Pound", Button_Currency1PoundEnabled, Button_Currency1PoundDisabled, Button_Currency2PoundEnabled, Button_Currency2PoundDisabled); }        
        private void Click_CurrencyKoruna(object sender, RoutedEventArgs e) { SetCurrencyButtons(EnumCurrency.CZK, "Czech Republic-Koruna", Button_Currency1KorunaEnabled, Button_Currency1KorunaDisabled, Button_Currency2KorunaEnabled, Button_Currency2KorunaDisabled); }        
        private void Click_CurrencyYen(object sender, RoutedEventArgs e) { SetCurrencyButtons(EnumCurrency.JPY, "Japan-Yen", Button_Currency1YenEnabled, Button_Currency1YenDisabled, Button_Currency2YenEnabled, Button_Currency2YenDisabled); }        
        private void Click_CurrencyYuan(object sender, RoutedEventArgs e) { SetCurrencyButtons(EnumCurrency.CNY, "China-Yuan", Button_Currency1YuanEnabled, Button_Currency1YuanDisabled, Button_Currency2YuanEnabled, Button_Currency2YuanDisabled); }        

        private void SetCurrencyButtons(EnumCurrency currency, string currencyTextblockText, Button Button_Currency1Visible, Button Button_Currency1Collapsed, Button Button_Currency2Visible, Button Button_Currency2Collapsed)
        {
            ResetButtons();

            //Currency1
            if (Border_SelectionCurrency1.Visibility == Visibility.Visible)
            {
                Currency1 = currency;
                TextBlock_SelectedCurrency1.Text = currencyTextblockText;

                //Set the Clicked Button as Visible
                Button_Currency1Visible.Visibility = Visibility.Visible;
                Button_Currency1Collapsed.Visibility = Visibility.Collapsed;

                Border_SelectionCurrency1.Visibility = Visibility.Collapsed;
            }

            //Currency2
            if (Border_SelectionCurrency2.Visibility == Visibility.Visible)
            {
                Currency2 = currency;
                TextBlock_SelectedCurrency2.Text = currencyTextblockText;

                //Set the Clicked Button as Visible
                Button_Currency2Visible.Visibility = Visibility.Visible;
                Button_Currency2Collapsed.Visibility = Visibility.Collapsed;

                Border_SelectionCurrency2.Visibility = Visibility.Collapsed;
            }

            UpdateCurrencyRate();           
        }

        private void ResetButtons()
        {
            if (Border_SelectionCurrency1.Visibility == Visibility.Visible)
            {
                Button_Currency1EuroEnabled.Visibility = Visibility.Collapsed;
                Button_Currency1DollarEnabled.Visibility = Visibility.Collapsed;
                Button_Currency1PoundEnabled.Visibility = Visibility.Collapsed;
                Button_Currency1KorunaEnabled.Visibility = Visibility.Collapsed;
                Button_Currency1YenEnabled.Visibility = Visibility.Collapsed;
                Button_Currency1YuanEnabled.Visibility = Visibility.Collapsed;

                Button_Currency1EuroDisabled.Visibility = Visibility.Visible;
                Button_Currency1DollarDisabled.Visibility = Visibility.Visible;
                Button_Currency1PoundDisabled.Visibility = Visibility.Visible;
                Button_Currency1KorunaDisabled.Visibility = Visibility.Visible;
                Button_Currency1YenDisabled.Visibility = Visibility.Visible;
                Button_Currency1YuanDisabled.Visibility = Visibility.Visible;
            }

            if (Border_SelectionCurrency2.Visibility == Visibility.Visible)
            {
                Button_Currency2EuroEnabled.Visibility = Visibility.Collapsed;
                Button_Currency2DollarEnabled.Visibility = Visibility.Collapsed;
                Button_Currency2PoundEnabled.Visibility = Visibility.Collapsed;
                Button_Currency2KorunaEnabled.Visibility = Visibility.Collapsed;
                Button_Currency2YenEnabled.Visibility = Visibility.Collapsed;
                Button_Currency2YuanEnabled.Visibility = Visibility.Collapsed;

                Button_Currency2EuroDisabled.Visibility = Visibility.Visible;
                Button_Currency2DollarDisabled.Visibility = Visibility.Visible;
                Button_Currency2PoundDisabled.Visibility = Visibility.Visible;
                Button_Currency2KorunaDisabled.Visibility = Visibility.Visible;
                Button_Currency2YenDisabled.Visibility = Visibility.Visible;
                Button_Currency2YuanDisabled.Visibility = Visibility.Visible;
            }
        }

        //Input Buttons
        //Calculate
        private void Click_Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                double amountCurrency1 = double.Parse(TextBlock_Currency1.Text, CultureInfo.InvariantCulture);

                string currencyAmount = ConvertCurrency1.GetAmountCurrency2(Currency1, Currency2, amountCurrency1);
                string currencyRate = ConvertCurrency1.GetCurrencyRate(Currency1, Currency2);

                TextBlock_Currency2.Text = currencyAmount;
                TextBlock_CurrencyRate.Text = "1 " + Currency1 + " = " + Convert.ToString(currencyRate) + " " + Currency2;
            }
            catch (Exception)
            {
                TextBlock_Currency2.Text = "Error";
            }
        }

        //Refresh
        private void Click_Refresh(object sender, RoutedEventArgs e)
        {
            Refresh();
        }        
        
        //Clear All Input
        private void Click_ClearAllInput(object sender, RoutedEventArgs e)
        {
            TextBlock_Currency1.Text = "0";
            TextBlock_Currency2.Text = "0";
        }

        //Backspace
        private void Click_Backspace(object sender, RoutedEventArgs e)
        {
            if (TextBlock_Currency1.Text.Length <= 1)
            {
                TextBlock_Currency1.Text = "0";
            }
            else
            {
                //Subtracting the last sign
                TextBlock_Currency1.Text = TextBlock_Currency1.Text.Remove(TextBlock_Currency1.Text.Length - 1);
            }
        }

        //Add Input To Output Display
        private void AddToTextBox(string sign)
        {
            if (TextBlock_Currency1.Text == "0" && !(sign == "."))
            {
                TextBlock_Currency1.Text = "";
            }

            TextBlock_Currency1.Text += sign;
        }

        //Numbers + Signs
        private void Click_DecimalPoint(object sender, RoutedEventArgs e) { AddToTextBox("."); }
        private void Click_Zero(object sender, RoutedEventArgs e) { AddToTextBox("0"); }
        private void Click_One(object sender, RoutedEventArgs e) { AddToTextBox("1"); }
        private void Click_Two(object sender, RoutedEventArgs e) { AddToTextBox("2"); }
        private void Click_Three(object sender, RoutedEventArgs e) { AddToTextBox("3"); }
        private void Click_Four(object sender, RoutedEventArgs e) { AddToTextBox("4"); }
        private void Click_Five(object sender, RoutedEventArgs e) { AddToTextBox("5"); }
        private void Click_Six(object sender, RoutedEventArgs e) { AddToTextBox("6"); }
        private void Click_Seven(object sender, RoutedEventArgs e) { AddToTextBox("7"); }
        private void Click_Eight(object sender, RoutedEventArgs e) { AddToTextBox("8"); }
        private void Click_Nine(object sender, RoutedEventArgs e) { AddToTextBox("9"); }
    }
}
