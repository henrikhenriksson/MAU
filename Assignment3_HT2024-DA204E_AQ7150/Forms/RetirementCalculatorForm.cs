using Assignment3_HT2024_DA204E_AQ7150.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3_HT2024_DA204E_AQ7150.Forms
{
    public partial class RetirementCalculatorForm : Form
    {

        private TextBox txtInitialBalance;
        private TextBox txtMonthlySaving;
        private TextBox txtAnnualInterestRate;
        private TextBox txtMonthlyFees;
        private ComboBox cmbRetirementAge;
        private Label lblResult;
        private Person person;
        private TextBox txtBirthYear;

        public RetirementCalculatorForm(Person person)
        {
            InitializeComponent();
            this.person = person;
            InitializeRetirementCalculatorGUI();

            // if the user has not yet created a "Person" object in the other calculator:

        }




        private void InitializeRetirementCalculatorGUI()
        {
            Text = "Retirement savings Calculator";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.DarkGray;
            Size = new Size(500,550 );

            Color labelTextColor = Color.White;
            Font commonFont = new("Arial", 10, FontStyle.Regular);

            Panel pnlRetirementCalculator = new()
            {
                Location = new Point(10, 10),
                Size = new Size(460, 460),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.DarkSlateGray
            };
            Controls.Add(pnlRetirementCalculator);

            Label lblInitialBalance = new Label()
            {
                Text = "Initial Balance: ",
                Location = new Point(20, 10),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            pnlRetirementCalculator.Controls.Add(lblInitialBalance);

            txtInitialBalance = new TextBox()
            {
                Name = "txtInitialBalance",
                Location = new Point(250, 10),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180

            };
            pnlRetirementCalculator.Controls.Add(txtInitialBalance);

            Label lblMonthlySaving = new Label()
            {
                Text = "Monthly Savings: ",
                Location = new Point(20, 50),
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 160
            };
            pnlRetirementCalculator.Controls.Add(lblMonthlySaving);

            txtMonthlySaving = new TextBox()
            {
                Name = "txtMonthlySaving",
                Location = new Point(250, 50),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180
            };
            pnlRetirementCalculator.Controls.Add(txtMonthlySaving);

            Label lblAnnualInterestRate = new Label()
            {
                Text = "Annual Interest Rate (%): ",
                Location = new Point(20, 90),
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 160

            };
            pnlRetirementCalculator.Controls.Add(lblAnnualInterestRate);

            txtAnnualInterestRate = new TextBox()
            {
                Name = "txtAnnualInterestRate",
                Location = new Point(250, 90),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180
            };
            pnlRetirementCalculator.Controls.Add(txtAnnualInterestRate);

            Label lblMonthlyFees = new Label()
            {
                Text = "Monthly Fees (%)",
                Location = new Point(20, 130),
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 160

            };
            pnlRetirementCalculator.Controls.Add(lblMonthlyFees);

            txtMonthlyFees = new TextBox()
            {
                Name = "txtMonthlyFees",
                Location = new Point(250, 130),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180

            };
            pnlRetirementCalculator.Controls.Add(txtMonthlyFees);


            // In case the user has not entered personal details in the other calculator and the person object is null,
            // we will prompt them to add their birthyear here.
            Label lblBirthYear = new Label()
            {
                Text = "Your year of birth: ",
                Location = new Point(20, 170),
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 160,

                Visible = false


            };
            pnlRetirementCalculator.Controls.Add(lblBirthYear);


            txtBirthYear = new TextBox()
            {
                Name = "txtBirthYear",
                Location = new Point(250, 170),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180,
                Visible = false

            };
            pnlRetirementCalculator.Controls.Add(txtBirthYear);

            if (person.BirthYear < 1900)
            {
                lblBirthYear.Visible = true;
                txtBirthYear.Visible = true;
            }

            Label lblRetirementAge = new Label()
            {
                Text = "Retirement Age:",
                Location = new Point(20, 210),
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 160

            };
            pnlRetirementCalculator.Controls.Add(lblRetirementAge);

            // Combobox for a reasonable range of retirement ages.
            cmbRetirementAge = new ComboBox()
            {
                Name = "cmbRetirementAge",
                Location = new Point(250, 210),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180
            };


            cmbRetirementAge.Items.AddRange(["62", "63", "64", "65", "66", "67", "68", "69", "70",]);
            cmbRetirementAge.SelectedIndex = 0;
            pnlRetirementCalculator.Controls.Add(cmbRetirementAge);




            Button btnCalculateRetirement = new Button()
            {
                Text = "Calculate Savings",
                Location = new Point(20, 260),
                BackColor = Color.Gray,
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 340
            };
            btnCalculateRetirement.Click += BtnCalculateRetirement_Click;
            pnlRetirementCalculator.Controls.Add(btnCalculateRetirement);

            // presenting the results:
            lblResult = new Label()
            {
                Location = new Point(20, 300),
                Size = new Size(320, 100),
                ForeColor = labelTextColor,
                Font = commonFont,
                AutoSize = false
            };
            pnlRetirementCalculator.Controls.Add(lblResult);


        }

        private void BtnCalculateRetirement_Click(object? sender, EventArgs e)
        {



            try
            {
                if (person.BirthYear < 1900)
                {
                    if (int.TryParse(txtBirthYear.Text, out int birthYear))
                    {
                        // create a new person and set age in case the person object is null.
                        person = new Person()
                        {
                            BirthYear = birthYear,
                        };
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid birth year input. Please enter a valid number between 1 and Current Year.",
                            "Input Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
                if (!double.TryParse(txtInitialBalance.Text, out double initialBalance) || initialBalance < 0 || initialBalance > 1000000)
                {
                    MessageBox.Show("Initial balance must be between 0 and 1,000,000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(txtMonthlySaving.Text, out double monthlySaving) || monthlySaving < 0)
                {
                    MessageBox.Show("Monthly saving must be a non-negative value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(txtAnnualInterestRate.Text, out double annualInterestRate) || annualInterestRate < 0 || annualInterestRate > 100)
                {
                    MessageBox.Show("Annual interest rate must be between 0 and 100.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(txtMonthlyFees.Text, out double monthlyFees) || monthlyFees < 0 || monthlyFees > 100)
                {
                    MessageBox.Show("Monthly fees must be between 0 and 100.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int retirementAge = int.Parse(cmbRetirementAge.SelectedItem.ToString());


                int currentAge = person.GetAge();

                int periodInYears = retirementAge - currentAge;

                if (periodInYears <= 0)
                {
                    MessageBox.Show(
                        "Retirement age must be greater than your current age.",
                        "Input Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);


                }

                RetirementCalculator retirementCalculator = new
                    (
                    person,
                    initialBalance,
                    monthlySaving,
                    annualInterestRate,
                    monthlyFees,
                    retirementAge
                    );

                if (retirementCalculator.Calculate(person, retirementAge))
                {
                    lblResult.Text = $"Final Balance: {retirementCalculator.Balance:C}\n" +
                        $"Total Interest Earned: {retirementCalculator.TotalInterestEarned:C}\n" +
                        $"Total Fees Paid: {retirementCalculator.TotalFees:C}\n";

                }
            }
            catch (ArgumentException argumentException) 
            {
                MessageBox.Show($"Validation Error: {argumentException.Message}","Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception ex) // Suspenders and belt as we say in swedish
            {
                MessageBox.Show($"an error has occured: {ex.Message}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


        }
    }
}
