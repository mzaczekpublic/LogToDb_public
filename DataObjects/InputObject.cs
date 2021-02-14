namespace LogToDb
{
    class InputObject
    {
        public string id { get; set; }
        private string _state { get; set; }
        public string state
        {
            get
            {
                return _state;                
            }
            set
            {
                if((value.ToLower() == "started") || (value.ToLower() == "finished"))
                {
                    _state = value;
                }
                else
                {
                    _state = "invalid";
                }

            }
        }
        public string type { get; set; }
        public string host { get; set; }
        public long timestamp { get; set; }
    }
}
