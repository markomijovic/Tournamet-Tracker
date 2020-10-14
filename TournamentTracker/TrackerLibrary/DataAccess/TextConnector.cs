using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextExtensions;
using System.Linq;
using System.Runtime.InteropServices;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        public PersonModel CreatePerson(PersonModel model)
        {
            int currentId = 1;
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId++;
            people.Add(model);
            people.SaveToPersonFile(PeopleFile);
            return model;
        }

        /// <summary>
        /// Saves a new prize to the textfile
        /// </summary>
        /// <param name="model">The prize info.</param>
        /// <returns>The prize information, including the unique id</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            int currentId = 1;
            // calling the string extension methods 
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            // the id used for the new record
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            // curentId++ in case we want to add another model after
            model.Id = currentId++;
            prizes.Add(model);
            prizes.SaveToPrizeFile(PrizesFile);
            return model;
        }
    }
}
