using CMDL.Core;
using System;
using System.Threading.Tasks;

namespace CMDL.App
{
    internal class LoginViewModel : BindableBase
    {
        private string _userName;
        private string _password;

        public event Action<LoginViewModel> LoginClickEvent;

        public Command LoginCommand { get; }

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
        }

        public void Login(object obj = null)
        {
            LoginClickEvent?.Invoke(this);
        }
    }
}
