using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour {
	
	public float speed;
	public Transform source;
    public Transform sink;
	public GameObject wall;

	private GameObject _wall;

	void Start() {
		string[] nameSplit = wall.name.Split (' ');
		_wall = (GameObject) Instantiate(wall, new Vector3(0, 0, 15 * int.Parse(nameSplit[1])), Quaternion.identity);
	}
    
	void Update() {
		float step = speed * Time.deltaTime;
		_wall.transform.position =  new Vector3(_wall.transform.position.x, _wall.transform.position.y, _wall.transform.position.z - step);
		if (_wall.transform.position.z < sink.position.z) {
			Destroy(_wall);
			_wall = (GameObject) Instantiate(wall, source.position, Quaternion.identity);
			if (speed == 30.5f) {
				foreach (Transform child in _wall.transform) {
					if (child.tag == "Wall Component") {
						child.tag = "Wall Component Invincible Mode";
					}
				}
			} 
		}
	}

	// void OnCollisionEnter(Collision col) {
		
	// 	Debug.Log ("AAAA");

	// 	if (col.gameObject.tag == "Wall Component") {
	// 		//gameOver = true;
	// 		//Debug.Break ();

	// 		speed = 0;
		
	// 	} 
	// }
}