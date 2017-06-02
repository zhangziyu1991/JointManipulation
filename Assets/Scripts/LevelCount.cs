using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCount : MonoBehaviour {
	private Text level;

    private float time;

    //private bool time_up = false;
    //public Font TimeUpFont;
    //public string MainMenuScene;

    public bool cont;
    // AudioSource bgm;
    // AudioSource stop;

	// Use this for initialization
	void Start () {
		level = GameObject.Find("LevelTitle").GetComponent<Text>();
		level.text = "Level 1"; 
	}
	
	// Update is called once per frame
	void Update () {
		if(cont){
			time += Time.deltaTime;
		}
		else{
			time = time;
		}
		
		int currLevel = (int)time/10 + 1;
		Debug.Log("Current level" + currLevel);
		level.text = "Level " + currLevel;
		// if(time % 10 == 0){
		// 	Debug.Log("AAAA :" + (int)time/10 + 1);
			
		// }
		
	}
}
