using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// The prize awarded for placing in the tournament
    /// </summary>
    public class PrizeModel
    {   
        /// <summary>
        /// Unique ID for a prize
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The number placed
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// The name corresponding to the number placed
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// The prize amount for the specific placing
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// The percentage of the grand total prize for 
        /// the specific placing
        /// </summary>
        public double PrizePercentage { get; set; }
        
        public PrizeModel()
        {

        }
 
        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int.TryParse(placeNumber, out int placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal.TryParse(prizeAmount, out decimal prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double.TryParse(prizePercentage, out double prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
