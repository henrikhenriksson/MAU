

// Written by : Henrik Henriksson(AQ7150)
// Ignore Spelling: AQ

using Assignment3_HT2024_DA204E_AQ7150.Classes;
using Assignment3_HT2024_DA204E_AQ7150.Enums;
using Assignment3_HT2024_DA204E_AQ7150.Forms;
using System.Drawing;

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
            Text = "Calculator Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.DarkGray;
            Size = new Size(400, 300);

            Color labelTextColor = Color.White;
            Font commonFont = new("Arial", 10, FontStyle.Regular);

            Label lblInstruction = new Label()
            {
                Text = "Please select a calculator to launch:",
                Location = new Point(50, 20),
                Size = new Size(300, 20),
                ForeColor = labelTextColor,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(lblInstruction);



            Button btnWaterIntakeCalculator = new Button()
            {
                Text = "Water Intake Calculator",
                Location = new Point(50, 60),
                Size = new Size(300, 50),
                BackColor = Color.Gray,
                ForeColor = labelTextColor,
                Font = commonFont
                
            };
            btnWaterIntakeCalculator.Click += BtnWaterIntakeCalculator_Click;
            Controls.Add(btnWaterIntakeCalculator);

            Button btnRetirementCalculator = new Button()
            {
                Text = "Retirement Calculator",
                Location = new Point(50, 140),
                Size = new Size(300, 50),
                BackColor = Color.Gray,
                ForeColor = labelTextColor,
                Font = commonFont

            };
            btnRetirementCalculator.Click += BtnRetirementCalculator_Click;
            Controls.Add(btnRetirementCalculator);


        }

       

        private void BtnWaterIntakeCalculator_Click(object? sender, EventArgs e)
        {
           WaterIntakeCalculatorForm waterIntakeCalculatorForm = new WaterIntakeCalculatorForm();
            waterIntakeCalculatorForm.ShowDialog();
        }

        private void BtnRetirementCalculator_Click(object sender, EventArgs e)
        {
            RetirementCalculatorForm retirementForm = new RetirementCalculatorForm();
            retirementForm.ShowDialog();
        }
    }
}
