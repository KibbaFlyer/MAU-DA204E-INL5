using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry.Model
{
    internal class Address : BaseModel
    {
        private string _street {  get; set; }
        private string _city { get; set; }
        private string _zipCode { get; set; }
        private Countries _country { get; set; }

        public string Street
        {
            get => _street;
            set
            {
                if (_street != value)
                {
                    _street = value;
                    OnPropertyChanged(nameof(Street));
                }
            }
        }
        public string City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }
        public string ZipCode
        {
            get => _zipCode;
            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                    OnPropertyChanged(nameof(ZipCode));
                }
            }
        }
        public Countries Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged(nameof(Country));
                }
            }
        }

    }
}
