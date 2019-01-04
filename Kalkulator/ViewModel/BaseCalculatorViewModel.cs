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
        #endregion

        #region Calculator Methods

        public static void SetValue(object sender , object value)
        {
            var obj = (sender as TextBox);
            obj.Text += value.ToString();
        }

        #endregion
        /*Do zrobienia:
         * napisac system liczenia
        */
    }
}
