using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

	public Transform target;

	public Vector3 offset;

	void LateUpdate()
	{
		

		float yPos;

		Vector3 tempPos = target.position + offset;

		Vector3 newPos = new Vector3 (tempPos.x, tempPos.y , tempPos.z);
		newPos.y = transform.position.y;

		/*if (target.position.y - transform.position.y >= 1 ) {
			newPos.y = 1f;
		} else if (target.position.y - transform.position.y <= -1) {
			newPos.y = -0.5f;
		}*/

		transform.position = newPos;
	}
}
