using System.Collections;
using System.Collections.Generic;
using Assets;
using Assets.Script.EventSystem.Global;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public string ObjectName = "";

	// Use this for initialization
	void Start () {
	    if (ObjectName != "")
	    {
	        Global.RegisterItem(ObjectName, gameObject);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
