using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CMDL
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public delegate void ClickEventHandler();
        public event ClickEventHandler LoginClickEvent;
        
        public LoginControl()
        {
            InitializeComponent();

            BtLogin.Click += BtLogin_Click;
            passwordBox1.KeyDown += passwordBox1_KeyDown;
            TbUserName.KeyDown += TbUserName_KeyDown;

            this.Loaded += Uc_LoginControl_Loaded;
            
        }

        void Uc_LoginControl_Loaded(object sender, RoutedEventArgs e)
        {
            TbUserName.Focus();
        }

        void TbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (LoginClickEvent != null)
                    LoginClickEvent();
            }
        }

        void passwordBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (LoginClickEvent != null)
                    LoginClickEvent();
            }
        }

        void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoginClickEvent != null)
                LoginClickEvent();
        }

        public void UserNameFocus()
        {
            TbUserName.Focus();
        }

        public string UserName
        {
            get
            {
                return TbUserName.Text;
            }
        }
        public string Password
        {
            get
            {
                return passwordBox1.Password;
            }
        }
    }
}
