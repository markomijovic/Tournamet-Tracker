using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// The prize awarded for placing in the tournament
    /// </summary>
    public class PrizeModel
    {
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
    }
}
