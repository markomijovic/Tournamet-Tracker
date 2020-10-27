using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamDropdown.DataSource = null;
            selectTeamDropdown.DataSource = availableTeams;
            selectTeamDropdown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            tournamentPrizeListBox.DataSource = null;
            tournamentPrizeListBox.DataSource = selectedPrizes;
            tournamentPrizeListBox.DisplayMember = "PlaceName";

        }
        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropdown.SelectedItem;
            if (t == null)
            {
                MessageBox.Show("Please select a valid team.");
                return;
            }
            availableTeams.Remove(t);
            selectedTeams.Add(t);
            WireUpLists();
        }

        private void addTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call the create prize form
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();

            // Get back the prize model
            // Put the prize model into the list of selected prizes

        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back the prize model
            // Put the prize model into the list of selected prizes
            selectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void deleteSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;
            if (t == null)
            {
                MessageBox.Show("Please select 1 team to delete.");
                return;
            }
            availableTeams.Add(t);
            selectedTeams.Remove(t);
            WireUpLists();
        }

        private void deleteSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)tournamentPrizeListBox.SelectedItem;
            if (p == null)
            {
                MessageBox.Show("Please select 1 prize to delete.");
                return;
            }
            selectedPrizes.Remove(p);
            WireUpLists();
        }
    }
}
