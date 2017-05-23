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

        if (col.gameObject.tag == "coin") {
            scoreText.text = "SCORE： " + (_currScore + 5);
            Destroy(col.gameObject);
        }
    }
}
