using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        private BaseCalculatorViewModel viewModel;

        private double Value { get; set; }

        private double SecondValue { get; set; }

        private char Operator { get; set; } 
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new BaseCalculatorViewModel(this);

            this.DataContext = viewModel;
        
        }

        #region Button Click Events

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Button);

            viewModel.SetValue(MainTextBox, obj.Content);
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            SetValues(sender);
        }

        private void ButtonMinusClick(object sender, RoutedEventArgs e)
        {
            SetValues(sender);
        }

        private void ButtonTimesClick(object sender, RoutedEventArgs e)
        {
            SetValues(sender);
        }

        private void ButtonDivideClick(object sender, RoutedEventArgs e)
        {
            SetValues(sender);
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            MainTextBox.Text = string.Empty;
            viewModel.SetDefaults();
        }

        private void ButtonEqualClick(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Button);
            SecondValue = double.Parse(MainTextBox.Text);
            viewModel.SecondValue = SecondValue;
            var result = viewModel.Calculate(Operator);
            MainTextBox.Text = string.Empty;

            MainTextBox.Text = result.ToString();
        }
        #endregion

        #region Methods

        public void SetValues(object ss)
        {
            var obj = (ss as Button);
            Operator = char.Parse(obj.Content.ToString());
            Value = double.Parse(MainTextBox.Text);
            viewModel.FirstValue = Value;
            MainTextBox.Text = string.Empty;
        }
        #endregion

    }
}
