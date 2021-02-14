using LiteDB;

namespace LogToDb
{
    class EventObject
    {
        public ObjectId eventobjectId { get; set; }
        public string eventid { get; set; }
        public string type { get; set; }
        public string host { get; set; }
        public long duration { get; set; }
        public bool alert { get; set; }
        public EventObject(InputObject inputObject)
        {
            eventid = inputObject.id;
            duration = inputObject.timestamp;
            type = inputObject.type;
            host = inputObject.host;
            if (duration > 4)
                alert = true;
            else
                alert = false;
        }
        public EventObject()
        {
        }
    }
}
