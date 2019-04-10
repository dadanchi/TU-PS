using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnHello_Click(object sender, RoutedEventArgs e)
        {
            string message = string.Empty;
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Text.Length < 2)
                    {
                        MessageBox.Show("Името ти трябва да е по-дълго от един символ");
                        return;
                    }
                    message = message + ((TextBox)item).Text + ", ";
                }
            }
            message = message.TrimEnd(new char[] {' ', ',' });

            MessageBox.Show("Здрасти " + message + "!!! \nТова е твоята вашата програма на Visual Studio 2012!");
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сигурен ли сте, че искате да излезете?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, Windows Presentation Foundation!");
        }
    }
}
