using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour {
	
    public Text scoreText;
	private int _currScore;
    
    void OnCollisionEnter(Collision col) {
		string[] tokens = scoreText.text.Split('：');
		Int32.TryParse(tokens[1], out _currScore);	
		Debug.Log ("curr score: " + tokens [1]);
		Debug.Log ("Colliding into " + col.gameObject);

		if (col.gameObject.tag == "Wall") {
			Debug.Break ();
			return;
		} else if (col.gameObject.tag == "Coin") {
			scoreText.text = "SCORE： " + (_currScore + 5);
			Destroy (col.gameObject);
		} 
    }
}
