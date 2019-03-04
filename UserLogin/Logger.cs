using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.CurrentUserName + ";"
                + LoginValidation.CurrentUserRole + ";" + activity;
            currentSessionActivities.Add(activityLine);
            logToFile(activityLine);
        }

        public static string GetCurrentSessionActivities(string filter)
        {
            StringBuilder builder = new StringBuilder();
            List<string> filteredActivities = currentSessionActivities.Where(a => a.Contains(filter)).ToList();

            for (int i = 0; i < filteredActivities.Count; i++)
            {
                builder.AppendLine(filteredActivities[i]);
            }

            return builder.ToString();
        }

        private static void logToFile(string line)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"..\..\test.txt"), true))
            {
                outputFile.WriteLine(line);
            }
        }
    }
}
