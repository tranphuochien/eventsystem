using System.Collections;
using System.Collections.Generic;
using Assets.Event;
using UnityEngine;
using Event = Assets.Event.Event;

public class EventsManager : MonoBehaviour {
    public List<Event> EventList = new List<Event>();
    public EventSerializer EventRaws;
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (EventList.Count == 0)
	        return;
	    foreach (Event Event in EventList)
	    {
	        Event.CheckPreCondition();
	    }
	}

    public void LoadEventsFromJson(string events_json)
    {
        print(events_json);
        EventRaws = JsonUtility.FromJson<EventSerializer>(events_json);
        LoadEventsFromRawEvents();
        print(EventRaws);
    }

    public void LoadEventsFromRawEvents()
    {
        foreach (EventRaw eventRaw in EventRaws.events)
        {
            EventList.Add(new Event(eventRaw));
        }
    }
}
