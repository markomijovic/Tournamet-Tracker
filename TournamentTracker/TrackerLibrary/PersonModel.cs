using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// One person/player
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Person's first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Person's last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Person's email address
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Person's cellphone number
        /// </summary>
        public string CellphoneNumber { get; set; }
    }
}
