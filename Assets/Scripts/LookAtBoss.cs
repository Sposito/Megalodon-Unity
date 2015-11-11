using UnityEngine;
using System.Collections;

public class LookAtBoss : MonoBehaviour {


	
	void Update () {
		LookAt ();
	}
	
	void LookAt(){
		if (SingletonController.boss != null) { //to avoid null reference errors
			Vector3 direction = SingletonController.boss.transform.position - transform.position; // get the direction vector
			float rot = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg; // calculate the rotation angles in radians and convert to degrees
			transform.rotation = Quaternion.Euler (0f, 0f, rot); // change the Z rotation;
		}
		else
			Debug.LogWarning("No target assigned!"); // Warning Message
		
	}

}
