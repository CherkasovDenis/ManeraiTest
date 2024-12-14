using System;

namespace ManeraiTest.Backpack
{
    [Serializable]
    public class EventData
    {
        public string id;
        public string event_type;

        public EventData(string itemId, string eventType)
        {
            id = itemId;
            event_type = eventType;
        }
    }
}