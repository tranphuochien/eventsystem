using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
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

    static public void processEvent(int eventId, Dictionary<string,string> paramsData)
    {
        switch (eventId)
        {
             
            case Constant.EVENT_CLICK:
                handleClickEvent(paramsData);
                break;
            case Constant.EVENT_TOUCH:
                handleTouchEvent(paramsData);
                break;
        }
    }

    static private void handleClickEvent(Dictionary<string, string> paramsData)
    {
        throw new NotImplementedException();
    }

    static private void handleTouchEvent(Dictionary<string, string> paramsData)
    {
        String nameTarget;
        paramsData.TryGetValue(Constant.TARGET_NAME_LABEL, out nameTarget);
        
        if (nameTarget == null)
        {
            return;
        }
        int currentValue = Global.getFlag(nameTarget);
        if (currentValue == 1)
        {
            Global.setFlag(nameTarget, 0);
        }
        else
        {
            Global.setFlag(nameTarget, 1);
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
