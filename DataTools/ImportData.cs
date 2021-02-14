using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogToDb.DataTools
{
    static class ImportData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<EventObject> FromFile(string inputFilepath)
        {
            List<EventObject> eventObjects = new List<EventObject>();
            string line = String.Empty;
            InputObject inputObject = new InputObject();
            List<InputObject> inputObjects = new List<InputObject>();

            if (File.Exists(inputFilepath) == false)
            {
                log.Error("The input file does not exist");
                return null;
            }

            Stream str = new FileStream(inputFilepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(str);

            log.Info("Importing data from the imput file");
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    inputObject = JsonConvert.DeserializeObject<InputObject>(line,
                        new JsonSerializerSettings
                        {
                            MissingMemberHandling = MissingMemberHandling.Error
                        });

                    if (inputObject.state == "invalid")
                    {
                        log.Info("Invalid state for event id:" + inputObject.id);
                    }
                }
                catch (JsonSerializationException ex)
                {
                    log.Error(ex.Message);
                    continue;
                }
                catch (JsonException ex)
                {
                    log.Error(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                    continue;
                }

                var existingObject = inputObjects.SingleOrDefault(x => x.id.Equals(inputObject.id));
                if (existingObject is null)
                {
                    inputObjects.Add(inputObject);
                    continue;
                }
                existingObject.timestamp = Math.Abs(inputObject.timestamp - existingObject.timestamp);
                eventObjects.Add(new EventObject(existingObject));
                inputObjects.Remove(existingObject);
            }
            str.Close();

            foreach(var existingObj in inputObjects)
            {
                log.Info("Oprhaned (incomplete) log entries that were not exported to the database:");
                log.Info(existingObj.id);
            }

            return eventObjects;
        }
    }
}
