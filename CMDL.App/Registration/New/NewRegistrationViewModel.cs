using CMDL.App.Models;
using CMDL.App.Registration.Common;
using CMDL.Core;
using CMDL.Core.Helpers;
using System.Threading.Tasks;

namespace CMDL.App.Registration.New
{
	internal class NewRegistrationViewModel : BindableBase
    {
        public RegistrationModel Client { get; }

		public Command CopyAddressCommand { get; }
		public Command ShowRequestingPartyListCommand { get; }
		public Command NewRequestingPartyCommand { get; }
		public Command RemoveRequestingPartyCommand { get; }
		public Command CameraCommand { get; }
		public Command ExaminationListCommand { get; }
		public Command SaveCommand { get; }

		public NewRegistrationViewModel()
		{
			Client = new RegistrationModel();

			CopyAddressCommand = new Command(CopyAddress);
            ShowRequestingPartyListCommand = new Command(ShowRequestingPartyList);
		}

		private void CopyAddress(object obj)
		{
			Client.BirthPlace = Client.Address;
		}

		private async void ShowRequestingPartyList(object obj)
		{
			var vm = new RequestingPartiesViewModel();
            vm.AddRequestingPartyEvent += AddRequestingParty;
			await vm.LoadRequestPartiesAsync();

			vm.Show();
		}

        private void AddRequestingParty(RequestingPartiesViewModel vm)
        {
			if (Client.RequestingParties.Contains(vm.SelectedRequestingParty))
			{
				MessageBoxHelper.Error("Selected Requesting Party already exist: " + vm.SelectedRequestingParty);
			}
			else
			{
                Client.RequestingParties.Add(vm.SelectedRequestingParty);
                vm.Close();
            }
        }

		public async Task LoadSourcesAsync()
		{
			// gender
			// civil status
			// purpose
			// exams
		}

		
	}
}
