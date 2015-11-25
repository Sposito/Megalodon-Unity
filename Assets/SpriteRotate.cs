using UnityEngine;
using System.Collections;

public class SpriteRotate : MonoBehaviour {

	public float speed =5f;
	void Start () {
		//Assigns this sprite just below it parent(the bubble)

	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, 0f, speed);
	}
}
