using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// The main tournament model
    /// </summary>
    public class TournamentModel
    {
        /// <summary>
        /// The tournament name
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// The tournament's entry fee, if any
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// The list of the entered teams in the 
        /// spcific tournament
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        /// <summary>
        /// The list of the prizes for the specific
        /// tournament
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        /// <summary>
        /// The list of tournament matchup schedules 
        /// where List[0] is a list of matchups in 
        /// the first round, List[1] second and so on
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

    }
}
