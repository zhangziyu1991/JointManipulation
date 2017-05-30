using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float midRotation;
	public float deltaRotation;

	void OnMouseDrag() {

		Vector3 parentScreenPosition = Camera.main.WorldToScreenPoint(transform.parent.position);
		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector3 target = new Vector3 (screenPosition.x - parentScreenPosition.x, screenPosition.y - parentScreenPosition.y, 0);
		transform.parent.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), target);
		//		if (WrapAngle(transform.parent.localEulerAngles.z - midRotation) > deltaRotation) {
		//			transform.parent.transform.localRotation = Quaternion.Euler (transform.parent.transform.localEulerAngles.x,
		//				transform.parent.transform.localEulerAngles.y,
		//				UnwrapAngle(midRotation + deltaRotation));
		//		} else if (WrapAngle(transform.parent.localEulerAngles.z - midRotation) < -deltaRotation) {
		//			transform.parent.transform.localRotation = Quaternion.Euler (transform.parent.transform.localEulerAngles.x,
		//				transform.parent.transform.localEulerAngles.y,
		//				UnwrapAngle(midRotation - deltaRotation));
		//		}
	}

	float WrapAngle(float angle) {
		angle %= 360;
		if (angle > 180)
			return angle - 360;
		return angle;
	}

	float UnwrapAngle (float angle){
		if(angle >=0)
			return angle;
		angle = -angle%360;
		return 360-angle;
	}
}
