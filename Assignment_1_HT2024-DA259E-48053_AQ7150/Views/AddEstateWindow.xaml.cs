using RealEstateApp.Models.ConcreteClasses;
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
using System.Windows.Shapes;

namespace RealEstateApp.Views
{
    /// <summary>
    /// Interaction logic for AddEstateWindow.xaml
    /// </summary>
    public partial class AddEstateWindow : Window
    {
        public AddEstateWindow()
        {
            InitializeComponent();
        }

        private void cmbEstateType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected estate type
            string estateType = (cmbEstateType.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content.ToString();

            //chkHasGarden.Visibility = Visibility.Collapsed;
            //chkHasGarage.Visibility = Visibility.Collapsed;
            //chkHasBalcony.Visibility = Visibility.Collapsed;
            //chkHasSharedWalls.Visibility = Visibility.Collapsed;
            //chkHasFreezers.Visibility = Visibility.Collapsed;
            //chkIsIndustrial.Visibility = Visibility.Collapsed;
            //chkPerformsResearch.Visibility = Visibility.Collapsed;
            //chkHasEmergencyWard.Visibility = Visibility.Collapsed;
            //chkPerformsResearchHospital.Visibility = Visibility.Collapsed;
            //txtMonthlyFee.Visibility = Visibility.Collapsed;
            //txtHousingCooperative.Visibility = Visibility.Collapsed;
            //txtRent.Visibility = Visibility.Collapsed;
            //txtLeasePeriod.Visibility = Visibility.Collapsed;
            //txtTypeOfShop.Visibility = Visibility.Collapsed;

            // Always visible common fields
            txtRooms.Visibility = Visibility.Visible;
            txtArea.Visibility = Visibility.Visible;
            addressControl.Visibility = Visibility.Visible;

            // Conditional fields depending on user selection
            chkHasGarden.Visibility = Visibility.Collapsed;
            chkHasGarage.Visibility = Visibility.Collapsed;
            chkHasBalcony.Visibility = Visibility.Collapsed;
            chkHasSharedWalls.Visibility = Visibility.Collapsed;
            chkHasFreezers.Visibility = Visibility.Collapsed;
            chkIsIndustrial.Visibility = Visibility.Collapsed;
            txtDepartments.Visibility = Visibility.Collapsed;
            txtMaxCapacity.Visibility = Visibility.Collapsed;
            txtPrograms.Visibility = Visibility.Collapsed;
            chkPerformsResearch.Visibility = Visibility.Collapsed;
            chkHasEmergencyWard.Visibility = Visibility.Collapsed;
            txtMonthlyFee.Visibility = Visibility.Collapsed;
            txtHousingCooperative.Visibility = Visibility.Collapsed;
            txtRent.Visibility = Visibility.Collapsed;
            txtLeasePeriod.Visibility = Visibility.Collapsed;
            txtTypeOfShop.Visibility = Visibility.Collapsed;


            // Show/hide checkboxes depending on the estate type
            switch (estateType)
            {
                case "Apartment":
                    chkHasBalcony.Visibility = Visibility.Visible;
                    break;

                case "Villa":
                    chkHasGarden.Visibility = Visibility.Visible;
                    chkHasGarage.Visibility = Visibility.Visible;
                    break;

                case "Rowhouse":
                    chkHasGarden.Visibility = Visibility.Visible;
                    chkHasGarage.Visibility = Visibility.Visible;
                    chkHasSharedWalls.Visibility = Visibility.Visible;
                    break;

                case "Warehouse":
                    chkHasFreezers.Visibility = Visibility.Visible;
                    chkIsIndustrial.Visibility = Visibility.Visible;
                    break;

                case "University":
                    txtDepartments.Visibility = Visibility.Visible;
                    txtMaxCapacity.Visibility = Visibility.Visible;
                    txtPrograms.Visibility = Visibility.Visible;
                    chkPerformsResearch.Visibility = Visibility.Visible;
                    break;

                case "Hospital":
                    txtDepartments.Visibility = Visibility.Visible;
                    txtMaxCapacity.Visibility = Visibility.Visible;
                    chkHasEmergencyWard.Visibility = Visibility.Visible;
                    chkPerformsResearch.Visibility = Visibility.Visible;
                    break;

                case "Tenement":
                    txtMonthlyFee.Visibility = Visibility.Visible;
                    txtHousingCooperative.Visibility = Visibility.Visible;
                    break;

                case "Rental":
                    txtRent.Visibility = Visibility.Visible;
                    txtLeasePeriod.Visibility = Visibility.Visible;
                    break;

                case "Shop":
                    txtTypeOfShop.Visibility = Visibility.Visible;
                    break;
            }
        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            string? estateType = (cmbEstateType.SelectedItem as ComboBoxItem)?.Content.ToString();


            bool successRooms = int.TryParse(txtRooms.Text, out int numberOfRooms);
            bool successArea = double.TryParse(txtArea.Text, out double area);
            bool successConstructionYear = int.TryParse(txtConstructionYear.Text, out int constructionYear);
            bool successnumberOfFloors = int.TryParse(txtNumberOfFloors.Text, out int numberOfFloors);
            bool successLoadingDocks = int.TryParse(txtLoadingDocks.Text, out int loadingdocks);
            bool successStorageCapacity = double.TryParse(txtStorageCapacity.Text, out double storageCapacity);
            bool successDepartments = int.TryParse(txtDepartments.Text, out int numberOfDepartments);
            bool successMaxCapacity = int.TryParse(txtMaxCapacity.Text, out int maxCapacity);
            bool successPrograms = int.TryParse(txtPrograms.Text, out int universityPrograms);
            bool successMonthlyFee = int.TryParse(txtMonthlyFee.Text, out int monthlyFee);
            string housingCooperative = txtHousingCooperative.Text;

            // Capture Rental-specific inputs
            bool successRent = double.TryParse(txtRent.Text, out double rent);
            string leasePeriod = txtLeasePeriod.Text;

            // Capture Shop-specific input
            string typeOfShop = txtTypeOfShop.Text;


            if (!successRooms || !successArea || !successConstructionYear)
            {
                MessageBox.Show("Please enter valid numbers for rooms, area, and construction year.");
                return;
            }

            if (!successDepartments || !successMaxCapacity || (estateType == "University" && !successPrograms))
            {
                MessageBox.Show("Please enter valid numbers for departments, capacity, and university programs.");
                return;
            }

            Address address = addressControl.GetAddress();

            switch (estateType)
            {
                case "Apartment":
                    Apartment newApartment = new Apartment(1,
                                                           address,
                                                           numberOfRooms,
                                                           area,
                                                           chkHasGarden.IsChecked ?? false,
                                                           chkHasBalcony.IsChecked ?? false,
                                                           chkHasGarage.IsChecked ?? false);
                    break;
                case "Tenement":
                    Tenement newTenement = new Tenement(
                        7,
                        address,
                        3, // Assume floor number for now, or add input
                        numberOfRooms,
                        area,
                        chkHasGarden.IsChecked ?? false,
                        chkHasGarage.IsChecked ?? false,
                        chkHasBalcony.IsChecked ?? false,
                        monthlyFee,
                        housingCooperative
                    );
                    // Save the newTenement object
                    break;

                // Create Rental Object
                case "Rental":
                    Rental newRental = new Rental(
                        8,
                        address,
                        3, // Assume floor number for now, or add input
                        numberOfRooms,
                        area,
                        chkHasGarden.IsChecked ?? false,
                        chkHasGarage.IsChecked ?? false,
                        chkHasBalcony.IsChecked ?? false,
                        rent,
                        leasePeriod
                    );
                    // Save the newRental object
                    break;
                case "Villa":
                    Villa newVilla = new Villa(2,
                                               address,
                                               numberOfRooms,
                                               area,
                                               chkHasGarden.IsChecked ?? false,
                                               chkHasGarage.IsChecked ?? false,
                                               constructionYear);
                    break;

                case "Rowhouse":
                    Rowhouse newRowhouse = new Rowhouse(3,
                                                        address,
                                                        numberOfRooms,
                                                        area,
                                                        chkHasGarden.IsChecked ?? false,
                                                        chkHasGarage.IsChecked ?? false,
                                                        chkHasSharedWalls.IsChecked ?? false,
                                                        constructionYear);
                    break;

                case "Warehouse":
                    Warehouse newWarehouse = new Warehouse(4,
                                                           address,
                                                           area,
                                                           numberOfFloors,
                                                           chkIsIndustrial.IsChecked ?? false,
                                                           storageCapacity,
                                                           loadingdocks,
                                                           chkHasFreezers.IsChecked ?? false);
                    break;

                case "University":
                    University newUniversity = new University(5,
                                                              address,
                                                              "University",
                                                              numberOfDepartments.ToString(),
                                                              maxCapacity,
                                                              universityPrograms,
                                                              chkPerformsResearch.IsChecked ?? false);
                    break;
                case "Hospital":
                    Hospital newHospital = new Hospital(6,
                                                        address,
                                                        "Hospital",
                                                        numberOfDepartments.ToString(),
                                                        maxCapacity,
                                                        chkHasEmergencyWard.IsChecked ?? false,
                                                        chkPerformsResearch.IsChecked ?? false);
                    break;
                
                                 
                case "Shop":
                    Shop newShop = new Shop(9,
                        address,
                        area,
                        numberOfFloors,
                        false, // Assuming a shop is not industrial
                        typeOfShop);

                    break;
                default:
                    MessageBox.Show("Please select a valid estate type.");
                    return;
            }


        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window without saving
        }

    }
}
