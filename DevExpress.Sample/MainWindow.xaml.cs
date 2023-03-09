using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevExpress.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow , INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            ShowMessageCommand = new RelayCommand(param =>
            {
                string msg = string.Empty;

                if (param is not null and TextBox)
                {
                    msg = (param as TextBox).Text;
                }

                MessageBox.Show(msg);
            }); 
            
            this.DataContext = this;
        }

        public ICommand ShowMessageCommand { get; }


        private string message { get; set; } = "Click me";
        public string Message
        {
            get { return message; } set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
     
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> execute { get; set; }
        private Func<object, bool> canExecute { get; set; }


        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}
