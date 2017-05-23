using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    private Text timer;

    public float timeRemaining;

    // Use this for initialization
    void Start () {
        timer = GameObject.Find("Timer").GetComponent<Text>();
        timer.text = "TIMER: " + timeRemaining.ToString() + " S";
		
	}

    // Update is called once per frame

    void Update () {
        timeRemaining -= Time.deltaTime;

        //Debug.Log(timeRemaining);
        if ((int)timeRemaining > 0)
        {
            timer.text = "TIMER: " + (int)timeRemaining + " S";
        }
        else {
            timer.text = "TIME'S UP!";
            Debug.Break();
        }
		
	}
}
