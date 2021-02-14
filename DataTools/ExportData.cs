﻿using LiteDB;
using System;
using System.Collections.Generic;

namespace LogToDb.DataTools
{
    class ExportData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void ToDatabase(List<EventObject> eventObjects, string dbFilepath)
        {
            string dBtimeStamp = (DateTime.Now).ToString("yyyyMMddHHmmssffff");
            var db = new LiteDatabase(dbFilepath);
            var col = db.GetCollection<EventObject>("LogEntries" + dBtimeStamp);

            log.Info("Database collection: " + "LogEntries" + dBtimeStamp);
            foreach (var eventobject in eventObjects)
            {
                col.Insert(eventobject);
            }
        }
    }
}
