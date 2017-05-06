using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	//	private Vector3 _rotation;
	private float _rotation;
	private bool _isRotating;

	void Start () {
		_sensitivity = 0.4f;
		//		_rotation = Vector3.zero;
		_rotation = 0.0f;
	}

	void Update() {
		if(_isRotating) {
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);

			// apply rotation
			//			_mouseOffset.x = Mathf.Clamp(-_mouseOffset.x * sensitivity, -Mathf.PI / 2, Mathf.PI/2) / (-sensitivity);
			_rotation = -_mouseOffset.x * _sensitivity;

			// rotate
			transform.parent.RotateAround(transform.parent.position, new Vector3(0, 0, 1), _rotation);

			// store mouse
			_mouseReference = Input.mousePosition;
		}
	}

	void OnMouseDown() {
		// rotating flag
		_isRotating = true;

		// store mouse
		_mouseReference = Input.mousePosition;
	}

	void OnMouseUp() {
		// rotating flag
		_isRotating = false;
	}
}
