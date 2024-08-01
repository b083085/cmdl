using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CMDL.App
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginViewModel _loginViewModel;

        public LoginView()
        {
            InitializeComponent();

            Loaded += LoginViewLoaded;

            tbUserName.KeyDown += UserNameKeyDown;
            pbPassword.KeyDown += PasswordKeyDown;
        }

        private void PasswordKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _loginViewModel.Login();
        }

        private void UserNameKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                _loginViewModel.Login();
        }

        private void LoginViewLoaded(object sender, RoutedEventArgs e)
        {
            _loginViewModel = DataContext as LoginViewModel;

            tbUserName.Focus();
        }
    }
}
