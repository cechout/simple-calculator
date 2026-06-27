using Calculator_WinUI.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.ComponentModel;

namespace Calculator_WinUI.Views
{
    public sealed partial class StandardPage : Page
    {
        public StandardViewModel ViewModel { get; }
        private readonly string _kaTeXHtmlTemplate = @"
        <!DOCTYPE html>
        <html>
        <head>
            <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/katex@0.16.8/dist/katex.min.css'>
            <script src='https://cdn.jsdelivr.net/npm/katex@0.16.8/dist/katex.min.js'></script>
            <style>
                body {
                    margin: 0; 
                    padding: 0 10px;
                    display: flex; 
                    justify-content: flex-end; /* rechtsbündig */
                    align-items: center; /* vertikal zentriert */
                    height: 100vh; 
                    overflow: hidden;
                    color: [COLOR]; /* wird von C# ersetzt */
                    font-size: [SIZE]; /* wird von C# ersetzt */
                }
            </style>
        </head>
        <body>
            <div id='math-container'></div>
            <script>
                // diese funktion rufen wir später aus C# heraus auf!
                function updateMath(latexString) {
                    katex.render(latexString, document.getElementById('math-container'), {
                        throwOnError: false, // bei fehlern nicht abstürzen, sondern roh-text zeigen
                        displayMode: true
                    });
                }
            </script>
        </body>
        </html>";


        // constructor
        public StandardPage()
        {
            ViewModel = new StandardViewModel();
            this.InitializeComponent();

            this.Loaded += StandardPage_Loaded;
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }


        private async void StandardPage_Loaded(object sender, RoutedEventArgs e)
        {
            await MathWebView1.EnsureCoreWebView2Async();
            await MathWebView2.EnsureCoreWebView2Async();

            // WebView 1 configuration 
            string html1 = _kaTeXHtmlTemplate.Replace("[COLOR]", "gray").Replace("[SIZE]", "18px");
            MathWebView1.NavigateToString(html1);

            // WebView 2 configuration 
            string html2 = _kaTeXHtmlTemplate.Replace("[COLOR]", "white").Replace("[SIZE]", "36px");
            MathWebView2.NavigateToString(html2);

            await UpdateWebViewMath(MathWebView2, ViewModel.InputAndResultText);
        }

        private async void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (MathWebView1.CoreWebView2 == null || MathWebView2.CoreWebView2 == null) return;

            // if CalculationText (history) changes
            if (e.PropertyName == nameof(ViewModel.CalculationText))
            {
                await UpdateWebViewMath(MathWebView1, ViewModel.CalculationText);
            }
            // if InputAndResultText (current input) changes
            else if (e.PropertyName == nameof(ViewModel.InputAndResultText))
            {
                await UpdateWebViewMath(MathWebView2, ViewModel.InputAndResultText);
            }
        }

        // sends c# strings to the javascript function
        private async System.Threading.Tasks.Task UpdateWebViewMath(WebView2 webView, string mathText)
        {
            if (string.IsNullOrEmpty(mathText)) mathText = " "; // empty strings sometimes cause javascript to crash
            string escapedMath = mathText.Replace("\\", "\\\\").Replace("'", "\\'");
            await webView.ExecuteScriptAsync($"updateMath('{escapedMath}');");
        }
    }
}