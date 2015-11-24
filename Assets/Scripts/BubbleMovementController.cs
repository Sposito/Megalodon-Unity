using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class BubbleMovementController : MonoBehaviour {

	Vector3 pos;
	Rigidbody2D rB;
	float speed = 10;
	int count = 0;
	int frameN = 5;
	void Start () {
		rB = GetComponent<Rigidbody2D> ();
		pos = Vector3.right * Random.Range (-1f, 1f) / 20;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up / 20 * Random.Range(-1f, 0.3f);
	
		if (count > frameN) {
			pos = Vector3.right * Random.Range (-1f, 1f) / 20;
			count = 0;
		}
		transform.position += pos;
		count++;
	}
}
