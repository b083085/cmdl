using System.Windows;

namespace CMDL.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _mainWindowViewModel = new MainWindowViewModel();

            DataContext = _mainWindowViewModel;

            Loaded += MainWindowLoaded;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.ShowLoginView();
        }
    }
}
