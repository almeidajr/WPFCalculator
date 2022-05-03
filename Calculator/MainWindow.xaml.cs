using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currentValue = 0;
        private double result = 0;
        private Func<double, double, double> currentOperator = Operator.Add;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateResultLabel()
        {
            ResultLabel.Content = currentValue.ToString();
        }

        private void CalculateResult()
        {
            result = currentOperator(result, currentValue);
        }

        private void Reset()
        {
            currentValue = 0;
            result = 0;
            currentOperator = Operator.Add;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var buttonText = button.Content.ToString();
            if (string.IsNullOrEmpty(buttonText))
            {
                throw new System.ArgumentException("Button content is null or empty");
            }

            currentValue = currentValue * 10 + double.Parse(buttonText);
            UpdateResultLabel();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            UpdateResultLabel();
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateResult();
            var holder = result;
            ResultLabel.Content = holder.ToString();

            Reset();
            result = holder;
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            currentValue *= -1;
            UpdateResultLabel();
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            currentValue = result * currentValue / 100;
            UpdateResultLabel();
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var buttonText = button.Content.ToString();
            if (string.IsNullOrEmpty(buttonText))
            {
                throw new System.ArgumentException("Button content is null or empty");
            }
            CalculateResult();
            currentOperator = buttonText switch
            {
                Operation.Add => Operator.Add,
                Operation.Subtract => Operator.Subtract,
                Operation.Multiply => Operator.Multiply,
                Operation.Divide => Operator.Divide,
                _ => throw new System.ArgumentException("Button content is not an valid operator"),
            };
            currentValue = 0;
            UpdateResultLabel();
        }
    }

    public static class Operation
    {
        public const string Add = "+";
        public const string Subtract = "-";
        public const string Multiply = "×";
        public const string Divide = "÷";
    }

    public static class Operator
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b) => a / b;
    }
}
