using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class ClickController : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnMouseDown()
    {
        Dictionary<string, string> paramsData = new Dictionary<string, string>();
        paramsData.Add(Constant.TARGET_NAME_LABEL, transform.name);
        EventsManager.processEvent(Constant.EVENT_TOUCH, paramsData);
    }
}
