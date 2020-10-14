using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextExtensions;
using System.Linq;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
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
            // done-Load the text file
            // done-Convert the text to List<PrizeModel>
            // Find the max ID
            // Add the new record with the new ID (max + 1)
            // Convert the prizes to list<string>
            // Save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);
            return model;
        }
    }
}
