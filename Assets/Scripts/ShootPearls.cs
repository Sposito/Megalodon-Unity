using UnityEngine;
using System.Collections;

public class ShootPearls : MonoBehaviour {

	public GameObject pearl;
	[Range(0f, 60f)]
	public float interval = 1f;
	[Range(0f, 1f)]
	public float accuracy = 1f;
	float counter = 0f;

	void Start () {
	
	}
	

	void Update () {
		counter += Time.deltaTime;

		if (counter > interval) {
			Quaternion stdDev = Quaternion.Euler(0f,0f, Random.Range(0f, (1 - accuracy) * 45) );

			Instantiate(pearl, transform.position, transform.rotation * Quaternion.Euler(0f,0f,-90f) * stdDev );
			counter = counter - interval; 
		}

	}
}
