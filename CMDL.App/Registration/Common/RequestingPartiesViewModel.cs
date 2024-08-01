using CMDL.App.Models;
using CMDL.App.Shared;
using CMDL.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMDL.App.Registration.Common
{
    internal class RequestingPartiesViewModel : BindableBase, IContainerContent
    {
        private string _selectedRequestingParty;
        public IEnumerable<string> RequestingParties 
        { 
            get;
            private set;
        }

        public ContainerView ContainerView 
        { 
            get; 
            private set; 
        }

        public Command AddRequestingPartyCommand { get; }

        public event Action<RequestingPartiesViewModel> AddRequestingPartyEvent;

        public RequestingPartiesViewModel()
        {
            AddRequestingPartyCommand = new Command(AddRequestingParty);
        }

        private void AddRequestingParty(object obj)
        {
            AddRequestingPartyEvent?.Invoke(this);
        }

        public async Task LoadRequestPartiesAsync()
        {
            RequestingParties = new List<string>()
            {
                "JOLLIBEE",
                "DEPED"
            };
        }

        public void Show()
        {
            ContainerView = new ContainerView("Requesting Parties", 400, 400, this);
            ContainerView.ShowDialog();
        }

        public void Close()
        {
            ContainerView?.Close();
        }

        public string SelectedRequestingParty
        {
            get => _selectedRequestingParty;
            set => SetProperty(ref _selectedRequestingParty, value);
        }

    }
}
