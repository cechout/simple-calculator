using Calculator_WinUI.Classes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Calculator_WinUI.Pages;

namespace Calculator_WinUI.Pages
{
    public sealed partial class Menu : Page
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
            // WPF Navigation
            //Uri pageFunctionUri = new Uri("/Pages/" + targetPage.ToString() + ".xaml", UriKind.Relative);
            //this.NavigationService.Navigate(pageFunctionUri);

            // WinUI Navigation
            Type pageType = targetPage switch
            {
                EnumPage.Standard => typeof(Standard),
                EnumPage.Currency => typeof(Currency),
                _ => typeof(Standard)  
            };

            this.Frame.Navigate(pageType);
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
