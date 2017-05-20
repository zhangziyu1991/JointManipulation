using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	//	private Vector3 _rotation;
	private float _rotation;
	private bool _isRotating=false;
	public float speed;

	void Start () {
		_sensitivity = 0.4f;
		//		_rotation = Vector3.zero;
		_rotation = 0.0f;
	}

	void Update() {

		if(_isRotating) {
			// offset
			//			_mouseOffset = (Input.mousePosition - _mouseReference);

			// apply rotation
			//			_mouseOffset.x = Mathf.Clamp(-_mouseOffset.x * sensitivity, -Mathf.PI / 2, Mathf.PI/2) / (-sensitivity);
			//			_rotation = -_mouseOffset.x * _sensitivity;

			//			Vector3 current = new Vector3 (transform.position.x - transform.parent.position.x, transform.position.y - transform.parent.position.y);

			Vector3 p = new Vector3();
			Camera  c = Camera.main;
			Vector2 mousePos = new Vector2();

			mousePos.x = Input.mousePosition.x;
			mousePos.y = Input.mousePosition.y;

			p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 50));


			//			Vector3 target = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x , Input.mousePosition.y, 0));

			Vector3	target2	= p - transform.parent.position;

			//Debug.Log (p);




			//			float step = speed * Time.deltaTime;

			//			Vector3 newDir = Vector3.RotateTowards(new Vector3(0, 0, -1), target - current, step, 0.0F);

			//			Vector2 rotation = new Vector2(Input.mousePosition.x, Input.mousePosition.y)  - new Vector2 (transform.parent.position.x, transform.parent.position.y);

			// rotate
			//			transform.parent.RotateAround(transform.parent.position, new Vector3(0, 0, -1), _rotation);

			//			transform.parent.rotation = Quaternion.LookRotation (_rotation);


			//			transform.rotation = Quaternion.LookRotation (newDir);

			transform.parent.LookAt (p, new Vector3(0, 0, -1));

			// store mouse
			//				_mouseReference = Input.mousePosition;


		}
	}

	void OnMouseDown() {
		// rotating flag
		_isRotating = true;

		// store mouse
		//		_mouseReference = Input.mousePosition;
	}

	void OnMouseUp() {
		// rotating flag
		_isRotating = false;
	}
}
