using UnityEngine;
using System.Collections;

public class Inflate : MonoBehaviour {
	float reference;
	public float speed = 1f;
	public float maxScale = 1f;
	// Use this for initialization
	void Start () {
		reference = transform.localScale.magnitude;
		maxScale = maxScale * maxScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.sqrMagnitude <= maxScale)
			transform.localScale = transform.localScale + (Vector3.one * speed * (reference / 100));
	}


}
