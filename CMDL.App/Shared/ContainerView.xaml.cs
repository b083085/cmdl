using CMDL.App.Models;
using System.Windows;

namespace CMDL.App.Shared
{
    /// <summary>
    /// Interaction logic for ContainerView.xaml
    /// </summary>
    public partial class ContainerView : Window
    {
        public ContainerView(string title, double height, double width, IContainerContent containerContent)
        {
            InitializeComponent();

            Title = title;
            Height = height;
            Width = width;

            DataContext = containerContent;
        }
    }
}
