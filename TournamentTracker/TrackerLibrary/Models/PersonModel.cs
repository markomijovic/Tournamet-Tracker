using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// One person/player
    /// </summary>
    public class PersonModel
    {
        public int Id { get; set; }
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
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get { return $"{ FirstName }{" "}{ LastName }"; }
        }

    }
}
