using Assignment4_HT2024_DA204E_AQ7150.Classes;
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
    public partial class MainForm : Form
    {

        private EventManager eventManager;

        public MainForm()
        {
            InitializeComponent();
            eventManager = new EventManager();
            OpenEventManagerForm();

        }

        private void OpenEventManagerForm()
        {
            EventDetailsForm eventDetailsForm = new EventDetailsForm(eventManager);

            eventDetailsForm.ShowDialog();


        }
    }
}
