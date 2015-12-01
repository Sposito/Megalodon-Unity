using UnityEngine;
using System.Collections;

public class RotatePlayerTurtle : MonoBehaviour {

	Vector3 deltaPos;
	Vector3 lastPos;

	public float speed = 0.1f;
	void Start () {
		lastPos = transform.position;
		print (Mathf.Atan2 (-1, 0) * Mathf.Rad2Deg);
	}
	
	// Update is called once per frame
	void Update () {
		deltaPos = transform.position - lastPos;
		//deltaPos.Normalize ();

		if (deltaPos.sqrMagnitude != 0) {
			float z = Mathf.Lerp ((Mathf.Atan2 (deltaPos.y, deltaPos.x) * Mathf.Rad2Deg) - 90f, transform.rotation.z, speed);
			transform.rotation = Quaternion.Euler(0f,0f, (Mathf.Atan2 (deltaPos.y, deltaPos.x) * Mathf.Rad2Deg )- 90f );

		}

		lastPos = transform.position;


	}
}
