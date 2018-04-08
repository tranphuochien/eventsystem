using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {
    bool shouldStartSlide = false;
    bool isSlideIn = true;
    Vector3 beginPosition;
    Vector3 endPosition;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector3.Distance(transform.position, endPosition));
        if (Vector3.Distance(transform.position, endPosition) < 5)
        {
            shouldStartSlide = false;
            if (isSlideIn) { 
                transform.localPosition = new Vector3(4.63f, 0.05f, 9.24f);
            }
        }
        if (shouldStartSlide)
        {
            StartCoroutine(Move(Input.GetAxis("Horizontal")));
        }
    }
    public void SlideIn()
    {
        beginPosition = transform.position;
        endPosition = transform.position + new Vector3(-10, 0, 0);
        shouldStartSlide = true;
        isSlideIn = true;
    }
     public void SlideOut()
    {
        beginPosition = transform.position;
        endPosition = transform.position + new Vector3(10, 0, 0);
        shouldStartSlide = true;
        isSlideIn = false;
    }
    IEnumerator Move(float direction)
    {
       

        float step = 10.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        beginPosition = transform.position;

 
        yield return null;
    }
}
