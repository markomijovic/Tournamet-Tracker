using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class TextConnection : IDataConnection
    {
        /// <summary>
        /// Saves a new prize to the textfile
        /// </summary>
        /// <param name="model">The prize info.</param>
        /// <returns>The prize information, including the unique id</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
