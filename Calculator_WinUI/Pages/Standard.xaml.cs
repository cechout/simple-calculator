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
    public sealed partial class Standard : Page
    {
        Calculate Calculate1 = new Calculate();

        //Constructor
        public Standard()
        {
            InitializeComponent();

            Globals.CurrentPage = EnumPage.Standard;
            Globals.ErrorMessage = false;
        }

        //Header
        //Menu
        private void Click_Menu(object sender, RoutedEventArgs e)
        {
            // WPF Navigation
            //Uri pageFunctionUri = new Uri("/Pages/" + EnumPage.Menu.ToString() + ".xaml", UriKind.Relative);
            //this.NavigationService.Navigate(pageFunctionUri);

            // WinUI Navigation
            this.Frame.Navigate(typeof(Menu));
        }

        //Input Buttons
        //Calculate
        private void Click_Calculate(object sender, RoutedEventArgs e)
        {
            TextBlock_Calculation.Text = TextBlock_InputAndResult.Text + "=";
            TextBlock_InputAndResult.Text = "(" + TextBlock_InputAndResult.Text + ")";

            TextBlock_InputAndResult.Text = Calculate1.PreCalculate(TextBlock_InputAndResult.Text);

            if (TextBlock_InputAndResult.Text == "Error") TextBlock_Calculation.Text = "";
        }

        //Clear All Input
        private void Click_ClearAllInput(object sender, RoutedEventArgs e)
        {
            TextBlock_InputAndResult.Text = "0";
            TextBlock_Calculation.Text = "";
        }

        //Backspace
        private void Click_Backspace(object sender, RoutedEventArgs e)
        {
            if (TextBlock_InputAndResult.Text.Length <= 1)
            {
                TextBlock_InputAndResult.Text = "0";
            }
            else
            {
                //Subtracting the last sign
                TextBlock_InputAndResult.Text = TextBlock_InputAndResult.Text.Remove(TextBlock_InputAndResult.Text.Length - 1);
            }
        }

        //Add Input To Textblock
        private void AddToTextBox(string sign)
        {
            if (TextBlock_InputAndResult.Text == "0" && !(sign == "."))
            {
                TextBlock_InputAndResult.Text = "";
            }

            TextBlock_InputAndResult.Text += sign;
        }

        //Arithmetic Operations
        private void Click_Divide(object sender, RoutedEventArgs e) { AddToTextBox("/"); }
        private void Click_Multiply(object sender, RoutedEventArgs e) { AddToTextBox("*"); }
        private void Click_Subtract(object sender, RoutedEventArgs e) { AddToTextBox("-"); }
        private void Click_Add(object sender, RoutedEventArgs e) { AddToTextBox("+"); }

        private void Click_Power1(object sender, RoutedEventArgs e) { AddToTextBox("^2"); }
        private void CLick_Power2(object sender, RoutedEventArgs e) { AddToTextBox("^"); }
        private void Click_Root1(object sender, RoutedEventArgs e) { AddToTextBox("2√"); }
        private void Click_Root2(object sender, RoutedEventArgs e) { AddToTextBox("√"); }

        //Numbers + Signs
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

        private void Click_DecimalPoint(object sender, RoutedEventArgs e) { AddToTextBox("."); }
        private void Click_BracketLeft(object sender, RoutedEventArgs e) { AddToTextBox("("); }
        private void Click_BracketRight(object sender, RoutedEventArgs e) { AddToTextBox(")"); }
    }
}
