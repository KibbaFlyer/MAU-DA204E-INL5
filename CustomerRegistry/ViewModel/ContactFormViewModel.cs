using CustomerRegistry.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerRegistry.Model;
using System.ComponentModel;

namespace CustomerRegistry.ViewModel
{
    internal class ContactFormViewModel: ViewModelBase
    {
        #region Private fields
        private Contact _contact {  get; set; }
        #endregion
        #region Public properties
        public List<Countries> Countries { get; }
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
        #endregion
        public ContactFormViewModel(Contact? initialContact = null) 
        {
            Contact = initialContact ?? new Contact();
            Countries = Enum.GetValues(typeof(Countries)).Cast<Countries>().ToList();
        }

    }
}
