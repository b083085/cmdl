using System.Windows;

namespace CMDL.Core.Helpers
{
    public static class MessageBoxHelper
    {
        public static void Error(string errorMessage) => MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        public static void Success(string errorMessage) => MessageBox.Show(errorMessage, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
