﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createMemberValue_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();
                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.PhoneNumber = cellphoneValue.Text;
                GlobalConfig.Connection.CreatePerson(p);
                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid field input. Try again.");
            }
        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0 || lastNameValue.Text.Length == 0 || emailValue.Text.Length == 0 || cellphoneValue.Text.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}
