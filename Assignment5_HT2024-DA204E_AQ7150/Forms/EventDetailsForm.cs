// written by Henrik Henriksson(AQ7150)


using Assignment5_HT2024_DA204E_AQ7150.Classes;
using Assignment5_HT2024_DA204E_AQ7150.Forms;

namespace Assignment5_HT2024_DA204E_AQ7150
{
    public partial class EventDetailsForm : Form
    {

        private EventManager eventManager;


        private Font commonFont = new Font("Arial", 10, FontStyle.Regular);
        private Color commonBackColor = Color.DarkGray;
        private Color commonForeColor = Color.Black;

        private Button btnAddUpdateGuest;
        private Button btnUpdateGuest;
        private ListBox lstGuests;
        private Button btnRemoveGuest;
        private Button btnCalculateFinancials;
        private TextBox txtTotalCost;
        private TextBox txtTotalRevenue;
        private TextBox txtSurplusOrDeficit;


        public EventDetailsForm(EventManager eventmanager)
        {
            InitializeComponent();
            eventManager = eventmanager;
            InitializeGUI();

        }

        private void InitializeGUI()
        {
            ForeColor = commonForeColor;
            Text = "Event Organizer";
            Size = new Size(900, 700);

            Panel mainPanel = new()
            {
                Size = new Size(860, 650),
                Location = new Point((this.ClientSize.Width - 860) / 2, (this.ClientSize.Height - 650) / 2),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.DarkSlateGray
            };
            Controls.Add(mainPanel);

            // Guest List Management Section
            lstGuests = new ListBox()
            {
                Font = commonFont,
                BackColor = Color.White,
                ForeColor = commonForeColor,
                Location = new Point(20, 20),
                Size = new Size(400, 200)
            };
            mainPanel.Controls.Add(lstGuests);

            btnAddUpdateGuest = new Button()
            {
                Text = "Add/Update Guest",
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(20, 230),
                Size = new Size(150, 30)
            };
            btnAddUpdateGuest.Click += btnAddGuest;
            mainPanel.Controls.Add(btnAddUpdateGuest);

            btnUpdateGuest = new Button()
            {
                Text = "Update Guest",
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(200, 230),
                Size = new Size(150, 30)
            };
            btnUpdateGuest.Click += BtnUpdateGuest_Click;
            mainPanel.Controls.Add(btnUpdateGuest);

            btnRemoveGuest = new Button()
            {
                Text = "Remove Guest",
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(20, 270),
                Size = new Size(150, 30)
            };
            btnRemoveGuest.Click += BtnRemoveGuest_Click;
            mainPanel.Controls.Add(btnRemoveGuest);

            // Cost Calculation Section (on the right side)
            btnCalculateFinancials = new Button()
            {
                Text = "Calculate Financials",
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(460, 20),
                Size = new Size(150, 30)
            };
            btnCalculateFinancials.Click += (sender, e) => UpdateFinancials();
            mainPanel.Controls.Add(btnCalculateFinancials);

            Label lblTotalCost = new Label()
            {
                Text = "Total Cost:",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(460, 70),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblTotalCost);

            txtTotalCost = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(580, 70),
                Size = new Size(100, 20),
                ReadOnly = true
            };
            mainPanel.Controls.Add(txtTotalCost);

            Label lblTotalRevenue = new Label()
            {
                Text = "Total Revenue:",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(460, 110),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblTotalRevenue);

            txtTotalRevenue = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(580, 110),
                Size = new Size(100, 20),
                ReadOnly = true
            };
            mainPanel.Controls.Add(txtTotalRevenue);

            Label lblSurplusOrDeficit = new Label()
            {
                Text = "Surplus/Deficit:",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(460, 150),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblSurplusOrDeficit);

            txtSurplusOrDeficit = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(580, 150),
                Size = new Size(100, 20),
                ReadOnly = true
            };
            mainPanel.Controls.Add(txtSurplusOrDeficit);

            // Settings Section (below the two main sections)

        }




        private void btnAddGuest(object sender, EventArgs e)
        {
            using (AddOrUpdateGuestForm addOrUpdateGuestForm = new AddOrUpdateGuestForm(eventManager, null))
            {
                addOrUpdateGuestForm.ShowDialog();
                UpdateGuestList();
            }
        }

        private void UpdateGuestList()
        {

            if (eventManager.GetParticipantList != null)
            {

                if (eventManager.GetParticipantList().Length > 0) { UpdateFinancials(); }

                btnUpdateGuest.Enabled = true;
                btnRemoveGuest.Enabled = true;

                btnCalculateFinancials.Enabled = true;

                lstGuests.Items.Clear();
                string[] participants = eventManager.GetParticipantList();
                lstGuests.Items.AddRange(participants);

            }
        }

        private void UpdateFinancials()
        {
            if (eventManager != null)
            {
                txtTotalCost.Text = eventManager.GetTotalCost().ToString("C");
                txtTotalRevenue.Text = eventManager.GetTotalRevenue().ToString("C");
                txtSurplusOrDeficit.Text = eventManager.GetSurplusOrDeficit().ToString("F2");


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
                    using AddOrUpdateGuestForm updateGuestForm = new AddOrUpdateGuestForm(eventManager, eventManager.GetParticipantAt(lstGuests.SelectedIndex));

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


            if (lstGuests.SelectedIndex >= 0)
            {

                eventManager.RemoveParticipant(lstGuests.SelectedIndex);
                UpdateGuestList();
            }
        }

    }
}
