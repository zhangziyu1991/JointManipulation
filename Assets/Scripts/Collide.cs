using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour {

	public Text scoreText;
	private int _currScore;

	private bool gameOver = false;
    public Font GameOverFont;
    public string MainMenuScene;
    //public string ReloadScene;

	private bool _isInvincible = false;

	private string[] wall_names = new string[30]{"Wall 01","Wall 02", "Wall 03", "Wall 04", "Wall 05", "Wall 06", "Wall 07", "Wall 08", "Wall 09",
	 "Wall 10", "Wall 11", "Wall 12", "Wall 13", "Wall 14", "Wall 15", "Wall 16", "Wall 17", "Wall 18", "Wall 19", "Wall 20", "Wall 21", "Wall 22",
	 "Wall 23", "Wall 24", "Wall 25", "Wall 26", "Wall 27", "Wall 28", "Wall 29", "Wall 30"};

	 //public AudioClip otherClip;
    AudioSource bgm;
    AudioSource collide;

    void Start(){
    	 bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    	 collide =GameObject.Find("Auxillary Camera").GetComponent<AudioSource>();    
    	}

	void OnCollisionEnter(Collision col) {
		
		Debug.Log ("I'm colliding in to " + col.gameObject + " of tag " + col.gameObject.tag + ", " + col.gameObject.transform.parent.gameObject);

		if (col.gameObject.tag == "Wall Component") {
			string colliding_wall = col.gameObject.transform.parent.name;
			for(int i = 0; i < 30; i++){
				if(colliding_wall != wall_names[i]+"(Clone)" && GameObject.Find(wall_names[i])){
					GameObject wall = GameObject.Find(wall_names[i]);
					Translate translate = wall.GetComponent<Translate>();
//					Debug.Log(translate.speed);
					translate.speed = 0;
				}
			}
			//Time.timeScale = 0;
			if(GameObject.Find("Timer")){
				CountDown count = GameObject.Find("Timer").GetComponent<CountDown>();
				count.cont = false;
			}
			

			//Debug.Log(col.gameObject.transform.parent.name);

			gameOver = true;
			if(bgm.isPlaying){
				bgm.Stop();
				collide.Play();

			}
			//audio.Stop();
		
		} else if (col.gameObject.tag == "Coin") {
			string[] tokens = scoreText.text.Split ('：');
			Int32.TryParse (tokens [1], out _currScore);	
			scoreText.text = "SCORE： " + (_currScore + 5);
			Destroy (col.gameObject);
		
		} else if (col.gameObject.tag == "Golden Coin") {
			_isInvincible = true;
			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall Wrapper");
			foreach (GameObject wall in walls) {
				wall.GetComponent<Translate>().speed = 30.5f;
			}
			walls = GameObject.FindGameObjectsWithTag("Wall");
			foreach (GameObject wall in walls) {
				foreach (Transform child in wall.transform) {
					if (child.tag == "Wall Component") {
						child.tag = "Wall Component Invincible Mode";
					}
				}
			}

			Destroy (col.gameObject);

			// wait 5 seconds and then everything goes back to normal
			StartCoroutine (WaitAndRevert());
		}
	}

	IEnumerator WaitAndRevert() {
		yield return new WaitForSecondsRealtime (5.0f);

		_isInvincible = false;

		GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall Wrapper");
		foreach (GameObject wall in walls) {
			wall.GetComponent<Translate>().speed = 1.5f;
		}

		walls = GameObject.FindGameObjectsWithTag("Wall");
		foreach (GameObject wall in walls) {
			foreach (Transform child in wall.transform) {
				if (child.tag == "Wall Component Invincible Mode") {
					child.tag = "Wall Component";
				}
			}
		}
	}

	void OnGUI() {

        GUIStyle buttonStyle = new GUIStyle();
        GUIStyle boxStyle = new GUIStyle();

        buttonStyle.font = GameOverFont;
        // buttonStyle.normal.textColor = Color.black;
        // buttonStyle.hover.textColor = Color.red;
        buttonStyle.fontSize = 30;

        // GUI.skin.box.font = GameOverFont;
        // GUI.skin.button.font = GameOverFont;


        if (gameOver) {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 280), "Game Over");


            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 30, 250, 70), "Restart"))
            {
            	Scene scene = SceneManager.GetActiveScene(); 
            	SceneManager.LoadScene(scene.name);
				//SceneManager.LoadScene(ReloadScene);
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

		GUIStyle labelStyle = new GUIStyle();
		labelStyle.normal.textColor = Color.red;
		labelStyle.fontSize = 50;
		labelStyle.alignment = TextAnchor.MiddleCenter;
		if (_isInvincible) {
			GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height - 200, 400, 200), "INVINCIBLE MODE !!!", labelStyle);
		}
    }
}
