using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collide : MonoBehaviour {

	public Text scoreText;
	private int _currScore;

	private bool gameOver = false;
    public Font GameOverFont;
    public string MainMenuScene;

	private bool _isInvincible = false;

	void OnCollisionEnter(Collision col) {
		
		// Debug.Log ("I'm colliding in to " + col.gameObject + " of tag " col.gameObject.tag);

		if (col.gameObject.tag == "Wall Component") {
			gameOver = true;
			//Debug.Break ();
		
		} else if (col.gameObject.tag == "Coin") {
			string[] tokens = scoreText.text.Split ('：');
			Int32.TryParse (tokens [1], out _currScore);	
			scoreText.text = "SCORE： " + (_currScore + 5);
			Destroy (col.gameObject);
		
		} else if (col.gameObject.tag == "Golden Coin") {
			_isInvincible = true;
			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall Wrapper");
			foreach (GameObject wall in walls) {
				wall.GetComponent<Translate>().speed = 30;
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
			wall.GetComponent<Translate>().speed = 3;
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
                Application.LoadLevel(1);
            }

            //Make Main Menu button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 40, 250, 70), "Main Menu"))
            {
                Application.LoadLevel(0);
            }


            //Make quit game button
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 110, 250, 70), "Quit Game"))
            {
                Application.Quit();
            }

        }

		GUIStyle labelStyle = new GUIStyle();
		labelStyle.normal.textColor = Color.red;
		labelStyle.fontSize = 30;
		labelStyle.alignment = TextAnchor.MiddleCenter;
		if (_isInvincible) {
			GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height - 50, 400, 50), "INVINCIBLE MODE !!!", labelStyle);
		}
    }
}
