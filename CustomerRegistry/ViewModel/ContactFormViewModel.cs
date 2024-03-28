using CustomerRegistry.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerRegistry.Model;
using System.ComponentModel;
using System.Windows.Input;
using System.Diagnostics.Eventing.Reader;
using System.Windows;

namespace CustomerRegistry.ViewModel
{
    internal class ContactFormViewModel: ViewModelBase
    {
        #region Private fields
        private Contact _contact {  get; set; }
        #endregion
        #region Public properties
        public List<Countries> Countries { get; }
        public List<CountryDisplayFriendly> CountryListDisplayFriendly { get; set; }
        public Contact Contact 
        {
            get => _contact;
            set
            {
                if(_contact != value)
                {
                    _contact = value;
                    OnPropertyChanged(nameof(Contact));
                }
            }
        }
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }
        public event EventHandler<bool> CloseOnOk;
        #endregion
        public ContactFormViewModel(Contact? initialContact = null) 
        {
            Contact = initialContact ?? new Contact();
            Countries = Enum.GetValues(typeof(Countries)).Cast<Countries>().ToList();
            CountryListDisplayFriendly = new List<CountryDisplayFriendly>(
                        Countries.Select(countryEnum => new CountryDisplayFriendly
                        {
                            DisplayName = countryEnum.ToString().Replace("_"," "),
                            Value = countryEnum
                        }));
            OkCommand = new BaseICommand(OkAction, CanOk);
            CancelCommand = new BaseICommand(CancelAction, CanCancel);
        }
        #region Methods
        private bool CanOk()
        {
            return (_contact.FirstName != "" || _contact.LastName != "") && _contact.Address.City != "" && _contact.Address.City != null;
        }
        private bool CanCancel()
        {
            return true;
        }
        private void OkAction()
        {
            InvokeDialogClose(true);
        }
        private void CancelAction()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to close?", "Close contact dialog", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                InvokeDialogClose(false);
        }
        private void InvokeDialogClose (bool result)
        {
            CloseOnOk?.Invoke(this, result);
        }

        #endregion
        public class CountryDisplayFriendly
        {
            public string DisplayName { get; set; }
            public Countries Value { get; set; }
        }
    }
}
