using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelClickController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    private void TaskOnClick()
    {
        Dictionary<string, string> paramsData = new Dictionary<string, string>();
        paramsData.Add(Constant.TARGET_NAME_LABEL, transform.name);
        paramsData.Add(Constant.TARGET_GROUP_LABEL, "Panel");
        EventsManager.processEvent(Constant.EVENT_TOUCH, paramsData);
    }
}
