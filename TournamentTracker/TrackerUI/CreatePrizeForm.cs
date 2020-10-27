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
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;
        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void CreatePrizeForm_Load(object sender, EventArgs e)
        {

        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(placeNameValue.Text, placeNumberValue.Text,
                                                  prizeAmountValue.Text, prizePercentageValue.Text);
                GlobalConfig.Connection.CreatePrize(model);
                callingForm.PrizeComplete(model);
                this.Close();
                // Set to default values after submiting the prize form
                //placeNameValue.Text = "";
                //placeNumberValue.Text = "";
                //prizeAmountValue.Text = "0";
                //prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid input. Try again.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            // check that place number entry is valid
            if (!int.TryParse(placeNumberValue.Text, out int placeNumber))
            {
                output = false;
            }
            if (placeNumber < 1)
            {
                output = false;
            }
            // check that place name is entered and not null
            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }
            // check that prize amount entry is valid
            if (!decimal.TryParse(prizeAmountValue.Text, out decimal prizeAmount))
            {
                output = false;
            }
            if (prizeAmount < 0)
            {
                output = false;
            }
            // check that prize percentage entry is valid
            if (!double.TryParse(prizePercentageValue.Text, out double prizePercentage))
            {
                output = false;
            }
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }
            return output;
        }
    }
}
