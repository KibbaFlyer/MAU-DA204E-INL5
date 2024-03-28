using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry.Model
{
    /// <summary>
    /// Contains components to create emails for a Contact.
    /// Expands BaseModel in order to provide reactiveness on property change.
    /// </summary>
    internal class Email : BaseModel
    {
        private string _businessEmail {  get; set; }
        private string _privateEmail { get; set; }

        public string BusinessEmail
        {
            get => _businessEmail;
            set
            {
                if (_businessEmail != value)
                {
                    _businessEmail = value;
                    OnPropertyChanged(nameof(BusinessEmail));
                }
            }
        }
        public string PrivateEmail
        {
            get => _privateEmail;
            set
            {
                if (_privateEmail != value)
                {
                    _privateEmail = value;
                    OnPropertyChanged(nameof(PrivateEmail));
                }
            }
        }
    }
}
