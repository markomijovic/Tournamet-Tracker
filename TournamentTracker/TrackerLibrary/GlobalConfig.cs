using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TrackerLibrary
{
    /// <summary>
    /// A global variable that stores
    /// data connections
    /// </summary>
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType db)
        {
            switch (db)
            {
                case DatabaseType.sql:
                    SqlConnector sql = new SqlConnector();
                    Connection = sql;
                    break;
                case DatabaseType.txt:
                    // TODO - create .txt connection
                    TextConnector txt = new TextConnector();
                    Connection = txt;
                    break;
                default:
                    break;
            } 
        }

        /// <summary>
        /// Obtains the connection string value
        /// from App.config
        /// </summary>
        /// <param name="name">The connection string name id</param>
        /// <returns></returns>
        public static string CncString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
