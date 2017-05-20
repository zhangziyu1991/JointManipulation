using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {

    public Text score;
    private int curentScore;


    void Update() {
        Debug.Log("AAAAAAA");
        string sc = GameObject.Find("CoinText").GetComponent<Text>().text;
        string[] tokens = sc.Split('：');
        Debug.Log("IN pickup: " + tokens[1]);
        //curentScore = Convert.ToInt32(tokens[1]);

        Int32.TryParse(tokens[1], out curentScore);

    }
    
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject);
        if (col.gameObject.tag == "coin")
        {
            Debug.Log(GameObject.Find("CoinText").GetComponent<Text>());
            score = GameObject.Find("CoinText").GetComponent<Text>();
            score.text = "SCORE ：" + (curentScore + 5);
            Destroy(col.gameObject);
        }

    }
}
