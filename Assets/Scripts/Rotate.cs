using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	private bool _isRotating=false;

	void Update() {
		if(_isRotating) {
			Vector3 parentScreenPosition = Camera.main.WorldToScreenPoint(transform.parent.position);
			Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Vector3 target = new Vector3 (screenPosition.x - parentScreenPosition.x,
										  screenPosition.y - parentScreenPosition.y, 0.0f);
			transform.parent.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), target);
		}
	}

	void OnMouseDown() {
		_isRotating = true;
	}

	void OnMouseUp() {
		_isRotating = false;
	}
}
