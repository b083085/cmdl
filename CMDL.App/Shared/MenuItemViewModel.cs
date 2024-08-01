using CMDL.Core;
using System;
using System.Collections.ObjectModel;

namespace CMDL.App.Shared
{
    internal class MenuItemViewModel : BindableBase
    {
        public Command Command { get; }
        public string Header { get; }
        public ObservableCollection<MenuItemViewModel> MenuCollection { get; }
        public bool CanExecute { get; }
        public Type TargetContentType { get; }

        public event Action<MenuItemViewModel> ClickEvent;

        public MenuItemViewModel(string header, Type targetContentType, bool canExecute = true)
        {
            Header = header;
            Command = new Command(Execute);
            MenuCollection = new ObservableCollection<MenuItemViewModel>();
            CanExecute = canExecute;
            TargetContentType = targetContentType;
        }

        private void Execute(object obj)
        {
            if(obj is MenuItemViewModel mivm && mivm.CanExecute)
            {
                ClickEvent?.Invoke(mivm);
            }
        }
    }
}
