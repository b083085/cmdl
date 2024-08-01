using CMDL.App.Laboratory;
using CMDL.App.Neuro;
using CMDL.App.Registration.Display;
using CMDL.App.Registration.Edit;
using CMDL.App.Registration.New;
using CMDL.App.Registration.Print;
using CMDL.App.Registration.Sales;
using CMDL.App.Registration.Verification;
using CMDL.App.Reports;
using CMDL.App.Shared;
using CMDL.App.XRay;
using CMDL.Core;
using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace CMDL.App
{
    internal class MainViewModel : BindableBase
    {
        private Hashtable _contents = new Hashtable();
        private object _content;
        private string _userName;


        public ObservableCollection<MenuItemViewModel> MenuCollection { get; private set; }
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public object Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public MainViewModel()
        {
            SetMenuCollection();
        }

        private void SetMenuCollection()
        {
            var registration = CreateMenuItem("Registration", null, false);
            registration.MenuCollection.Add(CreateMenuItem("New Client", typeof(NewRegistrationViewModel)));
            registration.MenuCollection.Add(CreateMenuItem("Edit Client Records", typeof(EditRegistrationViewModel)));
            registration.MenuCollection.Add(CreateMenuItem("Client Verification", typeof(VerificationViewModel)));
            registration.MenuCollection.Add(CreateMenuItem("Display Registration", typeof(DisplayRegistrationViewModel)));
            registration.MenuCollection.Add(CreateMenuItem("Print Stub", typeof(PrintRegistrationViewModel)));
            registration.MenuCollection.Add(CreateMenuItem("Sales", typeof(SalesViewModel)));

            var xray = CreateMenuItem("X-Ray", typeof(XRayViewModel));
            var neuro = CreateMenuItem("Neuro", typeof(NeuroViewModel));
            var laboratory = CreateMenuItem("Laboratory", typeof(LaboratoryViewModel));
            var reports = CreateMenuItem("Reports", typeof(ReportsViewModel));

            MenuCollection = new ObservableCollection<MenuItemViewModel>
            {
                registration,
                xray,
                neuro,
                laboratory,
                reports
            };
        }

        private MenuItemViewModel CreateMenuItem(string header, Type targetContentType, bool canExecute = true)
        {
            var mivm = new MenuItemViewModel(header, targetContentType, canExecute);
            mivm.ClickEvent += ClickEvent;

            return mivm;
        }

        private void ClickEvent(MenuItemViewModel mivm)
        {
            if (_contents.ContainsKey(mivm.Header))
            {
                Content = _contents[mivm.Header];
            }
            else
            {
                var vm = Activator.CreateInstance(mivm.TargetContentType);
                _contents.Add(mivm.Header, vm);

                Content = vm;
            }
        }

    }
}
