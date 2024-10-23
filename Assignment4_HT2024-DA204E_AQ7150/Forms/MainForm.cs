// written by Henrik Henriksson(AQ7150)


using Assignment4_HT2024_DA204E_AQ7150.Classes;
using Assignment4_HT2024_DA204E_AQ7150.Forms;

namespace Assignment4_HT2024_DA204E_AQ7150
{
    public partial class MainForm : Form
    {

        private EventManager eventManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            Text = "Event Organizer ";
            Size = new Size(800, 600);

            Panel mainPanel = new()
            {
                Size = new Size(760, 540),
                Location = new Point(20, 20),
                BorderStyle = BorderStyle.FixedSingle

            };
            Controls.Add(mainPanel);

            Label lblMaxGuests = new()
            {
                Text = "Max Guests: ",
                Location = new Point(20, 20),
                AutoSize = true,
            };
            mainPanel.Controls.Add(lblMaxGuests);
            TextBox txtMaxGuest = new()
            {
                Name = "txtMaxGuests",
                Location = new Point(150, 20),
                Size = new Size(100, 20)
            };
            mainPanel.Controls.Add(txtMaxGuest);

            Label lblCostPerGuest = new()
            {

                Text = "Cost per Guest: ",
                Location = new Point(20, 60),
                AutoSize = true

            };
            mainPanel.Controls.Add(lblCostPerGuest);

            TextBox txtCostPerGuest = new()
            {
                Name = "txtCostPerGuest",
                Location = new Point(150, 60),
                Size = new Size(100, 20)
            };
            mainPanel.Controls.Add(txtCostPerGuest);

            Label lblFeePerGuest = new()
            {
                Text = "FeePerGuest",
                Location = new Point(20, 100),
                AutoSize = true
            };
            mainPanel.Controls.Add(lblFeePerGuest);

            TextBox txtFeePerGuest = new()
            {
                Name = "txtFeePerGuest",
                Location = new Point(150, 100),
                Size = new Size(100, 20)
            };
            mainPanel.Controls.Add(txtFeePerGuest);

            Button btnCreateList = new()
            {
                Text = "Create Guest List",
                Location = new Point(20, 140),
                Size = new Size(150, 30)
            };
            btnCreateList.Click += BtnCreateList_Click;
            mainPanel.Controls.Add(btnCreateList);

            Button btnOpenGuestForm = new()
            {
                Text = "Add Guest",
                Location = new Point(20, 190),
                Size = new Size(150, 30)
            };
            btnOpenGuestForm.Click += BtnOpenGuestForm_Click;
            mainPanel.Controls.Add(btnOpenGuestForm);

            ListBox lstGuests = new()
            {
                Name = "lstGuests",
                Location = new Point(400, 20),
                Size = new Size(300, 320)
            };
            mainPanel.Controls.Add(lstGuests);

            Button btnRemoveGuest = new()
            {
                Text = "Remove Guest",
                Location = new Point(400, 360),
                Size = new Size(120, 30)
            };
            btnRemoveGuest.Click += BtnRemoveGuest_Click;
            mainPanel.Controls.Add(btnRemoveGuest);

            Button btnUpdateGuest = new()
            {
                Text = "Update Guest",
                Location = new Point(580, 360),
                Size = new Size(120, 30)
            };
            btnUpdateGuest.Click += BtnUpdateGuest_Click;
            mainPanel.Controls.Add(btnUpdateGuest);

        }

        private void BtnUpdateGuest_Click(object? sender, EventArgs e)
        {
            using(AddGuestForm addGuestForm = new(eventManager)) // use with resources to handle disposable.
            {
                addGuestForm.ShowDialog();
            }
        }

        private void BtnRemoveGuest_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnOpenGuestForm_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnCreateList_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
