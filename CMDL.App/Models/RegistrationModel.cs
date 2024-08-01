using CMDL.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CMDL.App.Models
{
	internal class RegistrationModel : BindableBase
    {
		private string _controlNumber;
		private string _lastName;
		private string _firstName;
		private string _middleInitial;
		private string _suffix;
		private string _address;
		private int _age;
		private string _gender;
		private string _civilStatus;
		private DateTime _dob;
		private string _birthPlace;
		private ObservableCollection<string> _requestingParties;
		private string _purpose;
		private string _telephoneNumber;
		private string _mobileNumber;
		private string _districtOrBranch;
		private byte[] _photo;
		private double _total;
		private double _amountPaid;
		private double _balance;
		private double _change;

		public RegistrationModel()
		{
			RequestingParties = new ObservableCollection<string>();
		}

		public double Change
		{
			get => _change; 
			set => SetProperty(ref _change, value);
		}

		public double Balance
		{
			get => _balance; 
			set => SetProperty(ref _balance, value);
		}

		public double AmountPaid
		{
			get => _amountPaid; 
			set => SetProperty(ref _amountPaid, value);
		}

		public double Total
		{
			get => _total; 
			set => SetProperty(ref _total, value);
		}

		public byte[] Photo
		{
			get => _photo; 
			set => SetProperty(ref _photo, value);
		}

		public string DistrictOrBranch
		{
			get => _districtOrBranch; 
			set => SetProperty(ref _districtOrBranch, value);
		}


		public string MobileNumber
		{
			get => _mobileNumber; 
			set => SetProperty(ref _mobileNumber, value);
		}


		public string TelephoneNumber
		{
			get => _telephoneNumber; 
			set => SetProperty(ref _telephoneNumber, value);
		}

		public string Purpose
		{
			get => _purpose; 
			set => SetProperty(ref _purpose, value);
		}

		public ObservableCollection<string> RequestingParties
		{
			get => _requestingParties; 
			set => SetProperty(ref _requestingParties, value);
		}

		public string BirthPlace
		{
			get => _birthPlace; 
			set => SetProperty(ref _birthPlace, value);
		}

		public DateTime DOB
		{
			get => _dob; 
			set => SetProperty(ref _dob, value);
		}

		public string CivilStatus
		{
			get => _civilStatus; 
			set => SetProperty(ref _civilStatus, value);
		}

		public string Gender
		{
			get => _gender; 
			set => SetProperty(ref _gender, value);
		}

		public int Age
		{
			get => _age; 
			set => SetProperty(ref _age, value);
		}

		public string Address
		{
			get => _address; 
			set => SetProperty(ref _address, value);
		}

		public string Suffix
		{
			get => _suffix;
			set => SetProperty(ref _suffix, value);
		}

		public string MiddleInitial
		{
			get => _middleInitial;
			set => SetProperty(ref _middleInitial, value);
		}

		public string FirstName
		{
			get => _firstName;
			set => SetProperty(ref _firstName, value);
		}

		public string LastName
		{
			get => _lastName;
			set => SetProperty(ref _lastName, value);
		}

        public string ControlNumber
        {
            get => _controlNumber;
            set => SetProperty(ref _controlNumber, value);
        }

    }
}
