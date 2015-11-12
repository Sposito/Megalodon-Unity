using UnityEngine;
using System.Collections;

public class TurtleLoop : MonoBehaviour {

	Vector3 spawn;
	float unspawn;


	public float baseRadius;
	void Start () {
		spawn = GameObject.Find ("Turtle Spawn Point").transform.position;
		unspawn = GameObject.Find ("Turtle Unspawn Point").transform.position.x;

	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= unspawn) {
			float diference = unspawn - transform.position.x;
			transform.position = spawn + new Vector3(diference, Random.Range(-0.3f, 0.3f),0f);
			float randomSize = Random.Range(0.75f, 1.25f);
			transform.localScale = Vector3.one * randomSize;


		}
	
	}
}
