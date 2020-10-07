using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{   
    /// <summary>
    /// One match in the tournament
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// The set of teams that were involved in this match
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// The match winner
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// Which tournament round the match happened in
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
