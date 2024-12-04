using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;

namespace WpfBrowser
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (WebView.CanGoBack)
                WebView.GoBack();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (WebView.CanGoForward)
                WebView.GoForward();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            WebView.Reload();
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToUrl();
        }

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NavigateToUrl();
            }
        }

        private void NavigateToUrl()
        {
            try
            {
                string url = UrlTextBox.Text;
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }
                WebView.Source = new Uri(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid URL: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}