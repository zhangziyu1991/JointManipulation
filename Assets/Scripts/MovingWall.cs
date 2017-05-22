using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {
	public float speed;
	public Transform start;
    public Transform target;
    
    private Vector3 frometh;
    private Vector3 untoeth;

    void Start() {
        frometh = start.position;
        untoeth = target.position;
    }

//    void Update() {
//        float step = speed * Time.deltaTime;
//        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
//        if (transform.position.z < untoeth.z) {
//            transform.position = frometh;
//        }
//    }

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position =  new Vector3(transform.position.x, transform.position.y, transform.position.z - step);
		if (transform.position.z < untoeth.z) {
			transform.position = new Vector3(transform.position.x, transform.position.y, frometh.z);
		}
	}
}