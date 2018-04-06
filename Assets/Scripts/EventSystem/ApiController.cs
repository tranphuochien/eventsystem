using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using Assets;
using Assets.Script.EventSystem.Global;
using UnityEngine;

public class ApiController : MonoBehaviour
{
    public string event_api_url = "http://localhost:3000/api/events";
    public bool ReloadEvent = false;
    public GameObject EventsManager;
	// Use this for initialization
	void Start ()
	{
        //StartCoroutine(GetEvents());
        InitDictionary();
        GetEvents();

    }

    private void InitDictionary()
    {
        Global.RegisterItem("cube1", this.gameObject.transform.GetChild(0).gameObject);
        Global.RegisterItem("cube2", this.gameObject.transform.GetChild(1).gameObject);
        Global.RegisterItem("cube3", this.gameObject.transform.GetChild(2).gameObject);
        Global.RegisterItem("cube4", this.gameObject.transform.GetChild(3).gameObject);
        Global.RegisterItem("globalInstance", GameObject.Find("Main Camera").transform.GetChild(0).transform.GetChild(0).gameObject);

        Global.setFlag("cube1", 0);
        Global.setFlag("cube2", 0);
        Global.setFlag("cube3", 0);
        Global.setFlag("cube4", 0);
        Global.setFlag("globalInstance", 0);
    }

    // Update is called once per frame
    void Update () {
	    if (ReloadEvent)
	    {
            EventsManager.GetComponent<EventsManager>().EventList.Clear();
            //StartCoroutine(GetEvents());
            GetEvents();

            ReloadEvent = false;
	    }
	}

    private void GetEvents()
    {
        /*WWW www = new WWW(event_api_url);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            ReturnEvents(www.text);
        }
        else
        {
            ReturnError(www.error);
        }*/
        using (StreamReader r = new StreamReader("raw.json"))
        {
            string json = r.ReadToEnd();
            ReturnEvents(json);
            //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        }
    }

    private void ReturnEvents(string events_raw_json)
    {
        EventsManager.GetComponent<EventsManager>().LoadEventsFromJson(events_raw_json);
    }

    private void ReturnError(string error)
    {
        print("error while calling api: ");
        print(error);
    }
}
