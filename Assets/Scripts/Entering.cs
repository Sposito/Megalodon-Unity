using UnityEngine;
using System.Collections;

public class Entering : MonoBehaviour {

	public float yPos = 3.2f;
	public float speed = 20;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > yPos) {
			transform.position += Vector3.down * speed / 100;
		}

		else {
			transform.position = new Vector3(transform.position.x, yPos);
			this.enabled = false;
		}

	
	}
}
