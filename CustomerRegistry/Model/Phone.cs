using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistry.Model
{
    internal class Phone : BaseModel
    {
        private string _homePhone { get; set; }
        private string _cellPhone { get; set; }
        public string HomePhone
        {
            get => _homePhone;
            set
            {
                if (_homePhone != value)
                {
                    _homePhone = value;
                    OnPropertyChanged(nameof(HomePhone));
                }
            }
        }
        public string CellPhone
        {
            get => _cellPhone;
            set
            {
                if (_cellPhone != value)
                {
                    _cellPhone = value;
                    OnPropertyChanged(nameof(CellPhone));
                }
            }
        }
    }
}
