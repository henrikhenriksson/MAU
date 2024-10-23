﻿using Assignment4_HT2024_DA204E_AQ7150.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4_HT2024_DA204E_AQ7150.Forms
{
    public partial class AddGuestForm : Form
    {

        private EventManager eventManager;
        private TextBox txtFirstName;
        private TextBox txtLastName;


        public AddGuestForm(EventManager eventManager)
        {
            InitializeComponent();
            this.eventManager = eventManager;
            initializeGUI();
        }

        private void initializeGUI()
        {
            Text = "Add New Guest";
            Size = new Size(400, 250);

            Label lblFirstName = new Label
            {
                Text = "First Name:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            Controls.Add(lblFirstName);

            txtFirstName = new TextBox
            {
                Location = new Point(120, 20),
                Size = new Size(200, 20)
            };
            Controls.Add(txtFirstName);


            Label lblLastName = new Label
            {
                Text = "Last Name:",
                Location = new Point(20, 60),
                AutoSize = true
            };
            Controls.Add(lblLastName);

            txtLastName = new TextBox
            {
                Location = new Point(120, 60),
                Size = new Size(200, 20)
            };
            Controls.Add(txtLastName);

            Button btnAdd = new Button
            {
                Text = "Add Guest",
                Location = new Point(120, 100),
                Size = new Size(80, 30),

            };
            btnAdd.Click += BtnAdd_Click;
            Controls.Add(btnAdd);

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(240, 100),
                Size = new Size(80, 30)
            };
            btnCancel.Click += BtnCancel_Click;
            Controls.Add(btnCancel);


        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            try
            {
                if (eventManager.AddGuest(firstName, lastName))
                {
                    MessageBox.Show("Guest added Succesfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Guest List is Full", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }


            } catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
