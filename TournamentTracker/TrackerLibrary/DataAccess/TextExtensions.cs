﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextExtensions
{   
    public static class TextExtensions
    {   
        /// <summary>
        /// Takes data csv file name and returns complete windows path
        /// </summary>
        /// <param name="fileName">The name of the csv data storage file</param>
        /// <returns></returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Returns list of prize models based on the prize csv data file
        /// </summary>
        /// <param name="lines">Lines of the csv data file</param>
        /// <returns></returns>
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {   
                // array of csv in each line
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel
                {
                    Id = int.Parse(cols[0]),
                    PlaceNumber = int.Parse(cols[1]),
                    PlaceName = cols[2],
                    PrizeAmount = decimal.Parse(cols[3]),
                    PrizePercentage = double.Parse(cols[4])
                };
                output.Add(p);
            }
            return output;
        }
        /// <summary>
        /// Returns list of person models based on the people csv data file
        /// </summary>
        /// <param name="lines">Lines of the csv data file</param>
        /// <returns></returns>
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                // array of csv in each line
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel
                {
                    Id = int.Parse(cols[0]),
                    FirstName = cols[1],
                    LastName = cols[2],
                    EmailAddress = cols[3],
                    PhoneNumber = cols[4]
                };
                output.Add(p);
            }
            return output;
        }
        /// <summary>
        /// Returns list of team models based on the team csv data file
        /// </summary>
        /// <param name="lines">id, teamname, person1ID|person2ID|person3ID...|personNthID</param>
        /// <returns></returns>
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel t = new TeamModel
                {
                    Id = int.Parse(cols[0]),
                    TeamName = cols[1]
                };
                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).FirstOrDefault());
                }
                output.Add(t);
            }
            return output;
        }
        /// <summary>
        /// Extension method for a list of prizes models that saves a new prize
        /// to the csv prize data file
        /// </summary>
        /// <param name="models">The list of new prize models we want to save</param>
        /// <param name="fileName">The csv file name</param>
        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach(PrizeModel p in models)
            {
                lines.Add($"{ p.Id },{ p.PlaceNumber },{ p.PlaceName },{ p.PrizeAmount },{ p.PrizePercentage }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        /// <summary>
        /// Extension method for a list of people models that saves a new person
        /// to the csv prize data file
        /// </summary>
        /// <param name="models">The list of new person models we want to save</param>
        /// <param name="fileName">The csv file name</param>
        public static void SaveToPersonFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PersonModel p in models)
            {
                lines.Add($"{ p.Id },{ p.FirstName },{ p.LastName },{ p.EmailAddress },{ p.PhoneNumber }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel t in models)
            {
                lines.Add($"{ t.Id }, { t.TeamName }, { ConvertPeopleListToString(t.TeamMembers) }");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";

            if (people.Count == 0)
            {
                return "";
            }
            foreach (PersonModel p in people)
            {
                output += $"{ p.Id }|";
            }
            return output.Substring(0, output.Length - 1);
        }
    }
}
