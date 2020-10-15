using System;
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
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        public CreateTeamForm()
        {
            InitializeComponent();
            //CreateSampleData();
            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Marko", LastName = "Mijovic" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Alex", LastName = "Situ" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Marko", LastName = "Joa" });
        }
        private void WireUpLists()
        {
            selectMemberDropdown.DataSource = null;
            selectMemberDropdown.DataSource = availableTeamMembers;
            selectMemberDropdown.DisplayMember = "FullName";
            teamMemberListBox.DataSource = null;
            teamMemberListBox.DataSource = selectedTeamMembers;
            teamMemberListBox.DisplayMember = "FullName";
        }
        private void createMemberValue_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel
                {
                    FirstName = firstNameValue.Text,
                    LastName = lastNameValue.Text,
                    EmailAddress = emailValue.Text,
                    PhoneNumber = cellphoneValue.Text
                };
                p = GlobalConfig.Connection.CreatePerson(p);
                selectedTeamMembers.Add(p);
                WireUpLists();
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
        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel) selectMemberDropdown.SelectedItem;

            availableTeamMembers.Remove(p);
            selectedTeamMembers.Add(p);
            WireUpLists();
        }

        private void deleteMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMemberListBox.SelectedItem;

            if (p == null)
            {
                MessageBox.Show("Please select 1 person to delete from the team.");
                return;
            }
            availableTeamMembers.Add(p);
            selectedTeamMembers.Remove(p);
            WireUpLists();
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;
            GlobalConfig.Connection.CreateTeam(t);
        }
    }
}
