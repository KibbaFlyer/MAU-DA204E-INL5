using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CustomerRegistry.Model;
using CustomerRegistry.Commands;
using CustomerRegistry.View;
using CustomerRegistry.Services;
using System.Collections.ObjectModel;

namespace CustomerRegistry.ViewModel
{
    /// <summary>
    /// Main ViewModel of the application
    /// Extends the ViewModelBase in order to give reactiveness on property change
    /// </summary>
    internal class CustomerViewModel : ViewModelBase
    {
        #region Private fields
        private IDialogService _dialogService = new DialogService();
        private ObservableCollection<Contact> _contacts { get; set; } = new ObservableCollection<Contact>();
        private string _authorName { get; set; } = string.Empty;
        private string _currentContactDetails { get; set; } = string.Empty ;
        private Contact? _selectedContact { get; set; }
        #endregion
        #region Public properties
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set
            {
                if (value != _contacts)
                {
                    _contacts = value;
                    OnPropertyChanged(nameof(Contacts));
                }
            }
        }
        public string AuthorName
        {
            get => _authorName;
            set
            {
                if (value != _authorName)
                {
                    _authorName = value;
                    OnPropertyChanged(nameof(AuthorName));
                }
            }
        }
        public string CurrentContactDetails
        {
            get => _currentContactDetails;
            set
            {
                if (value != _currentContactDetails)
                {
                    _currentContactDetails = value;
                    OnPropertyChanged(nameof(CurrentContactDetails));
                }
            }
        }
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (value != _selectedContact && value != null)
                {
                    // Here we format the string for usage in a Label such that row-breaks and adjustment is consistent
                    _selectedContact = value;
                    string formattedContact = String.Format(
                        "{1}{0}{2}{0}{3} {4}{0}{5}{0}" +
                        "{0}" +
                        "{6,-15}{0}" +
                        " {7,-15}{8}{0}" +
                        " {9,-15}{10}{0} " +
                        "{0}" +
                        "{11,-15}{0}" +
                        " {7,-15}{12}{0}" +
                        " {9,-15}{13} ",
                        Environment.NewLine, //0
                        value.Name,
                        value.Address.Street,
                        value.Address.ZipCode,
                        value.Address.City,
                        value.Address.Country.ToString().Replace("_"," "), //5
                        "Emails",
                        "Private",
                        value.Email.PrivateEmail, // 8
                        "Office",
                        value.Email.BusinessEmail,
                        "Phone numbers", // 11
                        value.Phone.HomePhone,
                        value.Phone.CellPhone
                        );
                    CurrentContactDetails = formattedContact;
                    OnPropertyChanged(nameof(SelectedContact));
                }
                // If the selectedContact has been deleted, we need to reset the data
                else if ( value == null )
                {
                    _selectedContact = value;
                    CurrentContactDetails = "";
                    OnPropertyChanged(nameof(SelectedContact));
                }
            }
        }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion
        public CustomerViewModel(string authorName) 
        {
            AddCommand = new BaseICommand(AddCommandAction, CanAddCommand);
            EditCommand = new BaseICommand(EditCommandAction, CanEditCommand);
            DeleteCommand = new BaseICommand(DeleteCommandAction, CanDeleteCommand);
            AuthorName = $"Customer Registry By {authorName}";
        }
        #region Methods
        private bool CanAddCommand()
        {
            return true;
        }
        private bool CanEditCommand()
        {
            return _selectedContact != null;
        }
        private bool CanDeleteCommand()
        {
            return _selectedContact != null;
        }
        /// <summary>
        /// Opens up a new view with a new ViewModel.
        /// Upon close the data is fed back to this main ViewModel if the DialogResult was true.
        /// </summary>
        private void AddCommandAction()
        {
            var contactViewModel = new ContactFormViewModel();
            _dialogService.ShowDialog(
                "ContactFormView",
                "Add new customer",
               contactViewModel,
                (viewModelResult, dialogResult) =>
                {
                    if (dialogResult.ToString() == "True" && viewModelResult is ContactFormViewModel returnViewModel)
                    {
                        if (returnViewModel != null)
                        {
                            int maxId = 0;
                            if(Contacts.Count  > 0)
                            {
                                maxId = Contacts.MaxBy(x => x.Id).Id;
                            }
                            returnViewModel.Contact.Id = maxId + 1;
                            Contacts.Add(returnViewModel.Contact);
                        }
                    }
                }
                );
        }
        /// <summary>
        /// Opens up a new view with a new ViewModel with data from the current contact selected.
        /// Upon close the data is fed back to this main ViewModel if the DialogResult was true.
        /// </summary>
        private void EditCommandAction()
        {
            int oldContactIndex = Contacts.IndexOf(_selectedContact);

            Contact copiedContact = new Contact();
            copiedContact.Email = _selectedContact.Email;
            copiedContact.Address = _selectedContact.Address;
            copiedContact.Phone = _selectedContact.Phone;
            copiedContact.Id = _selectedContact.Id;
            copiedContact.FirstName = _selectedContact.FirstName;
            copiedContact.LastName = _selectedContact.LastName;

            ContactFormViewModel newViewModel = new ContactFormViewModel(copiedContact);
            _dialogService.ShowDialog(
                "ContactFormView",
                "Add new customer",
               newViewModel,
                (viewModelResult, dialogResult) =>
                {
                    if (dialogResult.ToString() == "True" && viewModelResult is ContactFormViewModel returnViewModel)
                    {
                        if (returnViewModel != null)
                        {
                            Contacts[oldContactIndex] = returnViewModel.Contact;
                            SelectedContact = returnViewModel.Contact;
                        }
                    }
                }
                );
        }
        private void DeleteCommandAction()
        {
            var oldContact = Contacts.FirstOrDefault(x => x.Id == _selectedContact.Id);
            if(oldContact != null)
            {
                Contacts.Remove(oldContact);
            }
            SelectedContact = null;
        }
        #endregion
    }
}
