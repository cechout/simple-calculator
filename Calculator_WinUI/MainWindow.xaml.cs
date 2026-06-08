using Calculator_WinUI.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Windowing;
using WinUIEx;

namespace Calculator_WinUI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.AppWindow.SetIcon("Assets\\Icon\\Icon.ico");

            MainFrame.Navigate(typeof(StandardPage));
            NavView.SelectedItem = NavView.MenuItems[0];

            // AppWindow configuration
            // theme 
            AppWindow.TitleBar.PreferredTheme = TitleBarTheme.UseDefaultAppMode;
            AppWindow.TitleBar.ExtendsContentIntoTitleBar = true;

            if (AppWindow.TitleBar.ExtendsContentIntoTitleBar)
            {
                AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Standard;
                AppWindow.TitleBar.ButtonBackgroundColor = Microsoft.UI.Colors.Transparent;
                AppWindow.TitleBar.ButtonInactiveBackgroundColor = Microsoft.UI.Colors.Transparent;

            }
            // size
            this.SetWindowSize(330, 480);
            var manager = WinUIEx.WindowManager.Get(this);
            manager.MinWidth = 300;
            manager.MinHeight = 450;
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