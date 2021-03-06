﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {

    private Text timer;

    public float timeRemaining;

    private bool time_up = false;
    public Font TimeUpFont;
    public string MainMenuScene;

    public bool cont;
    AudioSource bgm;
    AudioSource stop;

    // Use this for initialization
    void Start () {
        timer = GameObject.Find("Timer").GetComponent<Text>();
        timer.text = "TIMER: " + timeRemaining.ToString() + " S";
        bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        stop =GameObject.Find("Directional Light").GetComponent<AudioSource>();    
		
	}

    // Update is called once per frame

    void Update () {
        if(cont){
            timeRemaining -= Time.deltaTime;
        }
        else{
         timeRemaining = timeRemaining;
        }
        

        //Debug.Log(timeRemaining);
        if ((int)timeRemaining > 0)
        {
            int min = (int)(timeRemaining / 60);
            if(min != 0){
                timer.text = "TIMER: " + min + "min " + (int)timeRemaining % 60 + " S";
            }
            else{
                if(timeRemaining <= 10){
                    timer.color = Color.red;
                    timer.fontSize = 40;
                }
                timer.text = "TIMER: " + (int)timeRemaining + " S";
            }
        }
        else {
            timer.text = "TIME'S UP!";
            //Debug.Break();
            time_up = true;
            if(bgm.isPlaying){
                bgm.Stop();
                stop.Play();

            }

			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall Wrapper");
			foreach (GameObject wall in walls) {
				wall.GetComponent<Translate>().speed = 0;
			}
        }
	}

    void OnGUI() {

        GUIStyle buttonStyle = new GUIStyle();
        GUIStyle boxStyle = new GUIStyle();

        buttonStyle.font = TimeUpFont;
        buttonStyle.fontSize = 30;

        if (time_up) {
            Text score =  GameObject.Find("CoinText").GetComponent<Text>();
            string[] tokens = score.text.Split ('：');
            int finalScore = 0;
            Int32.TryParse (tokens [1],out finalScore);    
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 280), "Final score: " + finalScore);


            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 250, 70), "Restart"))
            {
                SceneManager.LoadScene(1);
            }

            //Make Main Menu button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 40, 250, 70), "Main Menu"))
            {
                SceneManager.LoadScene(0);
            }


            //Make quit game button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 110, 250, 70), "Quit Game"))
            {
                Application.Quit();
            }

        }

        // GUIStyle labelStyle = new GUIStyle();
        // labelStyle.normal.textColor = Color.red;
        // labelStyle.fontSize = 30;
        // labelStyle.alignment = TextAnchor.MiddleCenter;
        // if (_isInvincible) {
        //     GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height - 50, 400, 50), "INVINCIBLE MODE !!!", labelStyle);
        // }
    }
}
