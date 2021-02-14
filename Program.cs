using LogToDb.DataTools;
using System;
using System.Collections.Generic;
using System.IO;

namespace LogToDb
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("LogToDb STARTED ############");

            // REGION: VARIABLES
            string inputFilepath = @"c:\Temp\input.json";
            if (args.Length != 0)
                inputFilepath = args[0];
            string currentPath = Directory.GetCurrentDirectory();
            string dbFilepath = currentPath + @"\LogEntries.db";

            // REGION: DATA INPUT AND DESERIALIZATION
            List<EventObject> eventObjects = ImportData.FromFile(inputFilepath);
            if (eventObjects is null)
                return;

            // REGION: DATA OUTPUT
            ExportData.ToDatabase(eventObjects, dbFilepath);
       
            log.Info("LogToDb COMPLETED ##########");
            Console.ReadKey();
        }
    }
}
