// Written by: Henrik Henriksson(7150)
// Ignore Spelling: AQ

using Assignment3_HT2024_DA204E_AQ7150.Classes;
using Assignment3_HT2024_DA204E_AQ7150.Enums;
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
    public partial class WaterIntakeCalculatorForm : Form
    {

        private TextBox txtName;
        private TextBox txtFeet;
        private TextBox txtInches;
        private TextBox txtHeight;
        private TextBox txtWeight;
        private TextBox txtBirthYear;
        private Label lblWaterResult;
        private string personName;
        private RadioButton rdoMetric;
        private RadioButton rdoImperial;
        private Panel pnlWaterIntakeCalculator;
        private double dailyWaterIntake;
        private Person person;

        public WaterIntakeCalculatorForm(Person person)
        {
            InitializeComponent();
            this.person = person;
            InitializeWaterIntakeGUI();
        }

        private void InitializeWaterIntakeGUI()
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
            pnlWaterIntakeCalculator = new()
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
            pnlWaterIntakeCalculator.Controls.Add(grpUnits);

            rdoMetric = new RadioButton()
            {
                Name = "rdoMetric",
                Text = "Metric (cm,kg,ml)",
                Location = new Point(10, 25),
                Checked = true, // metric shall be the default.
                ForeColor = labelTextColor,
                Font = commonFont
            };
            grpUnits.Controls.Add(rdoMetric);
            rdoMetric.CheckedChanged += (s, e) => ToggleHeightInputs();

            rdoImperial = new RadioButton()
            {
                Name = "rdoImperial",
                Text = "Imperial (ft.in / lbs. oz)",
                Location = new Point(180, 25),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            grpUnits.Controls.Add(rdoImperial);
            // event handlers to toggle input fields and update the values in the txtboxes.

            Label lblName = new Label()
            {
                Text = "Name: ",
                Location = new Point(20, 90),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            pnlWaterIntakeCalculator.Controls.Add(lblName);

            txtName = new TextBox()
            {
                Name = "txtName",
                Location = new Point(120, 90),
                BackColor = labelTextColor,
                Font = commonFont,
                Width = 200

            };
            pnlWaterIntakeCalculator.Controls.Add(txtName);


            Label lblHeight = new Label()
            {
                Text = "Height:",
                Location = new System.Drawing.Point(20, 130),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            pnlWaterIntakeCalculator.Controls.Add(lblHeight);

            txtHeight = new TextBox()
            {
                Name = "TxtHeight",
                Location = new Point(120, 130),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };
            pnlWaterIntakeCalculator.Controls.Add(txtHeight);

            txtFeet = new TextBox()
            {
                Name = "TxtFeet",
                Location = new Point(120, 130),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 90,
                Visible = false
            };
            pnlWaterIntakeCalculator.Controls.Add(txtFeet);

            txtInches = new TextBox()
            {
                Name = "TxtInches",
                Location = new Point(230, 130),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 90,
                Visible = false
            };
            pnlWaterIntakeCalculator.Controls.Add(txtInches);

            Label lblWeight = new Label()
            {
                Text = "Weight",
                Location = new Point(20, 170),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            pnlWaterIntakeCalculator.Controls.Add(lblWeight);

            txtWeight = new TextBox()
            {
                Name = "txtWeight",
                Location = new Point(120, 170),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };
            pnlWaterIntakeCalculator.Controls.Add(txtWeight);

            Label lblGender = new Label()
            {
                Text = "Gender:",
                Location = new Point(20, 210),
                ForeColor = Color.LightGray,
                Font = commonFont
            };
            pnlWaterIntakeCalculator.Controls.Add(lblGender);

            ComboBox cmbGender = new ComboBox()
            {
                Name = "cmbGender",
                Location = new Point(120, 210),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };
            cmbGender.Items.AddRange(Enum.GetNames(typeof(Gender)));
            pnlWaterIntakeCalculator.Controls.Add(cmbGender);

            Label lblActitivyLevel = new Label()
            {
                Text = "Activity Level:",
                Location = new Point(20, 250),
                ForeColor = Color.LightGray,
                Font = commonFont
            };
            pnlWaterIntakeCalculator.Controls.Add(lblActitivyLevel);


            ComboBox cmbActivityLevel = new ComboBox()
            {
                Name = "cmbActivityLevel",
                Location = new Point(120, 250),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };

            cmbActivityLevel.Items.AddRange(Enum.GetNames(typeof(ActivityLevel)));
            pnlWaterIntakeCalculator.Controls.Add(cmbActivityLevel);

            Label lblBirthYear = new()
            {
                Text = "Birth Year:",
                Location = new System.Drawing.Point(20, 290),
                ForeColor = labelTextColor,
                Font = commonFont
            };
            pnlWaterIntakeCalculator.Controls.Add(lblBirthYear);

            // TextBox for Birth Year input
            txtBirthYear = new TextBox()
            {
                Name = "txtBirthYear",
                Location = new System.Drawing.Point(120, 290),
                BackColor = Color.LightGray,
                Font = commonFont,
                Width = 200
            };
            pnlWaterIntakeCalculator.Controls.Add(txtBirthYear);


            Button btnCalculate = new Button()
            {
                Text = "Calculate Water Intake",
                Location = new Point(20, 330),
                BackColor = Color.Gray,
                ForeColor = labelTextColor,
                Font = commonFont,
                Width = 200
            };
            btnCalculate.Click += btnCalculate_Click;
            pnlWaterIntakeCalculator.Controls.Add(btnCalculate);

            lblWaterResult = new Label()
            {
                Name = "lblWaterResult",
                Text = $"Daily Water Intake: ",
                Location = new Point(20, 370),
                AutoSize = true,
                ForeColor = labelTextColor,
                Font = commonFont

            };
            pnlWaterIntakeCalculator.Controls.Add(lblWaterResult);

        }

        private void UpdateConversion()
        {

            lblWaterResult = (Label)pnlWaterIntakeCalculator.Controls["lblWaterResult"];

            if (rdoMetric.Checked)
            {
                // convert ft&in to cm and update inputfield.
                if (!string.IsNullOrWhiteSpace(txtFeet.Text)
                    && !string.IsNullOrWhiteSpace(txtInches.Text))
                {
                    double cm = Conversions.InchesToCm((int.Parse(txtFeet.Text) * 12) + double.Parse(txtInches.Text));
                    txtHeight.Text = cm.ToString("N2");
                    lblWaterResult.Text = $"Daily Water Intake for {personName}: {dailyWaterIntake:N2} ml";
                }


            }
            else if (rdoImperial.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtHeight.Text))
                {
                    (int feet, double inches) = Conversions.CmToFeetAndInches(double.Parse(txtHeight.Text));
                    txtFeet.Text = feet.ToString();
                    txtInches.Text = inches.ToString("N2");
                    lblWaterResult.Text = $"Daily Water Intake for {personName}: {Conversions.MlToOunces(dailyWaterIntake):N2} oz";

                }
            }
        }
        private void ToggleHeightInputs()
        {

            UpdateConversion(); // update before toggling to ensure correct values are shown.

            bool isMetric = rdoMetric.Checked;

            txtHeight.Visible = isMetric;
            txtFeet.Visible = !isMetric;
            txtInches.Visible = !isMetric;

        }





        private void btnCalculate_Click(object? sender, EventArgs e)
        {
            CalculateAndDisplayWaterIntake();
        }

        private void CalculateAndDisplayWaterIntake()
        {
            try
            {
                dailyWaterIntake = 0; // reset the variable when calculating for a new person.
                // get metric or imperial
                bool isMetric = rdoMetric.Checked;

                // get name
                string name = txtName.Text;

                // get values for height/weight
                // check conversion or not

                double height = isMetric
                    ? double.Parse(txtHeight.Text)
                    : Conversions.InchesToCm((int.Parse(txtFeet.Text) * 12) + double.Parse(txtInches.Text));


                double weight = isMetric
                    ? double.Parse(txtWeight.Text)
                    : Conversions.PoundsToKg(double.Parse(txtWeight.Text));

                // get gender

                Gender gender = (Gender)Enum.Parse(typeof(Gender), ((ComboBox)pnlWaterIntakeCalculator.Controls["cmbGender"]).SelectedItem.ToString());


                // get actiivity


                ActivityLevel activityLevel = (ActivityLevel)Enum.Parse(typeof(ActivityLevel), ((ComboBox)pnlWaterIntakeCalculator.Controls["cmbActivityLevel"]).SelectedItem.ToString());

                // get year of birth
                int birthYear = int.Parse(txtBirthYear.Text);

                // create person
                // Person person = new Person(name, height, weight, gender, activityLevel, birthYear);

                // assign values to the Person object:
                person.Name = name;
                person.Height = height;
                person.Weight = weight;
                person.BirthYear = birthYear;
                person.Gender = gender;
                person.ActivityLevel = activityLevel;

                // create watercalculator instance and insert person
                WaterIntakeCalculator waterIntakeCalculator = new WaterIntakeCalculator(person);

                dailyWaterIntake = waterIntakeCalculator.CalculateIntake();


                // display the calculated result
                lblWaterResult = (Label)pnlWaterIntakeCalculator.Controls["lblWaterResult"];
                personName = $"{person.Name}";

                lblWaterResult.Text = isMetric
                    ? $"Daily Water Intake for {personName}: {dailyWaterIntake:N2} ml"
                    : $"Daily Water Intake for {personName}: {Conversions.MlToOunces(dailyWaterIntake):N2} oz";

            }
            catch (Exception)
            {
                MessageBox.Show($"Please check the input values before converting.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
