﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// The team playing in a tournament
    /// </summary>
    public class TeamModel
    {   
        public int Id { get; set; }
        /// <summary>
        /// The list of people where each person 
        /// is a team member
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
        /// <summary>
        /// The team name
        /// </summary>
        public string TeamName { get; set; }
        
    }
}
