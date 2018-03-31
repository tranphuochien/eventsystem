using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class FlagsWatcher : MonoBehaviour
{
    public List<Flag> Flags;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Flags = Global.ToList();
	}
}
