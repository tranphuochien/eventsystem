using System.Collections;
using System.Collections.Generic;
using Assets.Event;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public GameObject target;
    private Action action;
	void Start () {
//		action = new Hide(target, 2.0f);
//	    action.DoAction();
	}
	
	// Update is called once per frame
	void Update () {
		//check precondition of each event
	}
}
