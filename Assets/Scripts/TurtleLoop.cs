using UnityEngine;
using System.Collections;

public class TurtleLoop : MonoBehaviour {

	Vector3 spawn;
	float unspawn;

	public bool havePowerUp {private set;  get; } // this bools marks the ones who will give the player the power up;



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
			havePowerUp = false; //clears the register
			if (randomSize < 0.80f){ // only the small(young) ones are brave enought to defy the bosses >>and they are harder to hit as well
				havePowerUp = true;
			}
			transform.localScale = Vector3.one * randomSize;


		}
	
	}
}
