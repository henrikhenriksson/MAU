

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
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            BackColor = Color.DarkGray;


            Color labelTextColor = Color.White;
            Font commonFont = new("Arial", 10, FontStyle.Regular);

            GroupBox grpUnits = new GroupBox()
            {
                Text = "Select Units",
                Location = new Point(20, 20),
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
            // add the
            // 
            Controls.Add(grpUnits);

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
                Font = commonFont
            };
            Controls.Add(lblHeight);
            Controls.Add(txtHeight);


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
                Location = new Point(20, 140),
                BackColor = Color.LightGray,
                Font = commonFont
            };
            Controls.Add(lblWeight);
            Controls.Add(txtWeight);


            ComboBox cmbGender = new ComboBox()
            {
                Name = "cmbGender",
                Location = new Point(120, 180),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont
            };
            cmbGender.Items.AddRange(Enum.GetNames(typeof(GenderEnum)));
            Controls.Add(cmbGender);


            ComboBox cmbActivityLevel = new ComboBox()
            {
                Name = "cmbActivityLevel",
                Location = new Point(120, 120),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont
            };
            cmbActivityLevel.Items.AddRange(Enum.GetNames(typeof(ActivityLevel)));
            Controls.Add(cmbActivityLevel);

            Button btnCalculate = new Button()
            {
                Text = "Calculate Water Intake",
                Location = new Point(20, 260),
                BackColor = Color.Gray,
                ForeColor = labelTextColor,
                Font = commonFont
            };
            btnCalculate.Click += btnCalculate_Click;
            Controls.Add(btnCalculate);

            Label lblResult = new Label()
            {
                Name = "lblResult",
                Text = "Daily Water Intake",
                Location= new Point(20,300),
                AutoSize = true,
                ForeColor= labelTextColor,
                Font = commonFont
            };
            this.Controls.Add(lblResult);

        }

        private void btnCalculate_Click(object? sender, EventArgs e)
        {


        }
    }
}
