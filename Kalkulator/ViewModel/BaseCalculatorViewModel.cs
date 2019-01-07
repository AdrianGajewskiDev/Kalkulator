using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kalkulator
{
    public class BaseCalculatorViewModel
    {
        public BaseCalculatorViewModel(Window window)
        {
            mWindow = window;
            Title = "Kalkulator";
            
            WindowCloseCommand = new RelayCommand(Close);
            WindowMinimizeCommand = new RelayCommand(Minimize);
            WindowMaximizeCommand = new RelayCommand(Maximize);
        }

        #region Private Members
        /// <summary>
        /// Window to operate on
        /// </summary>
        private Window mWindow { get; set; }
        #endregion

        #region Window Properties

        /// <summary>
        /// Title to display in the header
        /// </summary>
        public string Title { get; set; }
        #endregion

        #region Commands
        public ICommand WindowCloseCommand { get; set; } 
        public ICommand WindowMinimizeCommand { get; set; }
        public ICommand WindowMaximizeCommand { get; set; }
        #endregion

        #region Commands Methods
        public void Close()
        {
            mWindow.Close();
        }

        public void Minimize()
        {
            mWindow.WindowState = WindowState.Minimized;
        }

        public void Maximize()
        {
            if(mWindow.WindowState == WindowState.Normal)
            {
                mWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                mWindow.WindowState = WindowState.Normal;
            }
        }

        #endregion

        #region Calculator Properties
        /// <summary>
        /// Text to display in main texbox
        /// </summary
        public string TextToDisplayX { get; set; }

        /// <summary>
        /// First value that user provide in main textbox
        /// </summary>
        private double _firstValue;

        public double FirstValue
        {
            get => _firstValue;
            set
            {
                if (_firstValue == value)
                    return;

                _firstValue = value;
            }

        }

        /// <summary>
        /// First value that user provide in main textbox
        /// </summary>
        private double _secondValue;

        public double SecondValue
        {
            get => _secondValue;
            set
            {
                if (_secondValue == value)
                    return;

                _secondValue = value;
            }

        }

        /// <summary>
        /// The given operator
        /// </summary>
        private char _operator;

        public char Operator
        {
            get => _operator;
            set
            {
                if (_operator == value)
                    return;

                _operator = value;
            }
        }

        public double result;
        #endregion

        #region Calculator Methods

        public void SetValue(object sender , object value)
        {
            var obj = (sender as TextBox);
            obj.Text += value.ToString();
        }

        public double Calculate(char _operator)
        {

            switch(_operator)
            {
                case '+':
                    {
                        result = FirstValue + SecondValue;      
                    }break;
                case '-':
                    {
                        result = FirstValue - SecondValue;
                    }break;
                case '*':
                    {
                        result = FirstValue * SecondValue;
                    }break;
                case '/':
                    {
                        try
                        {
                            result = FirstValue / SecondValue;
                        }
                        catch(DivideByZeroException ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }break;
            }

            return result;
        }

        public void SetDefaults()
        {
            FirstValue = 0;
            SecondValue = 0;
        }
        #endregion
    }
}
