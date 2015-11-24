using UnityEngine;
using System.Collections;

public class LookAtGameObject : MonoBehaviour {

	public GameObject target;
	protected float angleCompensation = 0f;

	void Update () {
		LookAt ();
	}

	void LookAt(){
		if (target != null) { //to avoid null reference errors
			Vector3 direction = target.transform.position - transform.position; // get the direction vector
			float rot = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg; // calculate the rotation angles in radians and convert to degrees
			transform.rotation = Quaternion.Euler (0f, 0f, rot + angleCompensation); // change the Z rotation;
		}
		else
			Debug.LogWarning("No target assigned!"); // Warning Message

	}
}
