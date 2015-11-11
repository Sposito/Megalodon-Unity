using UnityEngine;
using System.Collections;

public class TurtleLoop : MonoBehaviour {

	Vector3 spawn;
	float unspawn;
	void Start () {
		spawn = GameObject.Find ("Turtle Spawn Point").transform.position;
		unspawn = GameObject.Find ("Turtle Unspawn Point").transform.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= unspawn) {
			float diference = unspawn - transform.position.x;
			transform.position = spawn + new Vector3(diference, 0f,0f);
		}
	
	}
}
