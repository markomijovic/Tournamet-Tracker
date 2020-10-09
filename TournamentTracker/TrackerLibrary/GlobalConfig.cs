using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - create actualy .sql connection
                SqlConnection sql = new SqlConnection();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                // TODO - create .txt connection
                TextConnection txt = new TextConnection();
                Connections.Add(txt);
            }
        }
    }
}
