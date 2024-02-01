using System;
using System.Windows;

namespace LoginViewApplication
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

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginButton.IsEnabled = true;
        }
        /// <summary>
        /// Reads the environemtal variables  TestUsername and TestPassword and if the credentials inserted by the user match it shows a correct Password message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginOperation(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameField.Text) || string.IsNullOrEmpty(PasswordField.Password))
            {
                MessageBox.Show("Invalid Fields");
                return;
            }
            string availableUser = Environment.GetEnvironmentVariable("TestUsername");
            string correspodentPassword = Environment.GetEnvironmentVariable("TestPassword");

            if (string.Equals(availableUser, UsernameField.Text, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(correspodentPassword, PasswordField.Password, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Password is correct!");
                return;
            }

        }
    }
}
