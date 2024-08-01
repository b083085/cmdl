using CMDL.Common;
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
using System.Windows.Shapes;

namespace CMDL.Views.WPF
{
    /// <summary>
    /// Interaction logic for PasswordForm.xaml
    /// </summary>
    public partial class PasswordForm : Window
    {
        public PasswordForm()
        {
            InitializeComponent();

            btnOK.Click += BtnOK_Click;
            Loaded += PasswordForm_Loaded;
            pbPassword.KeyDown += PbPassword_KeyDown;
        }

        private void PbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Verify();
        }

        private void PasswordForm_Loaded(object sender, RoutedEventArgs e)
        {
            pbPassword.Focus();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            Verify();
        }

        private void Verify()
        {
            if(pbPassword.Password == GlobalInstance.Instance.User.Password)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid password.", "Verification", MessageBoxButton.OK, MessageBoxImage.Stop);
                pbPassword.Focus();
            }
        }
    }
}
