using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry.Model
{
    /// <summary>
    /// Contains components to create a contact, including sub-classes.
    /// Expands BaseModel in order to provide reactiveness on property change.
    /// </summary>
    internal class Contact : BaseModel
    {
        private int _id { get; set; }
        private string _firstName { get; set; } = "";
        private string _lastName { get; set; } = "";
        private Phone _phone { get; set; } = new Phone();
        private Email _email { get; set; } = new Email();
        private Address _address { get; set; } = new Address();

        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        /// <summary>
        /// Contains the firstname and lastname concatenated and the lastname in uppercase.
        /// </summary>
        public string Name
        {
            get
            {
                string returnString = _lastName.ToUpper() + ", " + _firstName;
                return returnString;
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        public Phone Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }
        public Email Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public Address Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

    }
}
