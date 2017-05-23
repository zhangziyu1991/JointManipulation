using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour {
//	void OnCollisionEnter(Collision col)
//	{
//		Debug.Log("AAAAAA");
//		Debug.Log(col.gameObject);
//		if (col.gameObject.tag == "WallDown")
//		{
//			Debug.Log("BBBBBB");
//			Debug.Break();
//			//EndGame = true;​
//			//Destroy(col.gameObject);
//		}
//	}

    void OnCollisionEnter(Collision col) {
		Debug.Break ();
    }
}
