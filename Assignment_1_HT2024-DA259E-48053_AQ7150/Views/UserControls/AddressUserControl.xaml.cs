using RealEstateApp.Models.Enums;
using RealEstateApp.Models.SupportingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealEstateApp.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AddressUserControl.xaml
    /// </summary>
    public partial class AddressUserControl : UserControl
    {
        public AddressUserControl()
        {
            InitializeComponent();
            SetItemSource();
        }

        private void SetItemSource()
        {
            cmbCountry.ItemsSource = Enum.GetValues(typeof(Countries)).Cast<Countries>();
            cmbCountry.SelectedIndex = 164; // set default to Sweden
        
        }

        public Address GetAddress()
        {
            string street = txtStreet.Text;
            string postalCode = txtPostalCode.Text;
            string city = txtCity.Text;

            Countries country = (Countries)cmbCountry.SelectedItem;
            return new Address(street, postalCode, city, country);
        }
    }
}
