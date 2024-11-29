// written by Henrik Henriksson (AQ7150)

using Assignment5_HT2024_DA204E_AQ7150.Classes;
using EventOrganizerApp.Classes;

namespace Assignment5_HT2024_DA204E_AQ7150.Forms
{
    public partial class AddOrUpdateGuestForm : Form
    {
        private EventManager eventManager;
        private Participant participant;
        private bool isUpdateMode;

        private Font commonFont = new Font("Arial", 10, FontStyle.Regular);
        private Color commonBackColor = Color.DarkGray;
        private Color commonForeColor = Color.Black;

        public AddOrUpdateGuestForm(EventManager eventManager, Participant participant)
        {
            InitializeComponent();
            this.eventManager = eventManager;
            this.participant = participant;
            isUpdateMode = participant != null;
            initializeGUI();
        }

        private void initializeGUI()
        {
            ForeColor = commonForeColor;
            BackColor = Color.DarkSlateGray;
            Text = isUpdateMode ? "Update Guest" : "Add New Guest";
            Size = new Size(400, 400);

            Label lblFirstName = new Label
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "First Name:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            Controls.Add(lblFirstName);

            TextBox txtFirstName = new TextBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(130, 20),
                Size = new Size(150, 20)
            };
            Controls.Add(txtFirstName);
            if (isUpdateMode) txtFirstName.Text = participant.FirstName;

            Label lblLastName = new Label
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "Last Name:",
                Location = new Point(20, 60),
                AutoSize = true
            };
            Controls.Add(lblLastName);

            TextBox txtLastName = new TextBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
              
                Location = new Point(130, 60),
                Size = new Size(200, 20)
            };
            if (isUpdateMode) txtLastName.Text = participant.LastName;
            Controls.Add(txtLastName);

            Label lblStreet = new Label()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                AutoSize = true,
                Text = "Street:",
                Location = new Point(20, 100)
            };
            Controls.Add(lblStreet);

            TextBox txtStreet = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(130, 100),
                Size = new Size(200, 20)
            };
            if (isUpdateMode) txtStreet.Text = participant.Address.Street;
            Controls.Add(txtStreet);

            Label lblCity = new Label()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                AutoSize = true,
                Text = "City:",
                Location = new Point(20, 140)
            };
            Controls.Add(lblCity);

            TextBox txtCity = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(130, 140),
                Size = new Size(150, 20)
            };
            if (isUpdateMode) txtCity.Text = participant.Address.City;
            Controls.Add(txtCity);

            Label lblPostalCode = new Label()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                AutoSize = true,
                Text = "Postal Code:",
                Location = new Point(20, 180)
            };
            Controls.Add(lblPostalCode);

            TextBox txtPostalCode = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(130, 180),
                Size = new Size(100, 20)
            };
            if (isUpdateMode) txtPostalCode.Text = participant.Address.PostalCode;
            Controls.Add(txtPostalCode);

            Label lblCountry = new Label()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                AutoSize = true,
                Text = "Country:",
                Location = new Point(20, 220)
            };
            Controls.Add(lblCountry);

            ComboBox countryComboBox = new ComboBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(130, 220),
                Size = new Size(150, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            countryComboBox.Items.AddRange(Enum.GetNames(typeof(Countries)));
            if (isUpdateMode) countryComboBox.SelectedItem = participant.Address.Country.ToString();
            Controls.Add(countryComboBox);

            Button btnSave = new Button
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Text = "Save",
                Location = new Point(50, 270),
                Size = new Size(100, 30)
            };
            btnSave.Click += (sender, e) => SaveParticipant(txtFirstName, txtLastName, txtStreet, txtCity, txtPostalCode, countryComboBox);
            Controls.Add(btnSave);

            Button btnCancel = new Button
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Text = "Cancel",
                Location = new Point(200, 270),
                Size = new Size(100, 30)
            };
            btnCancel.Click += (sender, e) => this.Close();
            Controls.Add(btnCancel);
        }

        private void SaveParticipant(TextBox txtFirstName, TextBox txtLastName, TextBox txtStreet, TextBox txtCity, TextBox txtPostalCode, ComboBox countryComboBox)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string postalCode = txtPostalCode.Text;
            Countries country = (Countries)Enum.Parse(typeof(Countries), countryComboBox.SelectedItem.ToString());

            Address address = new Address(street, city, postalCode, country);

            if (isUpdateMode)
            {
                participant.FirstName = firstName;
                participant.LastName = lastName;
                participant.Address = address;
                MessageBox.Show("Participant updated successfully.", "Success");
            }
            else
            {
                if (!eventManager.AddParticipant(firstName, lastName, address))
                {
                    MessageBox.Show("Participant already exists or invalid input.", "Error");
                }
                else
                {
                    MessageBox.Show("Participant added successfully.", "Success");
                }
            }
            this.Close();
        }
    }
}
