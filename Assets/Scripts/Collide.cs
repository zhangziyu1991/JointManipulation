using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collide : MonoBehaviour {

	public Text scoreText;
	private int _currScore;

	void OnCollisionEnter(Collision col) {
		
		// Debug.Log ("I'm colliding in to " + col.gameObject + " of tag " col.gameObject.tag);

		if (col.gameObject.tag == "Wall Component") {
			Debug.Break ();
		
		} else if (col.gameObject.tag == "Coin") {
			string[] tokens = scoreText.text.Split ('：');
			Int32.TryParse (tokens [1], out _currScore);	
			scoreText.text = "SCORE： " + (_currScore + 5);
		
		} else if (col.gameObject.tag == "Golden Coin") {
			GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall Wrapper");
			Debug.Log ("This many walls: " + walls.Length);
			foreach (GameObject wall in walls) {
				Debug.Log ("lalalalal" + wall);
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
		}
	}
}
