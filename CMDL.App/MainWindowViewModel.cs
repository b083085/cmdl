using CMDL.Core;
using CMDL.Core.Helpers;
using CMDL.Data;
using System.Linq;

namespace CMDL.App
{
    internal class MainWindowViewModel : BindableBase
    {
        private MainViewModel _mainViewModel;
        private object _content;
        public object Content
        {
            get => _content;
            set => SetProperty(ref _content, value);   
        }

        public string Title { get; } = "Cyber Medical & Diagnostic Laboratory";

        public MainWindowViewModel()
        {
            _mainViewModel = new MainViewModel();
        }

        public void ShowLoginView()
        {
            var loginViewModel = new LoginViewModel();
            loginViewModel.LoginClickEvent += Login;

            Content = loginViewModel;
        }

        public void ShowMainView()
        {
            Content = _mainViewModel;
        }

        private async void Login(LoginViewModel obj)
        {
            var db = new DataContext();

            var query = new DataQuery();
            query.Query = "SELECT * FROM office_user WHERE user_name=@userName and user_pwd=@password";
            query.AddParameter("@userName", obj.UserName);
            query.AddParameter("@password", obj.Password);

            var rows = await db.GetAsync(query);
            if (rows.Any())
            {
                _mainViewModel.UserName = obj.UserName;
                ShowMainView();
            }
            else
            {
                MessageBoxHelper.Error("Invalid user name or password.");
            }
        }
    }
}
