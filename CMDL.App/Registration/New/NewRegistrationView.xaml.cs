using System.Windows.Controls;

namespace CMDL.App.Registration.New
{
    /// <summary>
    /// Interaction logic for NewRegistrationView.xaml
    /// </summary>
    public partial class NewRegistrationView : UserControl
    {
        public NewRegistrationView()
        {
            InitializeComponent();

            Loaded += NewRegistrationViewLoaded;
        }

        private void NewRegistrationViewLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            tbLastName.Focus();
        }
    }
}
