using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collide : MonoBehaviour {
	
    public Text scoreText;
	private int _currScore;
    
    void OnCollisionEnter(Collision col) {
		
		if (col.gameObject.tag == "Wall") {
			Debug.Break ();
			return;
		} else if (col.gameObject.tag == "Coin") {
			string[] tokens = scoreText.text.Split('：');
			Int32.TryParse(tokens[1], out _currScore);	
			scoreText.text = "SCORE： " + (_currScore + 5);
			Destroy (col.gameObject);
		} 
    }
}
