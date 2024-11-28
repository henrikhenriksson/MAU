// written by Henrik Henriksson(AQ7150)


using Assignment4_HT2024_DA204E_AQ7150.Classes;
using Assignment4_HT2024_DA204E_AQ7150.Forms;

namespace Assignment4_HT2024_DA204E_AQ7150
{
    public partial class MainForm : Form
    {

        private EventManager eventManager;

        // Made these into class fields as they are accessed across different methods.
        private ListBox lstGuests;
        private TextBox txtTotalCost;
        private TextBox txtTotalRevenue;
        private TextBox txtSurplusOrDeficit;
        private TextBox txtMaxGuest;
        private TextBox txtCostPerGuest;
        private TextBox txtFeePerGuest;

        private Font commonFont = new Font("Arial", 10, FontStyle.Regular);
        private Color commonBackColor = Color.DarkGray;
        private Color commonForeColor = Color.Black;
        private Button btnRemoveGuest;
        private Button btnUpdateGuest;
        private Button btnOpenGuestForm;
        private Button btnCalculateFinancials;

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            ForeColor = commonForeColor;
            Text = "Event Organizer ";
            Size = new Size(800, 600);

            Panel mainPanel = new()
            {
                Size = new Size(760, 540),
                Location = new Point((this.ClientSize.Width - 760) / 2, (this.ClientSize.Height - 540) / 2), // Center the panel
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.DarkSlateGray

            };
            Controls.Add(mainPanel);

