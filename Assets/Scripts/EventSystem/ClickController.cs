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
        //transform.Rotate(0, 2* Time.deltaTime, 0, Space.World);
    }

    private void OnMouseDown()
    {
        string currentKey = transform.name;
        int currentValue = Global.getFlag(currentKey);
        if (currentValue == 1)
        {
            Global.setFlag(currentKey, 0);
        } else
        {
            Global.setFlag(currentKey, 1);
        }
    }
}
