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
        public BaseCalculatorViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new BaseCalculatorViewModel(this);

            this.DataContext = viewModel;
        
        }

        #region Button Click Events

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var obj = (sender as Button);

            BaseCalculatorViewModel.SetValue(MainTextBox, obj.Content);
        }
    }
}
