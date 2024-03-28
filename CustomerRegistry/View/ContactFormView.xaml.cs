using CustomerRegistry.Model;
using CustomerRegistry.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomerRegistry.View
{
    /// <summary>
    /// Interaction logic for ContactForm.xaml
    /// </summary>
    public partial class ContactFormView : UserControl
    {
        public ContactFormView()
        {
            InitializeComponent();
        }
        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as Window;
            window.DialogResult = true;
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = this.Parent as Window;
            window.DialogResult = false;
        }
    }
}
