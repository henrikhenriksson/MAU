

// Written by : Henrik Henriksson(AQ7150)
// Ignore Spelling: AQ

using Assignment3_HT2024_DA204E_AQ7150.Classes;
using Assignment3_HT2024_DA204E_AQ7150.Enums;

namespace Assignment3_HT2024_DA204E_AQ7150
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            Text = "Water Intake Calculator";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.DarkGray;
            Size = new Size(420, 500);


            Color labelTextColor = Color.White;
            Font commonFont = new("Arial", 10, FontStyle.Regular);

            // Panel for the calculator:
            Panel pnlWaterIntakeCalculator = new Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(380, 400),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.DarkSlateGray

            };
            Controls.Add(pnlWaterIntakeCalculator);

            GroupBox grpUnits = new GroupBox()
            {
                Text = "Select Units",
                Location = new Point(10, 10),
                Size = new Size(350, 70),
                ForeColor = labelTextColor,
                Font = commonFont,
                BackColor = Color.DarkSlateGray
            };

            RadioButton rdoMetric = new RadioButton()
            {
                Name = "rdoMetric",
                Text = "Metric (cm,kg,ml)",
                Location = new Point(10, 25),
                Checked = true, // metric shall be the default.
                ForeColor = labelTextColor,
                Font = commonFont
            };


            RadioButton rdoImperial = new RadioButton()
            {
                Name = "rdoImperial",
                Text = "Imperial (ft.in / lbs. oz)",
                Location = new Point(180, 25),
                ForeColor = labelTextColor,
                Font = commonFont
            };

            // add them to the control
            grpUnits.Controls.Add(rdoMetric);
            grpUnits.Controls.Add(rdoImperial);
            // add the grpbox to panel
            // 
            pnlWaterIntakeCalculator.Controls.Add(grpUnits);

            Label lblName = new Label()
            {
                Text = "Name: ",
                Location = new Point(20, 90),
                ForeColor = labelTextColor,
                Font = commonFont
            };

            // TODO: Add and show ft&in if imperial is checked.

            TextBox txtName = new TextBox()
            {
                Name = "txtName",
                Location = new Point(120, 90),
                BackColor = labelTextColor,
                Font = commonFont,
                Width = 200

            };

            Label lblHeight = new Label()
            {
                Text = "Height:",
                Location = new System.Drawing.Point(20, 100),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            TextBox txtHeight = new TextBox()
            {
                Name = "TxtHeight",
                Location = new Point(120, 100),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };
            pnlWaterIntakeCalculator.Controls.Add(lblHeight);
            pnlWaterIntakeCalculator.Controls.Add(txtHeight);


            Label lblWeight = new Label()
            {
                Text = "Weight",
                Location = new Point(20, 140),
                ForeColor = labelTextColor,
                Font = commonFont
            };

            TextBox txtWeight = new TextBox()
            {
                Name = "txtWeight",
                Location = new Point(120, 140),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };
            pnlWaterIntakeCalculator.Controls.Add(lblWeight);
            pnlWaterIntakeCalculator.Controls.Add(txtWeight);

            Label lblGender = new Label()
            {
                Text = "Gender:",
                Location = new Point(20, 180),
                ForeColor = Color.LightGray,
                Font = commonFont
            };

            ComboBox cmbGender = new ComboBox()
            {
                Name = "cmbGender",
                Location = new Point(120, 180),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };
            cmbGender.Items.AddRange(Enum.GetNames(typeof(GenderEnum)));
            pnlWaterIntakeCalculator.Controls.Add(lblGender);
            pnlWaterIntakeCalculator.Controls.Add(cmbGender);

            Label lblActitivyLevel = new Label()
            {
                Text = "Activity Level:",
                Location = new Point(20, 220),
                ForeColor = Color.LightGray,
                Font = commonFont
            };


            ComboBox cmbActivityLevel = new ComboBox()
            {
                Name = "cmbActivityLevel",
                Location = new Point(120, 220),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };

            cmbActivityLevel.Items.AddRange(Enum.GetNames(typeof(ActivityLevel)));
            pnlWaterIntakeCalculator.Controls.Add(lblActitivyLevel);
            pnlWaterIntakeCalculator.Controls.Add(cmbActivityLevel);

            Button btnCalculate = new Button()
            {
                Text = "Calculate Water Intake",
                Location = new Point(20, 260),
                BackColor = Color.Gray,
                ForeColor = labelTextColor,
                Font = commonFont,
                Width= 300
            };
            btnCalculate.Click += btnCalculate_Click;
            pnlWaterIntakeCalculator.Controls.Add(btnCalculate);

            Label lblResult = new Label()
            {
                Name = "lblResult",
                Text = "Daily Water Intake",
                Location = new Point(20, 300),
                AutoSize = true,
                ForeColor = labelTextColor,
                Font = commonFont
                
            };
            this.Controls.Add(lblResult);

        }

        private void btnCalculate_Click(object? sender, EventArgs e)
        {
            // get metric or imperial

            // get values for height/weight

            // check conversion or not


            // get gender

            // get actiivity

            // create person



        }
    }
}
