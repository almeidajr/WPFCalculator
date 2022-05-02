using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DefaultDisplayResult = "0";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var buttonText = button.Content.ToString();
            if (ResultLabel.Content.ToString() == DefaultDisplayResult)
            {
                ResultLabel.Content = buttonText;
            }
            else
            {
                ResultLabel.Content += buttonText;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = DefaultDisplayResult;
        }
    }
}