            Label lblMaxGuests = new()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "Max Guests: ",
                Location = new Point(20, 20),
                AutoSize = true,
            };
            mainPanel.Controls.Add(lblMaxGuests);
            txtMaxGuest = new()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Name = "txtMaxGuests",
                Location = new Point(150, 20),
                Size = new Size(100, 20)
            };
            mainPanel.Controls.Add(txtMaxGuest);

            Label lblCostPerGuest = new()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "Cost per Guest: ",
                Location = new Point(20, 60),
                AutoSize = true

            };
            mainPanel.Controls.Add(lblCostPerGuest);

            txtCostPerGuest = new()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Name = "txtCostPerGuest",
                Location = new Point(150, 60),
                Size = new Size(100, 20)
            };
            mainPanel.Controls.Add(txtCostPerGuest);

            Label lblFeePerGuest = new()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "FeePerGuest",
                Location = new Point(20, 100),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblFeePerGuest);

            txtFeePerGuest = new()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Name = "txtFeePerGuest",
                Location = new Point(150, 100),
                Size = new Size(100, 20)
            };
            mainPanel.Controls.Add(txtFeePerGuest);

            Button btnCreateList = new()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                BackColor = commonBackColor,
                Text = "Create Guest List",
                Location = new Point(20, 140),
                Size = new Size(150, 30)
            };
            btnCreateList.Click += BtnCreateList_Click;
            mainPanel.Controls.Add(btnCreateList);

            btnOpenGuestForm = new()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                BackColor = commonBackColor,
                Text = "Add Guest",
                Location = new Point(20, 190),
                Size = new Size(150, 30),
                Enabled = false
            };
            btnOpenGuestForm.Click += BtnOpenGuestForm_Click;
            mainPanel.Controls.Add(btnOpenGuestForm);
          
            btnRemoveGuest = new()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                BackColor = commonBackColor,
                Text = "Remove Guest",
                Location = new Point(400, 360),
                Size = new Size(120, 30),
                Enabled = false
            };
            btnRemoveGuest.Click += BtnRemoveGuest_Click;
            mainPanel.Controls.Add(btnRemoveGuest);

            btnUpdateGuest = new()
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                BackColor = commonBackColor,
                Text = "Update Guest",
                Location = new Point(580, 360),
                Size = new Size(120, 30),
                Enabled = false

            };
            btnUpdateGuest.Click += BtnUpdateGuest_Click;
            mainPanel.Controls.Add(btnUpdateGuest);

            Label lblTotalCost = new Label
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "Total Cost:",
                Location = new System.Drawing.Point(20, 250),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblTotalCost);

            txtTotalCost = new TextBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Name = "txtTotalCost",
                Location = new System.Drawing.Point(150, 250),
                Size = new System.Drawing.Size(100, 20),
                ReadOnly = true
            };
            mainPanel.Controls.Add(txtTotalCost);

            Label lblTotalRevenue = new Label
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "Total Revenue:",
                Location = new System.Drawing.Point(20, 290),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblTotalRevenue);

            txtTotalRevenue = new TextBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Name = "txtTotalRevenue",
                Location = new System.Drawing.Point(150, 290),
                Size = new System.Drawing.Size(100, 20),
                ReadOnly = true
            };
            mainPanel.Controls.Add(txtTotalRevenue);

            Label lblSurplusOrDeficit = new Label
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                Text = "Surplus/Deficit:",
                Location = new System.Drawing.Point(20, 330),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblSurplusOrDeficit);

            txtSurplusOrDeficit = new TextBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Name = "txtSurplusOrDeficit",
                Location = new System.Drawing.Point(150, 330),
                Size = new System.Drawing.Size(100, 20),
                ReadOnly = true
            };
            mainPanel.Controls.Add(txtSurplusOrDeficit);

            btnCalculateFinancials = new Button
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                BackColor = commonBackColor,
                Text = "Calculate Financials",
                Location = new System.Drawing.Point(20, 370),
                Size = new System.Drawing.Size(150, 30),
                Enabled = false

            };
            btnCalculateFinancials.Click += new EventHandler(this.btnCalculateFinancials_Click);
            mainPanel.Controls.Add(btnCalculateFinancials);

            lstGuests = new ListBox
            {
                Font = commonFont,
                ForeColor = commonForeColor,
                BackColor = commonBackColor,
                Name = "lstGuests",
                Location = new System.Drawing.Point(400, 20),
                Size = new System.Drawing.Size(300, 320)
            };
            mainPanel.Controls.Add(lstGuests);



        }

        private void UpdateGuestList()
        {
            if (eventManager != null && lstGuests != null)
            {
                lstGuests.Items.Clear();
                foreach (string guest in eventManager.GetParticipantList())
                {
                    if (!string.IsNullOrEmpty(guest))
                    {
                        lstGuests.Items.Add(guest);
                    }
                }
            }
        }

        private void UpdateFinancials()
        {
            if (eventManager != null)
            {
                txtTotalCost.Text = eventManager.GetTotalCost().ToString("C");
                txtTotalRevenue.Text = eventManager.GetTotalRevenue().ToString("C");
                txtSurplusOrDeficit.Text = eventManager.GetSurplusOrDeficit().ToString("C");
            }


        }

        private void btnCalculateFinancials_Click(object? sender, EventArgs e)
        {
            UpdateFinancials();
        }

        private void BtnUpdateGuest_Click(object? sender, EventArgs e)
        {
            try
            {

                if (lstGuests != null && lstGuests.SelectedIndex >= 0)
                {
                    using AddOrUpdateGuestForm updateGuestForm = new AddOrUpdateGuestForm(eventManager, lstGuests.SelectedIndex);

                    updateGuestForm.ShowDialog();
                    UpdateGuestList();
                }
                else
                {
                    MessageBox.Show("Please selct a guest to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must have at least one guest before updating", "No guest to update", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void BtnRemoveGuest_Click(object? sender, EventArgs e)
        {


            if (lstGuests != null && lstGuests.SelectedIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove this guest?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (eventManager.RemoveParticipant(lstGuests.SelectedIndex))
                    {
                        MessageBox.Show("Guest removed Succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateGuestList();

                    }
                    else
                    {
                        MessageBox.Show("Unable to remove the selected guest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select a guest to remove.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void BtnOpenGuestForm_Click(object? sender, EventArgs e)
        {
            using AddOrUpdateGuestForm addGuestForm = new(eventManager); // use with resources to handle disposable.
            addGuestForm.ShowDialog();
            UpdateGuestList();

        }

        private void BtnCreateList_Click(object? sender, EventArgs e)
        {



            // get inputs
            // Parse 
            if (!int.TryParse(txtMaxGuest.Text, out int maxGuest) || maxGuest <= 0)
            {
                MessageBox.Show("Enter a valid positive number for max amount of guests", "No Guests Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!decimal.TryParse(txtCostPerGuest.Text, out decimal costPerGuest) || costPerGuest < 0)
            {
                MessageBox.Show("Please enter a valid number value for cost per guest.", "Guest Cost Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtFeePerGuest.Text, out decimal feePerGuest) || feePerGuest < 0)
            {
                MessageBox.Show("Please enter a valid positive value for fee per guest.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // generate class object
            eventManager = new(maxGuest)
            {
                CostPerPerson = costPerGuest,
                FeePerPerson = feePerGuest
            };

            MessageBox.Show("Guest list created successfully! You can now add, update, or remove guests.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // update and enable buttons for manipulation.


            if (eventManager.GetParticipantList().Length > 0) { UpdateFinancials(); }

            btnUpdateGuest.Enabled = true;
            btnRemoveGuest.Enabled = true;
            btnOpenGuestForm.Enabled = true;
            btnCalculateFinancials.Enabled = true;

        }
    }
}
