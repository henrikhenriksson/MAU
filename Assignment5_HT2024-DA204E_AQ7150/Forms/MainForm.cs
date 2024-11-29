// written by Henrik Henriksson(AQ7150)

using Assignment5_HT2024_DA204E_AQ7150.Classes;

namespace Assignment5_HT2024_DA204E_AQ7150.Forms
{
    public partial class MainForm : Form
    {
        private EventManager eventManager;


        // i hope these fields are OK as it's very handy to have the controls accessible directly in click methods
        private TextBox txtCostPerGuest;
        private TextBox txtFeePerGuest;
        private TextBox txtEventTitle;


        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();

        }

        private void InitializeGUI()
        {
            Font commonFont = new("Arial", 10, FontStyle.Regular);
            Color commonBackColor = Color.DarkGray;
            Color commonForeColor = Color.Black;

            ForeColor = commonForeColor;
            Text = "Event Organizer";
            Size = new Size(400, 350);

            Panel mainPanel = new()
            {
                Size = new Size(380, 260),
                Location = new Point((this.ClientSize.Width - 380) / 2, (this.ClientSize.Height - 310) / 2),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.DarkSlateGray
            };
            Controls.Add(mainPanel);


            Label lblEventTitle = new Label()
            {
                Text = "Event Title:",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(20, 20),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblEventTitle);

            txtEventTitle = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(150, 20),
                Size = new Size(150, 25)
            };
            mainPanel.Controls.Add(txtEventTitle);

            Label lblCostPerGuest = new()
            {
                Text = "Cost per Guest:",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(20, 60),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblCostPerGuest);

             txtCostPerGuest = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(150, 60),
                Size = new Size(150, 25) 
            };
            mainPanel.Controls.Add(txtCostPerGuest);

            Label lblFeePerGuest = new()
            {
                Text = "Fee per Guest:",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(20, 100),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblFeePerGuest);

             txtFeePerGuest = new TextBox()
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(150, 100), 
                Size = new Size(150, 25) 
            };
            mainPanel.Controls.Add(txtFeePerGuest);


            Button btnOpenEventOrganizer = new Button()
            {
                Text = "Open Event Organizer",
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(20, 140),
                Size = new Size(300, 30)
            };
            btnOpenEventOrganizer.Click += BtnOpenEventOrganizer_Click;
            mainPanel.Controls.Add(btnOpenEventOrganizer);
        }

        private void BtnOpenEventOrganizer_Click(object? sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtEventTitle.Text))
            {
                MessageBox.Show("Please enter a valid title for the event.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (decimal.TryParse(txtCostPerGuest.Text, out decimal costPerGuest) && costPerGuest > 0 &&
                decimal.TryParse(txtFeePerGuest.Text, out decimal feePerGuest) && feePerGuest > 0)
            {
               eventManager = new EventManager(costPerGuest, feePerGuest);
                string title = txtEventTitle.Text;
                OpenEventManagerForm(title);
            }
            else
            {
                MessageBox.Show("Please enter valid values for both Cost per Guest and Fee per Guest.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenEventManagerForm(string title)
        {
            EventDetailsForm eventDetailsForm = new(eventManager,title);

            eventDetailsForm.ShowDialog();
        }
    }
}