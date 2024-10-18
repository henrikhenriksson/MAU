﻿using Assignment3_HT2024_DA204E_AQ7150.Classes;
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
            Size = new Size(400, 500);

            Color labelTextColor = Color.White;
            Font commonFont = new("Arial", 10, FontStyle.Regular);

            Panel pnlRetirementCalculator = new()
            {
                Location = new Point(10, 10),
                Size = new Size(380, 450),
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
                Location = new Point(180, 20),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180

            };


            Label lblMonthlySaving = new Label()
            {
                Text = "Monthly Savings: ",
                Location = new Point(20, 60),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            pnlRetirementCalculator.Controls.Add(lblMonthlySaving);

            txtMonthlySaving = new TextBox()
            {
                Name = "txtMonthlySaving",
                Location = new Point(180, 60),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180
            };
            pnlRetirementCalculator.Controls.Add(txtMonthlySaving);

            Label lblAnnualInterestRate = new Label()
            {
                Text = "Annual Interest Rate (%): ",
                Location = new Point(20, 100),
                ForeColor = labelTextColor,
                Font = commonFont,
            };
            pnlRetirementCalculator.Controls.Add(lblAnnualInterestRate);

            txtAnnualInterestRate = new TextBox()
            {
                Name = "txtAnnualInterestRate",
                Location = new Point(180, 100),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180
            };
            pnlRetirementCalculator.Controls.Add(txtAnnualInterestRate);

            Label lblMonthlyFees = new Label()
            {
                Text = "Monthly Fees (%)",
                Location = new Point(20, 140),
                BackColor = labelTextColor,
                ForeColor = labelTextColor,
                Font = commonFont
            };
            pnlRetirementCalculator.Controls.Add(lblMonthlyFees);

            txtMonthlyFees = new TextBox()
            {
                Name = "txtMonthlyFees",
                Location = new Point(180, 140),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180

            };
            pnlRetirementCalculator.Controls.Add(txtMonthlyFees);


            // Combobox for a reasonable range of retirement ages.
            cmbRetirementAge = new ComboBox()
            {
                Name = "cmbRetirementAge",
                Location = new Point(180, 180),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180
            };


            cmbRetirementAge.Items.AddRange(["62", "63", "64", "65", "66", "67", "68", "69", "70",]);
            cmbRetirementAge.SelectedIndex = 0;
            pnlRetirementCalculator.Controls.Add(cmbRetirementAge);
                    
            
            // In case the user has not entered personal details in the other calculator and the person object is null,
            // we will prompt them to add their birthyear here.
            Label lblBirthYear = new Label()
            {
                Text = "Your year of birth: ",
                Location = new Point(20, 140),
                BackColor = labelTextColor,
                ForeColor = labelTextColor,
                Font = commonFont,
                Visible= false


            };
            pnlRetirementCalculator.Controls.Add(lblBirthYear);


            txtBirthYear = new TextBox()
            {
                Name = "txtBirthYear",
                Location = new Point(180, 140),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 180,
                Visible = false

            };
            pnlRetirementCalculator.Controls.Add(txtBirthYear);

            if (person == null) {
                lblBirthYear.Visible = true;
                txtBirthYear.Visible = true;
            }


            // presenting the results:
            lblResult = new Label()
            {
                Location = new Point(20, 280),
                Size = new Size(340, 150),
                ForeColor = labelTextColor,
                Font = commonFont,
                AutoSize = false
            };
            pnlRetirementCalculator.Controls.Add(txtBirthYear);

            

            Button btnCalculateRetirement = new Button()
            {
                Text = "Calculate Savings",
                Location = new Point(20, 230),
                BackColor = Color.Gray,
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 340
            };
            btnCalculateRetirement.Click += BtnCalculateRetirement_Click;
            pnlRetirementCalculator.Controls.Add(btnCalculateRetirement);


        }

        private void BtnCalculateRetirement_Click(object? sender, EventArgs e)
        {
            double initialBalance = double.Parse(txtInitialBalance.Text);
            double monthlySaving = double.Parse(txtMonthlySaving.Text);
            double annualInterestRate = double.Parse(txtAnnualInterestRate.Text);
            double monthylFees = double.Parse(txtMonthlyFees.Text);
            int retirementAge = int.Parse(cmbRetirementAge!.SelectedItem.ToString());



        }
    }
}
