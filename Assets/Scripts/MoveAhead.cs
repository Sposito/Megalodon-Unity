using UnityEngine;
using System.Collections;

public class MoveAhead : MonoBehaviour {

	public float speed = 20f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up * speed / 100);
	}
}
