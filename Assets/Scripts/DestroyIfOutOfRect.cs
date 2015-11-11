using UnityEngine;
using System.Collections;

public class DestroyIfOutOfRect : MonoBehaviour {

	public float boundries;

	void Update () {
		if (Mathf.Abs (transform.position.x) > boundries || Mathf.Abs (transform.position.y) > boundries)
			GameObject.Destroy (gameObject);
	}

}
